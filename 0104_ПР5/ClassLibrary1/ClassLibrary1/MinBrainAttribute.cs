using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MinBrainAttribute : Attribute
    {
        public int MinValue { get; }

        public MinBrainAttribute(int minValue)
        {
            MinValue = minValue;
        }
    }
}