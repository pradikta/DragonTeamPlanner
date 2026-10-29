# Dragon Team Planner

A small C# console application that distributes warriors
among dragons according to the provided team composition rules.

## Project structure

```text
DragonTeamPlanner.sln
DragonTeamPlanner/
  DragonTeamPlanner.csproj
DragonTeamPlanner.Tests/
  DragonTeamPlanner.Tests.csproj
```

The solution file is at the repository root and includes both the
application and its test project.

## Requirements

- .NET 10 SDK

## Run

```bash
dotnet run --project DragonTeamPlanner/DragonTeamPlanner.csproj
```

Enter the number of swordsmen, archers, mages, and healers when prompted.

## Build and test

The root solution includes the console application and its tests.

```bash
dotnet build DragonTeamPlanner.sln
dotnet test DragonTeamPlanner.sln
```

## Rules

- Each dragon can carry up to five warriors.
- Assign one warrior from each available class first.
- Fill remaining seats in priority order:
  swordsmen, archers, mages, then healers.
- While at least five warriors remain overall, assign
  no more than two warriors of the same class to a dragon.
- If fewer than five warriors remain overall, assign
  all remaining warriors to the final dragon.
- Warrior counts must be non-negative integers.
