using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Common;
using PCL.Common.Enum;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using PCL.UI.Templates.Cells;
using Xamarin.Forms;

namespace PCL.UI
{
    public partial class ViewStructureItemList : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private new class ViewModel : ContentPageBase.ViewModel
        {
            public CV_ListView ListView;

            public Section Section;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewStructureItemList()
        {
            this.InitializeComponent();

            // Get ListView
            this.View.ListView = this.listView;

            // Set ItemTapped handler
            this.View.ListView.ItemTapped += this.OnItemTapped;

            // Create Search toolbar item
            ToolbarCommand.Search(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            // Parent is section (first lists)
            if (this.BindingContext.GetType() == typeof(Section))
            {
                this.View.Section = (Section)this.BindingContext;

                // Set title
                this.Title = App.CurrentInstance.DependencyApplicationGeneral.GetApplicationName();

                switch (this.View.Section.Type)
                {
                    case SectionType.Favorites:

                        // Set item template
                        this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextCell));

                        // Set bindings
                        this.View.ListView.ItemTemplate.SetBinding(TextCell.TextProperty, "Title");
                        this.View.ListView.ItemTemplate.SetBinding(TextCell.DetailProperty, "SubTitle");
                        this.View.ListView.ItemTemplate.SetValue(TextCell.TextColorProperty, Color.Black);
                        this.View.ListView.ItemTemplate.SetValue(TextCell.DetailColorProperty, Color.Gray);

                        // Get favorites and set source
                        this.View.ListView.ItemsSource = this.View.RepositoryFavorite.Get();

                        break;
                    case SectionType.Pages:

                        // Set item template
                        this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

                        // Get children and set source
                        this.View.ListView.ItemsSource = this.View.RepositoryStructureItem.GetBySection(this.View.Section.Id);

                        break;
                    case SectionType.Calculators:

                        // Set item template
                        this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextButtonCell));

                        // Get children and set source
                        this.View.ListView.ItemsSource = this.View.RepositoryStructureItem.GetBySection(this.View.Section.Id);

                        break;
                    case SectionType.Directory:

                        // Set item template
                        this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

                        // Get children and set source
                        this.View.ListView.ItemsSource = this.View.RepositoryStructureItem.GetBySection(this.View.Section.Id);

                        break;
                }

                // Create Information toolbar item
                ToolbarCommand.Information(this);
            }

            // Parent is structure item (nested lists)
            else if (this.BindingContext.GetType() == typeof(StructureItem))
            {
                StructureItem structureItem = (StructureItem)this.BindingContext;

                // Set title
                this.Title = structureItem.Title;

                // Get section
                this.View.Section = this.View.RepositorySection.Get(structureItem.SectionId);

                // Set item template
                this.View.ListView.ItemTemplate = new DataTemplate(typeof(TextDefaultCell));

                switch (this.View.Section.Type)
                {
                    case SectionType.Pages:

                        // Get children and set source
                        this.View.ListView.ItemsSource = this.View.RepositoryStructureItem.GetByParent(structureItem.Id);

                        break;
                    case SectionType.Directory:

                        // Get children and set source
                        this.View.ListView.ItemsSource = this.View.RepositoryStructureItem.GetByParent(structureItem.Id).OrderBy(x => x.Title).ToList();

                        break;
                }

                // Create Home toolbar item
                ToolbarCommand.Home(this);

                // Create Favorite toolbar item
                ToolbarCommand.Favorite(this, this.View.RepositoryFavorite, structureItem);
            }
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            StructureItem structureItem = null;

            if (e.Item.GetType() == typeof(Favorite))
            {
                Favorite favorite = (Favorite) e.Item;

                structureItem = this.View.RepositoryStructureItem.GetByUuid(favorite.Uuid);
            }
            else
            {
                structureItem = (StructureItem)e.Item;
            }

            switch (structureItem.Type)
            {
                case StructureItemType.Category:

                    // Show children
                    await this.Navigation.PushAsync(new ViewStructureItemList
                    {
                        BindingContext = structureItem
                    }, true);
                    break;

                case StructureItemType.Page:

                    // Show page
                    await this.Navigation.PushAsync(new ViewItemPage
                    {
                        BindingContext = structureItem
                    }, true);
                    break;

                case StructureItemType.Calculator:

                    // Show calculator
                    await App.CurrentInstance.DependencyApplicationUI.CalculatorStart(this, structureItem);
                    
                    break;

                case StructureItemType.Contact:

                    // Show contact
                    await this.Navigation.PushAsync(new ViewItemContact
                    {
                        BindingContext = structureItem
                    }, true);
                    break;
            }

            // Deselect item
            ((ListView)sender).SelectedItem = null;
        }
    }
}