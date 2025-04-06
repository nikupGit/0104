using System.Drawing;
using System.Resources;

namespace ProgrammingResourcesFile
{
    public class Example
    {
        public static void Main()
        {
            // Создание экземпляра объекта Automobile
            Automobile car1 = new Automobile("Ford", "Model N", 1906, 0, 4);
            Automobile car2 = new Automobile("Ford", "Model T", 1909, 2, 4);
            // Define a resource file named CarResources.resx.
            using (ResourceWriter rw =
      new ResourceWriter(@".\CarResources.resources"))
            {
                rw.AddResource("Title", "Classic American Cars");
                rw.AddResource("HeaderString1", "Make");
                rw.AddResource("HeaderString2", "Model");
                rw.AddResource("HeaderString3", "Year");
                rw.AddResource("HeaderString4", "Doors");
                rw.AddResource("HeaderString5", "Cylinders");
                rw.AddResource("Information", SystemIcons.Information);
                rw.AddResource("EarlyAuto1", car1);
                rw.AddResource("EarlyAuto2", car2);
                rw.Close();
            }
        }
    }
}