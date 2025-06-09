package construct;

public class Artefact {
    private static final int MAX_INTEGRITY = 50;
    private static final int TIME_BOOST_THRESHOLD = 11;
    private static final int TIME_CRITICAL_THRESHOLD = 6;

    private final String name;
    private int integrity;
    private int timeToLive;

    public Artefact(String name, int integrity, int timeToLive) {
        this.name = name;
        this.integrity = integrity;
        this.timeToLive = timeToLive;
    }

    void decreaseIntegrity() {
        integrity--;
    }

    void increaseIntegrity() {
        if (isBelowMaxIntegrity()) {
            integrity++;
        }
    }

    void decreaseTimeToLive() {
        timeToLive--;
    }

    void resetIntegrity() {
        integrity = 0;
    }

    boolean iBelowTimeCriticalThreshold() {
        return timeToLive < TIME_CRITICAL_THRESHOLD;
    }

    boolean isBelowMaxIntegrity() {
        return integrity < MAX_INTEGRITY;
    }

    boolean isBelowTimeBoostThreshold() {
        return timeToLive < TIME_BOOST_THRESHOLD;
    }

    boolean noTimeToLive() {
        return timeToLive < 0;
    }

    boolean hasIntegrity() {
        return integrity > 0;
    }

    public String getName() {
        return name;
    }

    // Only there for testing purposes 🫠
    // Should be removed to preserve encapsulation
    public int getIntegrity() {
        return integrity;
    }

    public int getTimeToLive() {
        return timeToLive;
    }

    @Override
    public String toString() {
        return this.name + ", " + this.integrity + ", " + this.timeToLive;
    }
}
