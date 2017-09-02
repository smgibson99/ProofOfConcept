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

        private Task Sleep()
        {
            return Task.Delay(SleepDuration);
        }

        public async Task<User> Login(string userid, string password)
        {
            await Logout();

            await Sleep();

            foreach (User user in fakeRepository.users)
            {
                if (user.UserId.CompareTo(userid) == 0 && user.Password.CompareTo(password) == 0)
                    App.settings.User = user;
            }

            if (App.settings?.User == null)
                throw new Exception("User Not Found, or Password is not correct!");
            
            return App.settings.User;
        }

        public async Task<User> Register(User user)
        {
            await Sleep();

            await Logout();

            if (fakeRepository.users.Contains(user))
                throw new Exception("User Exists Already!");

            user.Id = Guid.NewGuid().ToString();
            fakeRepository.users.Add(user);
            App.settings.User = user;

            return user;
        }

        public async Task<bool> UpdateUser(User user)
        {
            bool found = false;

            await Sleep();

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

        public async Task<bool> ChangePassword(string userid, string password, string newpassword)
        {
            bool result = false;
            User foundUser = null;

			await Sleep();

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

        public async Task  Logout()
        {
            await Sleep();
            App.settings.User = null;
            if (App.HomePage != null)
                App.HomePage.ClearList();
        }

        public async Task<Config> GetConfig()
        {
            await Sleep();

            return fakeRepository.configuration;
        }

        public async Task<Config> UpdateConfig(Config config)
        {
            await Sleep();

            fakeRepository.configuration = config;
            return config;
        }

        public async Task<ObservableCollection<Category>> GetCategories()
        {
            await Sleep();

            return new ObservableCollection<Category>(fakeRepository.categories);
        }

        public async Task<Category> AddCategory(Category category)
        {
            await Sleep();

            category.Id = Guid.NewGuid().ToString();
            fakeRepository.categories.Add(category);

            return category;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            bool found = false;

            await Sleep();

            if (fakeRepository.categories.Contains(category))
            {
                int index = fakeRepository.categories.IndexOf(category);
                fakeRepository.categories[index] = category;
                found = true;
            }

            return found;
        }

        public async Task<bool> RemoveCategory(Category category)
        {
            bool found = false;

            await Sleep();

            if (fakeRepository.categories.Contains(category))
            {
                found = fakeRepository.categories.Remove(category);
            }

            return found;

        }

        public async Task<ObservableCollection<Quality>> GetQualities()
        {
            await Sleep();

            return new ObservableCollection<Quality>(fakeRepository.qualities);
        }

        public async Task<Quality> AddQuality(Quality quality)
        {
            await Sleep();

            quality.Id = Guid.NewGuid().ToString();
            fakeRepository.qualities.Add(quality);

            return quality;
        }

        public async Task<bool> UpdateQuality(Quality quality)
        {
            bool found = false;

            await Sleep();

            if (fakeRepository.qualities.Contains(quality))
            {
                int index = fakeRepository.qualities.IndexOf(quality);
                fakeRepository.qualities[index] = quality;
                found = true;
            }

            return found;
        }

        public async Task<bool> RemoveQuality(Quality quality)
        {
            bool found = false;

            await Sleep();

            if (fakeRepository.qualities.Contains(quality))
            {
                found = fakeRepository.qualities.Remove(quality);
            }

            return found;
        }

        public async Task<ObservableCollection<MasterData>> GetMasterDatas()
        {
            await Sleep();

            return new ObservableCollection<MasterData>(fakeRepository.masterDatas);
        }

        public async Task<MasterData> AddMasterData(MasterData masterData)
        {
            await Sleep();

            masterData.Id = Guid.NewGuid().ToString();
            fakeRepository.masterDatas.Add(masterData);

            return masterData;
        }

        public async Task<bool> UpdateMasterData(MasterData masterData)
        {
            bool found = false;

            await Sleep();

            if (fakeRepository.masterDatas.Contains(masterData))
            {
                int index = fakeRepository.masterDatas.IndexOf(masterData);
                fakeRepository.masterDatas[index] = masterData;
                found = true;
            }

            return found;
        }

        public async Task<bool> RemoveMasterData(MasterData masterData)
        {
            bool found = false;

            await Sleep();

            if (fakeRepository.masterDatas.Contains(masterData))
            {
                found = fakeRepository.masterDatas.Remove(masterData);
            }

            return found;
        }

        public async Task<ObservableCollection<IdealMate>> GetIdealMates(string userId)
        {
            await Sleep();

            return new ObservableCollection<IdealMate>(fakeRepository.idealMates.Where(i => i.UserId.Equals(userId)));
        }

        public async Task<IdealMate> AddIdealMate(IdealMate idealMate)
        {
            await Sleep();

            idealMate.Id = Guid.NewGuid().ToString();
            fakeRepository.idealMates.Add(idealMate);

            return idealMate;
        }

        public async Task<bool> UpdateIdealMate(IdealMate idealMate)
        {
            bool found = false;

            await Sleep();

            if (fakeRepository.idealMates.Contains(idealMate))
            {
                int index = fakeRepository.idealMates.IndexOf(idealMate);
                fakeRepository.idealMates[index] = idealMate;
                found = true;
            }

            return found;
        }

        public async Task<bool> RemoveIdealMate(IdealMate idealMate)
        {
            bool found = false;

            await Sleep();

            if (fakeRepository.idealMates.Contains(idealMate))
            {
                found = fakeRepository.idealMates.Remove(idealMate);
            }

            return found;
        }

        public async Task<ObservableCollection<Candidate>> GetCandidates(string userId)
        {
            await Sleep();

            return new ObservableCollection<Candidate>(fakeRepository.candidates.Where(c => c.UserId.Equals(userId)));
        }

        public async Task<Candidate> AddCandidate(Candidate candidate)
        {
            await Sleep();

            candidate.Id = Guid.NewGuid().ToString();
            fakeRepository.candidates.Add(candidate);

            return candidate;
        }

        public async Task<bool> UpdateCandidate(Candidate candidate)
        {
            bool found = false;

            await Sleep();

            if (fakeRepository.candidates.Contains(candidate))
            {
                int index = fakeRepository.candidates.IndexOf(candidate);
                fakeRepository.candidates[index] = candidate;
                found = true;
            }

            return found;
        }

        public async Task<bool> RemoveCandidate(Candidate candidate)
        {
            bool found = false;

            await Sleep();

            if (fakeRepository.candidates.Contains(candidate))
            {
                found = fakeRepository.candidates.Remove(candidate);
            }

            return found;
        }

        public async Task<ObservableCollection<UserDate>> GetUserDates(string userId)
        {
            await Sleep();

            return new ObservableCollection<UserDate>(fakeRepository.userDates.Where(u => u.UserId.Equals(userId)));
        }

        public async Task<UserDate> AddUserDate(UserDate userDate)
        {
            await Sleep();

            userDate.Id = Guid.NewGuid().ToString();
            fakeRepository.userDates.Add(userDate);

            return userDate;
        }

        public async Task<bool> UpdateUserDate(UserDate userDate)
        {
            bool found = false;

            await Sleep();

            if (fakeRepository.userDates.Contains(userDate))
            {
                int index = fakeRepository.userDates.IndexOf(userDate);
                fakeRepository.userDates[index] = userDate;
                found = true;
            }

            return found;
        }

        public async Task<bool> RemoveUserDate(UserDate userDate)
        {
            bool found = false;

            await Sleep();

            if (fakeRepository.userDates.Contains(userDate))
            {
                found = fakeRepository.userDates.Remove(userDate);
            }

            return found;
        }
    }
}
