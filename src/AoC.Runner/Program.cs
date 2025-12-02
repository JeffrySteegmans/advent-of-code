using System.Reflection;
using AoC.Common;

var yearArg = GetArg("--year") ?? DateTime.Now.Year.ToString();
var dayArg  = GetArg("--day")  ?? "1";
var partArg = GetArg("--part") ?? "both";
var inputRoot = Path.Combine(AppContext.BaseDirectory, "../", "../", "../", "../", "../", "inputs");

if (!int.TryParse(yearArg, out var year) || !int.TryParse(dayArg, out var day))
{
    Console.WriteLine("Usage: --year YYYY --day DD [--part 1|2|both]");
    return;
}

// Load all types implementing IDay from referenced assemblies
var assemblies = new[]
{
    Assembly.Load("AoC.Common"),
    Assembly.Load("AoC.2025")
}.Where(a => a != null);

var allDays = assemblies
    .SelectMany(a => a.GetTypes())
    .Where(t => typeof(IDay).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
    .Select(t => Activator.CreateInstance(t) as IDay)
    .Where(d => d != null)
    .ToList();

var target = allDays.FirstOrDefault(d => d!.Year == year && d.Day == day);
if (target is null)
{
    Console.WriteLine($"No implementation found for {year} Day {day:D2}");
    return;
}

// Load input file
var inputPath = Path.Combine(inputRoot, year.ToString(), $"day{day:D2}.txt");
if (!File.Exists(inputPath))
{
    Console.WriteLine($"Input not found: {inputPath}");
    return;
}
var input = File.ReadAllText(inputPath);

// Run parts
if (partArg is "1" or "both")
{
    var ans1 = Time(() => target.Part1(input));
    Console.WriteLine($"[{year} Day {day:D2}] Part 1: {ans1.Value} ({ans1.Ms} ms)");
}
if (partArg is "2" or "both")
{
    var ans2 = Time(() => target.Part2(input));
    Console.WriteLine($"[{year} Day {day:D2}] Part 2: {ans2.Value} ({ans2.Ms} ms)");
}

static (string Value, long Ms) Time(Func<string> f)
{
    var sw = System.Diagnostics.Stopwatch.StartNew();
    var val = f();
    sw.Stop();
    return (val, sw.ElapsedMilliseconds);
}

static string? GetArg(string name)
{
    var args = Environment.GetCommandLineArgs();
    var idx = Array.IndexOf(args, name);
    return idx >= 0 && idx + 1 < args.Length ? args[idx + 1] : null;
}
