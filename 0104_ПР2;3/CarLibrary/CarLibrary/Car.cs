using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CarLibrary
{
    // Представляет состояние двигателя.
    public enum EngineState { engineAlive, engineDead }
    // Абстрактный базовый класс в иерархии.
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
        public Car() { } //конструктор по умолчанию
        public Car(string name, int maxSp, int currSp)  // конструктор с параметрами
        {
            PetName = name;
            MaxSpeed = maxSp;
            CurrentSpeed = currSp;
        }

        public void TurnOnRadio(bool musicOn, MusicMedia mm)
        {
            if (musicOn) MessageBox.Show(string.Format("Jamming {0}", mm));
            else MessageBox.Show("Quiet time...");
        }
        public enum MusicMedia
        {
            musicCd, // 0
            musicTape, // 1
            musicRadio, // 2
            musicMp3 // 3
        }
    }
}
