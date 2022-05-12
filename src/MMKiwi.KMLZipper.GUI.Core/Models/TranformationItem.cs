using System.Collections.Generic;

namespace MMKiwi.KMLZipper.GUI.Core.Models;

public sealed record TranformationItem(string FileName, string FilePath, double Longitude, double Latitude, double Orientation, Dictionary<string,string> Fields)
{
}