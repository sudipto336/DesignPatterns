namespace ObserverDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class TicketChange
    {
        public int Amount { get; set; }
        public int ArtistId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="artistId"></param>
        public TicketChange(int amount, int artistId)
        {
            Amount = amount;
            ArtistId = artistId;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public abstract class TicketChangeNotifier
    {
        private List<ITicketChangeListener> _observers = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="observer"></param>
        public void AddObservers(ITicketChangeListener observer) {
            _observers.Add(observer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="observer"></param>
        public void RemoveObservers(ITicketChangeListener observer)
        {
            _observers.Remove(observer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticketChange"></param>
        public void NotifyObservers(TicketChange ticketChange) {
            foreach (var observer in _observers)
            {
                observer.ReceiveTicketCHangeNotification(ticketChange);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ITicketChangeListener
    {
        void ReceiveTicketCHangeNotification(TicketChange ticketChange);
    }

    /// <summary>
    /// 
    /// </summary>
    public class OrderService: TicketChangeNotifier
    {
        public void CompleteTicketSale(int artistId, int amount)
        {
            //change local data store.
            Console.WriteLine($"{nameof(OrderService)} is changing its state...");
            //notify observers
            Console.WriteLine($"{nameof(OrderService)} is notifying observers...");
            NotifyObservers(new TicketChange(amount, artistId));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TicketResellerService : ITicketChangeListener
    {
        public void ReceiveTicketCHangeNotification(TicketChange ticketChange)
        {
            //update local data store.
            Console.WriteLine($"{nameof(TicketResellerService)} notified of ticket change: artist - {ticketChange.ArtistId} and amount - {ticketChange.Amount}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TicketStockService : ITicketChangeListener
    {
        public void ReceiveTicketCHangeNotification(TicketChange ticketChange)
        {
            //update local data store.
            Console.WriteLine($"{nameof(TicketStockService)} notified of ticket change: artist - {ticketChange.ArtistId} and amount - {ticketChange.Amount}");
        }
    }
}
