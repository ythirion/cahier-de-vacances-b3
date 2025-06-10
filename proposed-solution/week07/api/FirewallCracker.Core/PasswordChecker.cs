using System.Text.RegularExpressions;

namespace FirewallCracker.Core;

public record Rule(string Expression, string Description)
{
    public bool Match(string password) => Regex.Match(password, Expression).Success;
}

public sealed class PasswordChecker(IPasswordRuleRepository passwordRuleRepository) : IPasswordChecker
{
    public CheckPasswordResult Check(string password)
    {
        var errors = passwordRuleRepository.GetRules()
            .Where(rule => !rule.Match(password))
            .Select(rule => rule.Description)
            .ToList();

        return new CheckPasswordResult(errors.Count == 0, errors.ToArray());
    }
}

public interface IPasswordChecker
{
    public CheckPasswordResult Check(string password);
}