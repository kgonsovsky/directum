using System.Collections.Generic;
using System.ServiceModel;
using MeetingCard.Service.DataContracts;

namespace MeetingCard.Service.IServices
{
    [ServiceContract]
    public interface IArticleService
    {
        [OperationContract]
        List<Article> GetArticleByResearcher(int researcherId);

        [OperationContract]
        int AddArticle(int researcherId, Article article);

        [OperationContract]
        void UpdateArticle(Article article);

        [OperationContract]
        void DeleteArticle(int articleId);

        [OperationContract]
        Article GetArticle(int articleId);
    }
}