using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Exceptions;
using MvvmCross.WindowsUWP.Views;

namespace AlarmClock.Win
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RegionAttribute
       : Attribute
    {
        public RegionAttribute(string regionName)
        {
            Name = regionName;
        }

        public string Name { get; private set; }
    }

    public interface IMvxMultiRegionHost
    {
        void Show(MvxWindowsPage view);

        void CloseViewModel(IMvxViewModel viewModel);

        void CloseAll();
    }
    class MvxWindowsMultiRegionViewPresenter : MvxWindowsViewPresenter
    {
        private readonly IMvxWindowsFrame _rootFrame;

        public MvxWindowsMultiRegionViewPresenter(IMvxWindowsFrame rootFrame)
            : base(rootFrame)
        {
            _rootFrame = rootFrame;
            
        }

        public override async void Show(MvxViewModelRequest request)
        {
            var host = _rootFrame.Content as IMvxMultiRegionHost;
            var view = CreateView(request);

            if (host != null && view.HasRegionAttribute())
            {
                host.Show(view as MvxWindowsPage);
            }
            else
            {
                base.Show(request);
            }
        }

        private static IMvxWindowsView CreateView(MvxViewModelRequest request)
        {
            var viewFinder = Mvx.Resolve<IMvxViewsContainer>();

            var viewType = viewFinder.GetViewType(request.ViewModelType);
            if (viewType == null)
                throw new MvxException("View Type not found for " + request.ViewModelType);

            // Create instance of view
            var viewObject = Activator.CreateInstance(viewType);
            if (viewObject == null)
                throw new MvxException("View not loaded for " + viewType);

            var view = viewObject as IMvxWindowsView;
            if (view == null)
                throw new MvxException("Loaded View is not a IMvxWindowsView " + viewType);

            view.ViewModel = LoadViewModel(request);

            return view;
        }

        private static IMvxViewModel LoadViewModel(MvxViewModelRequest request)
        {
            // Load the viewModel
            var viewModelLoader = Mvx.Resolve<IMvxViewModelLoader>();

            return viewModelLoader.LoadViewModel(request, null);
        }
    }
}

