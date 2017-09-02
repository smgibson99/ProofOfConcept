using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ProofOfConcept.Interfaces
{
    public interface IWebService
    {
        Task<User> Login(string userid, string password);

        Task Logout();

        Task<User> Register(User user);

        Task<bool> UpdateUser(User user);

        Task<bool> ChangePassword(string userid, string password, string newpassword);

        //Config
        Task<Config> GetConfig();

        Task<Config> UpdateConfig(Config config);

        // Category
        Task<ObservableCollection<Category>> GetCategories();

        Task<Category> AddCategory(Category category);

        Task<bool> UpdateCategory(Category category);

        Task<bool> RemoveCategory(Category category);

        // Quality
        Task<ObservableCollection<Quality>> GetQualities();

        Task<Quality> AddQuality(Quality quality);

        Task<bool> UpdateQuality(Quality quality);

        Task<bool> RemoveQuality(Quality quality);

        //Master Data
        Task<ObservableCollection<MasterData>> GetMasterDatas();

        Task<MasterData> AddMasterData(MasterData masterData);

        Task<bool> UpdateMasterData(MasterData masterData);

        Task<bool> RemoveMasterData(MasterData masterData);

        // Ideal Mate
        Task<ObservableCollection<IdealMate>> GetIdealMates(string userId);

        Task<IdealMate> AddIdealMate(IdealMate idealMate);

        Task<bool> UpdateIdealMate(IdealMate idealMate);

        Task<bool> RemoveIdealMate(IdealMate idealMate);

        //Candidate
        Task<ObservableCollection<Candidate>> GetCandidates(string userId);

        Task<Candidate> AddCandidate(Candidate candidate);

        Task<bool> UpdateCandidate(Candidate candidate);

        Task<bool> RemoveCandidate(Candidate candidate);

        //User Date
        Task<ObservableCollection<UserDate>> GetUserDates(string userId);

        Task<UserDate> AddUserDate(UserDate userDate);

        Task<bool> UpdateUserDate(UserDate userDate);

        Task<bool> RemoveUserDate(UserDate userDate);

    }
}
