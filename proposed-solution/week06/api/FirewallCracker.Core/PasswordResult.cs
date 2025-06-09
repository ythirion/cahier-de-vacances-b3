namespace FirewallCracker.Core;

public record PasswordResult(bool IsValid, Rules Rules, string Message);
public record Rules(bool MinLength, bool HasUpperCase, bool HasLowerCase, bool HasNumber, bool HasCyberSymbol, bool HasOnlyAllowedCharacters);