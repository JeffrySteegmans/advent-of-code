# advent-of-code
Advent of Code solutions in C#. Organized by year with a shared library for common utilities and a CLI runner for 
easy execution. Includes input management, reflection-based day discovery, and unit tests for each puzzle.

## Features
- ✅ Organized by year (`AoC.2023`, `AoC.2024`, `AoC.2025`)
- ✅ Shared utilities in `AoC.Common`
- ✅ CLI runner to execute any day/part
- ✅ Unit tests for each solution
- ✅ Inputs stored in `inputs/{year}/dayXX.txt`
- ✅ Optional input auto-fetch from AoC website

## Run a solution

```bash
dotnet run --project src/AoC.Runner --year 2025 --day 1 --part both
```
