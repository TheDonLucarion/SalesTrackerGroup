
using SalesTracker.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SalesTracker.BusinessLogic
{
    public class CommissionLogic
    {
        ICommissionLogicVars Vars = new ICommissionLogicVars();
        List<float> Numbers;

        public CommissionLogic(double SalesPrice, float TotalCommission, double ThirdPartyReferral, float RoyaltyFee, float AgentSplit, float ReloSplit, float Base, float APCF, float EnrollPCC, float CharitbaleContribution)
        {
            Vars.SalesPrice = SalesPrice;
            Vars.TotalCommission = TotalCommission;
            Vars.ThirdPartyReferral = ThirdPartyReferral;
            Vars.RoyaltyFee = RoyaltyFee;
            Vars.AgentSplit = AgentSplit;
            Vars.ReloSplit = ReloSplit;
            Vars.Base = Base;
            Vars.APCF = APCF;
            Vars.EnrollPCC = EnrollPCC;
            Vars.CharitbaleContribution = CharitbaleContribution;

            Numbers = new List<float>(new float[] { Vars.TotalCommission, Vars.RoyaltyFee, Vars.AgentSplit, Vars.ReloSplit, Vars.Base, Vars.APCF, Vars.EnrollPCC, Vars.CharitbaleContribution });
        }

        public double DoMath()
        {
            var Commission = 0;

            //Converts them to percentages
            Vars.RoyaltyFee /= 100;
            Vars.ThirdPartyReferral /= 100;
            Vars.ReloSplit /= 100;
            Vars.AgentSplit /= 100;
            Vars.Base /= 100;

            Commission = Vars.TotalCommission - (Vars.TotalCommission * Vars.ThirdPartyReferral);
            Commission = Commission - (Commission * Vars.RoyaltyFee);
            Commission = Commission - (Commission * Vars.AgentSplit);
            Commission = Commission - (Commission * Vars.ReloSplit);
            Commission = Commission - (Commission * Vars.Base);
            Commission -= Vars.APCF;
            Commission -= Vars.EnrollPCC;
            Commission -= Vars.CharitbaleContribution;


            return Commission;
        }
    }
}