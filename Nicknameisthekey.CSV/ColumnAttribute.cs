namespace Nicknameisthekey.CSV;
public class ColumnAttribute : Attribute
{
    public int ColumnNumber { get; private init; }

    public ColumnAttribute(int columnNumber)
    {
        this.ColumnNumber = columnNumber;
    }
}