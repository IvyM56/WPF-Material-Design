using System;
using System.Data;

namespace WPF_MaterialDesignApp.Model.Entity
{
    /// <summary>
    /// Represents entity for each record in the calendar.
    /// </summary>
    public sealed class RecordEntity
    {
        private int id;
        private string time;
        private string name;
        private string details;
        private DateEntity date;

        public RecordEntity(DataRow sourceRow)
        {
            this.id = Convert.ToInt32(sourceRow["ID"]);
            this.time = sourceRow["TimeColumn"].ToString().Trim();
            this.name = sourceRow["NameColumn"].ToString().Trim();
            this.details = sourceRow["DetailsColumn"].ToString().Trim();
        }

        DateEntity Date
        {
            get
            {
                return this.date;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Time
        {
            get
            {
                return this.time;
            }

            set
            {
                this.time = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }

            set
            {
                this.details = value;
            }
        }
    }
}
