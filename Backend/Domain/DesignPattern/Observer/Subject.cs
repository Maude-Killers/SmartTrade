namespace Backend.Domain.DesignPattern;

public interface Subject
{
    void AddObserver(Observer obs);
    void RemoveObserver(Observer obs);
    void Notify();
}