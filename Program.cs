class Program
{
     static void Main(string[] args)
    {
        string ticketsFilePath = "Tickets.csv";
        string enhancementsFilePath = "Enhancements.csv";
        string tasksFilePath = "Tasks.csv";

        TicketFile ticketFile = new TicketFile(ticketsFilePath, enhancementsFilePath, tasksFilePath);

        string userChoice;
        do
        {
            Console.WriteLine("1) Read data from Tickets file.");
            Console.WriteLine("2) Read data from Enhancements file.");
            Console.WriteLine("3) Read data from Tasks file.");
            Console.WriteLine("4) Create file from data.");
            Console.WriteLine("5) Search through Tickets file.");
            Console.WriteLine("Enter any other key to exit.");

            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    ticketFile.ReadDataFromTicketsFile();
                    break;
                case "2":
                    ticketFile.ReadDataFromEnhancementsFile();
                    break;
                case "3":
                    ticketFile.ReadDataFromTasksFile();
                    break;
                case "4":
                    ticketFile.CreateFileFromData();
                    break;
                case "5":
                    ticketFile.SearchThroughTicketsFile();
                    break;
                default:
                    Console.WriteLine("Exiting program...");
                    break;
            }

        } while (userChoice == "1" || userChoice == "2" || userChoice == "3" || userChoice == "4" || userChoice == "5");
    }
}