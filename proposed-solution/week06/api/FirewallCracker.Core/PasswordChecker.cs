namespace FirewallCracker.Core;

public static class PasswordChecker
{
    private const int MinimumLength = 8;
    private static readonly List<char> SpecialCharacters = ['.', '*', '#', '@', '$', '%', '&'];

    public static PasswordResult Check(string password)
    {
        var minLength = password.Length >= MinimumLength;
        var hasUpper = password.Any(char.IsUpper);
        var hasLower = password.Any(char.IsLower);
        var hasNumber = password.Any(char.IsDigit);
        var hasSymbol = password.Any(SpecialCharacters.Contains);
        var onlyAllowed = password.All(IsAValidCharacter);

        var rules = new Rules(
            MinLength: minLength,
            HasUpperCase: hasUpper,
            HasLowerCase: hasLower,
            HasNumber: hasNumber,
            HasCyberSymbol: hasSymbol,
            HasOnlyAllowedCharacters: onlyAllowed
        );

        var isValid = rules.MinLength &&
                      rules.HasUpperCase &&
                      rules.HasLowerCase &&
                      rules.HasNumber &&
                      rules.HasCyberSymbol &&
                      rules.HasOnlyAllowedCharacters;

        var message = isValid ? "Firewall Breached" : GetFailureMessage(rules);

        return new PasswordResult(isValid, rules, message);
    }

    private static bool IsAValidCharacter(char c) =>
        char.IsLetter(c)
        || char.IsDigit(c)
        || SpecialCharacters.Contains(c);

    private static string GetFailureMessage(Rules rules)
    {
        if (!rules.HasOnlyAllowedCharacters) return "Invalid characters detected!!!";
        if (!rules.MinLength) return "Password must be at least 8 characters long";
        if (!rules.HasUpperCase) return "Password must contain at least one uppercase letter";
        if (!rules.HasLowerCase) return "Password must contain at least one lowercase letter";
        if (!rules.HasNumber) return "Password must contain at least one number";
        if (!rules.HasCyberSymbol) return "Password must contain at least one cyber-symbol (. * # @ $ % &)";
        return "Invalid password";
    }
}