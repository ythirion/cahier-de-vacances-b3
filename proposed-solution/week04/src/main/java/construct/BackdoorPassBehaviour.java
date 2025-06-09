package construct;

public class BackdoorPassBehaviour implements Behaviour {
    @Override
    public void update(Artefact artefact) {
        if (artefact.isBelowMaxIntegrity()) {
            artefact.increaseIntegrity();

            if (artefact.isBelowTimeBoostThreshold() && artefact.isBelowMaxIntegrity()) {
                artefact.increaseIntegrity();
            }

            if (artefact.iBelowTimeCriticalThreshold() && artefact.isBelowMaxIntegrity()) {
                artefact.increaseIntegrity();
            }
        }

        artefact.decreaseTimeToLive();

        if (artefact.noTimeToLive()) {
            artefact.integrity = 0;
        }
    }
}