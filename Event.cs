namespace csharp_gestore_eventi;

public class Event
{
    private DateOnly _date;
    
    public string Title { get; set; }

    public DateOnly Date
    {
        get => _date;
        set
        {
            if (value < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("Date must be in the future");
            }

            _date = value;
        }
    }
    public int Capacity { get; }
    public int Reserved { get; private set; }

    public Event(string title, DateOnly date, int capacity)
    {
        Title = title;
        if (date < DateOnly.FromDateTime(DateTime.Now))
        {
            throw new ArgumentException("Date must be in the future");
        }
        _date = date;
        Capacity = capacity;
        Reserved = 0;
    }

    public void Reserve(int seats)
    {
        if (seats > Capacity - Reserved)
        {
            throw new ArgumentException("Not enough seats available");
        }
        
        if (DateOnly.FromDateTime(DateTime.Now) > Date)
        {
            throw new ArgumentException("Event already happened");
        }

        Reserved += seats;
    }
    
    public void Cancel(int seats)
    {
        if (seats > Reserved)
        {
            throw new ArgumentException("Not enough seats reserved");
        }
        
        if (DateOnly.FromDateTime(DateTime.Now) > Date)
        {
            throw new ArgumentException("Event already happened");
        }

        Reserved -= seats;
    }
    
    public override string ToString()
    {
        return $"{Date.ToString("dd/MM/yyyy")} - {Title}";
    }
    
    
}