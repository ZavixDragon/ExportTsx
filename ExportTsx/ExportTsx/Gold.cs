using System.IO;
using System.Xml.Linq;

namespace ExportTsx
{
    public class Gold
    {
        public Gold(string tsxPath, string destinationPath)
        {
            var doc = XDocument.Load(tsxPath);
            var tileset = doc.Element("tileset");
            var tsxDirectory = Path.GetDirectoryName(tsxPath);
            var image = tileset.Element("image");
            var imageSource = image.Attribute("source");
            var imagePath = Path.Combine(tsxDirectory, imageSource.Value);
            var imageName = Path.GetFileName(imageSource.Value);
            var imageDestination = Path.Combine(destinationPath, imageName);
            File.Copy(imagePath, imageDestination, true);
            imageSource.SetValue(imageName);
            var tsxDestination = Path.Combine(destinationPath, Path.GetFileName(tsxPath));
            doc.Save(tsxDestination);
        }
    }
}
