using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM.Model
{
    [Serializable]
    public sealed class Region : Object, ICRUD
    {
        public static Store<Region> Store = new Store<Region>("RegionStore");

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

            if (Store.Items.Where(x => x.ShortName == ShortName).Count() > 0)
            {
                throw new Exception("Duplicated ShortName");
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
                throw new Exception("Region is not in the store");
            }

            Store.Items.Remove(this);
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
}
