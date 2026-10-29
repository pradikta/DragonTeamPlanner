namespace DragonTeamPlanner.Models;

public sealed class DragonTeam
{
    public int Swordsmen { get; init; }
    public int Archers { get; init; }
    public int Mages { get; init; }
    public int Healers { get; init; }
    public int Total => Swordsmen + Archers + Mages + Healers;
}
