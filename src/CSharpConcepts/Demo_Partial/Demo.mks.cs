namespace Demo_Partial;

internal partial class Demo
{
    internal string Name { get; set; }
}


internal partial class Demo
{
    internal void Display()
    {
        Console.WriteLine( "ID: {0}, Name: {1}", this.Id, this.Name );
    }
}