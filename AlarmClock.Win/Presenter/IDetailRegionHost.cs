using MvvmCross.WindowsUWP.Views;

namespace AlarmClock.Win.Presenter
{
    public interface IDetailRegionHost
    {
        IMvxWindowsFrame DetailContent { get; }
    }
}