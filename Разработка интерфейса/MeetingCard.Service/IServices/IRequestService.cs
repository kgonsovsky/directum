using System;
using System.ServiceModel;

namespace MeetingCard.Service.IServices
{
    [ServiceContract]
    public interface IRequestService
    {
        [OperationContract]
        int GetPresentationRequest(DateTime dateTime);

        [OperationContract]
        int GetReportRequest(int departmentNumber);
    }
}