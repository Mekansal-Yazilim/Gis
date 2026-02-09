using Gis.Core.BaseLibrary.Interfaces;
using NetTopologySuite.Geometries;
using Volo.Abp.Domain.Entities;

namespace Gis.Core.BaseLibrary.Features;

public abstract class GeoMultiLineStringBase<TKey> : Entity<TKey>, IHasMultiLineString
{
    public virtual MultiLineString Geometry { get; set; } = default!;

    public virtual double GetTotalLength() => Geometry?.Length ?? 0;

    public virtual int LineCount => Geometry?.NumGeometries ?? 0;

    Geometry IGisEntity.Geometry => Geometry;

    public virtual LineString? GetLine(int index) => Geometry?.GetGeometryN(index) as LineString;
}
