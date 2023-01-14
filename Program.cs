using System;
using System.Drawing;
using QRCoder;
namespace QrCodeGenerator
{
    public class Program
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        static void Main(string[] args)
        {
            string logo = @"
        ▒█▀▀█ ▒█▀▀█ 　 ▒█▀▀█ ▒█▀▀▀ ▒█▄░▒█ ▒█▀▀█ ░█▀▀█ ▀▀█▀▀ ▒█▀▀▀█ ▒█▀▀█ 
        ▒█░▒█ ▒█▄▄▀ 　 ▒█░▄▄ ▒█▀▀▀ ▒█▒█▒█ ▒█▄▄▀ ▒█▄▄█ ░▒█░░ ▒█░░▒█ ▒█▄▄▀ 
        ░▀▀█▄ ▒█░▒█ 　 ▒█▄▄█ ▒█▄▄▄ ▒█░░▀█ ▒█░▒█ ▒█░▒█ ░▒█░░ ▒█▄▄▄█ ▒█░▒█
                                by AlaSwek03043
        ";
            Console.WriteLine(logo);
            Console.WriteLine("Hello!");
            System.Threading.Thread.Sleep(900);
            Console.WriteLine("I'm so glad we met! I think I know what you need me for..");
            System.Threading.Thread.Sleep(900);
            Console.WriteLine("Do you want me to generate a QR code for you?");
            System.Threading.Thread.Sleep(900);
            Console.WriteLine("[ 1 ] Yes");
            Console.WriteLine("[ 2 ] No  \n");
            while(true)
            {
                string options = Console.ReadLine();
                if (options == "1")
                {
                    Console.Clear();
                    Console.WriteLine(logo);
                    Console.WriteLine("Enter the link for which you want me to generate your qr code");
                    string link = Console.ReadLine();
                    #region Check if the user's input is a link or not.
                    Uri uriResult;
                    bool isUri = Uri.TryCreate(link, UriKind.Absolute, out uriResult)
                     && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                    if (isUri)
                    {
                        // Create a QR code generator
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();

                        // Create a QR code data object
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(link, QRCodeGenerator.ECCLevel.Q);

                        // Create a QR code graphic object
                        QRCode qrCode = new QRCode(qrCodeData);

                        // Generate the QR code image
                        Bitmap qrCodeImage = qrCode.GetGraphic(20);

                        // Save the QR code image to a file
                        qrCodeImage.Save("qrcode.png");

                        // Display the QR code image
                        Console.WriteLine("QR code image created and saved to qrcode.png");

                        Console.WriteLine("Done!");
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(logo + "\n\n");
                        Console.WriteLine("Sorry, but what you entered is not a link.");
                        Console.Read();
                        break;
                    }
                    #endregion
                }
                else if (options == "2")
                {
                    Console.WriteLine("Ok, application exit..");
                    Console.Read();
                    Environment.Exit(0);
                } else
                {
                    Console.Clear();
                    Console.WriteLine("Error: Please enter a valid option (1 or 2)\n");
                    System.Threading.Thread.Sleep(1200);
                    Console.WriteLine("Do you want me to generate a QR code for you?");
                    System.Threading.Thread.Sleep(400);
                    Console.WriteLine("[ 1 ] Yes");
                    Console.WriteLine("[ 2 ] No \n");
                }
            }
        }
    }
}
