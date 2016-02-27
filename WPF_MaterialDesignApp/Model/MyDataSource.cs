using System;
using System.Data;

namespace WPF_MaterialDesignApp.Model
{
    /// <summary>
    /// Gets demo data.
    /// </summary>
    public sealed class MyDataSource
    {
        public DataSet RecordsSet = new DataSet();

        public MyDataSource()
        {
            this.InitializeData();
        }

        private void InitializeData()
        {
            //
            // Create table which contains date information.
            //
            var dateTable = new DataTable("DateTable");
            var keyColumn = new DataColumn("ID");
            keyColumn.AutoIncrement = true;
            keyColumn.AutoIncrementStep = 1;

            dateTable.Columns.Add(keyColumn);
            dateTable.PrimaryKey = new DataColumn[] {keyColumn };

            dateTable.Columns.Add("DayColumn", typeof(int));
            dateTable.Columns.Add("MonthColumn", typeof(int));
            dateTable.Columns.Add("YearColumn", typeof(int));

            DateTime day;
            int counter = 0;
            for (int number = -3; number <= 3; number++, counter++)
            {
                day = DateTime.Today.AddDays(number);
                dateTable.Rows.Add(counter, day.Day, day.Month, day.Year);
            }
            RecordsSet.Tables.Add(dateTable);


            var detailsTable = new DataTable("DetailsTable");

            var detailsForeignKeyColumn = new DataColumn("ID");
            detailsForeignKeyColumn.AutoIncrement = true;
            detailsForeignKeyColumn.AutoIncrementStep = 1;
            detailsTable.Columns.Add(detailsForeignKeyColumn);
            detailsTable.PrimaryKey = new DataColumn[] { detailsForeignKeyColumn };

            detailsTable.Columns.Add("DateID", typeof(int));
            detailsTable.Columns.Add("TimeColumn", typeof(string));
            detailsTable.Columns.Add("NameColumn", typeof(string));
            detailsTable.Columns.Add("DetailsColumn", typeof(string));

   

            detailsTable.Rows.Add(0, 1, "12.00", "Mockups creation", "Pri minim possim id, ad mundi argumentum eam. Apeirian conceptam argumentum eos ad, eam duis pertinax ne, has ne habeo probatus.");

            detailsTable.Rows.Add(1, 3, "09.00", "Light breakfast", "Movet maluisset at duo, quot omnes mel ad,"
                + " graeco epicuri conclusionemque vim ei. Quo ex dico accusamus. Per illud dicunt disputando no."
                + " Prompta constituto sed te. Noster graeco sapientem ad qui, cum nullam appareat ei.");
            detailsTable.Rows.Add(2, 3, "12.00", "Design discussion", "Lorem ipsum dolor sit amet, dolorem reprimique no per,"
                + "facer tollit saperet nam no. Mea elitr menandri legendos te. Erant homero vel ad. Vim prima graeci ne.");
            detailsTable.Rows.Add(3, 3, "15.00", "General functionality implementation", "Duo appetere postulant et."
                + " Has ea iuvaret definitiones interpretaris, ad veritus quaerendum quo, detracto patrioque vulputate ex vis. ");
            

            detailsTable.Rows.Add(4, 4, "10.00", "Demo preparation", "Eum cu tincidunt dissentias,"
                + "id has soleat tamquam atomorum, nec audiam lucilius cu. No vel mazim cetero rationibus. Cu augue inimicus nec, has esse atqui id. Virtute intellegat argumentum nam an, cu his aliquid offendit interpretaris, dicit possit evertitur in ius.");
            detailsTable.Rows.Add(5, 4, "15.00", "Dinner", "Ut nam delenit scripserit."
                +" At quo quot prompta pericula, an mel verear facilis iracundia, nec vidit menandri ne. Epicuri eleifend evertitur eu sea.");

            RecordsSet.Tables.Add(detailsTable);

            DataRelation relation = new DataRelation("Details", keyColumn, detailsTable.Columns["DateID"]);
            RecordsSet.Relations.Add(relation);
        }
    }
}