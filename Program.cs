using csharp_gestore_eventi;

ProgramEvent eventManager = CreateProgram();
AddEvent(eventManager);


Console.WriteLine($"Numero di eventi: {eventManager.HowManyEvents()}");

eventManager.PrintSummary();

ProgramEvent.PrintEvents(SearchByDate(eventManager));

eventManager.EmptyProgram();





Event CreateEvent()
{
    Event? e = null;
    try
    {
        // Console.WriteLine();
        Console.Write("Inserisci il nome dell'evento: ");
        string title = Console.ReadLine() ?? "";
        Console.Write("Inserisci la data dell'evento(gg/mm/aaaa): ");
        DateOnly date = FromString(Console.ReadLine() ?? "01/01/2000");
        Console.Write("Inserisci la capienza dell'evento: ");
        int capacity = Convert.ToInt32(Console.ReadLine() ?? "0");
        e = new Event(title, date, capacity);
        return e;
    }
    catch (ArgumentException error)
    {
        // Console.WriteLine(error.Message);
        throw;
    }
}

DateOnly FromString(string date)
{
    if (date == "")
    {
        throw new ArgumentException("Not valid date");
    }
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

ProgramEvent CreateProgram()
{
    ProgramEvent? program = null;
    bool flag = true;
    do
    {
        try
        {
            Console.Write("Inserisci il nome del programma: ");
            string name = Console.ReadLine() ?? "";
            program = new ProgramEvent(name);
            flag = false;
            Console.WriteLine();
            return program;
        }
        catch (ArgumentException error)
        {
            Console.WriteLine(error.Message);
            flag = true;
        } 
    } while (flag);
    

    return program;
}

void AddEvent(ProgramEvent program)
{
    Console.Write("Quanti eventi vuoi aggiungere? ");
    int n = Convert.ToInt32(Console.ReadLine() ?? "0");

    while (n != program.HowManyEvents())
    {
        bool flag = true;
        
        do
        {
            try
            {
                Event tmpEvent = CreateEvent();
                program.AddEvent(tmpEvent);
                Console.WriteLine();
                flag = false;
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
                flag = true;

            }
        } while (flag);
    }
}

List<Event> SearchByDate(ProgramEvent program)
{
    Console.Write("Inserisci la data in cui cercare gli eventi(gg/mm/aaaa): ");
    DateOnly date = FromString(Console.ReadLine() ?? "01/01/2000");
    return program.GetEventsFromDate(date);
}

