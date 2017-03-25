using QuranX.DomainLayer.DataModel;
using System.Data.Entity;

namespace QuranX.DomainLayer.ServicesImpl
{
	public class ObjectSpace : DbContext
	{
		public ObjectSpace() : base("DefaultConnection") { }

		public DbSet<Chapter> Chapters { get; set; }
	}
}
