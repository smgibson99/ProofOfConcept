using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ProofOfConcept.Interfaces
{
    public interface IWebService
    {
        Task<User> LoginAsync(string userid, string password);

        Task LogoutAsync();

        Task<User> RegisterAsync(User user);

        Task<User> GetUserAsync(string userId);

        Task<bool> UpdateUserAsync(User user);

        Task<bool> ChangePasswordAsync(string userid, string password, string newpassword);

        //Config
        Task<Config> GetConfigAsync();

        Task<Config> UpdateConfigAsync(Config config);

        // Category

        Task<Category> GetCategoryAsync(string categoryName);

        Task<ObservableCollection<Category>> GetCategoriesAsync();

        Task<Category> AddCategoryAsync(Category category);

        Task<bool> UpdateCategoryAsync(Category category);

        Task<bool> RemoveCategoryAsync(Category category);

        // Quality
        Task<Quality> GetQualityAsync(string qualityName);

        Task<ObservableCollection<Quality>> GetQualitiesAsync();

        Task<Quality> AddQualityAsync(Quality quality);

        Task<bool> UpdateQualityAsync(Quality quality);

        Task<bool> RemoveQualityAsync(Quality quality);

        //Master Data
        Task<MasterData> GetMasterDataAsync(string qualityName, int sequenceNo);

        Task<ObservableCollection<MasterData>> GetMasterDatasAsync();

        Task<MasterData> AddMasterDataAsync(MasterData masterData);

        Task<bool> UpdateMasterDataAsync(MasterData masterData);

        Task<bool> RemoveMasterDataAsync(MasterData masterData);

        // Ideal Mate
        Task<IdealMate> GetIdealMateAsync(string userId, string qualityName);

        Task<ObservableCollection<IdealMate>> GetIdealMatesAsync(string userId);

        Task<IdealMate> AddIdealMateAsync(IdealMate idealMate);

        Task<bool> UpdateIdealMateAsync(IdealMate idealMate);

        Task<bool> RemoveIdealMateAsync(IdealMate idealMate);

        //Candidate
        Task<Candidate> GetCandidateAsync(string userId, string candidateName);

        Task<ObservableCollection<Candidate>> GetCandidatesAsync(string userId);

        Task<Candidate> AddCandidateAsync(Candidate candidate);

        Task<bool> UpdateCandidateAsync(Candidate candidate);

        Task<bool> RemoveCandidateAsync(Candidate candidate);

        //User Date
        Task<UserDate> GetUserDateAsync(string userId, string candidateName, DateTime dateOfDate, string qualityName);

        Task<ObservableCollection<UserDate>> GetUserDatesAsync(string userId);

        Task<UserDate> AddUserDateAsync(UserDate userDate);

        Task<bool> UpdateUserDateAsync(UserDate userDate);

        Task<bool> RemoveUserDateAsync(UserDate userDate);

    }
}
