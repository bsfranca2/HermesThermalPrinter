namespace Printer.Printers;

public record Cmd(string Name, object[]? Args, byte[] Data)
{
    public Cmd(string name, byte[] data) : this(name, null, data) { }
};
