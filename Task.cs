public class Task : Ticket
{
    public string ProjectName { get; set; }
    public DateTime DueDate { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()},{ProjectName},{DueDate:yyyy-MM-dd}";
    }
}