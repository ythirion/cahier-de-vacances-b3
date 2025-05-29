package marine;

import static java.lang.Integer.parseInt;

public record Instruction(String text, int x) {
    public static Instruction fromText(String text) {
        var split = text.split(" ");
        return new Instruction(split[0], parseInt(split[1].trim()));
    }
}