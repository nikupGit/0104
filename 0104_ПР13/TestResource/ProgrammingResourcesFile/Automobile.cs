using System;

[Serializable]
public class Automobile
{
    private string carMake;
    private string carModel;
    private int carYear;
    private int carDoors;
    private int carCylinders;

    public Automobile(string make, string model, int year) :
                      this(make, model, year, 0, 0)
    { }
    public Automobile(string make, string model, int year, int doors, int cylinders)
    {
        this.carMake = make;
        this.carModel = model;
        this.carYear = year;
        this.carDoors = doors;
        this.carCylinders = cylinders;
    }

    public string Make
    {
        get { return this.carMake; }
    }

    public string Model
    {
        get { return this.carModel; }
    }

    public int Year
    {
        get { return this.carYear; }
    }

    public int Doors
    {
        get
        {
            return this.carDoors;
        }
    }

    public int Cylinders
    {
        get
        {
            return this.carCylinders;
        }
    }
}
