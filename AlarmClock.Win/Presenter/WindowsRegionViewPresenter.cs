using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlarmClock.Core;
using AlarmClock.Win.Presenter;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Exceptions;
using MvvmCross.WindowsUWP.Views;

namespace AlarmClock.Win.Presenter
{
    /// <summary>
    /// Inspired by: http://stackoverflow.com/questions/33131034/how-to-implement-a-custom-presenter-in-a-windows-uwp-xamarin-mvvmcross
    /// </summary>
    class WindowsRegionViewPresenter : MvxWindowsViewPresenter
    {
        private readonly IMvxWindowsFrame _rootFrame;

        public WindowsRegionViewPresenter(IMvxWindowsFrame rootFrame)
            : base(rootFrame)
        {
            _rootFrame = rootFrame;
        }

        public override async void Show(MvxViewModelRequest request)
        {
            if (RootHost != null)
            {
                var viewFinder = Mvx.Resolve<IMvxViewsContainer>();
                var viewType = viewFinder.GetViewType(request.ViewModelType);
                var regionAttribute = GetRegionAttribute(viewType);
                var hostContentFrame = FindHostContentFrame(regionAttribute?.HostType);
                var converter = Mvx.Resolve<IMvxNavigationSerializer>();
                var requestText = converter.Serializer.SerializeObject(request);
                hostContentFrame?.Navigate(viewType, requestText);
            }
        }

        private IRegionHost RootHost => _rootFrame.Content as IRegionHost;

        private IMvxWindowsFrame FindHostContentFrame(Type hostType)
        {
            if (hostType == null)
            {
                return _rootFrame;
            }
            return FindHostContentFrame(hostType, RootHost);
        }
        private IMvxWindowsFrame FindHostContentFrame(Type hostType, IRegionHost host)
        {
            if (host != null)
            {
                if (host.GetType() == hostType) return host.ContentFrame;
                else return FindHostContentFrame(hostType, host.ContentFrame.Content as IRegionHost);
            }
            return null;
        }

        private RegionAttribute GetRegionAttribute(Type viewType)
        {
            var regionAttribute = viewType.GetCustomAttributes(typeof(RegionAttribute), true).FirstOrDefault() as RegionAttribute;
            return regionAttribute;
        }

        public override void Close(IMvxViewModel viewModel)
        {
            var viewFinder = Mvx.Resolve<IMvxViewsContainer>();
            var viewType = viewFinder.GetViewType(viewModel.GetType());
            var regionAttribute = GetRegionAttribute(viewType);
            var hostContentFrame = FindHostContentFrame(regionAttribute?.HostType);
            var currentView = hostContentFrame?.Content as IMvxView;
            if (currentView != null && currentView.ViewModel == viewModel && hostContentFrame.CanGoBack)
            {
                hostContentFrame?.GoBack();
            }
        }
    }
}

