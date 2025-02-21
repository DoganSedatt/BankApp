public class Paginate<T> : IPaginate<T>
{
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public IList<T> Items { get; set; }

    public Paginate()
    {
        Items = new List<T>();
    }
} 