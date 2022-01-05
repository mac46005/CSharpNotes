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

        /// <summary>
        /// An array can have multiple dimensions, up to 32. For this
        /// king of array, each row must have the same number of columns
        /// </summary>
        public void MultidimensionalArray(){

            // This is a sample of an array with 2 rows
            // and 3 elements each, also called a matrix
            string[,] textArray = new string[2,3];

            // You can also initialize a multidimensional arrays directly
            int[,] intArray = new int[,]{
                {1,2,3},
                {4,5,6}
            };

            // Use the index position of a set value to a multidimensional
            // array element. If there is already a value set for an element,
            // it will be replaced
            intArray[1,0] = 7;

            // use the index position to get a value fromm a multidimensional
            // array element
            int number = intArray[1,0];

            // To loop through a multidimensioal array, you can use the 
            // GetUpperBound() method to get the length of a specific dimension of an array
            for (int row = 0; row < intArray.GetUpperBound(0); row++)
            {
                
            }
        }


        /// <summary>
        /// In a multidimensional arrays, the structure need to have always number of elements(columns) for each row.
        /// Jagged arrays are arrays , where each elementt of the arracy can have a distinct array with different  sizes
        /// </summary>
        public void JaggedArray(){

            int[][] jaggedArray = new int[2][];

            // Use the inde position to set a value to a multidimensional array element. 
            // If there is already a value set for the element the value will be repaved.
            jaggedArray[0] = new int[]{1,2,3};
            jaggedArray[1] = new int[2];
            jaggedArray[1][0] = 4;
            jaggedArray[1][1] = 3;


            for (int i = 0; i < jaggedArray[i].Length; i++)
            {
                for (int j = 0; j < jaggedArray[i][j]; j++)
                {
                    Console.WriteLine(jaggedArray[i][j]);
                }
            }

            // You can also initialize jagged arrays directly
            int[][] jaggedArray2 = new int[2][]{
                new int[]{1,2,3},
                new int[]{4,5}
            };
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