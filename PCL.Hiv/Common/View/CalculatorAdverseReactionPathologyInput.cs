using PCL.UI.Templates.Views;

namespace PCL.Hiv.Common.View
{
    public class CalculatorAdverseReactionPathologyInput
    {
        public CalculatorAdverseReactionPathologyParameter Parameter { get; set; }

        public EntryView Entry { get; set; }

        public CalculatorAdverseReactionPathologyInput(CalculatorAdverseReactionPathologyParameter parameter, EntryView entry)
        {
            this.Parameter = parameter;
            this.Entry = entry;
        }
    }
}