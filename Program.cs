using csharp_gestore_eventi;

DateOnly date = new DateOnly(2023,6, 9); // June 9, 2012

try
{
    Event e = new Event("Concerto", date, 500);
    Console.WriteLine(e.Title);
    Console.WriteLine(e.Date);
    Console.WriteLine(e.Capacity);
    Console.WriteLine(e.Reserved);
    Console.WriteLine(e.ToString());
}
catch (ArgumentException e )
{
    Console.WriteLine(e.Message);
}

