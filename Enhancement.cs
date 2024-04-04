public class Enhancement : Ticket
{
    public string Software { get; set; }
    public double Cost { get; set; }
    public string Reason { get; set; }
    public TimeSpan Estimate { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()},{Software},{Cost},{Reason},{Estimate}";
    }
}