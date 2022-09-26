namespace csharp_gestore_eventi;

public class ProgramEvent
{
    private string Title { get; }
    private List<Event> _events { get; }

    public ProgramEvent(string title)
    {
        if (title == "")
        {
            throw new ArgumentException("Title cannot be empty");
        }
        Title = title;
        _events = new List<Event>();
    }
    
    public void AddEvent(Event e)
    {
        _events.Add(e);
    }
    
    public List<Event> GetEvents()
    {
        return _events;
    }

    public List<Event> GetEventsFromDate(DateOnly date)
    {
        List<Event> selectedEvents = new List<Event>();

        foreach (Event e in _events)
        {
            if (e.Date == date)
            {
                selectedEvents.Add(e);
            }
        }
        return selectedEvents;
    }

    public static void PrintEvents(List<Event> events)
    {
        Console.WriteLine("\nEvents:");
        foreach (Event e in events)
        {
            Console.WriteLine(e.ToString());
        }
    }
    
    public int HowManyEvents()
    {
        return _events.Count;
    }
    
    public void EmptyProgram()
    {
        Console.WriteLine("\nEmptying program...");
        _events.Clear();
    }
    
    public void PrintSummary()
    {
        Console.WriteLine("Ecco il tuo programma Eventi");
        Console.WriteLine(Title);
        foreach (Event e in _events)
        {
            Console.WriteLine("\t" + e.ToString());
            
        }
    }

}