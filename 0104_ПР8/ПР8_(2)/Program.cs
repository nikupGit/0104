using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Windows.Forms;

[Serializable]
public enum EngineState { engineAlive, engineDead }

[Serializable]
public abstract class Car
{
    public string PetName { get; set; }
    public int CurrentSpeed { get; set; }
    public int MaxSpeed { get; set; }
    protected EngineState egnState = EngineState.engineAlive;
    public EngineState EngineState
    {
        get { return egnState; }
    }
    public abstract void TurboBoost();
    public virtual void Show()
    {
        Console.WriteLine(PetName);
        Console.WriteLine(MaxSpeed);
        Console.WriteLine(CurrentSpeed);
        Console.WriteLine(egnState);
    }
    public Car() { }
    public Car(string name, int maxSp, int currSp)
    {
        PetName = name;
        MaxSpeed = maxSp;
        CurrentSpeed = currSp;
    }
}

[Serializable]
public class SportsCar : Car
{
    public SportsCar() { }
    public SportsCar(string name, int maxSp, int currSp) : base(name, maxSp, currSp) { }
    public override void TurboBoost()
    {
        MessageBox.Show("Таранная скорость!", "Чем быстрее, тем лучше...");
    }
}

[Serializable]
public class MiniVan : Car
{
    public MiniVan() { }
    public MiniVan(string name, int maxSp, int currSp) : base(name, maxSp, currSp) { }
    public override void TurboBoost()
    {
        egnState = EngineState.engineDead;
        MessageBox.Show("Упс!", "Ваш блок двигателя взорвался!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Шаг 2: Создание объектов и вызов TurboBoost
        MiniVan miniVan = new MiniVan("MiniVan1", 100, 50);
        SportsCar sportsCar = new SportsCar("SportsCar1", 200, 100);
        miniVan.TurboBoost();
        sportsCar.TurboBoost();

        // Шаг 3: Сериализация объектов
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fs = new FileStream("miniVan.bin", FileMode.Create))
        {
            binaryFormatter.Serialize(fs, miniVan);
        }

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SportsCar));
        using (FileStream fs = new FileStream("sportsCar.xml", FileMode.Create))
        {
            xmlSerializer.Serialize(fs, sportsCar);
        }

        // Шаг 4: Десериализация объектов
        MiniVan deserializedMiniVan;
        using (FileStream fs = new FileStream("miniVan.bin", FileMode.Open))
        {
            deserializedMiniVan = (MiniVan)binaryFormatter.Deserialize(fs);
        }

        SportsCar deserializedSportsCar;
        using (FileStream fs = new FileStream("sportsCar.xml", FileMode.Open))
        {
            deserializedSportsCar = (SportsCar)xmlSerializer.Deserialize(fs);
        }

        Console.WriteLine("Десериализованный MiniVan:");
        deserializedMiniVan.Show();
        Console.WriteLine();

        Console.WriteLine("Десериализованный SportsCar:");
        deserializedSportsCar.Show();
    }
}