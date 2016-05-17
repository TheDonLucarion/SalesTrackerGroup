using System.Collections.Generic;

namespace SalesTracker.BusinessLogic
{
    public class CommissionLogic
    {
        ICommissionLogicVars Vars = new ICommissionLogicVars();

        public CommissionLogic(decimal SalesPrice, decimal TotalCommission, decimal ThirdPartyReferral, decimal RoyaltyFee, decimal AgentSplit, decimal ReloSplit, decimal Base, decimal APCF, decimal EnrollPCC, decimal CharitbaleContribution, decimal CommPercentage)
        {
            Vars.SalesPrice = SalesPrice;
            Vars.CommPercentage = CommPercentage;
            Vars.TotalCommission = TotalCommission;
            Vars.ThirdPartyReferral = ThirdPartyReferral;
            Vars.RoyaltyFee = RoyaltyFee;
            Vars.AgentSplit = AgentSplit;
            Vars.ReloSplit = ReloSplit;
            Vars.Base = Base;
            Vars.APCF = APCF;
            Vars.EnrollPCC = EnrollPCC;
            Vars.CharitbaleContribution = CharitbaleContribution;
        }

        public decimal DoMath()
        {
            decimal Commission = 0;


            //Converts them to percentages
            if (Vars.CommPercentage != 0)
                Vars.CommPercentage /= 100;
            if (Vars.RoyaltyFee != 0)
                Vars.RoyaltyFee /= 100;
            if (Vars.ThirdPartyReferral != 0)
                Vars.ThirdPartyReferral /= 100;
            if (Vars.ReloSplit != 0)
                Vars.ReloSplit /= 100;
            if (Vars.AgentSplit != 0)
                Vars.AgentSplit /= 100;
            if (Vars.Base != 0)
                Vars.Base /= 100;

            if (Vars.SalesPrice != 0 && Vars.CommPercentage != 0)
                Commission = Vars.SalesPrice * Vars.CommPercentage;

            if (Vars.ThirdPartyReferral != 0)
                Commission = Commission - (Commission * Vars.ThirdPartyReferral);

            if (Vars.RoyaltyFee != 0)
                Commission = Commission - (Commission * Vars.RoyaltyFee);

            if (Vars.AgentSplit != 0)
                Commission = Commission - (Commission * Vars.AgentSplit);

            if (Vars.ReloSplit != 0)
                Commission = Commission - (Commission * Vars.ReloSplit);

            if (Vars.Base != 0)
                Commission = Commission - (Commission * Vars.Base);

            if (Vars.APCF != 0)
                Commission -= Vars.APCF;

            if (Vars.EnrollPCC != 0)
                Commission -= Vars.EnrollPCC;

            if (Vars.CharitbaleContribution != 0)
                Commission -= Vars.CharitbaleContribution;


            return Commission;
        }
    }
}