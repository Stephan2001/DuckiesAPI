using System.Runtime.InteropServices.JavaScript;

namespace DuckAPI
{
    public class Duckie : IsSubject
    {
        protected List<IObserver> observers = new List<IObserver>();
        protected String name;

        public Duckie() { }
        public Duckie(string name)
        {
            this.name = name;
        }

        public void addSubscriber(IObserver observable)
        {
            observers.Add(observable);
        }

        public void notifySubscriber()
        {
            observers.ForEach(IObserver => IObserver.notificationAsync());

        }

        public void removeSubscriber(IObserver observable)
        {
            observers.Remove(observable);
        }

    }
}
