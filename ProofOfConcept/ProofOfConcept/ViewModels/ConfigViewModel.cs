using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ViewModels
{
    public class ConfigViewModel : BaseViewModel
    {
        public Config Configuration { get; set; }
        public int LowRatingBegin { get; set; }
        public int LowRatingEnd { get; set; }
        public int MedRatingBegin { get; set; }
        public int MedRatingEnd { get; set; }
        public int HighRatingBegin { get; set; }
        public int HighRatingEnd { get; set; }
        public string WelcomeMessage { get; set; }

        public async Task GetConfig()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            IsBusy = true;
            try
            {
                Configuration = await service.GetConfig();
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task UpdateConfig()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            if (LowRatingBegin < 0 || LowRatingBegin > 10)
            {
                throw new Exception("Low Rating Begin must be between 0 and 10");
            }

            if (LowRatingEnd < 0 || LowRatingEnd > 10)
            {
                throw new Exception("Low Rating End must be between 0 and 10");
            }

            if (MedRatingBegin < 0 || MedRatingBegin > 10)
            {
                throw new Exception("Medium Rating Begin must be between 0 and 10");
            }

            if (MedRatingEnd < 0 || MedRatingEnd > 10)
            {
                throw new Exception("Med Rating End must be between 0 and 10");
            }

            if (HighRatingBegin < 0 || HighRatingBegin > 10)
            {
                throw new Exception("High Rating Begin must be between 0 and 10");
            }

            if (HighRatingEnd < 0 || HighRatingEnd > 10)
            {
                throw new Exception("High Rating End must be between 0 and 10");
            }


            IsBusy = true;

            try
            {
                Configuration = await service.UpdateConfig(new Config {Id=Configuration.Id, LowRatingBegin = LowRatingBegin, LowRatingEnd = LowRatingEnd, MedRatingBegin = MedRatingBegin, MedRatingEnd = MedRatingEnd, HighRatingBegin = HighRatingBegin, HighRatingEnd = HighRatingEnd, WelcomeMessage = WelcomeMessage });
            }
            finally
            {
                IsBusy = false;
            }
        }

        //TODO: Add other operations
    }
}
