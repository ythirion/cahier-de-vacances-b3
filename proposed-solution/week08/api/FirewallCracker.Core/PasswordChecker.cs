using System.Text.RegularExpressions;
using static System.Text.RegularExpressions.Regex;

namespace FirewallCracker.Core;

public record Rule(string Regex, string Description)
{
    public bool Match(string password)
        // Use TimeSpan.FromMilliseconds(100) to prevent DoS attacks with long-running regex matches
        => IsMatch(password, Regex, RegexOptions.None, TimeSpan.FromMilliseconds(100));
}

public sealed class PasswordChecker(IPasswordRuleRepository passwordRuleRepository) : IPasswordChecker
{
    public async Task<CheckPasswordResult> CheckAsync(string password)
    {
        var rules = await passwordRuleRepository.GetRulesAsync();
        var errors = rules
            .Where(rule => !rule.Match(password))
            .Select(rule => rule.Description)
            .ToList();

        return new CheckPasswordResult(errors.Count == 0, errors.ToArray());
    }
}

public interface IPasswordChecker
{
    public Task<CheckPasswordResult> CheckAsync(string password);
}