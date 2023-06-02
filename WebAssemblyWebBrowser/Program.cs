using System;
using System.IO;
using System.Runtime.InteropServices.JavaScript;
using ImageGeneratorLib;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

Console.WriteLine("Hello, Browser!");

public partial class MyClass
{
    [JSExport]
    internal static string Greeting()
    {
        var text = $"Hello, World! Greetings from {GetHRef()}";
        Console.WriteLine(text);
        return text;
    }

    [JSExport]
    internal static string GetOs()
    {
        return Generator.GetOs();
    }

    [JSExport]
    internal static string GetImageFromImageSharp()
    {
        var b64String = Generator.GetImageImageSharp();

        var img = "data:image/png;base64," + b64String;

        return img;
    }

    [JSExport]
    internal static string GetImageFromDrawingCommon()
    {
        var b64String = Generator.GetImage();

        var img = "data:image/png;base64," + b64String;

        return img;
    }

    [JSExport]
    internal static string GetRnd()
    {
        return Generator.GetRnd();
    }

    [JSImport("window.location.href", "main.js")]
    internal static partial string GetHRef();
}
