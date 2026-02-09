using Gis.Core.BaseLibrary.Helpers;
using NetTopologySuite.Geometries;

namespace Gis.Core.BaseLibrary.Extensions;

public static class GisGeometryExtensions
{
    public static string ToWkt(this Geometry? geometry) => GisHelper.GeometryToWkt(geometry);

    public static bool IntersectsWith(this Geometry g1, Geometry g2) => g1.Intersects(g2);

    public static Geometry? GetIntersection(this Geometry g1, Geometry g2) =>
        GisHelper.Intersect(g1, g2);

    public static Geometry GetDifferenceFrom(this Geometry geom1, Geometry geom2) =>
        GisHelper.GetDifference(geom1, geom2);

    public static Geometry CreateBuffer(this Geometry geometry, double distance) =>
        GisHelper.CreateBuffer(geometry, distance);

    public static double DistanceTo(this Geometry geom1, Geometry geom2) =>
        GisHelper.CalculateDistance(geom1, geom2);
}
