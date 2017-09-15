using ProofOfConcept.Interfaces;
using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;

namespace ProofOfConcept.Fakes
{
    public class FakeWebService : IWebService
    {
        public int SleepDuration { get; set; }
        public FakeRepository fakeRepository { get; set; }

        public FakeWebService()
        {
            SleepDuration = 1;
            fakeRepository = new FakeRepository();
        }

        private Task SleepAsync()
        {
            return Task.Delay(SleepDuration);
        }

        //Users
        public async Task<User> LoginAsync(string userid, string password)
        {
            await LogoutAsync();

            await SleepAsync();

            foreach (User user in fakeRepository.users)
            {
                if (user.UserId.CompareTo(userid) == 0 && user.Password.CompareTo(password) == 0)
                    App.settings.User = user;
            }

            if (App.settings?.User == null)
                throw new Exception("User Not Found, or Password is not correct!");
            
            return App.settings.User;
        }

        public async Task<User> GetUserAsync(string userId)
        {
            await SleepAsync();

            User user = fakeRepository.users.Single(r => r.UserId.Equals(userId));

            return user;
        }

        public async Task<User> RegisterAsync(User user)
        {
            await SleepAsync();

            await LogoutAsync();

            if (fakeRepository.users.Contains(user))
                throw new Exception("User Exists Already!");

            user.Id = Guid.NewGuid().ToString();
            fakeRepository.users.Add(user);
            App.settings.User = user;

            return user;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            bool found = false;

            await SleepAsync();

            if (fakeRepository.users.Contains(user))
            {
                found = true;
                //user found, update it
                int pos = fakeRepository.users.IndexOf(user);
                fakeRepository.users[pos] = user;
                App.settings.User = user;
            }

            return found;
        }

        public async Task<bool> ChangePasswordAsync(string userid, string password, string newpassword)
        {
            bool result = false;
            User foundUser = null;

			await SleepAsync();

			foreach (User user in fakeRepository.users)
			{
                if (user.UserId.CompareTo(userid) == 0 && user.Password.CompareTo(password) == 0)
                {
                    foundUser = user;
                    foundUser.Password = newpassword;
                    result = true;
                }
			}

            if (foundUser == null)
				throw new Exception("User Not Found, or Password is not correct!");

			//user found, update it
            int pos = fakeRepository.users.IndexOf(foundUser);
            fakeRepository.users[pos] = foundUser;
            App.settings.User = foundUser;

            return result;
		}

        public async Task  LogoutAsync()
        {
            await SleepAsync();
            App.settings.User = null;
            if (App.HomePage != null)
                App.HomePage.ClearList();
        }

        //Config
        public async Task<Config> GetConfigAsync()
        {
            await SleepAsync();

            return fakeRepository.configuration;
        }

        public async Task<Config> UpdateConfigAsync(Config config)
        {
            await SleepAsync();

            fakeRepository.configuration = config;
            return config;
        }

        //Categories
        public async Task<Category> GetCategoryAsync(string categoryName)
        {
            await SleepAsync();

            Category category = fakeRepository.categories.Single(r => r.CategoryName.Equals(categoryName));

            return category;
        }

        public async Task<ObservableCollection<Category>> GetCategoriesAsync()
        {
            await SleepAsync();

            return new ObservableCollection<Category>(fakeRepository.categories.OrderBy(r => r.CategoryName));
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await SleepAsync();

            category.Id = Guid.NewGuid().ToString();
            fakeRepository.categories.Add(category);

            return category;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            bool found = false;

            await SleepAsync();

            if (fakeRepository.categories.Contains(category))
            {
                int index = fakeRepository.categories.IndexOf(category);
                fakeRepository.categories[index] = category;
                found = true;
            }

            return found;
        }

        public async Task<bool> RemoveCategoryAsync(Category category)
        {
            bool found = false;

            await SleepAsync();

            if (fakeRepository.categories.Contains(category))
            {
                found = fakeRepository.categories.Remove(category);
            }

            return found;

        }

        //Qualities
        public async Task<Quality> GetQualityAsync(string qualityName)
        {
            await SleepAsync();

            Quality quality = fakeRepository.qualities.Single(r => r.QualityName.Equals(qualityName));

            return quality;
        }

        public async Task<ObservableCollection<Quality>> GetQualitiesAsync()
        {
            await SleepAsync();

            return new ObservableCollection<Quality>(fakeRepository.qualities.OrderBy(r => r.CategoryName).ThenBy(r => r.QualityName));
        }

        public async Task<Quality> AddQualityAsync(Quality quality)
        {
            await SleepAsync();

            quality.Id = Guid.NewGuid().ToString();
            fakeRepository.qualities.Add(quality);

            return quality;
        }

        public async Task<bool> UpdateQualityAsync(Quality quality)
        {
            bool found = false;

            await SleepAsync();

            if (fakeRepository.qualities.Contains(quality))
            {
                int index = fakeRepository.qualities.IndexOf(quality);
                fakeRepository.qualities[index] = quality;
                found = true;
            }

            return found;
        }

        public async Task<bool> RemoveQualityAsync(Quality quality)
        {
            bool found = false;

            await SleepAsync();

            if (fakeRepository.qualities.Contains(quality))
            {
                found = fakeRepository.qualities.Remove(quality);
            }

            return found;
        }

        //Master Data
        public async Task<MasterData> GetMasterDataAsync(string qualityName, int sequenceNo)
        {
            await SleepAsync();

            MasterData masterData = fakeRepository.masterDatas.Single(r => r.QualityName.Equals(qualityName) && r.SequenceNo == sequenceNo);

            return masterData;
        }

        public async Task<ObservableCollection<MasterData>> GetMasterDatasAsync()
        {
            await SleepAsync();

            return new ObservableCollection<MasterData>(fakeRepository.masterDatas.OrderBy(r => r.QualityName).ThenBy(r => r.SequenceNo));
        }

        public async Task<MasterData> AddMasterDataAsync(MasterData masterData)
        {
            await SleepAsync();

            masterData.Id = Guid.NewGuid().ToString();
            fakeRepository.masterDatas.Add(masterData);

            return masterData;
        }

        public async Task<bool> UpdateMasterDataAsync(MasterData masterData)
        {
            bool found = false;

            await SleepAsync();

            if (fakeRepository.masterDatas.Contains(masterData))
            {
                int index = fakeRepository.masterDatas.IndexOf(masterData);
                fakeRepository.masterDatas[index] = masterData;
                found = true;
            }

            return found;
        }

        public async Task<bool> RemoveMasterDataAsync(MasterData masterData)
        {
            bool found = false;

            await SleepAsync();

            if (fakeRepository.masterDatas.Contains(masterData))
            {
                found = fakeRepository.masterDatas.Remove(masterData);
            }

            return found;
        }

        //Ideal Mates
        public async Task<IdealMate> GetIdealMateAsync(string userId, string qualityName)
        {
            await SleepAsync();

            IdealMate idealMate = fakeRepository.idealMates.Single(r => r.UserId.Equals(userId) && r.QualityName.Equals(qualityName));

            return idealMate;
        }

        public async Task<ObservableCollection<IdealMate>> GetIdealMatesAsync(string userId)
        {
            await SleepAsync();

            return new ObservableCollection<IdealMate>(fakeRepository.idealMates.Where(i => i.UserId.Equals(userId)).OrderBy(c => c.QualityName));
        }

        public async Task<IdealMate> AddIdealMateAsync(IdealMate idealMate)
        {
            await SleepAsync();

            idealMate.Id = Guid.NewGuid().ToString();
            fakeRepository.idealMates.Add(idealMate);

            return idealMate;
        }

        public async Task<bool> UpdateIdealMateAsync(IdealMate idealMate)
        {
            bool found = false;

            await SleepAsync();

            if (fakeRepository.idealMates.Contains(idealMate))
            {
                int index = fakeRepository.idealMates.IndexOf(idealMate);
                fakeRepository.idealMates[index] = idealMate;
                found = true;
            }

            return found;
        }

        public async Task<bool> RemoveIdealMateAsync(IdealMate idealMate)
        {
            bool found = false;

            await SleepAsync();

            if (fakeRepository.idealMates.Contains(idealMate))
            {
                found = fakeRepository.idealMates.Remove(idealMate);
            } 

            return found;
        }

        //Candidates
        public async Task<Candidate> GetCandidateAsync(string userId, string candidateName)
        {
            await SleepAsync();

            Candidate candidate = fakeRepository.candidates.Single(r => r.UserId.Equals(userId) && r.CandidateName.Equals(candidateName));

            return candidate;
        }

        public async Task<ObservableCollection<Candidate>> GetCandidatesAsync(string userId)
        {
            await SleepAsync();

            return new ObservableCollection<Candidate>(fakeRepository.candidates.Where(c => c.UserId.Equals(userId)).OrderBy(c => c.CandidateName));
        }

        public async Task<Candidate> AddCandidateAsync(Candidate candidate)
        {
            await SleepAsync();

            candidate.Id = Guid.NewGuid().ToString();
            fakeRepository.candidates.Add(candidate);

            return candidate;
        }

        public async Task<bool> UpdateCandidateAsync(Candidate candidate)
        {
            bool found = false;

            await SleepAsync();

            if (fakeRepository.candidates.Contains(candidate))
            {
                int index = fakeRepository.candidates.IndexOf(candidate);
                fakeRepository.candidates[index] = candidate;
                found = true;
            }

            return found;
        }

        public async Task<bool> RemoveCandidateAsync(Candidate candidate)
        {
            bool found = false;

            await SleepAsync();

            if (fakeRepository.candidates.Contains(candidate))
            {
                //check for existence of dates for this candidate
                var userDates = fakeRepository.userDates.Where(r => r.UserId.Equals(candidate.UserId) && r.CandidateName.Equals(candidate.CandidateName));
                if (userDates.Count() == 0)
                    found = fakeRepository.candidates.Remove(candidate);
                else
                    throw new Exception("Candidate has existing date records!");
            }

            return found;
        }

        //User Dates
        public async Task<UserDate> GetUserDateAsync(string userId, string candidateName, DateTime dateOfDate, string qualityName)
        {
            await SleepAsync();

            UserDate userDate = fakeRepository.userDates.Single(r => r.UserId.Equals(userId) && r.CandidateName.Equals(candidateName) && r.DateOfDate.Equals(dateOfDate) && r.QualityName.Equals(qualityName));

            return userDate;
        }

        public async Task<ObservableCollection<UserDate>> GetUserDatesAsync(string userId)
        {
            await SleepAsync();

            return new ObservableCollection<UserDate>(fakeRepository.userDates.Where(u => u.UserId.Equals(userId)).OrderBy(r => r.CandidateName).ThenBy(r => r.DateOfDate).ThenBy(r => r.QualityName));
        }

        public async Task<UserDate> AddUserDateAsync(UserDate userDate)
        {
            await SleepAsync();

            userDate.Id = Guid.NewGuid().ToString();
            fakeRepository.userDates.Add(userDate);

            return userDate;
        }

        public async Task<bool> UpdateUserDateAsync(UserDate userDate)
        {
            bool found = false;

            await SleepAsync();

            if (fakeRepository.userDates.Contains(userDate))
            {
                int index = fakeRepository.userDates.IndexOf(userDate);
                fakeRepository.userDates[index] = userDate;
                found = true;
            }

            return found;
        }

        public async Task<bool> RemoveUserDateAsync(UserDate userDate)
        {
            bool found = false;

            await SleepAsync();

            if (fakeRepository.userDates.Contains(userDate))
            {
                found = fakeRepository.userDates.Remove(userDate);
            }

            return found;
        }
    }
}
