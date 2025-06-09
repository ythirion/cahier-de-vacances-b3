package construct;

public class AgedSignalBehaviour implements Behaviour {
    @Override
    public void update(Artefact artefact) {
        increaseIntegrity(artefact);

        artefact.timeToLive--;

        if (artefact.timeToLive < 0) {
            increaseIntegrity(artefact);
        }
    }

    private void increaseIntegrity(Artefact artefact) {
        if (artefact.integrity < 50) {
            artefact.integrity++;
        }
    }
}
