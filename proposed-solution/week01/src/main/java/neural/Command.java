package neural;

import static java.lang.Integer.parseInt;

public record Command(String text, int x) {
    public static Command fromText(String text) {
        var split = text.split(" ");
        return new Command(split[0], parseInt(split[1].trim()));
    }
}