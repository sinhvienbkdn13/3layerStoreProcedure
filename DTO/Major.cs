using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Major
    {
        private string majorid;
        private string namemajor;

        public string Majorid
        {
            get
            {
                return majorid;
            }

            set
            {
                majorid = value;
            }
        }

        public string Namemajor
        {
            get
            {
                return namemajor;
            }

            set
            {
                namemajor = value;
            }
        }
    }
}
