using NetTopologySuite.Geometries;

namespace Gis.Core.BaseLibrary.Interfaces;

public interface IHasGeoPoint : IGisEntity
{
    new Point Geometry { get; set; }
}
