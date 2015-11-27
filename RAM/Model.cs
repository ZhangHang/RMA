using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM
{
    #region Carrier

    [Serializable]
    public sealed class Carrier : Object
    {
        /*
         * RMA must be able to manage the carrier information. Each carrier has a four character SCAC and name.
         * A carrier's SCAC is unique to that carrier.
         * Users should be able to view all of the carriers in the system, add new carriers, edit existing ca-
         * rriers, and delete existing carriers. Deleting a carrier should also delete all rates for that car-
         * rier.
         */

        public string SCAC; //  four characters, Primary ID
        public string Name; //  four characters
        private List<Rate> Rates = new List<Rate>();

        #region
        public bool AddRate(Rate newRate)
        {
            if (Rates.Contains(newRate))
            {
                return false;
            }
            Rates.Add(newRate);
            return true;
        }
        public bool RemoveRate(Rate oldRate)
        {
            if (Rates.Contains(oldRate))
            {
                Rates.Remove(oldRate);
                return true;
            }
            return false;
        }
        #endregion

        #region
        public override bool Equals(object obj)
        {
            if (obj is Carrier)
            {
                return (obj as Carrier).SCAC == SCAC;
            }
            return base.Equals(obj);
        }
        #endregion
    }

    #endregion

    #region Region

    [Serializable]
    public sealed class Region : Object
    {
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

        #region
        public override bool Equals(object obj)
        {
            if (obj is Carrier)
            {
                Region objToCompare = obj as Region;
                return objToCompare.XAxis == XAxis
                    && objToCompare.YAxis == YAxis;
            }
            return base.Equals(obj);
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

        public Region OriginRegion;
        public Region DestinationRegion;
        abstract public double Cost { get; }

        public Rate(Region origin, Region destination)
        {
            OriginRegion = origin;
            DestinationRegion = destination;
        }
        
        internal double Distance()
        {
            return OriginRegion.DistanceBetween(DestinationRegion);
        }
    }

    [Serializable]
    public sealed class FlatRate : Rate
    {
        private double Totalcost;

        public FlatRate(Region origin, Region destination, double totalcost) : base(origin, destination)
        {
            Totalcost = totalcost;
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
        private double CostPerMile;

        public UnflatRate(Region origin, Region destination, double costPerMile) : base(origin, destination)
        {
            CostPerMile = costPerMile;
        }

        public override double Cost
        {
            get
            {
                return CostPerMile * Distance();
            }
        }
    }

    #endregion
}
