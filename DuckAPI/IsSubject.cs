namespace DuckAPI
{
    public interface IsSubject
    {
        public void addSubscriber(IObserver observable);
        public void removeSubscriber(IObserver observable);
        public void notifySubscriber();
    }
    public interface IObserver
    {
        public void notificationAsync();
    }
}