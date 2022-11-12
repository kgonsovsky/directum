using System;
using System.Collections.Generic;
using ResearchersWPF.Data.Managers;

namespace ResearchersWPF.Business.Logic
{
    public class ResearcherBl
    {
        public int ResearcherId { get; private set; }

        // ФИО
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }

        // Номер отдела
        public int DepartmentNumber { get; private set; }

        // Возраст
        public int Age { get; }

        // Ученая степень
        public string AcademicDegree { get; }

        // Должность
        public string Position { get; }

        // Список статей
        public List<ArticleBl> Articles => GetArticles();
        // Список монографий
        public List<MonographBl> Monographs => GetMonographs();
        // Список докладов
        public List<Presentation> Presentations => GetPresentations();
        // Список научных отчётов
        public List<ReportBl> Reports => GetReports();

        public ResearcherBl(int researcherId, string lastName, string firstName, string middleName, int departmentNumber, int age, 
            string academicDegree, string position)
        {
            ResearcherId = researcherId;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            DepartmentNumber = departmentNumber;
            Age = age;
            AcademicDegree = academicDegree;
            Position = position;
        }

        #region Articles

        public int AddArticle(string name, string magazineName, DateTime releaseDate)
        {
            var manager = new FactoryManager();
            return manager.GetArticleManager().Add(name, magazineName, releaseDate, ResearcherId);
        }

        public void DeleteArticle(int articleId)
        {
            var manager = new FactoryManager();
            manager.GetArticleManager().Delete(articleId);
        }

        public void UpdateArticle(ArticleBl article)
        {
            var manager = new FactoryManager();
            manager.GetArticleManager().Update(article.Id, article.Name, article.MagazineName, article.ReleaseDate);
        }

        private List<ArticleBl> GetArticles()
        {
            var articles = new List<ArticleBl>();
            var manager = new FactoryManager();
            foreach (var article in manager.GetArticleManager().FindByResearcher(this.ResearcherId))
                articles.Add(new ArticleBl(article.Id, article.Name, article.MagazineName, article.ReleaseDate));
            return articles;
        }

        #endregion

        #region Monographs

        public int AddMonograph(string name, string coauthorLastName, string coauthorFirstName,
            string coauthorMiddleName,
            int releaseDate, int pageCount)
        {
            var manager = new FactoryManager();
            return manager.GetMonographManager().Add(name, coauthorLastName, coauthorFirstName, coauthorMiddleName, releaseDate, pageCount, ResearcherId);
        }

        public void DeleteMonograph(int monographId)
        {
            var manager = new FactoryManager();
            manager.GetMonographManager().Delete(monographId);
        }

        public void UpdateMonograph(MonographBl monograph)
        {
            var manager = new FactoryManager();
            manager.GetMonographManager().Update(monograph.Id, monograph.Name, monograph.CoauthorLastName, monograph.CoauthorFirstName, 
                monograph.CoauthorMiddleName, monograph.ReleaseDate, monograph.PageCount);
        }

        private List<MonographBl> GetMonographs()
        {
            var monographs = new List<MonographBl>();
            var manager = new FactoryManager();
            foreach (var monograph in manager.GetMonographManager().FindByResearcher(this.ResearcherId))
                monographs.Add(new MonographBl(monograph.Id, monograph.Name, monograph.CoauthorLastName, monograph.CoauthorFirstName, monograph.CoauthorMiddleName, 
                    monograph.ReleaseDate, monograph.PageCount));
            return monographs;
        }

        #endregion

        #region Presentations

        public int AddPresentation(string name, string conferenceName, DateTime presentationDate)
        {
            var manager = new FactoryManager();
            return manager.GetPresentationManager().Add(name, conferenceName, presentationDate, ResearcherId);
        }

        public void DeletePresentation(int presentationId)
        {
            var manager = new FactoryManager();
            manager.GetPresentationManager().Delete(presentationId);
        }

        public void UpdatePresentation(Presentation presentation)
        {
            var manager = new FactoryManager();
            manager.GetPresentationManager().Update(presentation.Id, presentation.Name, presentation.ConferenceName, presentation.PresentationDate);
        }

        private List<Presentation> GetPresentations()
        {
            var presentations = new List<Presentation>();
            var manager = new FactoryManager();
            foreach (var presentation in manager.GetPresentationManager().FindByResearcher(this.ResearcherId))
                presentations.Add(new Presentation(presentation.Id, presentation.Name, presentation.ConferenceName, presentation.PresentationDate));
            return presentations;
        }

        #endregion

        #region Reports

        public int AddReport(string name, int registerNumber, int releaseYear, int pageCount)
        {
            var manager = new FactoryManager();
            return manager.GetReportManager().Add(name, registerNumber, releaseYear, pageCount, ResearcherId);
        }

        public void DeleteReport(int reportId)
        {
            var manager = new FactoryManager();
            manager.GetReportManager().Delete(reportId);
        }

        public void UpdateReport(ReportBl report)
        {
            var manager = new FactoryManager();
            manager.GetReportManager().Update(report.Id, report.Name, report.RegisterNumber, report.ReleaseYear, report.PageCount);
        }

        private List<ReportBl> GetReports()
        {
            var reports = new List<ReportBl>();
            var manager = new FactoryManager();
            foreach (var report in manager.GetReportManager().FindByResearcher(this.ResearcherId))
                reports.Add(new ReportBl(report.Id, report.Name, report.RegisterNumber, report.ReleaseYear, report.PageCount));
            return reports;
        }

        #endregion
    }
}