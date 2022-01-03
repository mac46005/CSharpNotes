using System;

namespace Algorithms{
    public class ArrayTypes{
        public void SingleDimensionalArrays(){
            // Initializing single dimensional array
            string[] textArray = new string[10];

            // You can also initialize the array directly in the instantiation of the array
            int[] intArray = new int[]{1,2,3,4};

            // Creating an array of userDef Types
            SampleUserDefType[] sampleUserDefTypes = new SampleUserDefType[15];

            // User the index position to set a value
            // to an array element. If there is already
            // a value set for an element, it will be
            // replaced

            textArray[2] = "Text sample";
            intArray[3] = 2;
            sampleUserDefTypes[1] = new SampleUserDefType{TextProperty = "Test",IntProperty = 34};

            // Use the index position to get a value from an array element
            string text = textArray[4];
            int number = intArray[3];
            SampleUserDefType userDefinedElement = sampleUserDefTypes[1];

            // There are many ways to loop over an array
            Array.ForEach(textArray,t => Console.WriteLine(t));
            Array.ForEach(intArray,n => Console.WriteLine(n));
            Array.ForEach(sampleUserDefTypes,s => Console.WriteLine(s));



        }
    }

    public class SampleUserDefType{
        public string TextProperty { get; set; }
        public int IntProperty { get; set; }
        public override string ToString()
        {
            return $"{IntProperty} - {TextProperty}";
        }
    }
}