namespace csharp_gestore_eventi;

public class Conference : Event
{
    public string Speaker { get; }
    public decimal Price { get; }
    
    public Conference(string title, DateOnly date, int capacity, string speaker, decimal price) 
                    : base(title, date, capacity)
    {
        if (speaker == "")
        {
            throw new ArgumentException("Speaker cannot be empty");
        }
        Speaker = speaker;
        if (price < 1)
        {
            throw new ArgumentException("Price cannot be less than 1");
        }
        Price = price;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - {Speaker} - {Price.ToString("0.00")}";
    }
}
