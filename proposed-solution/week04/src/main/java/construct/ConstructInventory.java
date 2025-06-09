package construct;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

public class ConstructInventory {
    Artefact[] artefacts;
    private final Map<String, Behaviour> behaviours = new HashMap<>();

    public ConstructInventory(Artefact[] artefacts) {
        this.artefacts = artefacts;

        behaviours.put("Aged Signal", new AgedSignalBehaviour());
        behaviours.put("Backdoor Pass to TAFKAL80ETC Protocol", new BackdoorPassBehaviour());
        behaviours.put("Sulfuras Core Fragment", new SulfurasBehaviour());
    }

    public void updateSimulation() {
        Arrays.stream(artefacts)
                .forEach(this::update);
    }

    private void update(Artefact artefact) {
        behaviours.getOrDefault(artefact.name, new DefaultBehaviour())
                .update(artefact);
    }
}