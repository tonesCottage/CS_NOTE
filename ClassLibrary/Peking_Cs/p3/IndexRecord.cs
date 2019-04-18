using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.PRACTICE.p3
{
    class IndexRecord
    {
        private string[] data;
        public string this[int index]
        {
            set
            {
                if (index > -1 && index < data.Length - 1)
                    data[index] = value;
            }
            get
            {
                if (index > -1 && index < data.Length - 1)
                    return data[index];
                return null;
            }
        }
    }
}
