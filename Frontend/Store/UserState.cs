using Fluxor;

namespace Frontend.Store;

[FeatureState]
public class UserState
{
    public bool IsValid { get; set; }
    public string Name { get; set; }

    private UserState() { }

    public UserState(bool isValid, string name)
    {
        IsValid = isValid;
        Name = name;
    }
}

public static class Reducers
{
    [ReducerMethod]
    public static UserState SetUser(UserState state, SetUserAction action)
    {
        return new UserState(isValid: action.IsValid, name: action.Name);
    }
}
