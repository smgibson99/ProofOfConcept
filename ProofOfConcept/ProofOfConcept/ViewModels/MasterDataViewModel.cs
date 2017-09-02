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
    public class MasterDataViewModel : BaseViewModel
    {
        private ObservableCollection<MasterData> _masterdatas= new ObservableCollection<MasterData>();
        public ObservableCollection<MasterData> MasterDatas
		{
            get { return _masterdatas; }
			set
			{
				_masterdatas = value;
                OnPropertyChanged(nameof(MasterDatas));

			}
		}

        public string QualityName { get; set; }
        public int SequenceNo { get; set; }
        public string AdviceLow { get; set; }
        public string AdviceMed { get; set; }
        public string AdviceHigh { get; set; }
        public int AccessLevel { get; set; }

        public async Task<ObservableCollection<MasterData>> GetMasterDatas()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            IsBusy = true;
            try
            {
                MasterDatas = await service.GetMasterDatas();
            }
            finally
            {
                IsBusy = false;
            }
            return MasterDatas;
        }

        public async Task AddMasterData()
        {
            if (settings.User == null)
            {
                throw new Exception("Not logged in.");
            }

            if (string.IsNullOrEmpty(QualityName))
                throw new Exception("Quality Name is blank.");

            if (SequenceNo < 0)
                throw new Exception("Sequence Number must be greater than zero");

            if (AccessLevel < 0 || AccessLevel > 10)
                throw new Exception("Access Level must be between 0 and 10");

            IsBusy = true;

            try
            {
                var masterdata = await service.AddMasterData(new MasterData { QualityName = QualityName, SequenceNo = SequenceNo, AdviceLow = AdviceLow, AdviceMed = AdviceMed, AdviceHigh = AdviceHigh, AccessLevel = AccessLevel });

                // update our local list of candidates
                var masterdatas = new List<MasterData>();
                if (MasterDatas != null)
                    masterdatas.AddRange(MasterDatas);
                masterdatas.Add(masterdata);

                MasterDatas = new ObservableCollection<MasterData>(masterdatas.OrderBy(c => c.QualityName).ThenBy(c => c.SequenceNo));
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
					await GetMasterDatas();
					IsRefreshing = false;
				});
			}
		}
    }
}
