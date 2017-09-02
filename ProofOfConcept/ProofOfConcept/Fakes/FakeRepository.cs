using ProofOfConcept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.Fakes
{
    public class FakeRepository
    {
        public Config configuration = new Config { Id = Guid.NewGuid().ToString(), LowRatingBegin = 1, LowRatingEnd = 3, MedRatingBegin = 4, MedRatingEnd = 6, HighRatingBegin = 7, HighRatingEnd = 10, WelcomeMessage = "Welcome New User!" };
        public List<User> users = new List<User>
        {
            new User { Id = Guid.NewGuid().ToString(), UserId = "Admin", Password = "password", UserName = "Admin", UserEmail = "admin@gibsonsoftwarecompany.com", AccessLevel = 10 },
            new User { Id = Guid.NewGuid().ToString(), UserId = "Sue99", Password = "password", UserName = "Sue Friendly", UserEmail = "sue.friendly@phoney.com", AccessLevel = 1 }
        };
        public List<Category> categories = new List<Category>
        {
            new Category { Id = Guid.NewGuid().ToString(), CategoryName = "Outlook on Life", AccessLevel = 1},
            new Category { Id = Guid.NewGuid().ToString(), CategoryName = "Maturity", AccessLevel = 1},
            new Category { Id = Guid.NewGuid().ToString(), CategoryName = "Education/Career", AccessLevel = 1},
            new Category { Id = Guid.NewGuid().ToString(), CategoryName = "Emotional qualities", AccessLevel = 1},
            new Category { Id = Guid.NewGuid().ToString(), CategoryName = "Social qualities", AccessLevel = 1},
            new Category { Id = Guid.NewGuid().ToString(), CategoryName = "Integrity and morals", AccessLevel = 1},
            new Category { Id = Guid.NewGuid().ToString(), CategoryName = "Intellectual qualities", AccessLevel = 1},
            new Category { Id = Guid.NewGuid().ToString(), CategoryName = "Spirituality", AccessLevel = 1},
            new Category { Id = Guid.NewGuid().ToString(), CategoryName = "Looks", AccessLevel = 1},

        };

        public List<Quality> qualities = new List<Quality>
        {
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Trustworthy/Loyal", CategoryName = "Integrity and morals", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Loyal", CategoryName = "Integrity and morals", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Loving", CategoryName = "Emotional qualities", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Intelligent", CategoryName = "Intellectual qualities", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Moral", CategoryName = "Integrity and morals", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Funny/Sense of humor", CategoryName = "Outlook on Life", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Good Listener", CategoryName = "Emotional Qualities", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Compassionate/Empathetic", CategoryName = "Emotional Qualities", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Supportive", CategoryName = "Emotional qualities", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Optimistic/Positive", CategoryName = "Outlook on Life", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Fun-loving", CategoryName = "Outlook on Life", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Peaceful/Calm/Relaxed", CategoryName = "Emotional qualities", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Well-read", CategoryName = "Intellectual qualities", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Confident", CategoryName = "Emotional qualities", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Imaginative/creative", CategoryName = "Intellectual qualities", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Down to earth", CategoryName = "Emotional qualities", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Attractive/handsome/beautiful", CategoryName = "Looks", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Hard-working", CategoryName = "Maturity", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Resourceful", CategoryName = "Maturity", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Genuine/authentic", CategoryName = "Social qualities", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Has self-respect", CategoryName = "Social qualities", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Nurturing", CategoryName = "Emotional qualities", AccessLevel = 1},
            new Quality {Id = Guid.NewGuid().ToString(), QualityName = "Well-spoken", CategoryName = "Intellectual qualities", AccessLevel = 1},
        };

        public List<MasterData> masterDatas = new List<MasterData>
        {
            new MasterData {Id = Guid.NewGuid().ToString(), QualityName = "Trustworthy/Loyal", SequenceNo = 1,
                AdviceLow = "Low trust suggests a person who cannot be loyal or committed to a relationship. Perhaps, this is a quality you tolerate because it helps you be less vulnerable.",
                AdviceMed = " At the beginning of a relationship, a moderate amount of trust enables you to reflect and not commit to soon.  Moderate trust also keeps us from taking the other for granted.",
                AdviceHigh = "High trust makes us feel secure and more likely to be open about ourselves. However, it may indicate a naïve attitude toward the other and not seeing the other as they truly are.",
                AccessLevel = 1},
           new MasterData {Id = Guid.NewGuid().ToString(), QualityName = "Loyal", SequenceNo = 1,
                AdviceLow = "Low trust suggests a person who cannot be loyal or committed to a relationship. Perhaps, this is a quality you tolerate because it helps you be less vulnerable.",
                AdviceMed = " At the beginning of a relationship, a moderate amount of trust enables you to reflect and not commit to soon.  Moderate trust also keeps us from taking the other for granted.",
                AdviceHigh = "High trust makes us feel secure and more likely to be open about ourselves. However, it may indicate a naïve attitude toward the other and not seeing the other as they truly are.",
                AccessLevel = 1},
           new MasterData {Id = Guid.NewGuid().ToString(), QualityName="Loving", SequenceNo = 1,
                AdviceLow = "Eliminate--too loaded a word to define",
                AdviceMed = "If changed to compassionate (different from empathy--below) then low compassion or caring suggests an unwillingness to help others without personal gain and so selfishness. Is this person willing to at times put your interests above their own?",
                AdviceHigh = "Moderate compassion suggests a balance between self-interest and caring for others (selflessness).  However, if compassion for others is a very high value for you, a moderate score  may not reflect enough dedication to others, the planet, etc.",
                AccessLevel = 1},
           new MasterData {Id = Guid.NewGuid().ToString(), QualityName = "Intelligent", SequenceNo = 1,
               AdviceLow = "Intelligence of the other depends on how you perceive your intelligence. If much lower than yours, will you be bored or burdened by doing the other's thinking?",
               AdviceMed = "Average intelligence compared to yours might make discussions and arguments more productive and fair. Still, you may prefer someone smarter than you that you can idealize.",
               AdviceHigh = "If you are both matched on high intelligence, what heights of thinking could you both attain? But if you're comparatively much lower, will the other  respect you?",
               AccessLevel = 1
           },
           new MasterData {Id = Guid.NewGuid().ToString(), QualityName = "Moral", SequenceNo = 1,
               AdviceLow = "Low morals could be exciting if you're attracted to bad-asses or criminal types. Morals are hard to judge unless they are tested or their history revealed.",
               AdviceMed = "Moderate morals suggests a capacity to be flexible and situational with moral dilemmas. Are their some moral issues that you are unwilling to compromise on?",
               AdviceHigh = "Very high morals are often admired but they may suggest inflexibility and self-righteousness. They may help you be a moral person.",
               AccessLevel = 1
           }
        };

        public List<Candidate> candidates = new List<Candidate>
        {
            new Candidate {Id = Guid.NewGuid().ToString(), CandidateName = "Frank Smith", UserId = "Sue99", DateScore = 5, LastDate = new DateTime(2017,8,15)},
            new Candidate {Id = Guid.NewGuid().ToString(), CandidateName = "Tom Jones", UserId = "Sue99", DateScore = 9, LastDate = new DateTime(2017, 8, 24)}
        };

        public List<IdealMate> idealMates = new List<IdealMate>
        {
            new IdealMate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", QualityName = "Confident", ScoreValue = 8},
            new IdealMate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", QualityName = "Compassionate/Empathetic", ScoreValue = 4},
            new IdealMate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", QualityName = "Loyal", ScoreValue = 9},
            new IdealMate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", QualityName = "Down to earth", ScoreValue = 3},
            new IdealMate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", QualityName = "Resourceful", ScoreValue = 2},
            new IdealMate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", QualityName = "Genuine/authentic", ScoreValue = 8},
            new IdealMate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", QualityName = "Nurturing", ScoreValue = 7},
            new IdealMate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", QualityName = "Well-read", ScoreValue = 5},
            new IdealMate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", QualityName = "Well-spoken", ScoreValue = 6}
        };

        public List<UserDate> userDates = new List<UserDate>
        {
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Frank Smith", QualityName = "Confident", DateScore = 5, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Frank Smith", QualityName = "Compassionate/Empathetic", DateScore = 3, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Frank Smith", QualityName = "Loyal", DateScore = 5, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Frank Smith", QualityName = "Down to earth", DateScore = 6, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Frank Smith", QualityName = "Resourceful", DateScore = 8, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Frank Smith", QualityName = "Genuine/authentic", DateScore = 1, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Frank Smith", QualityName = "Nurturing", DateScore = 2, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Frank Smith", QualityName = "Well-read", DateScore = 3, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Frank Smith", QualityName = "Well-spoken", DateScore = 1, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },

            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Tom Jones", QualityName = "Confident", DateScore = 5, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Tom Jones", QualityName = "Compassionate/Empathetic", DateScore = 3, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Tom Jones", QualityName = "Loyal", DateScore = 5, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Tom Jones", QualityName = "Down to earth", DateScore = 6, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Tom Jones", QualityName = "Resourceful", DateScore = 8, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Tom Jones", QualityName = "Genuine/authentic", DateScore = 1, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Tom Jones", QualityName = "Nurturing", DateScore = 2, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Tom Jones", QualityName = "Well-read", DateScore = 3, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
            new UserDate {Id = Guid.NewGuid().ToString(), UserId = "Sue99", CandidateName = "Tom Jones", QualityName = "Well-spoken", DateScore = 1, DateOfDate = new DateTime(2017, 8, 15), AdviceGiven = "" },
        };

    }
}
