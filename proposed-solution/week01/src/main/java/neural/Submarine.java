package neural;

import java.util.List;

public record Submarine(Position position) {

    public static final String DOWN = "down";
    public static final String UP = "up";

    public static Submarine startingFrom(int horizontal, int depth) {
        return new Submarine(new Position(horizontal, depth));
    }

    public Submarine move(List<Command> commands) {
        return commands
                .stream()
                .reduce(this, Submarine::move, (s1, s2) -> s1);
    }

    private Submarine move(Command command) {
        return new Submarine(
                switch (command.text()) {
                    case DOWN -> down(command.x());
                    case UP -> up(command.x());
                    default -> forward(command.x());
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

    public int accessCoordinate() {
        return position().depth() * position().horizontal();
    }
}