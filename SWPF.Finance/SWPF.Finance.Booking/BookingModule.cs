using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace SWPF.Finance.Booking
{
    public class BookingModule : IModule
    {
        private IRegionManager _regionManager;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager = containerProvider.Resolve<IRegionManager>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}