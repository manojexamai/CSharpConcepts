using System.Numerics;

namespace Demo_NewTypes
{
    /// <summary>
    ///     Demo of New Types introduced in C# 4.0
    /// </summary>
    internal class Program
    {
        static void Main ( string[] args )
        {
            var oTuple = new Tuple<string, int>( "Manoj Sharma", 39 );
            Console.WriteLine( "Item 1 is {0} of Type: {1}",
                oTuple.Item1, oTuple.Item1.GetType().ToString() );
            Console.WriteLine( "Item 2 is {0} of Type: {1}",
                oTuple.Item2, oTuple.Item2.GetType().ToString() );
            //  oTuple.Item1 = oTuple.Item1.ToUpper();                  // READONLY PROPERTIES


            Console.WriteLine();

            System.Numerics.Complex num = new Complex( 1, 2 );
            Console.WriteLine( num );
            Console.WriteLine( "Imaginary: {0}", num.Imaginary );
            Console.WriteLine( "Magnitude: {0}", num.Magnitude );
            Console.WriteLine( "Phase : {0}", num.Phase );
            Console.WriteLine( "Real : {0}", num.Real );
            Console.WriteLine();

            Console.Write( "Press any key to continue..." );
            Console.ReadKey();

            Console.WriteLine( GetFactorial( 6000 ) );
            Console.WriteLine();
        }

        static System.Numerics.BigInteger GetFactorial ( int num )
        {
            return num == 0 ? new BigInteger( 1 ) : num * GetFactorial( num - 1 );
        }
    }
}
