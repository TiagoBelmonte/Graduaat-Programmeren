internal class Program
{
    private static void Main(string[] args)
    {
        Northwind.NorthwindContext dbContext = new();
        foreach (var item in dbContext.Suppliers)
        {
            Console.WriteLine(item.ContactName);
        }
    }
}