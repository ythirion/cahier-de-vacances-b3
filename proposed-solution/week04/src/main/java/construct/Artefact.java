package construct;

public class Artefact {
    public String name;
    public int integrity;
    public int timeToLive;

    public Artefact(String name, int integrity, int timeToLive) {
        this.name = name;
        this.integrity = integrity;
        this.timeToLive = timeToLive;
    }

    @Override
    public String toString() {
        return this.name + ", " + this.integrity + ", " + this.timeToLive;
    }
}
