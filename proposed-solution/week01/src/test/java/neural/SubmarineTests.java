package neural;

import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.List;

import static org.assertj.core.api.Assertions.assertThat;

class SubmarineTests {
    public static final String COMMANDS = "submarine.txt";

    @Test
    void should_move_on_given_instructions() {
        assertThat(
                Submarine.startingFrom(0, 0)
                        .move(commands())
                        .accessCoordinate()
        ).isEqualTo(1690020);
    }

    private List<Command> commands() {
        return Arrays.stream(FileUtils.getInputAsSeparatedLines(COMMANDS))
                .map(Command::fromText)
                .toList();
    }
}