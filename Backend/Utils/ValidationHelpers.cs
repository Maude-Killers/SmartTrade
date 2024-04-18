using System.Text.RegularExpressions;

public static class ValidationHelpers
{
    public static bool IsValidString(string input)
    {
        return Regex.IsMatch(input, @"^[a-zA-Z0-9 ]*$");
    }

    public static bool IsValidNumber(int input)
    {
        // Regex para validar que la entrada sólo contiene números.
        return Regex.IsMatch(input.ToString(), @"^[0-9]*$");
    }
}