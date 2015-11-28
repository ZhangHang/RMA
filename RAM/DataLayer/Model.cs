using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM
{
    interface ICRUD
    {
        void Insert();
        void UpdateValidation();
        void Delete();
    }

    #region Carrier

    [Serializable]
    public sealed class Carrier : Object, ICRUD
    {
        public static Store<Carrier> store = new Store<Carrier>("CarrierStore");

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

            if (store.Items.Where(x => x.SCAC == SCAC).Count() > 0)
            {
                throw new Exception("Duplicated SCAC");
            }

            store.Items.Add(this);
        }

        public void UpdateValidation()
        {
            Common_Validation();
        }

        public void Delete()
        {
            if (!store.Items.Contains(this))
            {
                throw new Exception("Carrier is not in the store");
            }

            store.Items.Remove(this);
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

    #endregion

    #region Region

    [Serializable]
    public sealed class Region : Object, ICRUD
    {
        public static Store<Region> store = new Store<Region>("RegionStore");

        /*
         * Regions are used to define rates. They represent a broad geographical area. Its up to you how to d-
         * efine the region, but they must have a short region name and a description. RMA must let users vie-
         * w all regions and add new regions.
         */
        public string ShortName;
        public string Description;

        public double XAxis;
        public double YAxis;

        public double DistanceBetween(Region anotherRegion)
        {
            return Math.Sqrt(
                Math.Pow(anotherRegion.XAxis - XAxis, 2) +
                Math.Pow(anotherRegion.YAxis - YAxis, 2)
                );
        }

        #region CRUD
        public void Insert()
        {
            Common_Validation();

            if (store.Items.Where(x => x.ShortName == ShortName).Count() > 0)
            {
                throw new Exception("Duplicated ShortName");
            }

            store.Items.Add(this);
        }

        public void UpdateValidation()
        {
            Common_Validation();
        }

        public void Delete()
        {
            if (!store.Items.Contains(this))
            {
                throw new Exception("Region is not in the store");
            }

            store.Items.Remove(this);
        }

        private void Common_Validation()
        {
            if (Description.Length == 0 || ShortName.Length == 0)
            {
                throw new Exception("Description & ShortName can't be empty");
            }
        }
        #endregion
    }

    #endregion

    #region Rate

    [Serializable]
    public abstract class Rate : Object
    {
        /*
         * Rates are defined by carrier and have an origin and destination region and a cost per mile and/ or
         * a flat rate. A per mile rate must be less than $10 and a minimum/flat rate must be no more than $-
         * 2000. Multiple carriers can have rates in the same lane, but each carrier can only have one rate
         * per lane. Users should be able to view all rates in the system, add new rates, edit existing rate-
         * s, and delete existing rates.
         */

        public string OriginRegionShortName;
        public string DestinationRegionShortName;
        public Region OriginRegion
        {
            get
            {
                return Region.store.Items.Where(x => x.ShortName == OriginRegionShortName).First();
            }
        }
        public Region DestinationRegion
        {
            get
            {
                return Region.store.Items.Where(x => x.ShortName == DestinationRegionShortName).First();
            }
        }
        abstract public double Cost { get; }
        abstract public String Description { get; }
        internal Double Distance
        {
            get
            {
                return OriginRegion.DistanceBetween(DestinationRegion);
            }
        }

        public Rate(Region origin, Region destination)
        {
            OriginRegionShortName = origin.ShortName;
            DestinationRegionShortName = destination.ShortName;
        }

        public Rate(string originShortName, string destinationShortName)
        {
            OriginRegionShortName = originShortName;
            DestinationRegionShortName = destinationShortName;
        }
    }

    [Serializable]
    public sealed class FlatRate : Rate
    {
        public double Totalcost;

        public FlatRate(Region origin, Region destination, double totalcost) : base(origin, destination)
        {
            if (totalcost < 0 || totalcost > 2000)
            {
                throw new Exception("Cost has to be $0 ~ $2000");
            }
            Totalcost = totalcost;
        }

        public FlatRate(string origin, string destination, double totalcost) : base(origin, destination)
        {
            if (totalcost < 0 || totalcost > 2000)
            {
                throw new Exception("Cost has to be $0 ~ $2000");
            }
            Totalcost = totalcost;
        }

        public override string Description
        {
            get
            {
                return String.Format("{0} to {1}, ${2} (${3} flat rate)", OriginRegionShortName, DestinationRegionShortName, Cost, Totalcost);
            }
        }

        public override double Cost
        {
            get
            {
                return Totalcost;
            }
        }
    }

    [Serializable]
    public sealed class UnflatRate : Rate
    {
        public double CostPerMile;

        public UnflatRate(Region origin, Region destination, double costPerMile) : base(origin, destination)
        {
            if (costPerMile < 0 || costPerMile > 10)
            {
                throw new Exception("Cost has to be $0 ~ $10 per mile");
            }
            CostPerMile = costPerMile;
        }

        public UnflatRate(string origin, string destination, double costPerMile) : base(origin, destination)
        {
            if (costPerMile < 0 || costPerMile > 10)
            {
                throw new Exception("Cost has to be $0 ~ $10 per mile");
            }
            CostPerMile = costPerMile;
        }

        public override double Cost
        {
            get
            {
                return CostPerMile * Distance;
            }
        }

        public override string Description
        {
            get
            {
                return String.Format("{0} to {1}, ${2} (${3}/mile unflat rate)", OriginRegionShortName, DestinationRegionShortName, Cost, CostPerMile);
            }
        }
    }

    #endregion
}
