package construct;

public class DefaultBehaviour implements Behaviour {
    @Override
    public void update(Artefact artefact) {
        decreaseIntegrity(artefact);

        artefact.timeToLive--;

        if (artefact.timeToLive < 0) {
            decreaseIntegrity(artefact);
        }
    }

    private void decreaseIntegrity(Artefact artefact) {
        if (artefact.integrity > 0) {
            artefact.integrity--;
        }
    }
}
