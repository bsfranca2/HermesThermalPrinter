namespace Printer.Printers;

public interface IPrinter
{
    IPrinter SetCharacterSet(CharacterSet set);
    IPrinter Initialize();
    IPrinter Raw(byte[] data);
    byte[] GetData();
    IPrinter Clear();
    IPrinter Debug();
    IPrinter Cut();
    IPrinter Cashdraw(CashDrawerPin pin);

    IPrinter Text(string data);
    IPrinter NewLine();
    IPrinter SetTextBold(bool bold);
    IPrinter SetTextUnderline(TextUnderline underline);
    IPrinter SetTextFont(TextFont font);
    IPrinter SetTextSize(TextSize width, TextSize height);
    IPrinter SetTextNormal();
    IPrinter SetAlign(Align align);
    IPrinter Invert(bool enabled);
    // IPrinter Image(Image image, ImageToRasterOptions? options);
    // IPrinter Qrcode(string data, QRCodeOptions? options);
    // IPrinter Barcode(string data, BarcodeType type, BarcodeOptions? options);
}
