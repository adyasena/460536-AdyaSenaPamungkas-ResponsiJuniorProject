using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responsi_2
{
    internal class Departemen
    {
        private string _id_dep;
        private string _nama_dep;
        
        public string IdDep
        {
            get { return _id_dep; }
            set { _id_dep = value; }
        }
        public string NamaDep
        {
            get { return _nama_dep; }
            set { _nama_dep = value; }
        }

        public Departemen() { }
        public Departemen(string IdDep, string NamaDep)
        {
            _id_dep = IdDep;
            _nama_dep = NamaDep;
        }
    }
}
