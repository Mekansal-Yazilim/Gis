using NetTopologySuite.Geometries;

namespace Gis.Core.BaseLibrary.Interfaces;

public interface IHasMultiLineString : IGisEntity
{
    new MultiLineString Geometry { get; set; }
}
