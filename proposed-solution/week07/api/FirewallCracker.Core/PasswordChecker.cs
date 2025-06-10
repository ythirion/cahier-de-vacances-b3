using System.Text.RegularExpressions;

namespace FirewallCracker.Core;

public record Rule(string Expression, string Description)
{
    public bool Match(string password) => Regex.Match(password, Expression).Success;
}

public sealed class PasswordChecker : IPasswordChecker
{
    private static readonly IReadOnlyList<Rule> Rules =
    [
        new(".{8,}", "Password must be at least 8 characters long"),
        new(".*[A-Z].*", "Password must contain at least one uppercase letter"),
        new(".*[a-z].*", "Password must contain at least one lowercase letter"),
        new(".*[0-9].*", "Password must contain at least one number"),
        new(".*[.*#@$%&].*", "Password must contain at least one cyber-symbol (. * # @ $ % &)"),
        new("^[a-zA-Z0-9.*#@$%&]+$", "Invalid characters detected!!!")
    ];

    public CheckPasswordResult Check(string password)
    {
        var errors = Rules.Where(rule => !rule.Match(password))
            .Select(rule => rule.Description)
            .ToList();

        return new CheckPasswordResult(errors.Count == 0, errors.ToArray());
    }
}

public interface IPasswordChecker
{
    public CheckPasswordResult Check(string password);
}