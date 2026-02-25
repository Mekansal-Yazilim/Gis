using Gis.Core.BaseLibrary.Dtos;

namespace Gis.Core.BaseLibrary.Interfaces;

public interface IFeatureProvider
{
    string CollectionName { get; }
    Task<IEnumerable<FeatureDto>> GetFeatureAsync(int limit, double?[] bbox);
}