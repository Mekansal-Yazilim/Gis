using NetTopologySuite.Geometries;

namespace Gis.Core.BaseLibrary.Interfaces;

public interface IHasGeoPolygon : IGisEntity
{
    new Polygon Geometry { get; set; }
}
