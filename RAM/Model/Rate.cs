using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM.Model
{

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
                return Region.Store.Items.Where(x => x.ShortName == OriginRegionShortName).First();
            }
        }
        public Region DestinationRegion
        {
            get
            {
                return Region.Store.Items.Where(x => x.ShortName == DestinationRegionShortName).First();
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
}
