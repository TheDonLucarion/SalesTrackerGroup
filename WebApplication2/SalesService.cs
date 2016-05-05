using System;
using System.Collections.Generic;
using System.Linq;
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
                                    Date = e.Date,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
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
                    Date = entity.Date,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Address = entity.Address,
                    SalesPrice = entity.SalesPrice,
                    TotalCommission = entity.TotalCommission,
                    ThirdPartyReferral = entity.ThirdPartyReferral,
                    RoyaltyFee = entity.RoyaltyFee,
                    AgentSplit = entity.AgentSplit,
                    ReloSplit = entity.ReloSplit,
                    Base = entity.Base,
                    APCF = entity.APCF,
                    EnrollPCC = entity.EnrollPCC,
                    CharitbaleContribution = entity.CharitbaleContribution,
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
                        Date = vm.Date,
                        FirstName = vm.FirstName,
                        LastName = vm.LastName,
                        Address = vm.Address,
                        SalesPrice = vm.SalesPrice,
                        TotalCommission = vm.TotalCommission,
                        ThirdPartyReferral = vm.ThirdPartyReferral,
                        RoyaltyFee = vm.RoyaltyFee,
                        AgentSplit = vm.AgentSplit,
                        ReloSplit = vm.ReloSplit,
                        Base = vm.Base,
                        APCF = vm.APCF,
                        EnrollPCC = vm.EnrollPCC,
                        CharitbaleContribution = vm.CharitbaleContribution,
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
                entity.FirstName = vm.FirstName;
                entity.LastName = vm.LastName;
                entity.Address = vm.Address;
                entity.SalesPrice = vm.SalesPrice;
                entity.TotalCommission = vm.TotalCommission;
                entity.ThirdPartyReferral = vm.ThirdPartyReferral;
                entity.RoyaltyFee = vm.RoyaltyFee;
                entity.AgentSplit = vm.AgentSplit;
                entity.ReloSplit = vm.ReloSplit;
                entity.Base = vm.Base;
                entity.APCF = vm.APCF;
                entity.EnrollPCC = vm.EnrollPCC;
                entity.CharitbaleContribution = vm.CharitbaleContribution;
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
