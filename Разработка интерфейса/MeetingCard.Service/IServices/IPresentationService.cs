using System.Collections.Generic;
using System.ServiceModel;
using MeetingCard.Service.DataContracts;

namespace MeetingCard.Service.IServices
{
    [ServiceContract]
    public interface IPresentationService
    {
        [OperationContract]
        List<Presentation> GetPresentationByResearcher(int researcherId);

        [OperationContract]
        int AddPresentation(int researcherId, Presentation presentation);

        [OperationContract]
        void UpdatePresentation(Presentation presentation);

        [OperationContract]
        void DeletePresentation(int presentationId);

        [OperationContract]
        Presentation GetPresentation(int presentationId);
    }
}