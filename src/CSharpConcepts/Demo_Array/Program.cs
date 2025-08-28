using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Array
{
    // NOTE: instead of "dimension", use the term "RANK"
    class Program
    {
        static void Main(string[] args)
        {
            // Array of Rank 1
            int[] arr = new int[5] { 10, 20, 30, 40, 50 };
            Console.WriteLine("Number of elements:");
            Console.WriteLine("Number of elements in Rank 1: {0}", arr.GetLength(0));
            Console.WriteLine("Length of the array: {0}", arr.Length);
            Console.WriteLine();

            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("{0} : {1}", i, arr[i]);
            }
            Console.WriteLine();

            //for (int i = 0; i < arr.GetLength(0); i++)
            int count = arr.GetLength(0);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("{0} : {1}", i, arr[i]);
            }
            Console.WriteLine();

            DemoArrayRank1();
            DemoArrayRank2();
            DemoArrayRank3();
        }

        static void DemoArrayRank1()
        {
            int[] arr1;         // declaration
            arr1 = new int[5];  // instantiation ("new") - when memory is assigned.
            arr1[0] = 10;       // initalized the [0] element in the array
            arr1[1] = 20;
            arr1[2] = 30;
            arr1[3] = 40;
            arr1[4] = 50;

            int[] arr2 = new int[5];    // declaration and instantiation.

            int[] arr3 = new int[5] { 10, 20, 30, 40, 50 };  // all three steps!

            int[] arr4 = { 10, 20, 30, 40, 50 };            // all three steps! size is inferred.

            int[] arr5 = [10, 20, 30, 40, 50];              // C# 8 way of working with arrays (collection initialization)
        }

        static void DemoArrayRank2()
        {
            int[,] arr = new int[2, 5] {
                                        { 1, 2, 3, 4, 5 },
                                        { 6, 7, 8, 9, 10 }
                                      };

            Console.WriteLine( arr.GetLength( 0 ) );        // 2
            Console.WriteLine( arr.GetLength( 1 ) );        // 5
            Console.WriteLine( arr.Length );                // 2 * 5 = 10

            Console.WriteLine( arr[1, 3] );            // 9
        }

        static void DemoArrayRank3()
        {
            int[,,] arr = new int[2, 3, 4];
            arr[0, 1, 2] = 50;
        }
    }
}
