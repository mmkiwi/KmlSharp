﻿using System.Xml.Serialization;

[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("altitudeMode", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public enum altitudeModeEnumType {
    
    /// <remarks/>
    clampToGround,
    
    /// <remarks/>
    relativeToGround,
    
    /// <remarks/>
    absolute,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("colorMode", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public enum colorModeEnumType {
    
    /// <remarks/>
    normal,
    
    /// <remarks/>
    random,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("displayMode", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public enum displayModeEnumType {
    
    /// <remarks/>
    @default,
    
    /// <remarks/>
    hide,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("gridOrigin", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public enum gridOriginEnumType {
    
    /// <remarks/>
    lowerLeft,
    
    /// <remarks/>
    upperLeft,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("hotSpot", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class vec2Type {
    
    private double xField;
    
    private double yField;
    
    private unitsEnumType xunitsField;
    
    private unitsEnumType yunitsField;
    
    public vec2Type() {
        this.xField = 1D;
        this.yField = 1D;
        this.xunitsField = unitsEnumType.fraction;
        this.yunitsField = unitsEnumType.fraction;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(1D)]
    public double x {
        get {
            return this.xField;
        }
        set {
            this.xField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(1D)]
    public double y {
        get {
            return this.yField;
        }
        set {
            this.yField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(unitsEnumType.fraction)]
    public unitsEnumType xunits {
        get {
            return this.xunitsField;
        }
        set {
            this.xunitsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(unitsEnumType.fraction)]
    public unitsEnumType yunits {
        get {
            return this.yunitsField;
        }
        set {
            this.yunitsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
public enum unitsEnumType {
    
    /// <remarks/>
    fraction,
    
    /// <remarks/>
    pixels,
    
    /// <remarks/>
    insetPixels,
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ImagePyramidType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ViewVolumeType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(SchemaDataType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AliasType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ResourceMapType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ScaleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(OrientationType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LocationType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractGeometryType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ModelType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LinearRingType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(MultiGeometryType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(DataType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LodType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractLatLonBoxType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LatLonBoxType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LatLonAltBoxType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(RegionType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(PairType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ItemIconType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(BasicLinkType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractSubStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ListStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(BalloonStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractColorStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(PolyStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LabelStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(IconStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractStyleSelectorType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(StyleMapType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(StyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractTimePrimitiveType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(TimeSpanType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(TimeStampType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractViewType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(CameraType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LookAtType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractFeatureType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractOverlayType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(PhotoOverlayType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ScreenOverlayType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundOverlayType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(NetworkLinkType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(PlacemarkType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractContainerType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(FolderType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(DocumentType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
public abstract partial class AbstractObjectType {
    
    private string[] objectSimpleExtensionGroupField;
    
    private string idField;
    
    private string targetIdField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ObjectSimpleExtensionGroup")]
    public string[] ObjectSimpleExtensionGroup {
        get {
            return this.objectSimpleExtensionGroupField;
        }
        set {
            this.objectSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="ID")]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NCName")]
    public string targetId {
        get {
            return this.targetIdField;
        }
        set {
            this.targetIdField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ModelType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(PolygonType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LinearRingType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(MultiGeometryType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
public abstract partial class AbstractGeometryType : AbstractObjectType {
    
    private string[] abstractGeometrySimpleExtensionGroupField;
    
    private AbstractObjectType[] abstractGeometryObjectExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractGeometrySimpleExtensionGroup")]
    public string[] AbstractGeometrySimpleExtensionGroup {
        get {
            return this.abstractGeometrySimpleExtensionGroupField;
        }
        set {
            this.abstractGeometrySimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractGeometryObjectExtensionGroup")]
    public AbstractObjectType[] AbstractGeometryObjectExtensionGroup {
        get {
            return this.abstractGeometryObjectExtensionGroupField;
        }
        set {
            this.abstractGeometryObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LatLonBoxType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LatLonAltBoxType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
public abstract partial class AbstractLatLonBoxType : AbstractObjectType {
    
    private double northField;
    
    private bool northFieldSpecified;
    
    private double southField;
    
    private bool southFieldSpecified;
    
    private double eastField;
    
    private bool eastFieldSpecified;
    
    private double westField;
    
    private bool westFieldSpecified;
    
    private string[] abstractLatLonBoxSimpleExtensionGroupField;
    
    private AbstractObjectType[] abstractLatLonBoxObjectExtensionGroupField;
    
    public AbstractLatLonBoxType() {
        this.northField = 180D;
        this.southField = -180D;
        this.eastField = 180D;
        this.westField = -180D;
    }
    
    /// <remarks/>
    public double north {
        get {
            return this.northField;
        }
        set {
            this.northField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool northSpecified {
        get {
            return this.northFieldSpecified;
        }
        set {
            this.northFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double south {
        get {
            return this.southField;
        }
        set {
            this.southField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool southSpecified {
        get {
            return this.southFieldSpecified;
        }
        set {
            this.southFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double east {
        get {
            return this.eastField;
        }
        set {
            this.eastField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool eastSpecified {
        get {
            return this.eastFieldSpecified;
        }
        set {
            this.eastFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double west {
        get {
            return this.westField;
        }
        set {
            this.westField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool westSpecified {
        get {
            return this.westFieldSpecified;
        }
        set {
            this.westFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractLatLonBoxSimpleExtensionGroup")]
    public string[] AbstractLatLonBoxSimpleExtensionGroup {
        get {
            return this.abstractLatLonBoxSimpleExtensionGroupField;
        }
        set {
            this.abstractLatLonBoxSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractLatLonBoxObjectExtensionGroup")]
    public AbstractObjectType[] AbstractLatLonBoxObjectExtensionGroup {
        get {
            return this.abstractLatLonBoxObjectExtensionGroupField;
        }
        set {
            this.abstractLatLonBoxObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LinkType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
public partial class BasicLinkType : AbstractObjectType {
    
    private string hrefField;
    
    private string[] basicLinkSimpleExtensionGroupField;
    
    private AbstractObjectType[] basicLinkObjectExtensionGroupField;
    
    /// <remarks/>
    public string href {
        get {
            return this.hrefField;
        }
        set {
            this.hrefField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("BasicLinkSimpleExtensionGroup")]
    public string[] BasicLinkSimpleExtensionGroup {
        get {
            return this.basicLinkSimpleExtensionGroupField;
        }
        set {
            this.basicLinkSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("BasicLinkObjectExtensionGroup")]
    public AbstractObjectType[] BasicLinkObjectExtensionGroup {
        get {
            return this.basicLinkObjectExtensionGroupField;
        }
        set {
            this.basicLinkObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ListStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(BalloonStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractColorStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(PolyStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LabelStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(IconStyleType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
public abstract partial class AbstractSubStyleType : AbstractObjectType {
    
    private string[] abstractSubStyleSimpleExtensionGroupField;
    
    private AbstractObjectType[] abstractSubStyleObjectExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractSubStyleSimpleExtensionGroup")]
    public string[] AbstractSubStyleSimpleExtensionGroup {
        get {
            return this.abstractSubStyleSimpleExtensionGroupField;
        }
        set {
            this.abstractSubStyleSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractSubStyleObjectExtensionGroup")]
    public AbstractObjectType[] AbstractSubStyleObjectExtensionGroup {
        get {
            return this.abstractSubStyleObjectExtensionGroupField;
        }
        set {
            this.abstractSubStyleObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(PolyStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LabelStyleType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(IconStyleType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
public abstract partial class AbstractColorStyleType : AbstractSubStyleType {
    
    private byte[] colorField;
    
    private colorModeEnumType colorModeField;
    
    private bool colorModeFieldSpecified;
    
    private string[] abstractColorStyleSimpleExtensionGroupField;
    
    private AbstractObjectType[] abstractColorStyleObjectExtensionGroupField;
    
    public AbstractColorStyleType() {
        this.colorModeField = colorModeEnumType.normal;
    }
    
    /// <remarks/>
    // CODEGEN Warning: 'default' attribute on items of type 'hexBinary' is not supported in this version of the .Net Framework.  Ignoring default='ffffffff' attribute.
    [System.Xml.Serialization.XmlElementAttribute(DataType="hexBinary")]
    public byte[] color {
        get {
            return this.colorField;
        }
        set {
            this.colorField = value;
        }
    }
    
    /// <remarks/>
    public colorModeEnumType colorMode {
        get {
            return this.colorModeField;
        }
        set {
            this.colorModeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool colorModeSpecified {
        get {
            return this.colorModeFieldSpecified;
        }
        set {
            this.colorModeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractColorStyleSimpleExtensionGroup")]
    public string[] AbstractColorStyleSimpleExtensionGroup {
        get {
            return this.abstractColorStyleSimpleExtensionGroupField;
        }
        set {
            this.abstractColorStyleSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractColorStyleObjectExtensionGroup")]
    public AbstractObjectType[] AbstractColorStyleObjectExtensionGroup {
        get {
            return this.abstractColorStyleObjectExtensionGroupField;
        }
        set {
            this.abstractColorStyleObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(StyleMapType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(StyleType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
public abstract partial class AbstractStyleSelectorType : AbstractObjectType {
    
    private string[] abstractStyleSelectorSimpleExtensionGroupField;
    
    private AbstractObjectType[] abstractStyleSelectorObjectExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractStyleSelectorSimpleExtensionGroup")]
    public string[] AbstractStyleSelectorSimpleExtensionGroup {
        get {
            return this.abstractStyleSelectorSimpleExtensionGroupField;
        }
        set {
            this.abstractStyleSelectorSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractStyleSelectorObjectExtensionGroup")]
    public AbstractObjectType[] AbstractStyleSelectorObjectExtensionGroup {
        get {
            return this.abstractStyleSelectorObjectExtensionGroupField;
        }
        set {
            this.abstractStyleSelectorObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(TimeSpanType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(TimeStampType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
public abstract partial class AbstractTimePrimitiveType : AbstractObjectType {
    
    private string[] abstractTimePrimitiveSimpleExtensionGroupField;
    
    private AbstractObjectType[] abstractTimePrimitiveObjectExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractTimePrimitiveSimpleExtensionGroup")]
    public string[] AbstractTimePrimitiveSimpleExtensionGroup {
        get {
            return this.abstractTimePrimitiveSimpleExtensionGroupField;
        }
        set {
            this.abstractTimePrimitiveSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractTimePrimitiveObjectExtensionGroup")]
    public AbstractObjectType[] AbstractTimePrimitiveObjectExtensionGroup {
        get {
            return this.abstractTimePrimitiveObjectExtensionGroupField;
        }
        set {
            this.abstractTimePrimitiveObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(CameraType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(LookAtType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
public abstract partial class AbstractViewType : AbstractObjectType {
    
    private string[] abstractViewSimpleExtensionGroupField;
    
    private AbstractObjectType[] abstractViewObjectExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractViewSimpleExtensionGroup")]
    public string[] AbstractViewSimpleExtensionGroup {
        get {
            return this.abstractViewSimpleExtensionGroupField;
        }
        set {
            this.abstractViewSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractViewObjectExtensionGroup")]
    public AbstractObjectType[] AbstractViewObjectExtensionGroup {
        get {
            return this.abstractViewObjectExtensionGroupField;
        }
        set {
            this.abstractViewObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractOverlayType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(PhotoOverlayType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ScreenOverlayType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundOverlayType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(NetworkLinkType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(PlacemarkType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractContainerType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(FolderType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(DocumentType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
public abstract partial class AbstractFeatureType : AbstractObjectType {
    
    private string nameField;
    
    private bool visibilityField;
    
    private bool visibilityFieldSpecified;
    
    private bool openField;
    
    private bool openFieldSpecified;
    
    private string addressField;
    
    private string phoneNumberField;
    
    private object itemField;
    
    private string descriptionField;
    
    private AbstractViewType item1Field;
    
    private AbstractTimePrimitiveType item2Field;
    
    private string styleUrlField;
    
    private AbstractStyleSelectorType[] itemsField;
    
    private RegionType regionField;
    
    private object item3Field;
    
    private string[] abstractFeatureSimpleExtensionGroupField;
    
    private AbstractObjectType[] abstractFeatureObjectExtensionGroupField;
    
    public AbstractFeatureType() {
        this.visibilityField = true;
        this.openField = false;
    }
    
    /// <remarks/>
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public bool visibility {
        get {
            return this.visibilityField;
        }
        set {
            this.visibilityField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool visibilitySpecified {
        get {
            return this.visibilityFieldSpecified;
        }
        set {
            this.visibilityFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public bool open {
        get {
            return this.openField;
        }
        set {
            this.openField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool openSpecified {
        get {
            return this.openFieldSpecified;
        }
        set {
            this.openFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string address {
        get {
            return this.addressField;
        }
        set {
            this.addressField = value;
        }
    }
    
    /// <remarks/>
    public string phoneNumber {
        get {
            return this.phoneNumberField;
        }
        set {
            this.phoneNumberField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Snippet", typeof(SnippetType))]
    [System.Xml.Serialization.XmlElementAttribute("snippet", typeof(string))]
    public object Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    public string description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Camera", typeof(CameraType))]
    [System.Xml.Serialization.XmlElementAttribute("LookAt", typeof(LookAtType))]
    public AbstractViewType Item1 {
        get {
            return this.item1Field;
        }
        set {
            this.item1Field = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TimeSpan", typeof(TimeSpanType))]
    [System.Xml.Serialization.XmlElementAttribute("TimeStamp", typeof(TimeStampType))]
    public AbstractTimePrimitiveType Item2 {
        get {
            return this.item2Field;
        }
        set {
            this.item2Field = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
    public string styleUrl {
        get {
            return this.styleUrlField;
        }
        set {
            this.styleUrlField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Style", typeof(StyleType))]
    [System.Xml.Serialization.XmlElementAttribute("StyleMap", typeof(StyleMapType))]
    public AbstractStyleSelectorType[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    public RegionType Region {
        get {
            return this.regionField;
        }
        set {
            this.regionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ExtendedData", typeof(ExtendedDataType))]
    [System.Xml.Serialization.XmlElementAttribute("Metadata", typeof(MetadataType))]
    public object Item3 {
        get {
            return this.item3Field;
        }
        set {
            this.item3Field = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractFeatureSimpleExtensionGroup")]
    public string[] AbstractFeatureSimpleExtensionGroup {
        get {
            return this.abstractFeatureSimpleExtensionGroupField;
        }
        set {
            this.abstractFeatureSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractFeatureObjectExtensionGroup")]
    public AbstractObjectType[] AbstractFeatureObjectExtensionGroup {
        get {
            return this.abstractFeatureObjectExtensionGroupField;
        }
        set {
            this.abstractFeatureObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("linkSnippet", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class SnippetType {
    
    private int maxLinesField;
    
    private string valueField;
    
    public SnippetType() {
        this.maxLinesField = 2;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute(2)]
    public int maxLines {
        get {
            return this.maxLinesField;
        }
        set {
            this.maxLinesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Camera", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class CameraType : AbstractViewType {
    
    private double longitudeField;
    
    private bool longitudeFieldSpecified;
    
    private double latitudeField;
    
    private bool latitudeFieldSpecified;
    
    private double altitudeField;
    
    private bool altitudeFieldSpecified;
    
    private double headingField;
    
    private bool headingFieldSpecified;
    
    private double tiltField;
    
    private bool tiltFieldSpecified;
    
    private double rollField;
    
    private bool rollFieldSpecified;
    
    private altitudeModeEnumType itemField;
    
    private string[] cameraSimpleExtensionGroupField;
    
    private AbstractObjectType[] cameraObjectExtensionGroupField;
    
    public CameraType() {
        this.longitudeField = 0D;
        this.latitudeField = 0D;
        this.altitudeField = 0D;
        this.headingField = 0D;
        this.tiltField = 0D;
        this.rollField = 0D;
        this.itemField = altitudeModeEnumType.clampToGround;
    }
    
    /// <remarks/>
    public double longitude {
        get {
            return this.longitudeField;
        }
        set {
            this.longitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool longitudeSpecified {
        get {
            return this.longitudeFieldSpecified;
        }
        set {
            this.longitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double latitude {
        get {
            return this.latitudeField;
        }
        set {
            this.latitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool latitudeSpecified {
        get {
            return this.latitudeFieldSpecified;
        }
        set {
            this.latitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double altitude {
        get {
            return this.altitudeField;
        }
        set {
            this.altitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool altitudeSpecified {
        get {
            return this.altitudeFieldSpecified;
        }
        set {
            this.altitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double heading {
        get {
            return this.headingField;
        }
        set {
            this.headingField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool headingSpecified {
        get {
            return this.headingFieldSpecified;
        }
        set {
            this.headingFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double tilt {
        get {
            return this.tiltField;
        }
        set {
            this.tiltField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool tiltSpecified {
        get {
            return this.tiltFieldSpecified;
        }
        set {
            this.tiltFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double roll {
        get {
            return this.rollField;
        }
        set {
            this.rollField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool rollSpecified {
        get {
            return this.rollFieldSpecified;
        }
        set {
            this.rollFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("altitudeMode")]
    public altitudeModeEnumType Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CameraSimpleExtensionGroup")]
    public string[] CameraSimpleExtensionGroup {
        get {
            return this.cameraSimpleExtensionGroupField;
        }
        set {
            this.cameraSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CameraObjectExtensionGroup")]
    public AbstractObjectType[] CameraObjectExtensionGroup {
        get {
            return this.cameraObjectExtensionGroupField;
        }
        set {
            this.cameraObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("LookAt", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class LookAtType : AbstractViewType {
    
    private double longitudeField;
    
    private bool longitudeFieldSpecified;
    
    private double latitudeField;
    
    private bool latitudeFieldSpecified;
    
    private double altitudeField;
    
    private bool altitudeFieldSpecified;
    
    private double headingField;
    
    private bool headingFieldSpecified;
    
    private double tiltField;
    
    private bool tiltFieldSpecified;
    
    private double rangeField;
    
    private bool rangeFieldSpecified;
    
    private altitudeModeEnumType itemField;
    
    private string[] lookAtSimpleExtensionGroupField;
    
    private AbstractObjectType[] lookAtObjectExtensionGroupField;
    
    public LookAtType() {
        this.longitudeField = 0D;
        this.latitudeField = 0D;
        this.altitudeField = 0D;
        this.headingField = 0D;
        this.tiltField = 0D;
        this.rangeField = 0D;
        this.itemField = altitudeModeEnumType.clampToGround;
    }
    
    /// <remarks/>
    public double longitude {
        get {
            return this.longitudeField;
        }
        set {
            this.longitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool longitudeSpecified {
        get {
            return this.longitudeFieldSpecified;
        }
        set {
            this.longitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double latitude {
        get {
            return this.latitudeField;
        }
        set {
            this.latitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool latitudeSpecified {
        get {
            return this.latitudeFieldSpecified;
        }
        set {
            this.latitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double altitude {
        get {
            return this.altitudeField;
        }
        set {
            this.altitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool altitudeSpecified {
        get {
            return this.altitudeFieldSpecified;
        }
        set {
            this.altitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double heading {
        get {
            return this.headingField;
        }
        set {
            this.headingField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool headingSpecified {
        get {
            return this.headingFieldSpecified;
        }
        set {
            this.headingFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double tilt {
        get {
            return this.tiltField;
        }
        set {
            this.tiltField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool tiltSpecified {
        get {
            return this.tiltFieldSpecified;
        }
        set {
            this.tiltFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double range {
        get {
            return this.rangeField;
        }
        set {
            this.rangeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool rangeSpecified {
        get {
            return this.rangeFieldSpecified;
        }
        set {
            this.rangeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("altitudeMode")]
    public altitudeModeEnumType Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LookAtSimpleExtensionGroup")]
    public string[] LookAtSimpleExtensionGroup {
        get {
            return this.lookAtSimpleExtensionGroupField;
        }
        set {
            this.lookAtSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LookAtObjectExtensionGroup")]
    public AbstractObjectType[] LookAtObjectExtensionGroup {
        get {
            return this.lookAtObjectExtensionGroupField;
        }
        set {
            this.lookAtObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("TimeSpan", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class TimeSpanType : AbstractTimePrimitiveType {
    
    private string beginField;
    
    private string endField;
    
    private string[] timeSpanSimpleExtensionGroupField;
    
    private AbstractObjectType[] timeSpanObjectExtensionGroupField;
    
    /// <remarks/>
    public string begin {
        get {
            return this.beginField;
        }
        set {
            this.beginField = value;
        }
    }
    
    /// <remarks/>
    public string end {
        get {
            return this.endField;
        }
        set {
            this.endField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TimeSpanSimpleExtensionGroup")]
    public string[] TimeSpanSimpleExtensionGroup {
        get {
            return this.timeSpanSimpleExtensionGroupField;
        }
        set {
            this.timeSpanSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TimeSpanObjectExtensionGroup")]
    public AbstractObjectType[] TimeSpanObjectExtensionGroup {
        get {
            return this.timeSpanObjectExtensionGroupField;
        }
        set {
            this.timeSpanObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("TimeStamp", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class TimeStampType : AbstractTimePrimitiveType {
    
    private string whenField;
    
    private string[] timeStampSimpleExtensionGroupField;
    
    private AbstractObjectType[] timeStampObjectExtensionGroupField;
    
    /// <remarks/>
    public string when {
        get {
            return this.whenField;
        }
        set {
            this.whenField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TimeStampSimpleExtensionGroup")]
    public string[] TimeStampSimpleExtensionGroup {
        get {
            return this.timeStampSimpleExtensionGroupField;
        }
        set {
            this.timeStampSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TimeStampObjectExtensionGroup")]
    public AbstractObjectType[] TimeStampObjectExtensionGroup {
        get {
            return this.timeStampObjectExtensionGroupField;
        }
        set {
            this.timeStampObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Style", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class StyleType : AbstractStyleSelectorType {
    
    private IconStyleType iconStyleField;
    
    private LabelStyleType labelStyleField;
    
    private LineStyleType lineStyleField;
    
    private PolyStyleType polyStyleField;
    
    private BalloonStyleType balloonStyleField;
    
    private ListStyleType listStyleField;
    
    private string[] styleSimpleExtensionGroupField;
    
    private AbstractObjectType[] styleObjectExtensionGroupField;
    
    /// <remarks/>
    public IconStyleType IconStyle {
        get {
            return this.iconStyleField;
        }
        set {
            this.iconStyleField = value;
        }
    }
    
    /// <remarks/>
    public LabelStyleType LabelStyle {
        get {
            return this.labelStyleField;
        }
        set {
            this.labelStyleField = value;
        }
    }
    
    /// <remarks/>
    public LineStyleType LineStyle {
        get {
            return this.lineStyleField;
        }
        set {
            this.lineStyleField = value;
        }
    }
    
    /// <remarks/>
    public PolyStyleType PolyStyle {
        get {
            return this.polyStyleField;
        }
        set {
            this.polyStyleField = value;
        }
    }
    
    /// <remarks/>
    public BalloonStyleType BalloonStyle {
        get {
            return this.balloonStyleField;
        }
        set {
            this.balloonStyleField = value;
        }
    }
    
    /// <remarks/>
    public ListStyleType ListStyle {
        get {
            return this.listStyleField;
        }
        set {
            this.listStyleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("StyleSimpleExtensionGroup")]
    public string[] StyleSimpleExtensionGroup {
        get {
            return this.styleSimpleExtensionGroupField;
        }
        set {
            this.styleSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("StyleObjectExtensionGroup")]
    public AbstractObjectType[] StyleObjectExtensionGroup {
        get {
            return this.styleObjectExtensionGroupField;
        }
        set {
            this.styleObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("IconStyle", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class IconStyleType : AbstractColorStyleType {
    
    private double scaleField;
    
    private bool scaleFieldSpecified;
    
    private double headingField;
    
    private bool headingFieldSpecified;
    
    private BasicLinkType iconField;
    
    private vec2Type hotSpotField;
    
    private string[] iconStyleSimpleExtensionGroupField;
    
    private AbstractObjectType[] iconStyleObjectExtensionGroupField;
    
    public IconStyleType() {
        this.scaleField = 1D;
        this.headingField = 0D;
    }
    
    /// <remarks/>
    public double scale {
        get {
            return this.scaleField;
        }
        set {
            this.scaleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool scaleSpecified {
        get {
            return this.scaleFieldSpecified;
        }
        set {
            this.scaleFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double heading {
        get {
            return this.headingField;
        }
        set {
            this.headingField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool headingSpecified {
        get {
            return this.headingFieldSpecified;
        }
        set {
            this.headingFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public BasicLinkType Icon {
        get {
            return this.iconField;
        }
        set {
            this.iconField = value;
        }
    }
    
    /// <remarks/>
    public vec2Type hotSpot {
        get {
            return this.hotSpotField;
        }
        set {
            this.hotSpotField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("IconStyleSimpleExtensionGroup")]
    public string[] IconStyleSimpleExtensionGroup {
        get {
            return this.iconStyleSimpleExtensionGroupField;
        }
        set {
            this.iconStyleSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("IconStyleObjectExtensionGroup")]
    public AbstractObjectType[] IconStyleObjectExtensionGroup {
        get {
            return this.iconStyleObjectExtensionGroupField;
        }
        set {
            this.iconStyleObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("LabelStyle", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class LabelStyleType : AbstractColorStyleType {
    
    private double scaleField;
    
    private bool scaleFieldSpecified;
    
    private string[] labelStyleSimpleExtensionGroupField;
    
    private AbstractObjectType[] labelStyleObjectExtensionGroupField;
    
    public LabelStyleType() {
        this.scaleField = 1D;
    }
    
    /// <remarks/>
    public double scale {
        get {
            return this.scaleField;
        }
        set {
            this.scaleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool scaleSpecified {
        get {
            return this.scaleFieldSpecified;
        }
        set {
            this.scaleFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LabelStyleSimpleExtensionGroup")]
    public string[] LabelStyleSimpleExtensionGroup {
        get {
            return this.labelStyleSimpleExtensionGroupField;
        }
        set {
            this.labelStyleSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LabelStyleObjectExtensionGroup")]
    public AbstractObjectType[] LabelStyleObjectExtensionGroup {
        get {
            return this.labelStyleObjectExtensionGroupField;
        }
        set {
            this.labelStyleObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("LineStyle", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class LineStyleType : AbstractColorStyleType {
    
    private double widthField;
    
    private bool widthFieldSpecified;
    
    private string[] lineStyleSimpleExtensionGroupField;
    
    private AbstractObjectType[] lineStyleObjectExtensionGroupField;
    
    public LineStyleType() {
        this.widthField = 1D;
    }
    
    /// <remarks/>
    public double width {
        get {
            return this.widthField;
        }
        set {
            this.widthField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool widthSpecified {
        get {
            return this.widthFieldSpecified;
        }
        set {
            this.widthFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LineStyleSimpleExtensionGroup")]
    public string[] LineStyleSimpleExtensionGroup {
        get {
            return this.lineStyleSimpleExtensionGroupField;
        }
        set {
            this.lineStyleSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LineStyleObjectExtensionGroup")]
    public AbstractObjectType[] LineStyleObjectExtensionGroup {
        get {
            return this.lineStyleObjectExtensionGroupField;
        }
        set {
            this.lineStyleObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("PolyStyle", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class PolyStyleType : AbstractColorStyleType {
    
    private bool fillField;
    
    private bool fillFieldSpecified;
    
    private bool outlineField;
    
    private bool outlineFieldSpecified;
    
    private string[] polyStyleSimpleExtensionGroupField;
    
    private AbstractObjectType[] polyStyleObjectExtensionGroupField;
    
    public PolyStyleType() {
        this.fillField = true;
        this.outlineField = true;
    }
    
    /// <remarks/>
    public bool fill {
        get {
            return this.fillField;
        }
        set {
            this.fillField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool fillSpecified {
        get {
            return this.fillFieldSpecified;
        }
        set {
            this.fillFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public bool outline {
        get {
            return this.outlineField;
        }
        set {
            this.outlineField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool outlineSpecified {
        get {
            return this.outlineFieldSpecified;
        }
        set {
            this.outlineFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PolyStyleSimpleExtensionGroup")]
    public string[] PolyStyleSimpleExtensionGroup {
        get {
            return this.polyStyleSimpleExtensionGroupField;
        }
        set {
            this.polyStyleSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PolyStyleObjectExtensionGroup")]
    public AbstractObjectType[] PolyStyleObjectExtensionGroup {
        get {
            return this.polyStyleObjectExtensionGroupField;
        }
        set {
            this.polyStyleObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("BalloonStyle", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class BalloonStyleType : AbstractSubStyleType {
    
    private byte[] itemField;
    
    private ItemChoiceType itemElementNameField;
    
    private byte[] textColorField;
    
    private string textField;
    
    private displayModeEnumType displayModeField;
    
    private bool displayModeFieldSpecified;
    
    private string[] balloonStyleSimpleExtensionGroupField;
    
    private AbstractObjectType[] balloonStyleObjectExtensionGroupField;
    
    public BalloonStyleType() {
        this.displayModeField = displayModeEnumType.@default;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("bgColor", typeof(byte[]), DataType="hexBinary")]
    [System.Xml.Serialization.XmlElementAttribute("color", typeof(byte[]), DataType="hexBinary")]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
    public byte[] Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemChoiceType ItemElementName {
        get {
            return this.itemElementNameField;
        }
        set {
            this.itemElementNameField = value;
        }
    }
    
    /// <remarks/>
    // CODEGEN Warning: 'default' attribute on items of type 'hexBinary' is not supported in this version of the .Net Framework.  Ignoring default='ff000000' attribute.
    [System.Xml.Serialization.XmlElementAttribute(DataType="hexBinary")]
    public byte[] textColor {
        get {
            return this.textColorField;
        }
        set {
            this.textColorField = value;
        }
    }
    
    /// <remarks/>
    public string text {
        get {
            return this.textField;
        }
        set {
            this.textField = value;
        }
    }
    
    /// <remarks/>
    public displayModeEnumType displayMode {
        get {
            return this.displayModeField;
        }
        set {
            this.displayModeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool displayModeSpecified {
        get {
            return this.displayModeFieldSpecified;
        }
        set {
            this.displayModeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("BalloonStyleSimpleExtensionGroup")]
    public string[] BalloonStyleSimpleExtensionGroup {
        get {
            return this.balloonStyleSimpleExtensionGroupField;
        }
        set {
            this.balloonStyleSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("BalloonStyleObjectExtensionGroup")]
    public AbstractObjectType[] BalloonStyleObjectExtensionGroup {
        get {
            return this.balloonStyleObjectExtensionGroupField;
        }
        set {
            this.balloonStyleObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2", IncludeInSchema=false)]
public enum ItemChoiceType {
    
    /// <remarks/>
    bgColor,
    
    /// <remarks/>
    color,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("ListStyle", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class ListStyleType : AbstractSubStyleType {
    
    private listItemTypeEnumType listItemTypeField;
    
    private bool listItemTypeFieldSpecified;
    
    private byte[] bgColorField;
    
    private ItemIconType[] itemIconField;
    
    private int maxSnippetLinesField;
    
    private bool maxSnippetLinesFieldSpecified;
    
    private string[] listStyleSimpleExtensionGroupField;
    
    private AbstractObjectType[] listStyleObjectExtensionGroupField;
    
    public ListStyleType() {
        this.listItemTypeField = listItemTypeEnumType.check;
        this.maxSnippetLinesField = 2;
    }
    
    /// <remarks/>
    public listItemTypeEnumType listItemType {
        get {
            return this.listItemTypeField;
        }
        set {
            this.listItemTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool listItemTypeSpecified {
        get {
            return this.listItemTypeFieldSpecified;
        }
        set {
            this.listItemTypeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    // CODEGEN Warning: 'default' attribute on items of type 'hexBinary' is not supported in this version of the .Net Framework.  Ignoring default='ffffffff' attribute.
    [System.Xml.Serialization.XmlElementAttribute(DataType="hexBinary")]
    public byte[] bgColor {
        get {
            return this.bgColorField;
        }
        set {
            this.bgColorField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemIcon")]
    public ItemIconType[] ItemIcon {
        get {
            return this.itemIconField;
        }
        set {
            this.itemIconField = value;
        }
    }
    
    /// <remarks/>
    public int maxSnippetLines {
        get {
            return this.maxSnippetLinesField;
        }
        set {
            this.maxSnippetLinesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool maxSnippetLinesSpecified {
        get {
            return this.maxSnippetLinesFieldSpecified;
        }
        set {
            this.maxSnippetLinesFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ListStyleSimpleExtensionGroup")]
    public string[] ListStyleSimpleExtensionGroup {
        get {
            return this.listStyleSimpleExtensionGroupField;
        }
        set {
            this.listStyleSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ListStyleObjectExtensionGroup")]
    public AbstractObjectType[] ListStyleObjectExtensionGroup {
        get {
            return this.listStyleObjectExtensionGroupField;
        }
        set {
            this.listStyleObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("listItemType", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public enum listItemTypeEnumType {
    
    /// <remarks/>
    radioFolder,
    
    /// <remarks/>
    check,
    
    /// <remarks/>
    checkHideChildren,
    
    /// <remarks/>
    checkOffOnly,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("ItemIcon", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class ItemIconType : AbstractObjectType {
    
    private string stateField;
    
    private string hrefField;
    
    private string[] itemIconSimpleExtensionGroupField;
    
    private AbstractObjectType[] itemIconObjectExtensionGroupField;
    
    /// <remarks/>
    public string state {
        get {
            return this.stateField;
        }
        set {
            this.stateField = value;
        }
    }
    
    /// <remarks/>
    public string href {
        get {
            return this.hrefField;
        }
        set {
            this.hrefField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemIconSimpleExtensionGroup")]
    public string[] ItemIconSimpleExtensionGroup {
        get {
            return this.itemIconSimpleExtensionGroupField;
        }
        set {
            this.itemIconSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemIconObjectExtensionGroup")]
    public AbstractObjectType[] ItemIconObjectExtensionGroup {
        get {
            return this.itemIconObjectExtensionGroupField;
        }
        set {
            this.itemIconObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("StyleMap", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class StyleMapType : AbstractStyleSelectorType {
    
    private PairType[] pairField;
    
    private string[] styleMapSimpleExtensionGroupField;
    
    private AbstractObjectType[] styleMapObjectExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Pair")]
    public PairType[] Pair {
        get {
            return this.pairField;
        }
        set {
            this.pairField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("StyleMapSimpleExtensionGroup")]
    public string[] StyleMapSimpleExtensionGroup {
        get {
            return this.styleMapSimpleExtensionGroupField;
        }
        set {
            this.styleMapSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("StyleMapObjectExtensionGroup")]
    public AbstractObjectType[] StyleMapObjectExtensionGroup {
        get {
            return this.styleMapObjectExtensionGroupField;
        }
        set {
            this.styleMapObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Pair", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class PairType : AbstractObjectType {
    
    private styleStateEnumType keyField;
    
    private bool keyFieldSpecified;
    
    private string styleUrlField;
    
    private AbstractStyleSelectorType itemField;
    
    private string[] pairSimpleExtensionGroupField;
    
    private AbstractObjectType[] pairObjectExtensionGroupField;
    
    public PairType() {
        this.keyField = styleStateEnumType.normal;
    }
    
    /// <remarks/>
    public styleStateEnumType key {
        get {
            return this.keyField;
        }
        set {
            this.keyField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool keySpecified {
        get {
            return this.keyFieldSpecified;
        }
        set {
            this.keyFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
    public string styleUrl {
        get {
            return this.styleUrlField;
        }
        set {
            this.styleUrlField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Style", typeof(StyleType))]
    [System.Xml.Serialization.XmlElementAttribute("StyleMap", typeof(StyleMapType))]
    public AbstractStyleSelectorType Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PairSimpleExtensionGroup")]
    public string[] PairSimpleExtensionGroup {
        get {
            return this.pairSimpleExtensionGroupField;
        }
        set {
            this.pairSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PairObjectExtensionGroup")]
    public AbstractObjectType[] PairObjectExtensionGroup {
        get {
            return this.pairObjectExtensionGroupField;
        }
        set {
            this.pairObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("key", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public enum styleStateEnumType {
    
    /// <remarks/>
    normal,
    
    /// <remarks/>
    highlight,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Region", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class RegionType : AbstractObjectType {
    
    private LatLonAltBoxType latLonAltBoxField;
    
    private LodType lodField;
    
    private string[] regionSimpleExtensionGroupField;
    
    private AbstractObjectType[] regionObjectExtensionGroupField;
    
    /// <remarks/>
    public LatLonAltBoxType LatLonAltBox {
        get {
            return this.latLonAltBoxField;
        }
        set {
            this.latLonAltBoxField = value;
        }
    }
    
    /// <remarks/>
    public LodType Lod {
        get {
            return this.lodField;
        }
        set {
            this.lodField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RegionSimpleExtensionGroup")]
    public string[] RegionSimpleExtensionGroup {
        get {
            return this.regionSimpleExtensionGroupField;
        }
        set {
            this.regionSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RegionObjectExtensionGroup")]
    public AbstractObjectType[] RegionObjectExtensionGroup {
        get {
            return this.regionObjectExtensionGroupField;
        }
        set {
            this.regionObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("LatLonAltBox", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class LatLonAltBoxType : AbstractLatLonBoxType {
    
    private double minAltitudeField;
    
    private bool minAltitudeFieldSpecified;
    
    private double maxAltitudeField;
    
    private bool maxAltitudeFieldSpecified;
    
    private altitudeModeEnumType itemField;
    
    private string[] latLonAltBoxSimpleExtensionGroupField;
    
    private AbstractObjectType[] latLonAltBoxObjectExtensionGroupField;
    
    public LatLonAltBoxType() {
        this.minAltitudeField = 0D;
        this.maxAltitudeField = 0D;
        this.itemField = altitudeModeEnumType.clampToGround;
    }
    
    /// <remarks/>
    public double minAltitude {
        get {
            return this.minAltitudeField;
        }
        set {
            this.minAltitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool minAltitudeSpecified {
        get {
            return this.minAltitudeFieldSpecified;
        }
        set {
            this.minAltitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double maxAltitude {
        get {
            return this.maxAltitudeField;
        }
        set {
            this.maxAltitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool maxAltitudeSpecified {
        get {
            return this.maxAltitudeFieldSpecified;
        }
        set {
            this.maxAltitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("altitudeMode")]
    public altitudeModeEnumType Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LatLonAltBoxSimpleExtensionGroup")]
    public string[] LatLonAltBoxSimpleExtensionGroup {
        get {
            return this.latLonAltBoxSimpleExtensionGroupField;
        }
        set {
            this.latLonAltBoxSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LatLonAltBoxObjectExtensionGroup")]
    public AbstractObjectType[] LatLonAltBoxObjectExtensionGroup {
        get {
            return this.latLonAltBoxObjectExtensionGroupField;
        }
        set {
            this.latLonAltBoxObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Lod", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class LodType : AbstractObjectType {
    
    private double minLodPixelsField;
    
    private bool minLodPixelsFieldSpecified;
    
    private double maxLodPixelsField;
    
    private bool maxLodPixelsFieldSpecified;
    
    private double minFadeExtentField;
    
    private bool minFadeExtentFieldSpecified;
    
    private double maxFadeExtentField;
    
    private bool maxFadeExtentFieldSpecified;
    
    private string[] lodSimpleExtensionGroupField;
    
    private AbstractObjectType[] lodObjectExtensionGroupField;
    
    public LodType() {
        this.minLodPixelsField = 0D;
        this.maxLodPixelsField = -1D;
        this.minFadeExtentField = 0D;
        this.maxFadeExtentField = 0D;
    }
    
    /// <remarks/>
    public double minLodPixels {
        get {
            return this.minLodPixelsField;
        }
        set {
            this.minLodPixelsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool minLodPixelsSpecified {
        get {
            return this.minLodPixelsFieldSpecified;
        }
        set {
            this.minLodPixelsFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double maxLodPixels {
        get {
            return this.maxLodPixelsField;
        }
        set {
            this.maxLodPixelsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool maxLodPixelsSpecified {
        get {
            return this.maxLodPixelsFieldSpecified;
        }
        set {
            this.maxLodPixelsFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double minFadeExtent {
        get {
            return this.minFadeExtentField;
        }
        set {
            this.minFadeExtentField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool minFadeExtentSpecified {
        get {
            return this.minFadeExtentFieldSpecified;
        }
        set {
            this.minFadeExtentFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double maxFadeExtent {
        get {
            return this.maxFadeExtentField;
        }
        set {
            this.maxFadeExtentField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool maxFadeExtentSpecified {
        get {
            return this.maxFadeExtentFieldSpecified;
        }
        set {
            this.maxFadeExtentFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LodSimpleExtensionGroup")]
    public string[] LodSimpleExtensionGroup {
        get {
            return this.lodSimpleExtensionGroupField;
        }
        set {
            this.lodSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LodObjectExtensionGroup")]
    public AbstractObjectType[] LodObjectExtensionGroup {
        get {
            return this.lodObjectExtensionGroupField;
        }
        set {
            this.lodObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("ExtendedData", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class ExtendedDataType {
    
    private DataType[] dataField;
    
    private SchemaDataType[] schemaDataField;
    
    private System.Xml.XmlElement[] anyField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Data")]
    public DataType[] Data {
        get {
            return this.dataField;
        }
        set {
            this.dataField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SchemaData")]
    public SchemaDataType[] SchemaData {
        get {
            return this.schemaDataField;
        }
        set {
            this.schemaDataField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlElement[] Any {
        get {
            return this.anyField;
        }
        set {
            this.anyField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Data", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class DataType : AbstractObjectType {
    
    private string displayNameField;
    
    private string valueField;
    
    private object[] dataExtensionField;
    
    private string nameField;
    
    /// <remarks/>
    public string displayName {
        get {
            return this.displayNameField;
        }
        set {
            this.displayNameField = value;
        }
    }
    
    /// <remarks/>
    public string value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("DataExtension")]
    public object[] DataExtension {
        get {
            return this.dataExtensionField;
        }
        set {
            this.dataExtensionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("SchemaData", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class SchemaDataType : AbstractObjectType {
    
    private SimpleDataType[] simpleDataField;
    
    private object[] schemaDataExtensionField;
    
    private string schemaUrlField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SimpleData")]
    public SimpleDataType[] SimpleData {
        get {
            return this.simpleDataField;
        }
        set {
            this.simpleDataField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SchemaDataExtension")]
    public object[] SchemaDataExtension {
        get {
            return this.schemaDataExtensionField;
        }
        set {
            this.schemaDataExtensionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
    public string schemaUrl {
        get {
            return this.schemaUrlField;
        }
        set {
            this.schemaUrlField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("SimpleData", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class SimpleDataType {
    
    private string nameField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Metadata", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class MetadataType {
    
    private System.Xml.XmlElement[] anyField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAnyElementAttribute()]
    public System.Xml.XmlElement[] Any {
        get {
            return this.anyField;
        }
        set {
            this.anyField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(PhotoOverlayType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(ScreenOverlayType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(GroundOverlayType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
public abstract partial class AbstractOverlayType : AbstractFeatureType {
    
    private byte[] colorField;
    
    private int drawOrderField;
    
    private bool drawOrderFieldSpecified;
    
    private LinkType iconField;
    
    private string[] abstractOverlaySimpleExtensionGroupField;
    
    private AbstractObjectType[] abstractOverlayObjectExtensionGroupField;
    
    public AbstractOverlayType() {
        this.drawOrderField = 0;
    }
    
    /// <remarks/>
    // CODEGEN Warning: 'default' attribute on items of type 'hexBinary' is not supported in this version of the .Net Framework.  Ignoring default='ffffffff' attribute.
    [System.Xml.Serialization.XmlElementAttribute(DataType="hexBinary")]
    public byte[] color {
        get {
            return this.colorField;
        }
        set {
            this.colorField = value;
        }
    }
    
    /// <remarks/>
    public int drawOrder {
        get {
            return this.drawOrderField;
        }
        set {
            this.drawOrderField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool drawOrderSpecified {
        get {
            return this.drawOrderFieldSpecified;
        }
        set {
            this.drawOrderFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public LinkType Icon {
        get {
            return this.iconField;
        }
        set {
            this.iconField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractOverlaySimpleExtensionGroup")]
    public string[] AbstractOverlaySimpleExtensionGroup {
        get {
            return this.abstractOverlaySimpleExtensionGroupField;
        }
        set {
            this.abstractOverlaySimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractOverlayObjectExtensionGroup")]
    public AbstractObjectType[] AbstractOverlayObjectExtensionGroup {
        get {
            return this.abstractOverlayObjectExtensionGroupField;
        }
        set {
            this.abstractOverlayObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Icon", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class LinkType : BasicLinkType {
    
    private refreshModeEnumType refreshModeField;
    
    private bool refreshModeFieldSpecified;
    
    private double refreshIntervalField;
    
    private bool refreshIntervalFieldSpecified;
    
    private viewRefreshModeEnumType viewRefreshModeField;
    
    private bool viewRefreshModeFieldSpecified;
    
    private double viewRefreshTimeField;
    
    private bool viewRefreshTimeFieldSpecified;
    
    private double viewBoundScaleField;
    
    private bool viewBoundScaleFieldSpecified;
    
    private string viewFormatField;
    
    private string httpQueryField;
    
    private string[] linkSimpleExtensionGroupField;
    
    private AbstractObjectType[] linkObjectExtensionGroupField;
    
    public LinkType() {
        this.refreshModeField = refreshModeEnumType.onChange;
        this.refreshIntervalField = 4D;
        this.viewRefreshModeField = viewRefreshModeEnumType.never;
        this.viewRefreshTimeField = 4D;
        this.viewBoundScaleField = 1D;
    }
    
    /// <remarks/>
    public refreshModeEnumType refreshMode {
        get {
            return this.refreshModeField;
        }
        set {
            this.refreshModeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool refreshModeSpecified {
        get {
            return this.refreshModeFieldSpecified;
        }
        set {
            this.refreshModeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double refreshInterval {
        get {
            return this.refreshIntervalField;
        }
        set {
            this.refreshIntervalField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool refreshIntervalSpecified {
        get {
            return this.refreshIntervalFieldSpecified;
        }
        set {
            this.refreshIntervalFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public viewRefreshModeEnumType viewRefreshMode {
        get {
            return this.viewRefreshModeField;
        }
        set {
            this.viewRefreshModeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool viewRefreshModeSpecified {
        get {
            return this.viewRefreshModeFieldSpecified;
        }
        set {
            this.viewRefreshModeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double viewRefreshTime {
        get {
            return this.viewRefreshTimeField;
        }
        set {
            this.viewRefreshTimeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool viewRefreshTimeSpecified {
        get {
            return this.viewRefreshTimeFieldSpecified;
        }
        set {
            this.viewRefreshTimeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double viewBoundScale {
        get {
            return this.viewBoundScaleField;
        }
        set {
            this.viewBoundScaleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool viewBoundScaleSpecified {
        get {
            return this.viewBoundScaleFieldSpecified;
        }
        set {
            this.viewBoundScaleFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string viewFormat {
        get {
            return this.viewFormatField;
        }
        set {
            this.viewFormatField = value;
        }
    }
    
    /// <remarks/>
    public string httpQuery {
        get {
            return this.httpQueryField;
        }
        set {
            this.httpQueryField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LinkSimpleExtensionGroup")]
    public string[] LinkSimpleExtensionGroup {
        get {
            return this.linkSimpleExtensionGroupField;
        }
        set {
            this.linkSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LinkObjectExtensionGroup")]
    public AbstractObjectType[] LinkObjectExtensionGroup {
        get {
            return this.linkObjectExtensionGroupField;
        }
        set {
            this.linkObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("refreshMode", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public enum refreshModeEnumType {
    
    /// <remarks/>
    onChange,
    
    /// <remarks/>
    onInterval,
    
    /// <remarks/>
    onExpire,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("viewRefreshMode", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public enum viewRefreshModeEnumType {
    
    /// <remarks/>
    never,
    
    /// <remarks/>
    onRequest,
    
    /// <remarks/>
    onStop,
    
    /// <remarks/>
    onRegion,
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(FolderType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(DocumentType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
public abstract partial class AbstractContainerType : AbstractFeatureType {
    
    private string[] abstractContainerSimpleExtensionGroupField;
    
    private AbstractObjectType[] abstractContainerObjectExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractContainerSimpleExtensionGroup")]
    public string[] AbstractContainerSimpleExtensionGroup {
        get {
            return this.abstractContainerSimpleExtensionGroupField;
        }
        set {
            this.abstractContainerSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AbstractContainerObjectExtensionGroup")]
    public AbstractObjectType[] AbstractContainerObjectExtensionGroup {
        get {
            return this.abstractContainerObjectExtensionGroupField;
        }
        set {
            this.abstractContainerObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("shape", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public enum shapeEnumType {
    
    /// <remarks/>
    rectangle,
    
    /// <remarks/>
    cylinder,
    
    /// <remarks/>
    sphere,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("kml", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class KmlType {
    
    private NetworkLinkControlType networkLinkControlField;
    
    private AbstractFeatureType itemField;
    
    private string[] kmlSimpleExtensionGroupField;
    
    private AbstractObjectType[] kmlObjectExtensionGroupField;
    
    private string hintField;
    
    /// <remarks/>
    public NetworkLinkControlType NetworkLinkControl {
        get {
            return this.networkLinkControlField;
        }
        set {
            this.networkLinkControlField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NetworkLink", typeof(NetworkLinkType))]
    [System.Xml.Serialization.XmlElementAttribute("Placemark", typeof(PlacemarkType))]
    public AbstractFeatureType Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("KmlSimpleExtensionGroup")]
    public string[] KmlSimpleExtensionGroup {
        get {
            return this.kmlSimpleExtensionGroupField;
        }
        set {
            this.kmlSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("KmlObjectExtensionGroup")]
    public AbstractObjectType[] KmlObjectExtensionGroup {
        get {
            return this.kmlObjectExtensionGroupField;
        }
        set {
            this.kmlObjectExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string hint {
        get {
            return this.hintField;
        }
        set {
            this.hintField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("NetworkLinkControl", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class NetworkLinkControlType {
    
    private double minRefreshPeriodField;
    
    private bool minRefreshPeriodFieldSpecified;
    
    private double maxSessionLengthField;
    
    private bool maxSessionLengthFieldSpecified;
    
    private string cookieField;
    
    private string messageField;
    
    private string linkNameField;
    
    private string linkDescriptionField;
    
    private SnippetType linkSnippetField;
    
    private string expiresField;
    
    private UpdateType updateField;
    
    private AbstractViewType itemField;
    
    private string[] networkLinkControlSimpleExtensionGroupField;
    
    private AbstractObjectType[] networkLinkControlObjectExtensionGroupField;
    
    public NetworkLinkControlType() {
        this.minRefreshPeriodField = 0D;
        this.maxSessionLengthField = -1D;
    }
    
    /// <remarks/>
    public double minRefreshPeriod {
        get {
            return this.minRefreshPeriodField;
        }
        set {
            this.minRefreshPeriodField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool minRefreshPeriodSpecified {
        get {
            return this.minRefreshPeriodFieldSpecified;
        }
        set {
            this.minRefreshPeriodFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double maxSessionLength {
        get {
            return this.maxSessionLengthField;
        }
        set {
            this.maxSessionLengthField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool maxSessionLengthSpecified {
        get {
            return this.maxSessionLengthFieldSpecified;
        }
        set {
            this.maxSessionLengthFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string cookie {
        get {
            return this.cookieField;
        }
        set {
            this.cookieField = value;
        }
    }
    
    /// <remarks/>
    public string message {
        get {
            return this.messageField;
        }
        set {
            this.messageField = value;
        }
    }
    
    /// <remarks/>
    public string linkName {
        get {
            return this.linkNameField;
        }
        set {
            this.linkNameField = value;
        }
    }
    
    /// <remarks/>
    public string linkDescription {
        get {
            return this.linkDescriptionField;
        }
        set {
            this.linkDescriptionField = value;
        }
    }
    
    /// <remarks/>
    public SnippetType linkSnippet {
        get {
            return this.linkSnippetField;
        }
        set {
            this.linkSnippetField = value;
        }
    }
    
    /// <remarks/>
    public string expires {
        get {
            return this.expiresField;
        }
        set {
            this.expiresField = value;
        }
    }
    
    /// <remarks/>
    public UpdateType Update {
        get {
            return this.updateField;
        }
        set {
            this.updateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Camera", typeof(CameraType))]
    [System.Xml.Serialization.XmlElementAttribute("LookAt", typeof(LookAtType))]
    public AbstractViewType Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NetworkLinkControlSimpleExtensionGroup")]
    public string[] NetworkLinkControlSimpleExtensionGroup {
        get {
            return this.networkLinkControlSimpleExtensionGroupField;
        }
        set {
            this.networkLinkControlSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NetworkLinkControlObjectExtensionGroup")]
    public AbstractObjectType[] NetworkLinkControlObjectExtensionGroup {
        get {
            return this.networkLinkControlObjectExtensionGroupField;
        }
        set {
            this.networkLinkControlObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Update", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class UpdateType {
    
    private string targetHrefField;
    
    private object[] itemsField;
    
    private object[] updateExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
    public string targetHref {
        get {
            return this.targetHrefField;
        }
        set {
            this.targetHrefField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Change", typeof(ChangeType))]
    [System.Xml.Serialization.XmlElementAttribute("Create", typeof(CreateType))]
    [System.Xml.Serialization.XmlElementAttribute("Delete", typeof(DeleteType))]
    [System.Xml.Serialization.XmlElementAttribute("UpdateOpExtensionGroup", typeof(object))]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("UpdateExtensionGroup")]
    public object[] UpdateExtensionGroup {
        get {
            return this.updateExtensionGroupField;
        }
        set {
            this.updateExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Change", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class ChangeType {
    
    private AbstractObjectType[] itemsField;
    
    private ItemsChoiceType[] itemsElementNameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Alias", typeof(AliasType))]
    [System.Xml.Serialization.XmlElementAttribute("Data", typeof(DataType))]
    [System.Xml.Serialization.XmlElementAttribute("Icon", typeof(LinkType))]
    [System.Xml.Serialization.XmlElementAttribute("ImagePyramid", typeof(ImagePyramidType))]
    [System.Xml.Serialization.XmlElementAttribute("ItemIcon", typeof(ItemIconType))]
    [System.Xml.Serialization.XmlElementAttribute("LatLonAltBox", typeof(LatLonAltBoxType))]
    [System.Xml.Serialization.XmlElementAttribute("LatLonBox", typeof(LatLonBoxType))]
    [System.Xml.Serialization.XmlElementAttribute("Link", typeof(LinkType))]
    [System.Xml.Serialization.XmlElementAttribute("Location", typeof(LocationType))]
    [System.Xml.Serialization.XmlElementAttribute("Lod", typeof(LodType))]
    [System.Xml.Serialization.XmlElementAttribute("Orientation", typeof(OrientationType))]
    [System.Xml.Serialization.XmlElementAttribute("Pair", typeof(PairType))]
    [System.Xml.Serialization.XmlElementAttribute("Region", typeof(RegionType))]
    [System.Xml.Serialization.XmlElementAttribute("ResourceMap", typeof(ResourceMapType))]
    [System.Xml.Serialization.XmlElementAttribute("Scale", typeof(ScaleType))]
    [System.Xml.Serialization.XmlElementAttribute("SchemaData", typeof(SchemaDataType))]
    [System.Xml.Serialization.XmlElementAttribute("Url", typeof(LinkType))]
    [System.Xml.Serialization.XmlElementAttribute("ViewVolume", typeof(ViewVolumeType))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public AbstractObjectType[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType[] ItemsElementName {
        get {
            return this.itemsElementNameField;
        }
        set {
            this.itemsElementNameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Alias", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class AliasType : AbstractObjectType {
    
    private string targetHrefField;
    
    private string sourceHrefField;
    
    private string[] aliasSimpleExtensionGroupField;
    
    private AbstractObjectType[] aliasObjectExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
    public string targetHref {
        get {
            return this.targetHrefField;
        }
        set {
            this.targetHrefField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
    public string sourceHref {
        get {
            return this.sourceHrefField;
        }
        set {
            this.sourceHrefField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AliasSimpleExtensionGroup")]
    public string[] AliasSimpleExtensionGroup {
        get {
            return this.aliasSimpleExtensionGroupField;
        }
        set {
            this.aliasSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AliasObjectExtensionGroup")]
    public AbstractObjectType[] AliasObjectExtensionGroup {
        get {
            return this.aliasObjectExtensionGroupField;
        }
        set {
            this.aliasObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("ImagePyramid", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class ImagePyramidType : AbstractObjectType {
    
    private int tileSizeField;
    
    private bool tileSizeFieldSpecified;
    
    private int maxWidthField;
    
    private bool maxWidthFieldSpecified;
    
    private int maxHeightField;
    
    private bool maxHeightFieldSpecified;
    
    private gridOriginEnumType gridOriginField;
    
    private bool gridOriginFieldSpecified;
    
    private string[] imagePyramidSimpleExtensionGroupField;
    
    private AbstractObjectType[] imagePyramidObjectExtensionGroupField;
    
    public ImagePyramidType() {
        this.tileSizeField = 256;
        this.maxWidthField = 0;
        this.maxHeightField = 0;
        this.gridOriginField = gridOriginEnumType.lowerLeft;
    }
    
    /// <remarks/>
    public int tileSize {
        get {
            return this.tileSizeField;
        }
        set {
            this.tileSizeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool tileSizeSpecified {
        get {
            return this.tileSizeFieldSpecified;
        }
        set {
            this.tileSizeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public int maxWidth {
        get {
            return this.maxWidthField;
        }
        set {
            this.maxWidthField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool maxWidthSpecified {
        get {
            return this.maxWidthFieldSpecified;
        }
        set {
            this.maxWidthFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public int maxHeight {
        get {
            return this.maxHeightField;
        }
        set {
            this.maxHeightField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool maxHeightSpecified {
        get {
            return this.maxHeightFieldSpecified;
        }
        set {
            this.maxHeightFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public gridOriginEnumType gridOrigin {
        get {
            return this.gridOriginField;
        }
        set {
            this.gridOriginField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool gridOriginSpecified {
        get {
            return this.gridOriginFieldSpecified;
        }
        set {
            this.gridOriginFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ImagePyramidSimpleExtensionGroup")]
    public string[] ImagePyramidSimpleExtensionGroup {
        get {
            return this.imagePyramidSimpleExtensionGroupField;
        }
        set {
            this.imagePyramidSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ImagePyramidObjectExtensionGroup")]
    public AbstractObjectType[] ImagePyramidObjectExtensionGroup {
        get {
            return this.imagePyramidObjectExtensionGroupField;
        }
        set {
            this.imagePyramidObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("LatLonBox", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class LatLonBoxType : AbstractLatLonBoxType {
    
    private double rotationField;
    
    private bool rotationFieldSpecified;
    
    private string[] latLonBoxSimpleExtensionGroupField;
    
    private AbstractObjectType[] latLonBoxObjectExtensionGroupField;
    
    public LatLonBoxType() {
        this.rotationField = 0D;
    }
    
    /// <remarks/>
    public double rotation {
        get {
            return this.rotationField;
        }
        set {
            this.rotationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool rotationSpecified {
        get {
            return this.rotationFieldSpecified;
        }
        set {
            this.rotationFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LatLonBoxSimpleExtensionGroup")]
    public string[] LatLonBoxSimpleExtensionGroup {
        get {
            return this.latLonBoxSimpleExtensionGroupField;
        }
        set {
            this.latLonBoxSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LatLonBoxObjectExtensionGroup")]
    public AbstractObjectType[] LatLonBoxObjectExtensionGroup {
        get {
            return this.latLonBoxObjectExtensionGroupField;
        }
        set {
            this.latLonBoxObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Location", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class LocationType : AbstractObjectType {
    
    private double longitudeField;
    
    private bool longitudeFieldSpecified;
    
    private double latitudeField;
    
    private bool latitudeFieldSpecified;
    
    private double altitudeField;
    
    private bool altitudeFieldSpecified;
    
    private string[] locationSimpleExtensionGroupField;
    
    private AbstractObjectType[] locationObjectExtensionGroupField;
    
    public LocationType() {
        this.longitudeField = 0D;
        this.latitudeField = 0D;
        this.altitudeField = 0D;
    }
    
    /// <remarks/>
    public double longitude {
        get {
            return this.longitudeField;
        }
        set {
            this.longitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool longitudeSpecified {
        get {
            return this.longitudeFieldSpecified;
        }
        set {
            this.longitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double latitude {
        get {
            return this.latitudeField;
        }
        set {
            this.latitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool latitudeSpecified {
        get {
            return this.latitudeFieldSpecified;
        }
        set {
            this.latitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double altitude {
        get {
            return this.altitudeField;
        }
        set {
            this.altitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool altitudeSpecified {
        get {
            return this.altitudeFieldSpecified;
        }
        set {
            this.altitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LocationSimpleExtensionGroup")]
    public string[] LocationSimpleExtensionGroup {
        get {
            return this.locationSimpleExtensionGroupField;
        }
        set {
            this.locationSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LocationObjectExtensionGroup")]
    public AbstractObjectType[] LocationObjectExtensionGroup {
        get {
            return this.locationObjectExtensionGroupField;
        }
        set {
            this.locationObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Orientation", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class OrientationType : AbstractObjectType {
    
    private double headingField;
    
    private bool headingFieldSpecified;
    
    private double tiltField;
    
    private bool tiltFieldSpecified;
    
    private double rollField;
    
    private bool rollFieldSpecified;
    
    private string[] orientationSimpleExtensionGroupField;
    
    private AbstractObjectType[] orientationObjectExtensionGroupField;
    
    public OrientationType() {
        this.headingField = 0D;
        this.tiltField = 0D;
        this.rollField = 0D;
    }
    
    /// <remarks/>
    public double heading {
        get {
            return this.headingField;
        }
        set {
            this.headingField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool headingSpecified {
        get {
            return this.headingFieldSpecified;
        }
        set {
            this.headingFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double tilt {
        get {
            return this.tiltField;
        }
        set {
            this.tiltField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool tiltSpecified {
        get {
            return this.tiltFieldSpecified;
        }
        set {
            this.tiltFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double roll {
        get {
            return this.rollField;
        }
        set {
            this.rollField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool rollSpecified {
        get {
            return this.rollFieldSpecified;
        }
        set {
            this.rollFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("OrientationSimpleExtensionGroup")]
    public string[] OrientationSimpleExtensionGroup {
        get {
            return this.orientationSimpleExtensionGroupField;
        }
        set {
            this.orientationSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("OrientationObjectExtensionGroup")]
    public AbstractObjectType[] OrientationObjectExtensionGroup {
        get {
            return this.orientationObjectExtensionGroupField;
        }
        set {
            this.orientationObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("ResourceMap", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class ResourceMapType : AbstractObjectType {
    
    private AliasType[] aliasField;
    
    private string[] resourceMapSimpleExtensionGroupField;
    
    private AbstractObjectType[] resourceMapObjectExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Alias")]
    public AliasType[] Alias {
        get {
            return this.aliasField;
        }
        set {
            this.aliasField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ResourceMapSimpleExtensionGroup")]
    public string[] ResourceMapSimpleExtensionGroup {
        get {
            return this.resourceMapSimpleExtensionGroupField;
        }
        set {
            this.resourceMapSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ResourceMapObjectExtensionGroup")]
    public AbstractObjectType[] ResourceMapObjectExtensionGroup {
        get {
            return this.resourceMapObjectExtensionGroupField;
        }
        set {
            this.resourceMapObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Scale", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class ScaleType : AbstractObjectType {
    
    private double xField;
    
    private bool xFieldSpecified;
    
    private double yField;
    
    private bool yFieldSpecified;
    
    private double zField;
    
    private bool zFieldSpecified;
    
    private string[] scaleSimpleExtensionGroupField;
    
    private AbstractObjectType[] scaleObjectExtensionGroupField;
    
    public ScaleType() {
        this.xField = 1D;
        this.yField = 1D;
        this.zField = 1D;
    }
    
    /// <remarks/>
    public double x {
        get {
            return this.xField;
        }
        set {
            this.xField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool xSpecified {
        get {
            return this.xFieldSpecified;
        }
        set {
            this.xFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double y {
        get {
            return this.yField;
        }
        set {
            this.yField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ySpecified {
        get {
            return this.yFieldSpecified;
        }
        set {
            this.yFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double z {
        get {
            return this.zField;
        }
        set {
            this.zField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool zSpecified {
        get {
            return this.zFieldSpecified;
        }
        set {
            this.zFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ScaleSimpleExtensionGroup")]
    public string[] ScaleSimpleExtensionGroup {
        get {
            return this.scaleSimpleExtensionGroupField;
        }
        set {
            this.scaleSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ScaleObjectExtensionGroup")]
    public AbstractObjectType[] ScaleObjectExtensionGroup {
        get {
            return this.scaleObjectExtensionGroupField;
        }
        set {
            this.scaleObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("ViewVolume", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class ViewVolumeType : AbstractObjectType {
    
    private double leftFovField;
    
    private bool leftFovFieldSpecified;
    
    private double rightFovField;
    
    private bool rightFovFieldSpecified;
    
    private double bottomFovField;
    
    private bool bottomFovFieldSpecified;
    
    private double topFovField;
    
    private bool topFovFieldSpecified;
    
    private double nearField;
    
    private bool nearFieldSpecified;
    
    private string[] viewVolumeSimpleExtensionGroupField;
    
    private AbstractObjectType[] viewVolumeObjectExtensionGroupField;
    
    public ViewVolumeType() {
        this.leftFovField = 0D;
        this.rightFovField = 0D;
        this.bottomFovField = 0D;
        this.topFovField = 0D;
        this.nearField = 0D;
    }
    
    /// <remarks/>
    public double leftFov {
        get {
            return this.leftFovField;
        }
        set {
            this.leftFovField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool leftFovSpecified {
        get {
            return this.leftFovFieldSpecified;
        }
        set {
            this.leftFovFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double rightFov {
        get {
            return this.rightFovField;
        }
        set {
            this.rightFovField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool rightFovSpecified {
        get {
            return this.rightFovFieldSpecified;
        }
        set {
            this.rightFovFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double bottomFov {
        get {
            return this.bottomFovField;
        }
        set {
            this.bottomFovField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool bottomFovSpecified {
        get {
            return this.bottomFovFieldSpecified;
        }
        set {
            this.bottomFovFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double topFov {
        get {
            return this.topFovField;
        }
        set {
            this.topFovField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool topFovSpecified {
        get {
            return this.topFovFieldSpecified;
        }
        set {
            this.topFovFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double near {
        get {
            return this.nearField;
        }
        set {
            this.nearField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool nearSpecified {
        get {
            return this.nearFieldSpecified;
        }
        set {
            this.nearFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ViewVolumeSimpleExtensionGroup")]
    public string[] ViewVolumeSimpleExtensionGroup {
        get {
            return this.viewVolumeSimpleExtensionGroupField;
        }
        set {
            this.viewVolumeSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ViewVolumeObjectExtensionGroup")]
    public AbstractObjectType[] ViewVolumeObjectExtensionGroup {
        get {
            return this.viewVolumeObjectExtensionGroupField;
        }
        set {
            this.viewVolumeObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2", IncludeInSchema=false)]
public enum ItemsChoiceType {
    
    /// <remarks/>
    Alias,
    
    /// <remarks/>
    Data,
    
    /// <remarks/>
    Icon,
    
    /// <remarks/>
    ImagePyramid,
    
    /// <remarks/>
    ItemIcon,
    
    /// <remarks/>
    LatLonAltBox,
    
    /// <remarks/>
    LatLonBox,
    
    /// <remarks/>
    Link,
    
    /// <remarks/>
    Location,
    
    /// <remarks/>
    Lod,
    
    /// <remarks/>
    Orientation,
    
    /// <remarks/>
    Pair,
    
    /// <remarks/>
    Region,
    
    /// <remarks/>
    ResourceMap,
    
    /// <remarks/>
    Scale,
    
    /// <remarks/>
    SchemaData,
    
    /// <remarks/>
    Url,
    
    /// <remarks/>
    ViewVolume,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Create", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class CreateType {
    
    private AbstractContainerType[] itemsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Document", typeof(DocumentType))]
    [System.Xml.Serialization.XmlElementAttribute("Folder", typeof(FolderType))]
    public AbstractContainerType[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Document", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class DocumentType : AbstractContainerType {
    
    private SchemaType[] schemaField;
    
    private AbstractFeatureType[] itemsField;
    
    private string[] documentSimpleExtensionGroupField;
    
    private AbstractObjectType[] documentObjectExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Schema")]
    public SchemaType[] Schema {
        get {
            return this.schemaField;
        }
        set {
            this.schemaField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NetworkLink", typeof(NetworkLinkType))]
    [System.Xml.Serialization.XmlElementAttribute("Placemark", typeof(PlacemarkType))]
    public AbstractFeatureType[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("DocumentSimpleExtensionGroup")]
    public string[] DocumentSimpleExtensionGroup {
        get {
            return this.documentSimpleExtensionGroupField;
        }
        set {
            this.documentSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("DocumentObjectExtensionGroup")]
    public AbstractObjectType[] DocumentObjectExtensionGroup {
        get {
            return this.documentObjectExtensionGroupField;
        }
        set {
            this.documentObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Schema", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class SchemaType {
    
    private SimpleFieldType[] simpleFieldField;
    
    private object[] schemaExtensionField;
    
    private string nameField;
    
    private string idField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SimpleField")]
    public SimpleFieldType[] SimpleField {
        get {
            return this.simpleFieldField;
        }
        set {
            this.simpleFieldField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SchemaExtension")]
    public object[] SchemaExtension {
        get {
            return this.schemaExtensionField;
        }
        set {
            this.schemaExtensionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="ID")]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("SimpleField", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class SimpleFieldType {
    
    private string displayNameField;
    
    private object[] simpleFieldExtensionField;
    
    private string typeField;
    
    private string nameField;
    
    /// <remarks/>
    public string displayName {
        get {
            return this.displayNameField;
        }
        set {
            this.displayNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SimpleFieldExtension")]
    public object[] SimpleFieldExtension {
        get {
            return this.simpleFieldExtensionField;
        }
        set {
            this.simpleFieldExtensionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("NetworkLink", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class NetworkLinkType : AbstractFeatureType {
    
    private bool refreshVisibilityField;
    
    private bool refreshVisibilityFieldSpecified;
    
    private bool flyToViewField;
    
    private bool flyToViewFieldSpecified;
    
    private LinkType itemField;
    
    private ItemChoiceType1 itemElementNameField;
    
    private string[] networkLinkSimpleExtensionGroupField;
    
    private AbstractObjectType[] networkLinkObjectExtensionGroupField;
    
    public NetworkLinkType() {
        this.refreshVisibilityField = false;
        this.flyToViewField = false;
    }
    
    /// <remarks/>
    public bool refreshVisibility {
        get {
            return this.refreshVisibilityField;
        }
        set {
            this.refreshVisibilityField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool refreshVisibilitySpecified {
        get {
            return this.refreshVisibilityFieldSpecified;
        }
        set {
            this.refreshVisibilityFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public bool flyToView {
        get {
            return this.flyToViewField;
        }
        set {
            this.flyToViewField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool flyToViewSpecified {
        get {
            return this.flyToViewFieldSpecified;
        }
        set {
            this.flyToViewFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Link", typeof(LinkType))]
    [System.Xml.Serialization.XmlElementAttribute("Url", typeof(LinkType))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
    public LinkType Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemChoiceType1 ItemElementName {
        get {
            return this.itemElementNameField;
        }
        set {
            this.itemElementNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NetworkLinkSimpleExtensionGroup")]
    public string[] NetworkLinkSimpleExtensionGroup {
        get {
            return this.networkLinkSimpleExtensionGroupField;
        }
        set {
            this.networkLinkSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NetworkLinkObjectExtensionGroup")]
    public AbstractObjectType[] NetworkLinkObjectExtensionGroup {
        get {
            return this.networkLinkObjectExtensionGroupField;
        }
        set {
            this.networkLinkObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2", IncludeInSchema=false)]
public enum ItemChoiceType1 {
    
    /// <remarks/>
    Link,
    
    /// <remarks/>
    Url,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Placemark", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class PlacemarkType : AbstractFeatureType {
    
    private AbstractGeometryType itemField;
    
    private string[] placemarkSimpleExtensionGroupField;
    
    private AbstractObjectType[] placemarkObjectExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LineString", typeof(LineStringType))]
    [System.Xml.Serialization.XmlElementAttribute("LinearRing", typeof(LinearRingType))]
    [System.Xml.Serialization.XmlElementAttribute("Model", typeof(ModelType))]
    [System.Xml.Serialization.XmlElementAttribute("MultiGeometry", typeof(MultiGeometryType))]
    [System.Xml.Serialization.XmlElementAttribute("Point", typeof(PointType))]
    [System.Xml.Serialization.XmlElementAttribute("Polygon", typeof(PolygonType))]
    public AbstractGeometryType Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PlacemarkSimpleExtensionGroup")]
    public string[] PlacemarkSimpleExtensionGroup {
        get {
            return this.placemarkSimpleExtensionGroupField;
        }
        set {
            this.placemarkSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PlacemarkObjectExtensionGroup")]
    public AbstractObjectType[] PlacemarkObjectExtensionGroup {
        get {
            return this.placemarkObjectExtensionGroupField;
        }
        set {
            this.placemarkObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("LineString", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class LineStringType : AbstractGeometryType {
    
    private bool extrudeField;
    
    private bool extrudeFieldSpecified;
    
    private bool tessellateField;
    
    private bool tessellateFieldSpecified;
    
    private altitudeModeEnumType itemField;
    
    private string coordinatesField;
    
    private string[] lineStringSimpleExtensionGroupField;
    
    private AbstractObjectType[] lineStringObjectExtensionGroupField;
    
    public LineStringType() {
        this.extrudeField = false;
        this.tessellateField = false;
        this.itemField = altitudeModeEnumType.clampToGround;
    }
    
    /// <remarks/>
    public bool extrude {
        get {
            return this.extrudeField;
        }
        set {
            this.extrudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool extrudeSpecified {
        get {
            return this.extrudeFieldSpecified;
        }
        set {
            this.extrudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public bool tessellate {
        get {
            return this.tessellateField;
        }
        set {
            this.tessellateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool tessellateSpecified {
        get {
            return this.tessellateFieldSpecified;
        }
        set {
            this.tessellateFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("altitudeMode")]
    public altitudeModeEnumType Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    public string coordinates {
        get {
            return this.coordinatesField;
        }
        set {
            this.coordinatesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LineStringSimpleExtensionGroup")]
    public string[] LineStringSimpleExtensionGroup {
        get {
            return this.lineStringSimpleExtensionGroupField;
        }
        set {
            this.lineStringSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LineStringObjectExtensionGroup")]
    public AbstractObjectType[] LineStringObjectExtensionGroup {
        get {
            return this.lineStringObjectExtensionGroupField;
        }
        set {
            this.lineStringObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("LinearRing", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class LinearRingType : AbstractGeometryType {
    
    private bool extrudeField;
    
    private bool extrudeFieldSpecified;
    
    private bool tessellateField;
    
    private bool tessellateFieldSpecified;
    
    private altitudeModeEnumType itemField;
    
    private string coordinatesField;
    
    private string[] linearRingSimpleExtensionGroupField;
    
    private AbstractObjectType[] linearRingObjectExtensionGroupField;
    
    public LinearRingType() {
        this.extrudeField = false;
        this.tessellateField = false;
        this.itemField = altitudeModeEnumType.clampToGround;
    }
    
    /// <remarks/>
    public bool extrude {
        get {
            return this.extrudeField;
        }
        set {
            this.extrudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool extrudeSpecified {
        get {
            return this.extrudeFieldSpecified;
        }
        set {
            this.extrudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public bool tessellate {
        get {
            return this.tessellateField;
        }
        set {
            this.tessellateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool tessellateSpecified {
        get {
            return this.tessellateFieldSpecified;
        }
        set {
            this.tessellateFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("altitudeMode")]
    public altitudeModeEnumType Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    public string coordinates {
        get {
            return this.coordinatesField;
        }
        set {
            this.coordinatesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LinearRingSimpleExtensionGroup")]
    public string[] LinearRingSimpleExtensionGroup {
        get {
            return this.linearRingSimpleExtensionGroupField;
        }
        set {
            this.linearRingSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LinearRingObjectExtensionGroup")]
    public AbstractObjectType[] LinearRingObjectExtensionGroup {
        get {
            return this.linearRingObjectExtensionGroupField;
        }
        set {
            this.linearRingObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Model", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class ModelType : AbstractGeometryType {
    
    private altitudeModeEnumType itemField;
    
    private LocationType locationField;
    
    private OrientationType orientationField;
    
    private ScaleType scaleField;
    
    private LinkType linkField;
    
    private ResourceMapType resourceMapField;
    
    private string[] modelSimpleExtensionGroupField;
    
    private AbstractObjectType[] modelObjectExtensionGroupField;
    
    public ModelType() {
        this.itemField = altitudeModeEnumType.clampToGround;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("altitudeMode")]
    public altitudeModeEnumType Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    public LocationType Location {
        get {
            return this.locationField;
        }
        set {
            this.locationField = value;
        }
    }
    
    /// <remarks/>
    public OrientationType Orientation {
        get {
            return this.orientationField;
        }
        set {
            this.orientationField = value;
        }
    }
    
    /// <remarks/>
    public ScaleType Scale {
        get {
            return this.scaleField;
        }
        set {
            this.scaleField = value;
        }
    }
    
    /// <remarks/>
    public LinkType Link {
        get {
            return this.linkField;
        }
        set {
            this.linkField = value;
        }
    }
    
    /// <remarks/>
    public ResourceMapType ResourceMap {
        get {
            return this.resourceMapField;
        }
        set {
            this.resourceMapField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ModelSimpleExtensionGroup")]
    public string[] ModelSimpleExtensionGroup {
        get {
            return this.modelSimpleExtensionGroupField;
        }
        set {
            this.modelSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ModelObjectExtensionGroup")]
    public AbstractObjectType[] ModelObjectExtensionGroup {
        get {
            return this.modelObjectExtensionGroupField;
        }
        set {
            this.modelObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("MultiGeometry", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class MultiGeometryType : AbstractGeometryType {
    
    private AbstractGeometryType[] itemsField;
    
    private string[] multiGeometrySimpleExtensionGroupField;
    
    private AbstractObjectType[] multiGeometryObjectExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LineString", typeof(LineStringType))]
    [System.Xml.Serialization.XmlElementAttribute("LinearRing", typeof(LinearRingType))]
    [System.Xml.Serialization.XmlElementAttribute("Model", typeof(ModelType))]
    [System.Xml.Serialization.XmlElementAttribute("MultiGeometry", typeof(MultiGeometryType))]
    [System.Xml.Serialization.XmlElementAttribute("Point", typeof(PointType))]
    [System.Xml.Serialization.XmlElementAttribute("Polygon", typeof(PolygonType))]
    public AbstractGeometryType[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("MultiGeometrySimpleExtensionGroup")]
    public string[] MultiGeometrySimpleExtensionGroup {
        get {
            return this.multiGeometrySimpleExtensionGroupField;
        }
        set {
            this.multiGeometrySimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("MultiGeometryObjectExtensionGroup")]
    public AbstractObjectType[] MultiGeometryObjectExtensionGroup {
        get {
            return this.multiGeometryObjectExtensionGroupField;
        }
        set {
            this.multiGeometryObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Point", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class PointType : AbstractGeometryType {
    
    private bool extrudeField;
    
    private bool extrudeFieldSpecified;
    
    private altitudeModeEnumType itemField;
    
    private string coordinatesField;
    
    private string[] pointSimpleExtensionGroupField;
    
    private AbstractObjectType[] pointObjectExtensionGroupField;
    
    public PointType() {
        this.extrudeField = false;
        this.itemField = altitudeModeEnumType.clampToGround;
    }
    
    /// <remarks/>
    public bool extrude {
        get {
            return this.extrudeField;
        }
        set {
            this.extrudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool extrudeSpecified {
        get {
            return this.extrudeFieldSpecified;
        }
        set {
            this.extrudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("altitudeMode")]
    public altitudeModeEnumType Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    public string coordinates {
        get {
            return this.coordinatesField;
        }
        set {
            this.coordinatesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PointSimpleExtensionGroup")]
    public string[] PointSimpleExtensionGroup {
        get {
            return this.pointSimpleExtensionGroupField;
        }
        set {
            this.pointSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PointObjectExtensionGroup")]
    public AbstractObjectType[] PointObjectExtensionGroup {
        get {
            return this.pointObjectExtensionGroupField;
        }
        set {
            this.pointObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Polygon", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class PolygonType : AbstractGeometryType {
    
    private bool extrudeField;
    
    private bool extrudeFieldSpecified;
    
    private bool tessellateField;
    
    private bool tessellateFieldSpecified;
    
    private altitudeModeEnumType itemField;
    
    private BoundaryType outerBoundaryIsField;
    
    private BoundaryType[] innerBoundaryIsField;
    
    private string[] polygonSimpleExtensionGroupField;
    
    private AbstractObjectType[] polygonObjectExtensionGroupField;
    
    public PolygonType() {
        this.extrudeField = false;
        this.tessellateField = false;
        this.itemField = altitudeModeEnumType.clampToGround;
    }
    
    /// <remarks/>
    public bool extrude {
        get {
            return this.extrudeField;
        }
        set {
            this.extrudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool extrudeSpecified {
        get {
            return this.extrudeFieldSpecified;
        }
        set {
            this.extrudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public bool tessellate {
        get {
            return this.tessellateField;
        }
        set {
            this.tessellateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool tessellateSpecified {
        get {
            return this.tessellateFieldSpecified;
        }
        set {
            this.tessellateFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("altitudeMode")]
    public altitudeModeEnumType Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    public BoundaryType outerBoundaryIs {
        get {
            return this.outerBoundaryIsField;
        }
        set {
            this.outerBoundaryIsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("innerBoundaryIs")]
    public BoundaryType[] innerBoundaryIs {
        get {
            return this.innerBoundaryIsField;
        }
        set {
            this.innerBoundaryIsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PolygonSimpleExtensionGroup")]
    public string[] PolygonSimpleExtensionGroup {
        get {
            return this.polygonSimpleExtensionGroupField;
        }
        set {
            this.polygonSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PolygonObjectExtensionGroup")]
    public AbstractObjectType[] PolygonObjectExtensionGroup {
        get {
            return this.polygonObjectExtensionGroupField;
        }
        set {
            this.polygonObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("outerBoundaryIs", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class BoundaryType {
    
    private LinearRingType linearRingField;
    
    private string[] boundarySimpleExtensionGroupField;
    
    private AbstractObjectType[] boundaryObjectExtensionGroupField;
    
    /// <remarks/>
    public LinearRingType LinearRing {
        get {
            return this.linearRingField;
        }
        set {
            this.linearRingField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("BoundarySimpleExtensionGroup")]
    public string[] BoundarySimpleExtensionGroup {
        get {
            return this.boundarySimpleExtensionGroupField;
        }
        set {
            this.boundarySimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("BoundaryObjectExtensionGroup")]
    public AbstractObjectType[] BoundaryObjectExtensionGroup {
        get {
            return this.boundaryObjectExtensionGroupField;
        }
        set {
            this.boundaryObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Folder", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class FolderType : AbstractContainerType {
    
    private AbstractFeatureType[] itemsField;
    
    private string[] folderSimpleExtensionGroupField;
    
    private AbstractObjectType[] folderObjectExtensionGroupField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NetworkLink", typeof(NetworkLinkType))]
    [System.Xml.Serialization.XmlElementAttribute("Placemark", typeof(PlacemarkType))]
    public AbstractFeatureType[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("FolderSimpleExtensionGroup")]
    public string[] FolderSimpleExtensionGroup {
        get {
            return this.folderSimpleExtensionGroupField;
        }
        set {
            this.folderSimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("FolderObjectExtensionGroup")]
    public AbstractObjectType[] FolderObjectExtensionGroup {
        get {
            return this.folderObjectExtensionGroupField;
        }
        set {
            this.folderObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("Delete", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class DeleteType {
    
    private AbstractFeatureType[] itemsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NetworkLink", typeof(NetworkLinkType))]
    [System.Xml.Serialization.XmlElementAttribute("Placemark", typeof(PlacemarkType))]
    public AbstractFeatureType[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("GroundOverlay", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class GroundOverlayType : AbstractOverlayType {
    
    private double altitudeField;
    
    private bool altitudeFieldSpecified;
    
    private altitudeModeEnumType item4Field;
    
    private LatLonBoxType latLonBoxField;
    
    private string[] groundOverlaySimpleExtensionGroupField;
    
    private AbstractObjectType[] groundOverlayObjectExtensionGroupField;
    
    public GroundOverlayType() {
        this.altitudeField = 0D;
        this.item4Field = altitudeModeEnumType.clampToGround;
    }
    
    /// <remarks/>
    public double altitude {
        get {
            return this.altitudeField;
        }
        set {
            this.altitudeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool altitudeSpecified {
        get {
            return this.altitudeFieldSpecified;
        }
        set {
            this.altitudeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("altitudeMode")]
    public altitudeModeEnumType Item4 {
        get {
            return this.item4Field;
        }
        set {
            this.item4Field = value;
        }
    }
    
    /// <remarks/>
    public LatLonBoxType LatLonBox {
        get {
            return this.latLonBoxField;
        }
        set {
            this.latLonBoxField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("GroundOverlaySimpleExtensionGroup")]
    public string[] GroundOverlaySimpleExtensionGroup {
        get {
            return this.groundOverlaySimpleExtensionGroupField;
        }
        set {
            this.groundOverlaySimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("GroundOverlayObjectExtensionGroup")]
    public AbstractObjectType[] GroundOverlayObjectExtensionGroup {
        get {
            return this.groundOverlayObjectExtensionGroupField;
        }
        set {
            this.groundOverlayObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("ScreenOverlay", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class ScreenOverlayType : AbstractOverlayType {
    
    private vec2Type overlayXYField;
    
    private vec2Type screenXYField;
    
    private vec2Type rotationXYField;
    
    private vec2Type sizeField;
    
    private double rotationField;
    
    private bool rotationFieldSpecified;
    
    private string[] screenOverlaySimpleExtensionGroupField;
    
    private AbstractObjectType[] screenOverlayObjectExtensionGroupField;
    
    public ScreenOverlayType() {
        this.rotationField = 0D;
    }
    
    /// <remarks/>
    public vec2Type overlayXY {
        get {
            return this.overlayXYField;
        }
        set {
            this.overlayXYField = value;
        }
    }
    
    /// <remarks/>
    public vec2Type screenXY {
        get {
            return this.screenXYField;
        }
        set {
            this.screenXYField = value;
        }
    }
    
    /// <remarks/>
    public vec2Type rotationXY {
        get {
            return this.rotationXYField;
        }
        set {
            this.rotationXYField = value;
        }
    }
    
    /// <remarks/>
    public vec2Type size {
        get {
            return this.sizeField;
        }
        set {
            this.sizeField = value;
        }
    }
    
    /// <remarks/>
    public double rotation {
        get {
            return this.rotationField;
        }
        set {
            this.rotationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool rotationSpecified {
        get {
            return this.rotationFieldSpecified;
        }
        set {
            this.rotationFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ScreenOverlaySimpleExtensionGroup")]
    public string[] ScreenOverlaySimpleExtensionGroup {
        get {
            return this.screenOverlaySimpleExtensionGroupField;
        }
        set {
            this.screenOverlaySimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ScreenOverlayObjectExtensionGroup")]
    public AbstractObjectType[] ScreenOverlayObjectExtensionGroup {
        get {
            return this.screenOverlayObjectExtensionGroupField;
        }
        set {
            this.screenOverlayObjectExtensionGroupField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.opengis.net/kml/2.2")]
[System.Xml.Serialization.XmlRootAttribute("PhotoOverlay", Namespace="http://www.opengis.net/kml/2.2", IsNullable=false)]
public partial class PhotoOverlayType : AbstractOverlayType {
    
    private double rotationField;
    
    private bool rotationFieldSpecified;
    
    private ViewVolumeType viewVolumeField;
    
    private ImagePyramidType imagePyramidField;
    
    private PointType pointField;
    
    private shapeEnumType shapeField;
    
    private bool shapeFieldSpecified;
    
    private string[] photoOverlaySimpleExtensionGroupField;
    
    private AbstractObjectType[] photoOverlayObjectExtensionGroupField;
    
    public PhotoOverlayType() {
        this.rotationField = 0D;
        this.shapeField = shapeEnumType.rectangle;
    }
    
    /// <remarks/>
    public double rotation {
        get {
            return this.rotationField;
        }
        set {
            this.rotationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool rotationSpecified {
        get {
            return this.rotationFieldSpecified;
        }
        set {
            this.rotationFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public ViewVolumeType ViewVolume {
        get {
            return this.viewVolumeField;
        }
        set {
            this.viewVolumeField = value;
        }
    }
    
    /// <remarks/>
    public ImagePyramidType ImagePyramid {
        get {
            return this.imagePyramidField;
        }
        set {
            this.imagePyramidField = value;
        }
    }
    
    /// <remarks/>
    public PointType Point {
        get {
            return this.pointField;
        }
        set {
            this.pointField = value;
        }
    }
    
    /// <remarks/>
    public shapeEnumType shape {
        get {
            return this.shapeField;
        }
        set {
            this.shapeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool shapeSpecified {
        get {
            return this.shapeFieldSpecified;
        }
        set {
            this.shapeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PhotoOverlaySimpleExtensionGroup")]
    public string[] PhotoOverlaySimpleExtensionGroup {
        get {
            return this.photoOverlaySimpleExtensionGroupField;
        }
        set {
            this.photoOverlaySimpleExtensionGroupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PhotoOverlayObjectExtensionGroup")]
    public AbstractObjectType[] PhotoOverlayObjectExtensionGroup {
        get {
            return this.photoOverlayObjectExtensionGroupField;
        }
        set {
            this.photoOverlayObjectExtensionGroupField = value;
        }
    }
}
