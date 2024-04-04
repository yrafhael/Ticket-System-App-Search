public class Ticket
{
    public int TicketID { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string Submitter { get; set; }
    public string Assigned { get; set; }
    public string Watching { get; set; }
    public string Severity { get; set; }

    public override string ToString()
    {
        return $"{TicketID},{Summary},{Status},{Priority},{Submitter},{Assigned},{Watching},{Severity}";
    }
}