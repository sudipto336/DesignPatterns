namespace ObserverDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicketResellerService ticketResellerService = new();
            TicketStockService ticketStockService = new();
            OrderService orderService = new();

            //add 2 observers
            orderService.AddObservers(ticketResellerService);
            orderService.AddObservers(ticketStockService);

            //notify observers
            orderService.CompleteTicketSale(1, 2);

            Console.WriteLine();

            //remove 1 observer
            orderService.RemoveObservers(ticketResellerService);

            //notify observer
            orderService.CompleteTicketSale(2, 4);

            Console.ReadKey();
        }
    }
}
