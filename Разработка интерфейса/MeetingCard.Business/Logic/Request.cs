using System;
using MeetingCard.Data.Managers;

namespace MeetingCard.Business.Logic
{
    public class RequestBl
    {
        public int GetPresentationRequest(DateTime dateTime)
        {
            var manager = new FactoryManager();
            return manager.GetRequestManager().GetPresentation(dateTime);
        }

        public int GetReportRequest(int departmentNumber)
        {
            var manager = new FactoryManager();
            return manager.GetRequestManager().GetReport(departmentNumber);
        }
    }
}