using System;
using System.Collections.Generic;
using WPF_MaterialDesignApp.Model.Entity;

namespace WPF_MaterialDesignApp.ViewModel
{
    /// <summary>
    /// View model representing each date.
    /// </summary>
    public sealed class DateViewModel: ViewModelBase
    {
        private DateEntity entity;
        private List<RecordViewModel> recordsList = new List<RecordViewModel>();
        private DateTime currentDate;

        public List<RecordViewModel> RecordsList
        {
            get
            {
                return this.recordsList;
            }
        }

        public DateViewModel(DateEntity entity)
        {
            this.entity = entity;
            this.entity.RecordList.ForEach(temp 
                => this.RecordsList.Add(new RecordViewModel(temp)));

            this.currentDate = new DateTime(this.entity.Year, this.entity.Month, this.entity.Day);
        }

        public bool IsMultiSelect
        {
            get
            {
                return this.RecordsList.Count > 0;
            }
        }

        public int Day
        {
            get
            {
                return this.entity.Day;
            }
        }

        public int Month
        {
            get
            {
                return this.entity.Month;
            }
        }

        public string DayOfWeekText
        {
            get
            {
                return this.currentDate.DayOfWeek.ToString().Substring(0, 3);
            }
        }

        public int Year
        {
            get
            {
                return this.entity.Year;
            }
        }
    }
}