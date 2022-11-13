using System;

namespace MeetingCard.Data.IManagers
{
    public interface IRequestManager
    {
        int GetPresentation(DateTime dateTime);
        int GetReport(int departmentNumber);
    }
}