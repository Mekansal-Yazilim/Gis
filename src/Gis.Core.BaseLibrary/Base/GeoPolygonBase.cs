using Gis.Core.BaseLibrary.Interfaces;
using NetTopologySuite.Geometries;
using Volo.Abp.Domain.Entities;

namespace Gis.Core.BaseLibrary.Base;

public abstract class GeoPolygonBase<TKey> : AggregateRoot<TKey>, IHasGeoPolygon
{
    public virtual Polygon Geometry { get; set; } = default!;

    public virtual double CalculateArea() => Geometry?.Area ?? 0;

    public virtual bool IsValid() => Geometry?.IsValid ?? false;

    public virtual int PointCount => Geometry?.NumPoints ?? 0;

    Geometry IGisEntity.Geometry => Geometry;

    public virtual double GetPerimeter() => Geometry?.Length ?? 0;
}
