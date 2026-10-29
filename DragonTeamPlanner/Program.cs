
using DragonTeamPlanner.Services;

int swordsmen = ReadCount("swordsmen");
int archers = ReadCount("archers");
int mages = ReadCount("mages");
int healers = ReadCount("healers");

var teams = DragonTeamService.CreateTeams(
    swordsmen,
    archers,
    mages,
    healers);

for (int i = 0; i < teams.Count; i++)
{
    var team = teams[i];

    Console.WriteLine(
        $"Dragon {i + 1}: " +
        $"{team.Swordsmen} swordsmen, " +
        $"{team.Archers} archers, " +
        $"{team.Mages} mages, " +
        $"{team.Healers} healers");
}

static int ReadCount(string warriorClass)
{
    while (true)
    {
        Console.Write($"Enter number of {warriorClass}: ");

        if (int.TryParse(Console.ReadLine(), out int count)
            && count >= 0)
        {
            return count;
        }

        Console.WriteLine(
            "Please enter a valid non-negative integer.");
    }
}
