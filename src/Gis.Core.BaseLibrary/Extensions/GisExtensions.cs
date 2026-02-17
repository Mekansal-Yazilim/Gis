using Gis.Core.BaseLibrary.Helpers;
using NetTopologySuite.Geometries;
using NetTopologySuite.Index.Strtree;
using Gis.Core.BaseLibrary.Interfaces;
namespace Gis.Core.BaseLibrary.Extensions;

public class GisExtensions
{
    public static IEnumerable<TEntity> QueryIntersects<TEntity>(
         STRtree<TEntity> index, Geometry searchArea, Func<TEntity, bool> predicate) 
        where TEntity : IGisEntity 
        => QuerySpatial(index, searchArea, (geom, mask) => geom.Intersects(mask), predicate);

   
    public static IEnumerable<TEntity> QueryWithin<TEntity>(
         STRtree<TEntity> index, Geometry searchArea, Func<TEntity, bool> predicate) 
        where TEntity : IGisEntity 
        => QuerySpatial(index, searchArea, (geom, mask) => geom.Within(mask), predicate);

    
    public static IEnumerable<TEntity> QueryWithinBuffer<TEntity>(
         STRtree<TEntity> index, Geometry pointOrLine, double distance, Func<TEntity, bool> predicate) 
        where TEntity : IGisEntity
    {
        var bufferArea = pointOrLine.Buffer(distance);
        return QuerySpatial(index, bufferArea, (geom, mask) => geom.Intersects(mask), predicate);
    }

    
    private static IEnumerable<TEntity> QuerySpatial<TEntity>(
         STRtree<TEntity> index, 
        Geometry mask, 
        Func<Geometry, Geometry, bool> spatialOp,
        Func<TEntity, bool> predicate) 
        where TEntity : IGisEntity
    {
        var candidates = index.Query(mask.EnvelopeInternal);
        return candidates.Where(entity => 
            entity.Geometry != null && 
            spatialOp(entity.Geometry, mask) && 
            predicate(entity));
    }
}