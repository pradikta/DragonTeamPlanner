using DragonTeamPlanner.Models;

namespace DragonTeamPlanner.Services;

public static class DragonTeamService
{
    public static IReadOnlyList<DragonTeam> CreateTeams(
        int swordsmen,
        int archers,
        int mages,
        int healers)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(swordsmen);
        ArgumentOutOfRangeException.ThrowIfNegative(archers);
        ArgumentOutOfRangeException.ThrowIfNegative(mages);
        ArgumentOutOfRangeException.ThrowIfNegative(healers);

        // Priority: swordsmen, archers, mages, healers.
        int[] remaining = [swordsmen, archers, mages, healers];

        var teams = new List<DragonTeam>();

        while (remaining.Sum() > 0)
        {
            int[] members = new int[4];
            int totalRemaining = remaining.Sum();

            // Assign all remaining warriors if fewer than five remain.
            if (totalRemaining < 5)
            {
                Array.Copy(remaining, members, remaining.Length);
                Array.Clear(remaining);
            }
            else
            {
                // First, assign one warrior from each available class.
                for (int i = 0; i < remaining.Length; i++)
                {
                    if (remaining[i] > 0)
                    {
                        members[i]++;
                        remaining[i]--;
                    }
                }

                // Fill remaining seats according to class priority.
                // Each class can contribute at most two warriors.
                int teamSize = members.Sum();

                for (int i = 0;
                     i < remaining.Length && teamSize < 5;
                     i++)
                {
                    if (remaining[i] > 0 && members[i] < 2)
                    {
                        members[i]++;
                        remaining[i]--;
                        teamSize++;
                    }
                }
            }

            teams.Add(new DragonTeam
            {
                Swordsmen = members[0],
                Archers = members[1],
                Mages = members[2],
                Healers = members[3]
            });
        }

        return teams;
    }
}
