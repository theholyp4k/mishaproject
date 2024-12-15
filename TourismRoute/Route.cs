using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismRoute
{
    internal class Routes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lenght { get; set; }

        public Routes(int Id, string Name, string Lenght)
        { this.Id = Id; this.Name = Name; this.Lenght = Lenght; }

        public Routes()
        {
        }

        internal object ShowDialog()
        {
            // todo
            return null;
        }
    }
}
