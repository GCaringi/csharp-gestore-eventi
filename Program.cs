using csharp_gestore_eventi;

ProgramEvent eventManager = CreateProgram();
// AddEvent(eventManager);
SetAllProgram(eventManager);

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
        throw;
    }
}

Conference CreateConference()
{
    Conference? conference = null;
    try
    {
        Console.Write("Inserisci il nome della conferenza: ");
        string title = Console.ReadLine() ?? "";
        Console.Write("Inserisci la data della conferenza(gg/mm/aaaa): ");
        DateOnly date = FromString(Console.ReadLine() ?? "01/01/2000");
        Console.Write("Inserisci la capienza della conferenza: ");
        int capacity = Convert.ToInt32(Console.ReadLine() ?? "0");
        Console.Write("Inserisci il nome del relatore: ");
        string speaker = Console.ReadLine() ?? "";
        Console.Write("Insrisci il prezzo del biglietto: ");
        int price = Convert.ToInt32(Console.ReadLine() ?? "0");
        conference = new Conference(title, date, capacity, speaker, price);
        return conference;
    }
    catch (ArgumentException error)
    {
        throw;
    }
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

List<Event> SearchByDate(ProgramEvent program)
{
    Console.Write("Inserisci la data in cui cercare gli eventi(gg/mm/aaaa): ");
    DateOnly date = FromString(Console.ReadLine() ?? "01/01/2000");
    return program.GetEventsFromDate(date);
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

void AddEvent(ProgramEvent program)
{
    int n = 0;
    bool flag = true;
    do
    {
        try
        {
            Console.Write("Quanti eventi vuoi aggiungere? ");
            n = Convert.ToInt32(Console.ReadLine() ?? "0");
            flag = false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + "\n");
            flag = true;
        }
    } while (flag);

    while (n != program.HowManyEvents())
    {
        flag = true;
        
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

void SetAllProgram(ProgramEvent program)
{
    int numEvent = 0;
    int numConference = 0;
    bool flag = true;

    do
    {
        try
        {
            Console.Write("Quanti eventi vuoi aggiungere? ");
            numEvent = Convert.ToInt32(Console.ReadLine() ?? "0");
            flag = false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + "\n");
            flag = true;
        }
    } while (flag);

    Console.WriteLine("BONUS\n");
    do
    {
        try
        {
            Console.Write("\nQuante conferenze ci sono nel tuo programma? ");
            numConference = Convert.ToInt32(Console.ReadLine() ?? "0");
            flag = false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + "\n");
            flag = true;
        }
    } while (flag);
    
    while (numEvent != program.HowManyEvents())
    {
        flag = true;
        
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

    while (numConference != program.HowManyEvents()- numEvent)
    {
        flag = true;

        do
        {
            try
            {
                Conference tmpConference = CreateConference();
                program.AddEvent(tmpConference);
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


