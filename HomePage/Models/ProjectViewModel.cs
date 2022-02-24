using Microsoft.Extensions.Localization;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomePage.Models
{
    public class ProjectsViewModel
    {
        public ProjectWrapper[] ExistingProjects;

        public ProjectWrapper SelectedProject;

        private PageMode _pageMode;

        private PageMode _pageParentMode;

        public enum PageMode
        {
            Inspect,
            Add,
            AddingImage,
            AddingTags,
            Modify,
        }

        public Image CreatingImage { get; set; }

        public string CreatingTag { get; set; }

        public PageMode CurrentMode
        {
            get => _pageMode;
            set => SetPageMode(value);
        }

        public bool HasProjectSelected
        { get => SelectedProject != null; set { } }

        public bool IsAddingProject
        { get => (CurrentMode == PageMode.Add || CurrentMode == PageMode.AddingImage || CurrentMode == PageMode.AddingTags); set { } }

        private IStringLocalizer<App> _localizer;

        public ProjectsViewModel(IStringLocalizer<App> library)
        {
            _localizer = library;
        }

        public Dictionary<PageMode, string> GetModes()
        {
            return new Dictionary<PageMode, string>()
{
                { PageMode.Add, _localizer["Add"] },
                { PageMode.Modify, _localizer["Modify"] },
                { PageMode.Inspect, _localizer["Inspect"] }
            };
        }

        public Dictionary<ProjectType, string> GetProjectTypes()
        {
            return new Dictionary<ProjectType, string>()
            {
                { ProjectType.Default, _localizer["Default"] },
                { ProjectType.Work, _localizer["Work"] },
                { ProjectType.Personal, _localizer["Personal"] },
                { ProjectType.School, _localizer["School"] },
            };
        }

        public KeyValuePair<ProjectType, string> GetProjectTypes(string label)
        {
            return GetProjectTypes().FirstOrDefault(i => (i.Value) == label);
        }

        public KeyValuePair<ProjectType, string> GetProjectTypes(int projectTypeID)
        {
            return GetProjectTypes().FirstOrDefault(i => ((int)i.Key) == projectTypeID);
        }

        public string[] GetModesAsArray()
        {
            return GetModes().Values.ToArray();
        }

        public PageMode SetPageMode(PageMode mode)
        {
            if (mode == PageMode.AddingImage || mode == PageMode.AddingTags)
            {
                CreatingImage = new Image();
                CreatingTag = null;
                _pageMode = mode;
            }
            else
            {
                _pageParentMode = mode;
                _pageMode = mode;
            }

            return _pageMode;
        }

        public void UndoPageMode(Services.LogService logService)
        {
            if (_pageMode == PageMode.AddingImage || _pageMode == PageMode.AddingTags)
            {
                _pageMode = _pageParentMode;
            }
        }
    }
}