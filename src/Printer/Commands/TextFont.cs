using Printer.Printers;

namespace Printer.Commands;

public static class TextFontExtensions
{
    private static readonly Dictionary<TextFont, byte> FontMapBytes = new Dictionary<TextFont, byte>
    {
        { TextFont.A, 0 },
        { TextFont.B, 1 },
        { TextFont.C, 2 },
        { TextFont.D, 3 },
        { TextFont.E, 4 },
        { TextFont.SpecialA, 97 },
        { TextFont.SpecialB, 98 }
    };

    public static byte GetByteRepresentation(this TextFont textFont)
    {
        return FontMapBytes.TryGetValue(textFont, out byte byteValue) ? byteValue : throw new Exception("Text font unrecognized");
    }
}
