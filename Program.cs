using csharp_gestore_eventi;

Event defaultEvent = new Event("Convegno", new DateOnly(2023, 05, 12), 500);

// Event e = CreateEvent();
Console.WriteLine(defaultEvent.ToString());

// ReserveSeats(defaultEvent);
// printInfo(defaultEvent);

// ReserveAndCancel(defaultEvent);

ProgramEvent EventManager = new ProgramEvent("Concerti");

EventManager.AddEvent(defaultEvent);

EventManager.PrintSummary();



Event CreateEvent()
{
    Event e = null;
    try
    {
        Console.Write("Inserisci il nome dell'evento: ");
        string title = Console.ReadLine() ?? "";
        Console.Write("Inserisci la data dell'evento(gg/mm/aaaa): ");
        DateOnly date = FromString(Console.ReadLine());
        Console.Write("Inserisci la capienza dell'evento: ");
        int capacity = Convert.ToInt32(Console.ReadLine() ?? "0");
        e = new Event(title, date, capacity);
    }
    catch (ArgumentException error)
    {
        Console.WriteLine(error.Message);
    }
    
    return e;
}

DateOnly FromString(string date)
{
    string[] dateArray = date.Split('/');
    int day = Convert.ToInt32(dateArray[0]);
    int month = Convert.ToInt32(dateArray[1]);
    int year = Convert.ToInt32(dateArray[2]);
    return new DateOnly(year, month, day);
}

void ReserveSeats(Event e)
{
    Console.Write("Quante posti vuoi prenotare? ");
    int seats = Convert.ToInt32(Console.ReadLine() ?? "0");
    try
    {
        e.Reserve(seats);
    }
    catch (ArgumentException error)
    {
        Console.WriteLine(error.Message);
    }
}

void CancelSeats(Event e)
{
    Console.WriteLine("Quanti posti vuoi disdire: ");
    int seats = Convert.ToInt32(Console.ReadLine() ?? "0");
    try
    {
        e.Cancel(seats);
    }
    catch (ArgumentException error)
    {
        Console.WriteLine(error.Message);
    }
}

void printInfo(Event e)
{
    Console.WriteLine($"Posti prenotati = {e.Reserved}");
    Console.WriteLine($"Posti disponibili = {e.Capacity}");
}

void ReserveAndCancel(Event e)
{
    printInfo(e);
    ReserveSeats(e);
    Console.Write("Vuoi disdire dei posti?(yes/no): ");
    string prompt = Console.ReadLine() ?? "";

    while (prompt == "yes")
    {
        try
        {
            CancelSeats(e);
            printInfo(e);
            
            Console.Write("Vuoi disdire altri posti?(yes/no): ");
            prompt = Console.ReadLine() ?? "";
        }
        catch (ArgumentException error)
        {
            Console.WriteLine(error.Message);
        }
    }
    
    Console.Clear();
    Console.WriteLine(e.ToString());
    printInfo(e);
}