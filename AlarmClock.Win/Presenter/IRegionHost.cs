using MvvmCross.WindowsUWP.Views;

namespace AlarmClock.Win.Presenter
{
    public interface IRegionHost
    {
        IMvxWindowsFrame ContentFrame { get; }
    }
}