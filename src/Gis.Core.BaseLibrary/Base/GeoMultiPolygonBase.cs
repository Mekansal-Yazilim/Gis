using Gis.Core.BaseLibrary.Interfaces;
using NetTopologySuite.Geometries;
using Volo.Abp.Domain.Entities;

namespace Gis.Core.BaseLibrary.Features;

public abstract class GeoMultiPolygonBase<TKey> : Entity<TKey>, IHasMultiPolygon
{
    public virtual MultiPolygon Geometry { get; set; } = default!;

    public virtual double GetTotalArea() => Geometry?.Area ?? 0;

    public virtual int PolygonCount => Geometry?.NumGeometries ?? 0;

    public virtual bool IsValid => Geometry?.IsValid ?? false;

    Geometry IGisEntity.Geometry => Geometry;

    public virtual double GetPerimeter() => Geometry?.Length ?? 0;
}
