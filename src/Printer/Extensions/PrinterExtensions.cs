using System.Text;

using Printer.Commands;
using Printer.Printers;

namespace Printer.Extensions;

internal static class PrinterExtensions
{
    public static byte[] ToByteArray(this string str, CharacterSet characterSet)
    {
        return Encoding.GetEncoding(characterSet.GetStringRepresentation()).GetBytes(str);
    }

    public static object[] ToObjectArray(this byte[] byteArray)
    {
        object[] objectArray = new object[byteArray.Length];

        for (int i = 0; i < byteArray.Length; i++)
        {
            objectArray[i] = byteArray[i];
        }

        return objectArray;
    }

    public static object[] ToObjectArray(this string str)
    {
        return new object[] { str };
    }

    public static object[] ToObjectArray(this bool value)
    {
        return new object[] { value };
    }

    public static object[] ToObjectArray(this TextFont textFont)
    {
        return new object[] { textFont.ToString() };
    }

    public static object[] ToObjectArray(this TextUnderline textUnderline)
    {
        return new object[] { textUnderline.ToString() };
    }

    public static object[] ToObjectArray(this CharacterSet characterSet)
    {
        return new object[] { characterSet.ToString() };
    }

    public static object[] ToObjectArray(this Align align)
    {
        return new object[] { align.ToString() };
    }

    public static object[] ToObjectArray(this CashDrawerPin pin)
    {
        return new object[] { pin.ToString() };
    }

    public static byte ToByte(this bool value)
    {
        return (byte)(value ? 1 : 0);
    }
}
