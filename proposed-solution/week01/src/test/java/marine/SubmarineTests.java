package marine;

import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.List;

import static org.assertj.core.api.Assertions.assertThat;

class SubmarineTests {
    public static final String INSTRUCTIONS = "submarine.txt";

    @Test
    void should_move_on_given_instructions() {
        assertThat(
                Submarine.startingFrom(0, 0)
                        .move(instructions())
                        .result()
        ).isEqualTo(1690020);
    }

    private List<Instruction> instructions() {
        return Arrays.stream(FileUtils.getInputAsSeparatedLines(INSTRUCTIONS))
                .map(Instruction::fromText)
                .toList();
    }
}