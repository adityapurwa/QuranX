namespace QuranX.DomainLayer.Services
{
	public interface IServiceRegistration
	{
		void Register<TService, TImplementation>() where TImplementation : TService;
	}
}
