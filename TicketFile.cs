public class TicketFile
{
    private string ticketsFilePath;
    private string enhancementsFilePath;
    private string tasksFilePath;

    public TicketFile(string ticketsFilePath, string enhancementsFilePath, string tasksFilePath)
    {
        this.ticketsFilePath = ticketsFilePath;
        this.enhancementsFilePath = enhancementsFilePath;
        this.tasksFilePath = tasksFilePath;
    }

    public void ReadDataFromTicketsFile()
    {
        ReadFromFile(ticketsFilePath);
    }

    public void ReadDataFromEnhancementsFile()
    {
        ReadFromFile(enhancementsFilePath);
    }

    public void ReadDataFromTasksFile()
    {
        ReadFromFile(tasksFilePath);
    }


    public void CreateFileFromData()
    {
        string choice;
        do
        {
            Console.WriteLine("Enter TicketID:");
            int ticketID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Summary:");
            string summary = Console.ReadLine();

            Console.WriteLine("Enter Status:");
            string status = Console.ReadLine();

            Console.WriteLine("Enter Priority:");
            string priority = Console.ReadLine();

            Console.WriteLine("Enter Submitter:");
            string submitter = Console.ReadLine();

            Console.WriteLine("Enter Assigned:");
            string assigned = Console.ReadLine();

            Console.WriteLine("Enter Watching (separate names with commas):");
            string watching = Console.ReadLine();
            watching = watching.Replace(",", "|");

            Console.WriteLine("Enter Severity:");
            string severity = Console.ReadLine();

            Console.WriteLine("Is this an Enhancement or Task ticket? (E/T)");
            choice = Console.ReadLine().ToUpper();

            if (choice == "E")
            {
                Console.WriteLine("Enter Software:");
                string software = Console.ReadLine();

                Console.WriteLine("Enter Cost:");
                double cost = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Reason:");
                string reason = Console.ReadLine();

                Console.WriteLine("Enter Estimate (in h:m:s format):");
                TimeSpan estimate = TimeSpan.Parse(Console.ReadLine());

                // Write to Enhancements.csv
                using (StreamWriter enhancementsWriter = new StreamWriter(enhancementsFilePath, append: true))
                {
                    if (new FileInfo(enhancementsFilePath).Length == 0)
                    {
                        enhancementsWriter.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching,Severity,Software,Cost,Reason,Estimate");
                    }
                    enhancementsWriter.WriteLine($"{ticketID},{summary},{status},{priority},{submitter},{assigned},{watching},{severity},{software},{cost},{reason},{estimate}");
                }
            }
            else if (choice == "T")
            {
                Console.WriteLine("Enter Project Name:");
                string projectName = Console.ReadLine();

                Console.WriteLine("Enter Due Date (YYYY-MM-DD):");
                DateTime dueDate = DateTime.Parse(Console.ReadLine());

                // Write to Tasks.csv
                using (StreamWriter tasksWriter = new StreamWriter(tasksFilePath, append: true))
                {
                    if (new FileInfo(tasksFilePath).Length == 0)
                    {
                        tasksWriter.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching,Severity,ProjectName,DueDate");
                    }
                    tasksWriter.WriteLine($"{ticketID},{summary},{status},{priority},{submitter},{assigned},{watching},{severity},{projectName},{dueDate:yyyy-MM-dd}");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 'E' for Enhancement or 'T' for Task.");
            }

            // Write to Tickets.csv
            using (StreamWriter sw = new StreamWriter(ticketsFilePath, append: true))
            {
                if (new FileInfo(ticketsFilePath).Length == 0)
                {
                    sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching,Severity");
                }
                sw.WriteLine($"{ticketID},{summary},{status},{priority},{submitter},{assigned},{watching},{severity}");
            }

            Console.WriteLine("Do you want to add another ticket? (Y/N)");
            choice = Console.ReadLine().ToUpper();
        } while (choice == "Y");
    }

    private void ReadFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        Console.WriteLine($"{headers[0]} = {fields[0]}");
                        Console.WriteLine($"{headers[1]} = {fields[1]}");
                        Console.WriteLine($"{headers[2]} = {fields[2]}");
                        Console.WriteLine($"{headers[3]} = {fields[3]}");
                        Console.WriteLine($"{headers[4]} = {fields[4]}");
                        Console.WriteLine($"{headers[5]} = {fields[5]}");
                        Console.WriteLine($"{headers[6]} = {fields[6]}");
                        Console.WriteLine($"{headers[7]} = {fields[7]}");

                        if (filePath == enhancementsFilePath)
                        {
                            Console.WriteLine($"{headers[8]} = {fields[8]}");
                            Console.WriteLine($"{headers[9]} = {fields[9]}");
                            Console.WriteLine($"{headers[10]} = {fields[10]}");
                            Console.WriteLine($"{headers[11]} = {fields[11]}");
                        }
                        else if (filePath == tasksFilePath)
                        {
                            Console.WriteLine($"{headers[8]} = {fields[8]}");
                            Console.WriteLine($"{headers[9]} = {fields[9]}");
                        }

                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
        }
    }
}