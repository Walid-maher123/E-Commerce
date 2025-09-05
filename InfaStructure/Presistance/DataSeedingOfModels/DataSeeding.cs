using DomainLayer;
using DomainLayer.Entities.OrderModels;
using DomainLayer.Entities.ProductsModels;
using DomainLayer.IDataSeedingOfModels;
using Microsoft.Extensions.Logging;
using Presistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistance.DataSeedingOfModels.DataSeeding
{
    public class DataSeeding : IDataSeeding
    {
        private readonly StoreDbContext _storedbcontect;
        private readonly ILogger<DataSeeding> _logger;

        public DataSeeding(StoreDbContext storedbcontect, ILogger<DataSeeding> logger)
        {
            _storedbcontect = storedbcontect;
            _logger = logger;
        }
        public async Task DataSeedAsync()
        {
            try
            {
                var Getpend = await _storedbcontect.Database.GetPendingMigrationsAsync();
                if (Getpend.Any())
                {
                    await _storedbcontect.Database.MigrateAsync();
                }

                if (!_storedbcontect.Brands.Any())
                {
                    var ReadData = File.OpenRead(@"..\InfaStructure\Presistance\Data\brands.json");
                    var Data = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ReadData);
                    if (Data != null && Data.Any())
                        _storedbcontect.Brands.AddRange(Data);
                }

                if (!_storedbcontect.Types.Any())
                {
                    var ReadData = File.OpenRead(@"..\InfaStructure\Presistance\Data\types.json");
                    var Data = await JsonSerializer.DeserializeAsync<List<ProductType>>(ReadData);
                    if (Data != null && Data.Any())
                       _storedbcontect.Types.AddRange(Data);

                }

                if (!_storedbcontect.Products.Any())
                {
                    var ReadData = File.OpenRead(@"..\InfaStructure\Presistance\Data\products.json");
                    var Data = await JsonSerializer.DeserializeAsync<List<Product>>(ReadData);
                    if (Data != null)
                        _storedbcontect.Products.AddRange(Data);
                }
                if (!_storedbcontect.DeliveryMethods.Any())
                {
                    var ReadData = File.OpenRead(@"..\InfaStructure\Presistance\Data\delivery.json");
                    var Data = await JsonSerializer.DeserializeAsync<List<DeliveryMethod>>(ReadData);
                    if (Data != null)
                        _storedbcontect.DeliveryMethods.AddRange(Data);
                }
                await _storedbcontect.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                {
                    _logger.LogError(ex, "Some Errors");
                }
            }
        }
    }
}
