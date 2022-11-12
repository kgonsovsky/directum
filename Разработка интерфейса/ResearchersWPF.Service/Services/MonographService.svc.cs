using System.Collections.Generic;
using ResearchersWPF.Service.DataContracts;
using ResearchersWPF.Service.IServices;

namespace ResearchersWPF.Service.Services
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "MonographService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы MonographService.svc или MonographService.svc.cs в обозревателе решений и начните отладку.
    public class MonographService : IMonographService
    {
        public List<Monograph> GetMonographByResearcher(int researcherId)
        {
            var result = new List<Monograph>();
            foreach (var monograph in Business.Logic.ResearcherManagerBl.Instance().GetResearcher(researcherId).Monographs)
            {
                result.Add(new Monograph(monograph));
            }

            return result;
        }

        public int AddMonograph(int researcherId, Monograph monograph)
        {
            return Business.Logic.ResearcherManagerBl.Instance().GetResearcher(researcherId).AddMonograph(monograph.Name,
                monograph.CoauthorLastName, monograph.CoauthorFirstName, monograph.CoauthorMiddleName,
                monograph.ReleaseDate, monograph.PageCount);
        }

        public void UpdateMonograph(Monograph monograph)
        {
            new Business.Logic.MonographBl(monograph.Id).Researcher.UpdateMonograph(
                new Business.Logic.MonographBl(monograph.Id, monograph.Name, monograph.CoauthorLastName,
                    monograph.CoauthorFirstName, monograph.CoauthorMiddleName, monograph.ReleaseDate,
                    monograph.PageCount));
        }

        public void DeleteMonograph(int monographId)
        {
            new Business.Logic.MonographBl(monographId).Researcher.DeleteMonograph(monographId);
        }

        public Monograph GetMonograph(int monographId)
        {
            var monograph = new Business.Logic.MonographBl(monographId);
            monograph.Refresh();
            return new Monograph(monograph);
        }
    }
}
