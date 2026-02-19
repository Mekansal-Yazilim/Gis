namespace Gis.Core.BaseLibrary.OGC;

public class OgcSourceConfiguration
{
    public string Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Table { get; set; } = default!;
    public string GeometryColumn { get; set; } = "Geometry";
    public string IdentifierColumn { get; set; } = "Id";
    
    public bool AllowCreate { get; set; }
    public bool AllowUpdate { get; set; }
    public bool AllowDelete { get; set; }
}