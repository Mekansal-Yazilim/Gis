using NetTopologySuite.Geometries;

namespace Gis.Core.BaseLibrary.Interfaces;

public interface IHasLineString : IGisEntity
{
    new LineString Geometry { get; set; }
}
