using System.Collections.Generic;

namespace MMKiwi.KMZipper.GUI.Core.Models;

public sealed record KmzPhotoInfo(string FileName, string FilePath, double Longitude, double Latitude, double Orientation, Dictionary<string,string> Fields)
{
}