namespace Construct;

public class ConstructInventory(Artefact[] artefacts)
{
    public void UpdateSimulation()
    {
        for (int i = 0; i < artefacts.Length; i++)
        {
            var artefact = artefacts[i];

            if (artefact.Name != "Aged Signal" &&
                artefact.Name != "Backdoor Pass to TAFKAL80ETC Protocol")
            {
                if (artefact.Integrity > 0)
                {
                    if (artefact.Name != "Sulfuras Core Fragment")
                    {
                        artefact.Integrity--;
                    }
                }
            }
            else
            {
                if (artefact.Integrity < 50)
                {
                    artefact.Integrity++;

                    if (artefact.Name == "Backdoor Pass to TAFKAL80ETC Protocol")
                    {
                        if (artefact.TimeToLive < 11 && artefact.Integrity < 50)
                        {
                            artefact.Integrity++;
                        }

                        if (artefact.TimeToLive < 6 && artefact.Integrity < 50)
                        {
                            artefact.Integrity++;
                        }
                    }
                }
            }

            if (artefact.Name != "Sulfuras Core Fragment")
            {
                artefact.TimeToLive--;
            }

            if (artefact.TimeToLive < 0)
            {
                if (artefact.Name != "Aged Signal")
                {
                    if (artefact.Name != "Backdoor Pass to TAFKAL80ETC Protocol")
                    {
                        if (artefact.Integrity > 0)
                        {
                            if (artefact.Name != "Sulfuras Core Fragment")
                            {
                                artefact.Integrity--;
                            }
                        }
                    }
                    else
                    {
                        artefact.Integrity = 0;
                    }
                }
                else
                {
                    if (artefact.Integrity < 50)
                    {
                        artefact.Integrity++;
                    }
                }
            }
        }
    }
}