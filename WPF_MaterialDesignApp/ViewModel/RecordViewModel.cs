using WPF_MaterialDesignApp.Model.Entity;

namespace WPF_MaterialDesignApp.ViewModel
{
    /// <summary>
    /// View model representing each record.
    /// </summary>
    public sealed class RecordViewModel: ViewModelBase
    {
        private RecordEntity entity;

        public RecordViewModel(RecordEntity entity)
        {
            this.entity = entity;
        }

        public string Time
        {
            get
            {
                return this.entity.Time;
            }
        }

        public string Name
        {
            get
            {
                return this.entity.Name;
            }
        }

        public string TimeAndName
        {
            get
            {
                return string.Format("{0} {1}", this.Time, this.Name);
            }
        }

        public string Details
        {
            get
            {
                return this.entity.Details;
            }
        }
    }
}