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
    /// Inspired from: http://stackoverflow.com/questions/33131034/how-to-implement-a-custom-presenter-in-a-windows-uwp-xamarin-mvvmcross
    /// </summary>
    class WindowsDetailRegionViewPresenter : MvxWindowsViewPresenter
    {
        private readonly IMvxWindowsFrame _rootFrame;

        public WindowsDetailRegionViewPresenter(IMvxWindowsFrame rootFrame)
            : base(rootFrame)
        {
            _rootFrame = rootFrame;
        }

        public override async void Show(MvxViewModelRequest request)
        {
            if (Host != null)
            {
                var viewFinder = Mvx.Resolve<IMvxViewsContainer>();
                var viewType = viewFinder.GetViewType(request.ViewModelType);
                var regionAttribute = GetRegionAttribute(viewType);
                if (regionAttribute != null)
                {
                    var host = FindHost(regionAttribute.ParentName);
                    var converter = Mvx.Resolve<IMvxNavigationSerializer>();
                    var requestText = converter.Serializer.SerializeObject(request);
                    host.DetailContent.Navigate(viewType, requestText);
                    return;
                }
            }
            base.Show(request);
        }

        private IDetailRegionHost Host => _rootFrame.Content as IDetailRegionHost;

        private IDetailRegionHost FindHost(string name)
        {
            return FindHost(name, Host);
        }
        private IDetailRegionHost FindHost(string name, IDetailRegionHost host)
        {
            if (host != null)
            {
                var ha = GetRegionAttribute(host.GetType());
                if (ha.Name == name) return host;
                else return FindHost(name, host.DetailContent.Content as IDetailRegionHost);
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

            var host = FindHost(regionAttribute.ParentName);
            var currentView = host.DetailContent.Content as IMvxView;
            if (currentView != null && currentView.ViewModel == viewModel && host.DetailContent.CanGoBack)
            {
                host.DetailContent.GoBack();
            }
        }
    }
}

