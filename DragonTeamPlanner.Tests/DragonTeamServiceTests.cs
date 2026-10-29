using DragonTeamPlanner.Models;
using DragonTeamPlanner.Services;

namespace DragonTeamPlanner.Tests;

public class DragonTeamServiceTests
{
    [Fact]
    public void CreateTeams_WithOneWarriorPerClass_ReturnsOneTeam()
    {
        var teams = DragonTeamService.CreateTeams(1, 1, 1, 1);

        Assert.Collection(
            teams,
            team => AssertTeam(team, 1, 1, 1, 1));
    }

    [Fact]
    public void CreateTeams_WithExampleTwo_ReturnsExpectedBalancedTeams()
    {
        var teams = DragonTeamService.CreateTeams(10, 6, 3, 5);

        Assert.Collection(
            teams,
            team => AssertTeam(team, 2, 1, 1, 1),
            team => AssertTeam(team, 2, 1, 1, 1),
            team => AssertTeam(team, 2, 1, 1, 1),
            team => AssertTeam(team, 2, 2, 0, 1),
            team => AssertTeam(team, 2, 1, 0, 1));
    }

    [Fact]
    public void CreateTeams_WithNoWarriors_ReturnsEmptyList()
    {
        var teams = DragonTeamService.CreateTeams(0, 0, 0, 0);

        Assert.Empty(teams);
    }

    [Fact]
    public void CreateTeams_WithFewerThanFiveWarriors_AssignsAllRemaining()
    {
        var teams = DragonTeamService.CreateTeams(2, 1, 0, 0);

        var team = Assert.Single(teams);

        Assert.Equal(3, team.Total);
        Assert.Equal(2, team.Swordsmen);
        Assert.Equal(1, team.Archers);
    }

    [Fact]
    public void CreateTeams_WithFewerThanFiveWarriorsRemaining_AllowsMoreThanTwoFromOneClass()
    {
        var teams = DragonTeamService.CreateTeams(8, 0, 0, 0);

        Assert.Collection(
            teams,
            team => AssertTeam(team, 2, 0, 0, 0),
            team => AssertTeam(team, 2, 0, 0, 0),
            team => AssertTeam(team, 4, 0, 0, 0));
    }

    [Theory]
    [InlineData(-1, 0, 0, 0)]
    [InlineData(0, -1, 0, 0)]
    [InlineData(0, 0, -1, 0)]
    [InlineData(0, 0, 0, -1)]
    public void CreateTeams_WithNegativeCount_ThrowsException(
        int swordsmen,
        int archers,
        int mages,
        int healers)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => DragonTeamService.CreateTeams(
                swordsmen, archers, mages, healers));
    }

    private static void AssertTeam(
        DragonTeam team,
        int swordsmen,
        int archers,
        int mages,
        int healers)
    {
        Assert.Equal(
            (swordsmen, archers, mages, healers),
            (team.Swordsmen, team.Archers, team.Mages, team.Healers));
    }
}
