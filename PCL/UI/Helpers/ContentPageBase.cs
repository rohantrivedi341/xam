using PCL.Database;
using PCL.Repository;
using PCL.Services;
using Xamarin.Forms;

namespace PCL.UI.Helpers
{
    public class ContentPageBase : ContentPage
    {
        public ViewModel ViewBase;

        public SQLiteConnectionDatabase SqLiteConnectionDatabase;
        
        public class ViewModel
        {
            public ContentPageBase Page;
            public SQLiteConnectionDatabase SqLiteConnectionDatabase;

            private FavoriteRepository _repositoryFavorite;
            public FavoriteRepository RepositoryFavorite => this._repositoryFavorite ?? (this._repositoryFavorite = new FavoriteRepository(this.Page.SqLiteConnectionDatabase));

            private ItemCalculatorLinkRepository _repositoryItemCalculatorLink;
            public ItemCalculatorLinkRepository RepositoryItemCalculatorLink => this._repositoryItemCalculatorLink ?? (this._repositoryItemCalculatorLink = new ItemCalculatorLinkRepository(this.Page.SqLiteConnectionDatabase));

            private ItemContactNumberRepository _repositoryItemContactNumber;
            public ItemContactNumberRepository RepositoryItemContactNumber => this._repositoryItemContactNumber ?? (this._repositoryItemContactNumber = new ItemContactNumberRepository(this.Page.SqLiteConnectionDatabase));

            private ItemContactRepository _repositoryItemContact;
            public ItemContactRepository RepositoryItemContact => this._repositoryItemContact ?? (this._repositoryItemContact = new ItemContactRepository(this.Page.SqLiteConnectionDatabase));

            private ItemPageRepository _repositoryItemPage;
            public ItemPageRepository RepositoryItemPage => this._repositoryItemPage ?? (this._repositoryItemPage = new ItemPageRepository(this.Page.SqLiteConnectionDatabase));

            private LabelRepository _repositoryLabel;
            public LabelRepository RepositoryLabel => this._repositoryLabel ?? (this._repositoryLabel = new LabelRepository(this.Page.SqLiteConnectionDatabase));

            private SectionRepository _repositorySection;
            public SectionRepository RepositorySection => this._repositorySection ?? (this._repositorySection = new SectionRepository(this.Page.SqLiteConnectionDatabase));

            private SpecialPageRepository _repositorySpecialPage;
            public SpecialPageRepository RepositorySpecialPage => this._repositorySpecialPage ?? (this._repositorySpecialPage = new SpecialPageRepository(this.Page.SqLiteConnectionDatabase));

            private StructureItemRepository _repositoryStructureItem;
            public StructureItemRepository RepositoryStructureItem => this._repositoryStructureItem ?? (this._repositoryStructureItem = new StructureItemRepository(this.Page.SqLiteConnectionDatabase));

            public ViewModel(ContentPageBase page)
            {
                this.Page = page;
                this.Page.ViewBase = this;
                
                this.SqLiteConnectionDatabase = page.SqLiteConnectionDatabase;
            }
        }

        public ContentPageBase()
        {
            this.SqLiteConnectionDatabase = SQLiteConnectionDatabase.NewConnection();

            this.SizeChanged += (s, e) => { App.ScreenSize = this.Bounds; };
        }
    }
}