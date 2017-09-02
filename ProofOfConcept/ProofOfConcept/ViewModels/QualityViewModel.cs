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
    public class QualityViewModel : BaseViewModel
    {
        private ObservableCollection<Quality> _qualities = new ObservableCollection<Quality>();
		public ObservableCollection<Quality> Qualities
		{
			get { return _qualities; }
			set
			{
				_qualities = value;
                OnPropertyChanged(nameof(Qualities));

			}
		}
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

        public string QualityName { get; set; }
        public string CategoryName { get; set; }
        public int AccessLevel { get; set; }

        public async Task<ObservableCollection<Quality>> GetQualities()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            IsBusy = true;
            try
            {
                Qualities = await service.GetQualities();
            }
            finally
            {
                IsBusy = false;
            }

            return Qualities;
        }

        public async Task<ObservableCollection<Category>> GetCategories()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            IsBusy = true;
            try
            {
                Categories = await service.GetCategories();
            }
            finally
            {
                IsBusy = false;
            }
            return Categories;
        }

        public async Task AddQuality()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            if (string.IsNullOrEmpty(QualityName))
                throw new Exception("Quality Name is blank.");

            if (string.IsNullOrEmpty(CategoryName))
                throw new Exception("Category Name is blank.");

            if (AccessLevel < 0 || AccessLevel > 10)
                throw new Exception("Access Level must be between 0 and 10");

            IsBusy = true;

            try
            {
                var quality = await service.AddQuality(new Quality { QualityName = QualityName, CategoryName = CategoryName, AccessLevel = AccessLevel });

                // update our local list of qualities
                var qualitites = new List<Quality>();
                if (Qualities != null)
                    qualitites.AddRange(Qualities);
                qualitites.Add(quality);

                Qualities = new ObservableCollection<Quality>(qualitites.OrderBy(c => c.QualityName));
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
					await GetQualities();
					IsRefreshing = false;
				});
			}
		}
    }
}
