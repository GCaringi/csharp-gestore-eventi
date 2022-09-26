namespace csharp_gestore_eventi;

public class ProgramEvent
{
    private string Title { get; }
    private List<Event> _events { get; }

    public ProgramEvent(string title)
    {
        Title = title;
        _events = new List<Event>();
    }
    
    public void AddEvent(Event e)
    {
        _events.Add(e);
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
        _events.Clear();
    }
    
    public void PrintSummary()
    {
        // string heading = String.Format("{0,-12} {0,12}\n", "Date", "Events");
        Console.WriteLine("{0,-12}  {1,-18}", $"{Title}", "Evento");
        foreach (Event e in _events)
        {
            // Console.WriteLine(e.ToString());
            Console.WriteLine("{0,-11}-  {1,-18}", $"{e.Date}", $"{e.Title}");
        }
    }

}