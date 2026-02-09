using NetTopologySuite.Geometries;

namespace Gis.Core.BaseLibrary.Interfaces;

public interface IHasMultiPolygon : IGisEntity
{
    new MultiPolygon Geometry { get; set; }
}
