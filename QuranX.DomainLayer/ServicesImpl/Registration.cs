using QuranX.DomainLayer.Services;

namespace QuranX.DomainLayer.ServicesImpl
{
	public static class Registration
	{
		public static void Register(IServiceRegistration serviceRegistration)
		{
			serviceRegistration.Register<ObjectSpace, ObjectSpace>();
		}
	}
}
