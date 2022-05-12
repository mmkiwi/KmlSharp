using MMKiwi.KMLZipper.GUI.Core.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMKiwi.KMLZipper.Core.Services;
public sealed class TransformService
{
    public TransformService(TranformationProperties properties) => Properties = properties;

    public TranformationProperties Properties { get; }

    public string Tranform()
    {
        return $"""
<?xml version="1.0" encoding="UTF-8"?>
<kml xmlns="http://www.opengis.net/kml/2.2" xmlns:gx="http://www.google.com/kml/ext/2.2" xmlns:kml="http://www.opengis.net/kml/2.2" xmlns:atom="http://www.w3.org/2005/Atom">
	<Document>
		<name>{Properties.Title}</name>
		<Style id="s_ylw-pushpin_hl">
			<IconStyle>
				<scale>1.4</scale>
				<Icon>
					<href>icon.png</href>
				</Icon>
				<hotSpot x="32" y="32" xunits="pixels" yunits="pixels" />
			</IconStyle>
		</Style>
		<StyleMap id="m_ylw-pushpin">
			<Pair>
				<key>normal</key>
				<styleUrl>#s_ylw-pushpin</styleUrl>
			</Pair>
			<Pair>
				<key>highlight</key>
				<styleUrl>#s_ylw-pushpin_hl</styleUrl>
			</Pair>
		</StyleMap>
		<Style id="s_ylw-pushpin">
			<IconStyle>
				<scale>1.2</scale>
				<Icon>
					<href>icon.png</href>
				</Icon>
				<hotSpot x="32" y="1" xunits="pixels" yunits="pixels" />
			</IconStyle>
		</Style>
		{TranformItems()}
	</Document>
</kml>
""";
    }

    private object TranformItems() => string.Join("\n", Properties.Items.Select(item => TransformItem(item)));
	private string? TransformItem(TranformationItem item) => $"""
		<Placemark>
			<name>{item.FileName}</name>
			<description>
				<html xlmns="http://www.w3.org/1999/xhtml">
					<head>
						<link rel="stylesheet" href="style.css" />
						<meta name="viewport" content="width=device-width,initial-scale=1" />
					</head>
					<body>
						<p class="imgHolder">
								<img style="max-width:500px;" src="images/{item.FileName}" />
						</p>
						<p>
							{item.FilePath}
						</p>
						<table>
							<thead>
								<tr>
									<th>
										Field
									</th>
									<th>Value</th>
								</tr>
							</thead>
							<tbody>
							{TranformFields(item)}
							</tbody>
						</table>
					</body>
				</html>
			</description>
			<LookAt>
				<longitude>{item.Longitude}</longitude>
				<latitude>{item.Latitude}</latitude>
				<altitude>0</altitude>
				<heading>0</heading>
				<tilt>0</tilt>
				<range>{Properties.Range}</range>
				<gx:altitudeMode>relativeToSeaFloor</gx:altitudeMode>
			</LookAt>
			{ TransformOrientation(item) }
			<styleUrl>#m_ylw-pushpin</styleUrl>
			<Point>
				<gx:drawOrder>1</gx:drawOrder>
				<coordinates>{item.Longitude},{item.Latitude},0</coordinates>
			</Point>
		</Placemark>
""";
    private string TranformFields(TranformationItem item) => string.Join("\n", item.Fields.Select(field => TransformField(field)));
	private string TransformField(KeyValuePair<string, string> field) => $"""
								<tr>
									<th>{field.Key}</th>
									<td>{field.Value}</td>
								</tr>
""";
    private string TransformOrientation(TranformationItem item) => Properties.RotateIcons ? $"""
			<Style>
				<IconStyle>
					<heading>{item.Orientation}</heading>
				</IconStyle>
			</Style>
""" : string.Empty;
}
