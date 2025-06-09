namespace Construct;

public class Artefact(string name, int timeToLive, int integrity)
{
    public string Name { get; set; } = name;
    public int TimeToLive { get; set; } = timeToLive;
    public int Integrity { get; set; } = integrity;

    public override string ToString() => $"{Name}, 🥄 integrity: {Integrity}, 💓 timeToLive: {TimeToLive}";
}