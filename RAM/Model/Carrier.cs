using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMA.Model
{
    [Serializable]
    public sealed class Carrier : Object, ICRUD
    {
        public static Store<Carrier> Store = new Store<Carrier>("CarrierStore");

        /*
         * RMA must be able to manage the carrier information. Each carrier has a four character SCAC and name.
         * A carrier's SCAC is unique to that carrier.
         * Users should be able to view all of the carriers in the system, add new carriers, edit existing ca-
         * rriers, and delete existing carriers. Deleting a carrier should also delete all rates for that car-
         * rier.
         */

        public string SCAC; //  four characters, Primary ID
        public string Name; //  four characters
        public List<Rate> Rates = new List<Rate>();

        #region
        public bool HasRate(string originRegionShortName, string destinationRegionShortName)
        {
            return Rates.Where(x => x.DestinationRegionShortName == destinationRegionShortName
            && x.OriginRegionShortName == originRegionShortName).Count() > 0;
        }

        public void AddRate(Rate newRate)
        {
            if (HasRate(newRate.OriginRegionShortName, newRate.DestinationRegionShortName))
            {
                throw new Exception("Each carrier can only have one rate per lane");
            }

            Rates.Add(newRate);
        }

        public void RemoveRate(Rate oldRate)
        {
            if (!Rates.Contains(oldRate))
            {
                throw new Exception("Rate not found");
            }
            Rates.Remove(oldRate);

        }
        #endregion

        #region CRUD 
        public void Insert()
        {
            Common_Validation();

            if (Store.Items.Where(x => x.SCAC == SCAC).Count() > 0)
            {
                throw new Exception("Duplicated SCAC");
            }

            Store.Items.Add(this);
        }

        public void UpdateValidation()
        {
            Common_Validation();
        }

        public void Delete()
        {
            if (!Store.Items.Contains(this))
            {
                throw new Exception("Carrier is not in the store");
            }

            Store.Items.Remove(this);
        }

        private void Common_Validation()
        {
            if (Name.Length == 0 || SCAC.Length == 0)
            {
                throw new Exception("Name & SCAC can't be empty");
            }

            if (SCAC.Length != 4)
            {
                throw new Exception("SCAC has to be 4 character long");
            }
        }
        #endregion
    }
}
