namespace Gis.Core.BaseLibrary.Dtos;

public class FeatureDto
{
    public object Geometry { get; set; }
    public Dictionary<string, object> Properties { get; set; } = new();
}