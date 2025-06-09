package construct;

public class Artefact {
    private static final int MAX_INTEGRITY = 50;
    private static final int TIME_BOOST_THRESHOLD = 11;
    private static final int TIME_CRITICAL_THRESHOLD = 6;

    public String name;
    public int integrity;
    public int timeToLive;

    public Artefact(String name, int integrity, int timeToLive) {
        this.name = name;
        this.integrity = integrity;
        this.timeToLive = timeToLive;
    }

    void increaseIntegrity() {
        integrity++;
    }

    void decreaseTimeToLive() {
        timeToLive--;
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

    @Override
    public String toString() {
        return this.name + ", " + this.integrity + ", " + this.timeToLive;
    }
}
