using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesTracker.Data;
using WebApplication1;

namespace ElevenNote.Services
{
    public class SalesService
    {
        private readonly Guid _userId;

        public SalesService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<SalesViewModel> GetSales()
        {
            using (var ctx = new SalesTrackerDbContext())
            {
                return
                    ctx
                        .Sales
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SalesViewModel
                                {
                                    SalesId = e.SalesId,
                                    Title = e.Title,
                                    Date = e.Date,
                                    Client = e.Client,
                                    Address = e.Address,
                                    SalesPrice = e.SalesPrice,
                                    Commission = e.Commission,
                                    Source = e.Source
                                })
                        .ToArray();
            }
        }

        public SalesDetailModel GetSalesById(int salesId)
        {
            SalesData entity;

            using (var ctx = new SalesTrackerDbContext())
            {
                entity =
                    ctx
                        .Sales
                        .SingleOrDefault(e => e.OwnerId == _userId && e.SalesId == salesId);
            }

            // TODO: Handle note not found

            return
                new SalesDetailModel
                {
                    SalesId = entity.SalesId,
                    Title = entity.Title,
                    Date = entity.Date,
                    Client = entity.Client,
                    Address = entity.Address,
                    SalesPrice = entity.SalesPrice,
                    Commission = entity.Commission,
                    Source = entity.Source
                };
        }

        public bool CreateSales(SalesCreateData vm)
        {
            using (var ctx = new SalesTrackerDbContext())
            {
                var entity =
                    new SalesData
                    {
                        OwnerId = _userId,
                        Title = vm.Title,
                        Date = vm.Date,
                        Client = vm.Client,
                        Address = vm.Address,
                        SalesPrice = vm.SalesPrice,
                        Commission = vm.Commission,
                        Source = vm.Source
                    };

                ctx.Sales.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateSales(SalesEditModel vm)
        {
            using (var ctx = new SalesTrackerDbContext())
            {
                var entity =
                    ctx
                        .Sales
                        .SingleOrDefault(e => e.OwnerId == _userId && e.SalesId == vm.SalesId);

                // TODO: Handle note not found

                entity.SalesId = vm.SalesId;
                entity.Date = vm.Date;
                entity.Client = vm.Client;
                entity.Address = vm.Address;
                entity.SalesPrice = vm.SalesPrice;
                entity.Commission = vm.Commission;
                entity.Source = vm.Source;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSales(int salesId)
        {
            using (var ctx = new SalesTrackerDbContext())
            {
                var entity =
                    ctx
                        .Sales
                        .SingleOrDefault(e => e.OwnerId == _userId && e.SalesId == salesId);

                // TODO: Handle note not found

                ctx.Sales.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
