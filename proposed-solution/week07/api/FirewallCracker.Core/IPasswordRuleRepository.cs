namespace FirewallCracker.Core;

public interface IPasswordRuleRepository
{
    Task<IEnumerable<Rule>> GetRules();
}