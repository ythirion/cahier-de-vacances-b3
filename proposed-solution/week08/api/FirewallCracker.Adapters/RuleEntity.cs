using FirewallCracker.Core;

namespace FirewallCracker.Adapters;

public class RuleEntity
{
    public int Id { get; init; }
    public required string Regex { get; init; }
    public required string Description { get; init; }
}

public static class RuleEntityExtensions
{
    public static Rule ToRule(this RuleEntity entity) => new(entity.Regex, entity.Description);
}