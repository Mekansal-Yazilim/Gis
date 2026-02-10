using NetTopologySuite.Geometries;

namespace Gis.Core.BaseLibrary.Interfaces;

public interface IGisEntity
{
    Geometry Geometry { get; }
}
