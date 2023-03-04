using Nicknameisthekey.CSV;

namespace Nicknameisthekey.CSV.Tests;

public class TestModel
{
    [ColumnAttribute(0)]
    public string String { get; set; } = null!;
    [ColumnAttribute(1)]
    public int Integer { get; set; }
    [ColumnAttribute(2)]
    public DateTime Date { get; set; }
}