using Printer.Commands;
using Printer.Extensions;

namespace Printer.Printers;

public class BasePrinter : IPrinter
{
    private readonly List<Cmd> _cmds = new();
    private CharacterSet CharacterSet { get; set; }

    public BasePrinter(CharacterSet characterSet)
    {
        CharacterSet = characterSet;
    }

    public IPrinter SetCharacterSet(CharacterSet set)
    {
        CharacterSet = set;
         _cmds.Add(new Cmd("SetCharacterSet", set.ToObjectArray(), EscPosCommands.CharacterSet(set)));
        return this;
    }

    public IPrinter Initialize()
    {
        _cmds.Add(new Cmd("Initialize", EscPosCommands.Initialize()));
        return this;
    }

    public IPrinter Raw(byte[] data)
    {
        _cmds.Add(new Cmd("Raw", data.ToObjectArray(), data));
        return this;
    }

    public byte[] GetData()
    {
        return _cmds.SelectMany(cmd => cmd.Data).ToArray();
    }

    public IPrinter Clear()
    {
        _cmds.Clear();
        return this;
    }

    public IPrinter Debug()
    {
        Console.WriteLine(_cmds);
        return this;
    }

    public IPrinter Cut()
    {
        _cmds.Add(new Cmd("Cut", EscPosCommands.Cut(48, null)));
        return this;
    }

    public IPrinter Cashdraw(CashDrawerPin pin)
    {
        var m = (byte)pin;
        _cmds.Add(new Cmd("Cashdraw", pin.ToObjectArray(), EscPosCommands.Cashdraw(m, 0x19, 0x78)));
        return this;
    }

    public IPrinter Text(string data)
    {
        _cmds.Add(new Cmd("Text", data.ToObjectArray(), data.ToByteArray(CharacterSet)));
        return this;
    }

    public IPrinter NewLine()
    {
        _cmds.Add(new Cmd("NewLine", new byte[] { Common.LF }));
        return this;
    }

    public IPrinter SetTextFont(TextFont font)
    {
        _cmds.Add(new Cmd("SetTextFont", font.ToObjectArray(), EscPosCommands.TextFont(font.GetByteRepresentation())));
        return this;
    }

    public IPrinter SetTextBold(bool bold)
    {
        _cmds.Add(new Cmd("SetTextBold", bold.ToObjectArray(), EscPosCommands.TextBold(bold.ToByte())));
        return this;
    }

    public IPrinter SetTextUnderline(TextUnderline underline)
    {
        _cmds.Add(new Cmd("SetTextUnderline", underline.ToObjectArray(), EscPosCommands.TextUnderline((byte)underline)));
        return this;
    }

    public IPrinter SetTextSize(TextSize width, TextSize height)
    {
        var w = ((byte)width - 1) * 16;
        var h = (byte)height - 1;
        var n = w + h;

        _cmds.Add(new Cmd("SetTextSize", new object[] { w, h }, EscPosCommands.TextSize((byte)n)));
        return this;
    }

    public IPrinter SetTextNormal()
    {
        _cmds.Add(new Cmd("SetTextNormal", EscPosCommands.TextMode(0)));
        return this;
    }

    public IPrinter SetAlign(Align align)
    {
        _cmds.Add(new Cmd("SetAlign", align.ToObjectArray(), EscPosCommands.Alignment((byte)align)));
        return this;
    }

    public IPrinter Invert(bool enabled)
    {
        _cmds.Add(new Cmd("Invert", enabled.ToObjectArray(), EscPosCommands.Invert(enabled.ToByte())));
        return this;
    }
}
