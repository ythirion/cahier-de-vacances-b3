namespace FirewallCracker.Core;

public record Rule(string Regex, string Description)
{
    public bool Match(string password) => System.Text.RegularExpressions.Regex.Match(password, Regex).Success;
}

public sealed class PasswordChecker(IPasswordRuleRepository passwordRuleRepository) : IPasswordChecker
{
    public CheckPasswordResult Check(string password)
    {
        //TODO fix async part
        var errors = passwordRuleRepository.GetRules()
            .Result
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