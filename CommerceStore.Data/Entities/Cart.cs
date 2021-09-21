using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceStore.Data.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public IList<CartLine> CartLines { get; set; }
    }
}
