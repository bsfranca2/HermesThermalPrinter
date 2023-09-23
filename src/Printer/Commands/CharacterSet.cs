using Printer.Printers;

namespace Printer.Commands;

public static class CharacterSetExtensions
{
    private static readonly Dictionary<CharacterSet, string> CharacterSetStrings = new Dictionary<CharacterSet, string>
    {
        { CharacterSet.PC437_USA, "CP437" },
        { CharacterSet.PC850_MULTILINGUAL, "CP850" },
        { CharacterSet.PC860_PORTUGUESE, "CP860" },
        { CharacterSet.PC863_CANADIAN_FRENCH, "CP863" },
        { CharacterSet.PC865_NORDIC, "CP865" },
        { CharacterSet.PC851_GREEK, "CP860" },
        { CharacterSet.PC857_TURKISH, "CP857" },
        { CharacterSet.PC737_GREEK, "CP737" },
        { CharacterSet.ISO8859_7_GREEK, "ISO-8859-7" },
        { CharacterSet.WPC1252, "CP1252" },
        { CharacterSet.PC866_CYRILLIC2, "CP866" },
        { CharacterSet.PC852_LATIN2, "CP852" },
        { CharacterSet.SLOVENIA, "CP852" },
        { CharacterSet.PC858_EURO, "CP858" },
        { CharacterSet.WPC775_BALTIC_RIM, "CP775" },
        { CharacterSet.PC855_CYRILLIC, "CP855" },
        { CharacterSet.PC861_ICELANDIC, "CP861" },
        { CharacterSet.PC862_HEBREW, "CP862" },
        { CharacterSet.PC864_ARABIC, "CP864" },
        { CharacterSet.PC869_GREEK, "CP869" },
        { CharacterSet.ISO8859_2_LATIN2, "ISO-8859-2" },
        { CharacterSet.ISO8859_15_LATIN9, "ISO-8859-15" },
        { CharacterSet.PC1125_UKRAINIAN, "CP1125" },
        { CharacterSet.WPC1250_LATIN2, "WIN1250" },
        { CharacterSet.WPC1251_CYRILLIC, "WIN1251" },
        { CharacterSet.WPC1253_GREEK, "WIN1253" },
        { CharacterSet.WPC1254_TURKISH, "WIN1254" },
        { CharacterSet.WPC1255_HEBREW, "WIN1255" },
        { CharacterSet.WPC1256_ARABIC, "WIN1256" },
        { CharacterSet.WPC1257_BALTIC_RIM, "WIN1257" },
        { CharacterSet.WPC1258_VIETNAMESE, "WIN1258" },
        { CharacterSet.KZ1048_KAZAKHSTAN, "RK1048" },
        { CharacterSet.JAPAN, "EUC-JP" },
        { CharacterSet.KOREA, "EUC-KR" },
        { CharacterSet.CHINA, "EUC-CN" },
        { CharacterSet.HK_TW, "Big5-HKSCS" }
    };

    private static readonly Dictionary<CharacterSet, byte> CharacterSetBytes = new Dictionary<CharacterSet, byte>
    {
        { CharacterSet.PC437_USA, 0 },
        { CharacterSet.PC850_MULTILINGUAL, 2 },
        { CharacterSet.PC860_PORTUGUESE, 3 },
        { CharacterSet.PC863_CANADIAN_FRENCH, 4 },
        { CharacterSet.PC865_NORDIC, 5 },
        { CharacterSet.PC851_GREEK, 11 },
        { CharacterSet.PC857_TURKISH, 12 },
        { CharacterSet.PC737_GREEK, 14 },
        { CharacterSet.ISO8859_7_GREEK, 15 },
        { CharacterSet.WPC1252, 16 },
        { CharacterSet.PC866_CYRILLIC2, 17 },
        { CharacterSet.PC852_LATIN2, 18 },
        { CharacterSet.SLOVENIA, 18 },
        { CharacterSet.PC858_EURO, 19 },
        { CharacterSet.WPC775_BALTIC_RIM, 33 },
        { CharacterSet.PC855_CYRILLIC, 34 },
        { CharacterSet.PC861_ICELANDIC, 35 },
        { CharacterSet.PC862_HEBREW, 36 },
        { CharacterSet.PC864_ARABIC, 37 },
        { CharacterSet.PC869_GREEK, 38 },
        { CharacterSet.ISO8859_2_LATIN2, 39 },
        { CharacterSet.ISO8859_15_LATIN9, 40 },
        { CharacterSet.PC1125_UKRANIAN, 44 },
        { CharacterSet.WPC1250_LATIN2, 45 },
        { CharacterSet.WPC1251_CYRILLIC, 46 },
        { CharacterSet.WPC1253_GREEK, 47 },
        { CharacterSet.WPC1254_TURKISH, 48 },
        { CharacterSet.WPC1255_HEBREW, 49 },
        { CharacterSet.WPC1256_ARABIC, 50 },
        { CharacterSet.WPC1257_BALTIC_RIM, 51 },
        { CharacterSet.WPC1258_VIETNAMESE, 52 },
        { CharacterSet.KZ1048_KAZAKHSTAN, 53 },
        { CharacterSet.JAPAN, 0x08 },
        { CharacterSet.KOREA, 0x0d },
        { CharacterSet.CHINA, 0x0f },
        { CharacterSet.HK_TW, 0x00 }
    };

    public static string GetStringRepresentation(this CharacterSet characterSet)
    {
        return CharacterSetStrings.TryGetValue(characterSet, out string? stringValue) ? stringValue : throw new Exception("Character Set unrecognized");
    }

    public static byte GetByteRepresentation(this CharacterSet characterSet)
    {
        return CharacterSetBytes.TryGetValue(characterSet, out byte byteValue) ? byteValue : throw new Exception("Character Set unrecognized");
    }

    public static bool IsInternational(this CharacterSet characterSet)
    {
        return characterSet == CharacterSet.JAPAN || characterSet == CharacterSet.KOREA || characterSet == CharacterSet.CHINA || characterSet == CharacterSet.HK_TW;
    }
}
