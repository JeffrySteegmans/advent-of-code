namespace AoC._2025.Tests;

public sealed class Day01Tests
{
    [Fact]
    public void GivenInput_WhenPart1_ThenReturnsExpectedResult()
    {
        const string Input = """
L68
L30
R48
L5
R60
L55
L1
L99
R14
L82
""";
        const string Expected = "3";
        var day = new Day01();

        var result = day.Part1(Input);

        Assert.Equal(
            Expected,
            result);
    }

    [Fact]
    public void GivenInput_WhenPart2_ThenReturnsExpectedResult()
    {
        const string Input = """
L68
L30
R48
L5
R60
L55
L1
L99
R14
L82
""";
        const string Expected = "unknown";
        var day = new Day01();

        var result = day.Part2(Input);

        Assert.Equal(
            Expected,
            result);
    }

}
