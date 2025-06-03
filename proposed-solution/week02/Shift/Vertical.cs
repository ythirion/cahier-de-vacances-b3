namespace Shift;

using Instruction = char;
using FloorStrategy = Func<char, int>;

public static class Vertical
{
    private const Instruction Up = '(';
    private const Instruction Down = ')';
    private const string ElfSymbol = "🧝";

    private static readonly FloorStrategy Standard = c => c == Up ? 1 : -1;

    private static readonly FloorStrategy Elf = c => c switch
    {
        Down => 3,
        Up => -2,
        _ => 0
    };

    public static int WhichFloor(string signalStream)
        => WhichFloor(
            signalStream,
            signalStream.Contains(ElfSymbol) ? Elf : Standard
        );

    private static int WhichFloor(string signalStream, FloorStrategy strategy)
        => signalStream
            .Select(strategy)
            .Sum();
}