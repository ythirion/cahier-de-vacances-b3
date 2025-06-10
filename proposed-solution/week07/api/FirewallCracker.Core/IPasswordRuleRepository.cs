namespace FirewallCracker.Core;

public interface IPasswordRuleRepository
{
    IEnumerable<Rule> GetRules();
}