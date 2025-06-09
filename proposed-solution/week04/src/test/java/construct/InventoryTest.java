package construct;

import org.approvaltests.Approvals;
import org.approvaltests.combinations.CombinationApprovals;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class InventoryTest {
    @Test
    void classicUnitTest() {
        // Arrange
        var artefact = new Artefact("Mirror Shard", 0, 0);
        var constructInventory = new ConstructInventory(new Artefact[]{artefact});

        // Act
        constructInventory.updateSimulation();

        // Assert
        assertThat(artefact.getTimeToLive()).isEqualTo(-1);
        assertThat(artefact.getIntegrity()).isEqualTo(0);
    }

    @Test
    void singleApprovalTestForExample() {
        var artefact = new Artefact("Mirror Shard", 0, 0);
        var constructInventory = new ConstructInventory(new Artefact[]{artefact});

        constructInventory.updateSimulation();

        // No more assertions here, just use Approvals
        Approvals.verify(artefact);
    }

    @Test
    void approvalTests() {
        CombinationApprovals.verifyAllCombinations(
                this::updateSimulation,
                new String[]{
                        "Mirror Shard",
                        "Aged Signal",
                        "Backdoor Pass to TAFKAL80ETC Protocol",
                        "Sulfuras Core Fragment"
                },
                new Integer[]{-1, 0, 10, 11, 51},
                new Integer[]{-1, 0, 1, 5, 49, 50}
        );
    }

    private String updateSimulation(String name, int integrity, int timeToLive) {
        var artefact = new Artefact(name, integrity, timeToLive);
        var constructInventory = new ConstructInventory(new Artefact[]{artefact});
        constructInventory.updateSimulation();

        return artefact.toString();
    }
}