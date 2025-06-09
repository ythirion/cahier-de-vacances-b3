namespace FirewallCracker.Core;

public static class PasswordChecker
{
    private const int MinimumLength = 8;
    private static readonly List<char> SpecialCharacters = ['.', '*', '#', '@', '$', '%', '&'];

    public static PasswordResult Check(string password)
    {
        var errors = new List<string>();
        var minLength = password.Length >= MinimumLength;

        if (!minLength)
        {
            errors.Add("Password must be at least 8 characters long");
        }

        var hasUpper = password.Any(char.IsUpper);
        if (!hasUpper)
        {
            errors.Add("Password must contain at least one uppercase letter");
        }

        var hasLower = password.Any(char.IsLower);
        if (!hasLower)
        {
            errors.Add("Password must contain at least one lowercase letter");
        }

        var hasNumber = password.Any(char.IsDigit);
        if (!hasNumber)
        {
            errors.Add("Password must contain at least one number");
        }

        var hasCyberSymbol = password.Any(SpecialCharacters.Contains);
        if (!hasCyberSymbol)
        {
            errors.Add("Password must contain at least one cyber-symbol (. * # @ $ % &)");
        }

        var hasOnlyAllowedCharacters = password.All(IsAValidCharacter);

        if (!hasOnlyAllowedCharacters)
        {
            errors.Add("Invalid characters detected!!!");
        }

        return new PasswordResult(errors.Count == 0, errors.ToArray());
    }

    private static bool IsAValidCharacter(char c) =>
        char.IsLetter(c)
        || char.IsDigit(c)
        || SpecialCharacters.Contains(c);
}