package construct;

import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class InventoryTest {
    @Test
    public void classicUnitTest() {
        // Arrange
        var artefact = new Artefact("a common item", 0, 0);
        var constructInventory = new ConstructInventory(new Artefact[]{artefact});

        // Act
        constructInventory.updateSimulation();

        // Assert
        assertThat(artefact.timeToLive).isEqualTo(-1);
        assertThat(artefact.integrity).isEqualTo(0);
    }
}
