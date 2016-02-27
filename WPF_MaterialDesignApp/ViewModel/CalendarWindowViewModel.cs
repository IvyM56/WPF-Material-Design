using System.Collections.Generic;
using WPF_MaterialDesignApp.Model.Entity;

namespace WPF_MaterialDesignApp.ViewModel
{
    /// <summary>
    /// Main view model for window.
    /// </summary>
    public sealed class CalendarWindowViewModel
    {
        public List<DateViewModel> SourceList
        {
            get;
            private set;
        }

        public CalendarWindowViewModel()
        {
            this.InitializeSourceCollection();
        }

        private void InitializeSourceCollection()
        {
            this.SourceList = new List<DateViewModel>();
            DateEntityCollection source = new DateEntityCollection();
            source.Fill();
            source.SourceCollection.ForEach(item => this.SourceList.Add(new DateViewModel(item)));
        }
    }
}