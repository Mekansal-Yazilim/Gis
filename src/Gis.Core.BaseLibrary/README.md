# Gis.Core.BaseLibrary

GIS Base Library

## 🚀 Designed for Use ABP Framework

This package is specifically built to be used with the ABP Framework, ensuring seamless integration with its modular architecture.

### Install

```bash

dotnet add package Gis.Core.BaseLibrary
```

### Modulde yayınlanacak FeatureDto yapısı
```bash
using OgcApi.Base;

namespace ModuleName.Application
{
    public class EntityFeatureDto : FeatureDto (ParselFeatureDto, BuildingFeatureDto gibi)
    {
        public string Name
        {
            get => Properties.ContainsKey("name") ? Properties["name"]!.ToString()! : "";
            set => Properties["name"] = value;
        }

        public double Height
        {
            get => Properties.ContainsKey("height") ? Convert.ToDouble(Properties["height"]) : 0;
            set => Properties["height"] = value;
        }
    }
}

```

### Modul Provider Servisi 
```bash
using OgcApi.Base;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using NetTopologySuite.Geometries;

namespace ModuleEntity.Application
{
    public class BuildingFeatureProvider : IFeatureProvider
    {
        private readonly IRepository<Building, Guid> _repo;

        public BuildingFeatureProvider(IRepository<Building, Guid> repo)
        {
            _repo = repo;
        }

        public string CollectionName => "collectionname"; (bina, parsel gibi)

        public async Task<IEnumerable<FeatureDto>> GetFeaturesAsync(int limit = 100, double?[]? bbox = null)
        {
            var query = await _repo.GetQueryableAsync();

            if (bbox != null && bbox.Length == 4)
            {
                var envelope = new Envelope(bbox[0].Value, bbox[2].Value, bbox[1].Value, bbox[3].Value);
                var polygon = new Polygon(new LinearRing(new[]
                {
                    new Coordinate(envelope.MinX, envelope.MinY),
                    new Coordinate(envelope.MaxX, envelope.MinY),
                    new Coordinate(envelope.MaxX, envelope.MaxY),
                    new Coordinate(envelope.MinX, envelope.MaxY),
                    new Coordinate(envelope.MinX, envelope.MinY)
                }));

                query = query.Where(b => b.Geometry.Intersects(polygon));
            }

            var data = await query.Take(limit).ToListAsync();

            return data.Select(b => new EntityFeatureDto (ParselFeatureDto Bina FeatureDto Gibi)
            {
                Id = b.Id.ToString(),
                Geometry = b.Geometry,
                Name = b.Name,
                Height = b.Height
            });
        }
    }
}
```
