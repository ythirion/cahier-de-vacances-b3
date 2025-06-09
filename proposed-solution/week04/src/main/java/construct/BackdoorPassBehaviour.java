package construct;

public class BackdoorPassBehaviour implements Behaviour {
    @Override
    public void update(Artefact artefact) {
        if (artefact.integrity < 50) {
            artefact.integrity++;

            if (artefact.timeToLive < 11 && artefact.integrity < 50) {
                artefact.integrity++;
            }

            if (artefact.timeToLive < 6 && artefact.integrity < 50) {
                artefact.integrity++;
            }
        }

        artefact.timeToLive--;

        if (artefact.timeToLive < 0) {
            artefact.integrity = 0;
        }
    }
}
