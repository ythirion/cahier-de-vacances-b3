using System.Text.RegularExpressions;

namespace FirewallCracker.Core;

public interface IPasswordChecker
{
    public CheckPasswordResult Check(string password);
}

public sealed class PasswordChecker : IPasswordChecker
{
    public CheckPasswordResult Check(string password) => PasswordPolicy.Check(password);
}

public static class PasswordPolicy
{
    public static CheckPasswordResult Check(string password)
    {
        var errors = new List<string>();

        GreaterThanMinimumLength(password, errors);
        AtLeastOneUpperCase(password, errors);
        AtLeastOneLowerCase(password, errors);
        AtLeastOneNumber(password, errors);
        AtLeastOneCyberSymbol(password, errors);
        HasOnlyValidCharacters(password, errors);

        return new CheckPasswordResult(errors.Count == 0, errors.ToArray());
    }

    private static void GreaterThanMinimumLength(string password, List<string> errors)
        => Match(password, ".{8,}", "Password must be at least 8 characters long", errors);

    private static void AtLeastOneUpperCase(string password, List<string> errors)
        => Match(password, ".*[A-Z].*", "Password must contain at least one uppercase letter", errors);

    private static void AtLeastOneLowerCase(string password, List<string> errors)
        => Match(password, ".*[a-z].*", "Password must contain at least one lowercase letter", errors);

    private static void AtLeastOneNumber(string password, List<string> errors)
        => Match(password, ".*[0-9].*", "Password must contain at least one number", errors);

    private static void AtLeastOneCyberSymbol(string password, List<string> errors)
        => Match(password, ".*[.*#@$%&].*", "Password must contain at least one cyber-symbol (. * # @ $ % &)", errors);

    private static void HasOnlyValidCharacters(string password, List<string> errors)
        => Match(password, "^[a-zA-Z0-9.*#@$%&]+$", "Invalid characters detected!!!",
            errors);

    private static void Match(string password, string regex, string reason, List<string> errors)
    {
        if (!Regex.Match(password, regex).Success)
        {
            errors.Add(reason);
        }
    }
}