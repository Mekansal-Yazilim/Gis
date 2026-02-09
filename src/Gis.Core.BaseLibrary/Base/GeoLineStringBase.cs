using Gis.Core.BaseLibrary.Interfaces;
using NetTopologySuite.Geometries;
using Volo.Abp.Domain.Entities;

namespace Gis.Core.BaseLibrary.Features;

public abstract class GeoLineStringBase<TKey> : Entity<TKey>, IHasLineString
{
    public virtual LineString Geometry { get; set; } = default!;

    public virtual double GetLength() => Geometry?.Length ?? 0;

    public virtual Point? GetStartPoint() => Geometry?.StartPoint;

    public virtual Point? GetEndPoint() => Geometry?.EndPoint;

    public virtual int PointCount => Geometry?.NumPoints ?? 0;

    Geometry IGisEntity.Geometry => Geometry;
}
