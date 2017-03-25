using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranX.DomainLayer.ServicesImpl
{
	public class ObjectSpace : DbContext
	{
		public ObjectSpace() : base("DefaultConnection") { }
	}
}
