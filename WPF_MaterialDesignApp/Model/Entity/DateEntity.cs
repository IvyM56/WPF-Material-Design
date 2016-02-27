using System;
using System.Collections.Generic;
using System.Data;

namespace WPF_MaterialDesignApp.Model.Entity
{
    /// <summary>
    /// Holds collection of date entities.
    /// </summary>
    public sealed class DateEntityCollection
    {
        public List<DateEntity> SourceCollection = new List<DateEntity>();
        private bool isFilled;

        public void Fill()
        {
            if (this.isFilled)
                return;

            MyDataSource source = new MyDataSource();
            foreach (DataRow row in source.RecordsSet.Tables["DateTable"].Rows)
                this.SourceCollection.Add(new DateEntity(row));

            this.isFilled = true;
        }
    }

    /// <summary>
    /// Represents date entity.
    /// </summary>
    public sealed class DateEntity
    {
        private int id;
        private int day;
        private int month;
        private int year;
        public List<RecordEntity> RecordList = new List<RecordEntity>();

        public DateEntity(DataRow sourceRow)
        {
            this.id = Convert.ToInt32(sourceRow["ID"]);
            this.day = Convert.ToInt32(sourceRow["DayColumn"]);
            this.month = Convert.ToInt32(sourceRow["MonthColumn"]);
            this.year = Convert.ToInt32(sourceRow["YearColumn"]);

            var relation = sourceRow.Table.ChildRelations[0];
            foreach (DataRow row in sourceRow.GetChildRows(relation))
                this.RecordList.Add(new RecordEntity(row));
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public int Day
        {
            get
            {
                return this.day;
            }

            set
            {
                this.day = value;
            }
        }

        public int Month
        {
            get
            {
                return this.month;
            }

            set
            {
                this.month = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            set
            {
                this.year = value;
            }
        }
    }
}
