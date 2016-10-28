using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using Atalasoft.Imaging;
using Atalasoft.Imaging.Codec;

namespace AnyCpuDemo
{
    class Program
    {
        // Traditional "Atalasoft Red" color to use for drawing
        private static readonly Color AtalasoftRed = Color.FromArgb(196, 18, 48);
        // Bitness of the running process
        private static readonly string ProcessBitness = 
            Environment.Is64BitProcess ? "x64" : "x86";

        static Program()
        {
            // First we need to find the folder where calling assembly is located.
            // It could be a tricky task, especially considering IIS deployments 
            // with shadow copy feature enabled.
            var assemblyLocalPath = new Uri(Assembly.GetCallingAssembly().EscapedCodeBase).LocalPath;
            var callingAssemblyFolder = Path.GetDirectoryName(assemblyLocalPath);
            
            // Construct a path to folder where we keep architecture specific assemblies.
            var binFolder = Path.Combine(callingAssemblyFolder, ProcessBitness);

            // Hack to force .NET to accept assembly regardless
            AppDomain.CurrentDomain.AssemblyResolve +=
                (sender, args) => AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(
                    assembly => assembly.FullName.Contains(args.Name));

            // Explicitly load the assemblies 
            foreach (var assemblyFile in Directory.GetFiles(binFolder))
                Assembly.LoadFrom(assemblyFile);
        }

        static void Main(string[] args)
        {            
            // Create an empty image to start with
            const int imageSize = 500;
            var image = new AtalaImage(imageSize, imageSize, PixelFormat.Pixel24bppBgr, Color.White);

            // Draw a simple message on the image (using Atalasoft Red color!)
            using(var g = image.GetGraphics())
            using (var atalasoftBrush = new SolidBrush(AtalasoftRed))
            {
                // Funny message to draw on image
                var message = "Hello from " + ProcessBitness + " process!";
                var font = new Font(FontFamily.GenericSansSerif, 20);
                
                // Center text string and draw it!
                var messageSize = g.MeasureString(message, font);
                g.DrawString(message, font, atalasoftBrush, 
                    (imageSize - messageSize.Width) / 2,
                    (imageSize - messageSize.Height) / 2);
            }

            // Save the image into PNG file
            image.Save("hello.png", new PngEncoder(), null);
        }
    }
}
