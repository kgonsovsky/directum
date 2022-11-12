using System.Collections.Generic;
using ResearchersWPF.Service.IServices;

namespace ResearchersWPF.Service.Services
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ResearcherService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ResearcherService.svc или ResearcherService.svc.cs в обозревателе решений и начните отладку.
    public class ResearcherService : IResearcherService
    {
        public List<DataContracts.Researcher> GetResearchers()
        {
            var result = new List<DataContracts.Researcher>();
            foreach (Business.Logic.ResearcherBl researcher in Business.Logic.ResearcherManagerBl.Instance().ResearcherList)
            {
                result.Add(new DataContracts.Researcher(researcher));
            }
            return result;
        }

        public int AddResearcher(string lastName, string firstName, string middleName, int departmentNumber, int age, string academicDegree, string position)
        {
            return Business.Logic.ResearcherManagerBl.Instance().AddResearcher(lastName, firstName, middleName, departmentNumber, age, academicDegree, position);
        }

        public void UpdateResearcher(DataContracts.Researcher c)
        {
            Business.Logic.ResearcherManagerBl.Instance().UpdateResearcher(new Business.Logic.ResearcherBl(c.ResearcherId, c.LastName, c.LastName, c.LastName,
                c.DepartmentNumber, c.Age, c.AcademicDegree, c.Position));
        }
        
        public void DeleteResearcher(int researcherId)
        {
            Business.Logic.ResearcherManagerBl.Instance().DeleteResearcher(researcherId);
        }
    }
}
