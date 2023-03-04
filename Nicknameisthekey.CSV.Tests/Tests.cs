using Nicknameisthekey.CSV;
using Nicknameisthekey.CSV.Tests;

public class Tests
{
    [Fact]
    public void ReadFromFile()
    {
        var result = CSV.ParseFromFile<TestModel>("test.csv");
        Assert.Equal(result.Count, 2);
        Assert.Equal("Строка1",                  result[0].String);
        Assert.Equal(1,                          result[0].Integer);
        Assert.Equal(new DateTime(2023, 03, 01), result[0].Date);
        Assert.Equal("Строка2",                  result[1].String);
        Assert.Equal(2,                          result[1].Integer);
        Assert.Equal(new DateTime(1995, 02, 20), result[1].Date);
    }
}