using System.Collections.Generic;
using System.ServiceModel;
using MeetingCard.Service.DataContracts;

namespace MeetingCard.Service.IServices
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IResearcherService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IResearcherService
    {
        [OperationContract]
        List<Researcher> GetResearchers();

        [OperationContract]
        int AddResearcher(string lastName, string firstName, string middleName, int departmentNumber, int age, string academicDegree, string position);

        [OperationContract]
        void UpdateResearcher(Researcher c);

        [OperationContract]
        void DeleteResearcher(int researcherId);
    }

}
