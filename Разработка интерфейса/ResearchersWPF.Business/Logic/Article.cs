﻿using System;
using ResearchersWPF.Data.Managers;

namespace ResearchersWPF.Business.Logic
{
    public class ArticleBl
    {
        private string _name;
        private string _magazineName;
        private ResearcherBl _researcher;
        private DateTime _releaseDate;

        public int Id { get; }

        // Название статьи
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    Refresh();
                }

                return _name;
            }
        }

        // Название журнала
        public string MagazineName
        {
            get
            {
                if (_magazineName == null)
                {
                    Refresh();
                }

                return _magazineName;
            }
        }

        // Год и месяц издания
        public DateTime ReleaseDate
        {
            get
            {
                if (_releaseDate == DateTime.MinValue)
                {
                    Refresh();
                }

                return _releaseDate;
            }
        }

        public ResearcherBl Researcher
        {
            get
            {
                if (_researcher == null)
                {
                    GetResearcher();
                }

                return _researcher;
            }
        }

        public ArticleBl(int articleId)
        {
            Id = articleId;
        }

        public ArticleBl(int articleId, string name, string magazineName, DateTime releaseDate)
        {
            Id = articleId;
            _name = name;
            _magazineName = magazineName;
            _releaseDate = releaseDate;
        }

        public void Refresh()
        {
            var manager = new FactoryManager();
            var article = manager.GetArticleManager().Find(Id);
            _name = article.Name;
            _magazineName = article.MagazineName;
            _releaseDate = article.ReleaseDate;
        }

        private void GetResearcher()
        {
            var manager = new FactoryManager();
            var researcher = manager.GetResearcherManager().FindByArticle(Id);
            _researcher = new ResearcherBl(researcher.Id, researcher.LastName, researcher.FirstName, researcher.MiddleName, 
                researcher.DepartmentNumber, researcher.Age, researcher.AcademicDegree, researcher.Position);
        }
    }
}