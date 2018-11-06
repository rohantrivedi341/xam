using Xamarin.Forms;

namespace PCL.UI.Templates.Views
{
    public interface BaseView
    {
        View Setup(View parent);

        void IsSelected();
    }

    public static class BaseViewExtensions
    {
        public static LabelView AsLabel(this BaseView baseView)
        {
            return baseView as LabelView;
        }

        public static EntryView AsEntry(this BaseView baseView)
        {
            return baseView as EntryView;
        }

        public static PickerView AsPicker(this BaseView baseView)
        {
            return baseView as PickerView;
        }
    }
}