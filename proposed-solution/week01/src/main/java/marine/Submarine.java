package marine;

import java.util.List;

public record Submarine(Position position) {

    public static final String DOWN = "down";
    public static final String UP = "up";

    public static Submarine startingFrom(int horizontal, int depth) {
        return new Submarine(new Position(horizontal, depth));
    }

    public Submarine move(List<Instruction> instructions) {
        return instructions
                .stream()
                .reduce(this, Submarine::move, (s1, s2) -> s1);
    }

    private Submarine move(Instruction instruction) {
        return new Submarine(
                switch (instruction.text()) {
                    case DOWN -> down(instruction.x());
                    case UP -> up(instruction.x());
                    default -> forward(instruction.x());
                }
        );
    }

    private Position down(int x) {
        return new Position(position.horizontal(), position.depth() + x);
    }

    private Position up(int x) {
        return new Position(position.horizontal(), position.depth() - x);
    }

    private Position forward(int x) {
        return new Position(position.horizontal() + x, position.depth());
    }

    public int result() {
        return position().depth() * position().horizontal();
    }
}