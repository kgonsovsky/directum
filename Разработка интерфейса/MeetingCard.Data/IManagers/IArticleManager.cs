using System;
using System.Collections.Generic;
using MeetingCard.Data.Model;

namespace MeetingCard.Data.IManagers
{
    public interface IArticleManager
    {
        int Add(string name, string magazineName, DateTime releaseDate, int researcherId);
        void Delete(int articleId);
        void Update(int articleId, string name, string magazineName, DateTime releaseDate);
        List<Article> FindByResearcher(int researcherId);
        Article Find(int articleId);
    }
}