using Gis.Core.BaseLibrary.Interfaces;
using NetTopologySuite.Geometries;
using Volo.Abp.Domain.Entities;

namespace Gis.Core.BaseLibrary.Base;

public abstract class GeoPointBase<Tkey> : Entity<Tkey>, IHasGeoPoint
{
    public virtual Point Geometry { get; set; } = default!;

    public virtual double X => Geometry?.X ?? 0;

    public virtual double Y => Geometry?.Y ?? 0;

    Geometry IGisEntity.Geometry => Geometry;
}
