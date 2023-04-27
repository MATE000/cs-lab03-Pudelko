namespace PudelkoLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pudelko p1 = new Pudelko(2,1,3);
            Pudelko p2 = new Pudelko(3,2,1);
            Console.WriteLine(p2.ToString());
            Console.WriteLine(p2.Pole);
            Console.WriteLine(p2.Equals(p1));


        }
    }
}