namespace Frontend.Store;
public class SetUserAction { 
    public bool IsValid;
    public string Name;

    public SetUserAction()
    {
    }

    public SetUserAction(bool IsValid, string Name)
    {
        this.IsValid = IsValid;
        this.Name = Name;
    }
}