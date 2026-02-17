using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace Gis.Core.BaseLibrary.Helpers;



public static class GisHelper
{

    private static readonly WKTReader _wktReader = new WKTReader();
    private static readonly WKTWriter _wktWriter = new WKTWriter();

    public static Geometry? WktToGeometry(string wkt, int srid = 4326)
    {
        if (string.IsNullOrWhiteSpace(wkt))
            return null;
        var geometry = _wktReader.Read(wkt);
        if (geometry != null)
            geometry.SRID = srid;
        return geometry;
    }

    public static string GeometryToWkt(Geometry? geometry)
    {
        if (geometry == null)
            return string.Empty;
        return _wktWriter.Write(geometry);
    }

    public static Geometry? Intersect(Geometry g1, Geometry g2) => g1.Intersection(g2);

    public static bool IsValid(Geometry geometry) => geometry is { IsValid: true };

    public static Geometry GetUnion(Geometry geom1, Geometry geom2)
    {
        return geom1.Union(geom2);
    }

    public static bool IsPointInPolygon(Point point, Polygon polygon)
    {
        return polygon.Contains(point);
    }

    public static Geometry GetDifference(Geometry geom1, Geometry geom2)
    {
        return geom1.Difference(geom2);
    }

    public static Geometry CreateBuffer(Geometry geometry, double distance) =>
        geometry.Buffer(distance);

    public static double CalculateDistance(Geometry geom1, Geometry geom2) => geom1.Distance(geom2);
}
