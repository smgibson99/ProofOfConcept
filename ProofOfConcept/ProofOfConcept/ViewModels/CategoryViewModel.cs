using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProofOfConcept.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private ObservableCollection<Category> _categories = new ObservableCollection<Category>();
		public ObservableCollection<Category> Categories
		{
			get { return _categories; }
			set
			{
				_categories = value;
				OnPropertyChanged(nameof(Categories));

			}
		}

        public string CategoryName { get; set; }
        public int AccessLevel { get; set; }

        public async Task<ObservableCollection<Category>> GetCategoriesAsync()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            IsBusy = true;
            try
            {
                Categories = await service.GetCategoriesAsync();
            }
            finally
            {
                IsBusy = false;
            }
            return Categories;
        }

        public async Task AddCategoryAsync()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            if (string.IsNullOrEmpty(CategoryName))
                throw new Exception("Category Name is blank.");

            if (AccessLevel < 0 || AccessLevel > 10)
                throw new Exception("Access Level must be between 0 and 10");

            IsBusy = true;
            try
            {
                var category = await service.AddCategoryAsync(new Category { CategoryName = CategoryName, AccessLevel = AccessLevel });

                // update our local list of categories
                var categories = new List<Category>();
                if (Categories != null)
                    categories.AddRange(Categories);
                categories.Add(category);

                Categories = new ObservableCollection<Category>(categories.OrderBy(c => c.CategoryName));
            }
            finally
            {
                IsBusy = false;
            }
        }

		//TODO: Add other operations

		public ICommand RefreshCommand
		{
			get
			{
				return new Command(async () =>
				{
					IsRefreshing = true;
					await GetCategoriesAsync();
					IsRefreshing = false;
				});
			}
		}
    }
}
