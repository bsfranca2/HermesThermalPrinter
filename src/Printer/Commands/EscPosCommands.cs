using Printer.Printers;

namespace Printer.Commands;

public static class EscPosCommands
{
    /**
     * Initialize printer
     * | Format   | Value   |
     * |---------|---------|
     * | ASCII   | ESC @   |
     * | Hex     | 1B 40   |
     * | Decimal | 27 64   |
     *
     * @see https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=192
     */
    public static byte[] Initialize()
    {
        return new byte[] { Common.ESC, 0x40 };
    }

    /**
    * Select justification
    * | Format   | Value    |
    * |---------|----------|
    * | ASCII   | ESC a n  |
    * | Hex     | 1B 61 n  |
    * | Decimal | 27 97 n  |
    *
    * @see https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=58
    */
    public static byte[] Alignment(byte n)
    {
        return new byte[] { Common.ESC, 0x61, n };
    }

    /**
     * Generate pulse
     * | Format  | Value                |
     * |---------|----------------------|
     * | ASCII   | ESC   p   m  t1   t2 |
     * | Hex     |  1B  70   m  t1   t2 |
     * | Decimal |  27  27   m  t1   t2 |
     *
     * @see https://www.epson-biz.com/modules/ref_escpos/index.php?content_id=195
     */
    public static byte[] Cashdraw(byte m, byte t1, byte t2)
    {
        return new byte[] { Common.ESC, 0x70, m, t1, t2 };
    }

    /**
     * Select cut mode and cut paper
     * <Function A>
     * | Format   | Value    |
     * |---------|----------|
     * | ASCII   | GS V m  |
     * | Hex     | 1D 56 m |
     * | Decimal | 29 86 m |
     *
     * <Function B, C, D>
     * | Format   | Value    |
     * |---------|-----------|
     * | ASCII   | GS V m n  |
     * | Hex     | 1D 56 m n |
     * | Decimal | 29 86 m n |
     *
     * @see https://www.epson-biz.com/modules/ref_escpos/index.php?content_id=87
     */
    public static byte[] Cut(byte m, byte? n)
    {
        var cmd = new byte[] { Common.GS, 0x56, m };
        if (n != null)
        {
            cmd = cmd.Concat(new byte[] { (byte)n }).ToArray();
        }
        return cmd;
    }

    /**
     * Select character code table
     * | Format   | Value     |
     * |---------|-----------|
     * | ASCII   | ESC t n   |
     * | Hex     | 1B 74 n   |
     * | Decimal | 27 116 n  |
     *
     * @see https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=32
     */
    public static byte[] CharacterCodeTable(byte n)
    {
        return new byte[] { Common.ESC, 0x74, n };
    }

    /**
     * Select an international character set
     * | Format   | Value    |
     * |---------|----------|
     * | ASCII   | ESC R n  |
     * | Hex     | 1B 52 n  |
     * | Decimal | 27 82 n  |
     *
     * @see https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=29
     */
    public static byte[] InternationalCharacterSet(byte n)
    {
        return new byte[] { Common.ESC, 0x52, n };
    }

    public static byte[] CharacterSet(CharacterSet set)
    {
        var n = set.GetByteRepresentation();

        return set.IsInternational() ? InternationalCharacterSet(n) : CharacterCodeTable(n);
    }

    /**
     * Specify/cancel white/black inverted printing
     * | Format   | Value    |
     * |---------|----------|
     * | ASCII   | GS b n   |
     * | Hex     | 1D 42 n  |
     * | Decimal | 29 66 n  |
     *
     * @see https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=25
     */
    public static byte[] Invert(byte n)
    {
        return new byte[] { Common.GS, 0x42, n };
    }

    /**
     * Turn emphasized mode on/off
     * | Format   | Value    |
     * |---------|----------|
     * | ASCII   | ESC E n  |
     * | Hex     | 1B 45 n  |
     * | Decimal | 27 69 n  |
     *
     * @see https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=25
     */
    public static byte[] TextBold(byte n)
    {
        return new byte[] { Common.ESC, 0x45, n };
    }

    /**
     * Select character font
     * | Format   | Value    |
     * |---------|----------|
     * | ASCII   | ESC M n  |
     * | Hex     | 1B 4D n  |
     * | Decimal | 27 7 n  |
     *
     * @see https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=27
     */
    public static byte[] TextFont(byte n)
    {
        return new byte[] { Common.ESC, 0x4d, n };
    }

    /**
     * Select print mode(s)
     * | Format   | Value    |
     * |---------|----------|
     * | ASCII   | ESC ! n  |
     * | Hex     | 1B 21 n  |
     * | Decimal | 27 33 n  |
     *
     * @see https://www.epson-biz.com/modules/ref_escpos/index.php?content_id=23
     */
    public static byte[] TextMode(byte n)
    {
        return new byte[] { Common.ESC, 0x21, n };
    }

    /**
     * Select character size
     * | Format   | Value    |
     * |---------|----------|
     * | ASCII   | GS ! n  |
     * | Hex     | 1D 21 n  |
     * | Decimal | 29 33 n  |
     *
     * @see https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=34
     */
    public static byte[] TextSize(byte n)
    {
        return new byte[] { Common.GS, 0x21, n };
    }

    /**
     * Turn underline mode on/off
     * | Format   | Value    |
     * |---------|----------|
     * | ASCII   | ESC - n  |
     * | Hex     | 1B 2D n  |
     * | Decimal | 27 45 n  |
     *
     * @see https://reference.epson-biz.com/modules/ref_escpos/index.php?content_id=24
     */
    public static byte[] TextUnderline(byte n)
    {
        return new byte[] { Common.ESC, 0x2d, n };
    }
}