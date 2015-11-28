using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM.Model
{
    interface ICRUD
    {
        void Insert();
        void UpdateValidation();
        void Delete();
    }
}
