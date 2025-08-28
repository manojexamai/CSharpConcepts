namespace Demo_Enum
{
    internal class Program
    {
        static void Main ( string[] args )
        {

            const string AuthorNAME = "Manoj Kumar Sharma";

            Console.WriteLine( AuthorNAME );

            Position p1 = Position.Second;
            Console.WriteLine( p1 );
            Console.WriteLine( (int) p1 );
            Console.WriteLine();

            Position2 p2 = Position2.Second;
            Console.WriteLine( p2 );
            Console.WriteLine( (int) p2 );

            Console.WriteLine();

            Position3 p3 = Position3.One;
            Console.WriteLine( p3 );            // First
            Console.WriteLine( (int) p3 );
            Console.WriteLine();

            int x = 1;
            Console.WriteLine( (Position3)x );
            Console.WriteLine();

            string s = "first";
            // Console.WriteLine( (Position3)s );
            Position3 p4 = (Position3) Enum.Parse( typeof( Position3 ), s );
            Console.WriteLine( p4 );

            object? p5;
            Enum.TryParse( typeof( Position3 ), s, out p5 );
            Position3 p5b = p5 is not null ? (Position3) p5 : Position3.Third;

        }
    }
}
