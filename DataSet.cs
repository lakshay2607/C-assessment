using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace practice_project
{
    class DataSet1
    {
        //summary
        /*
         By default the tables in the DataSet will have table names as Table, Table1, Table2 etc. 
         So if WE want to give the tables in the DataSet a meaningful name, use the TableName property as shown below.
         dataset.Tables[0].TableName = "Products";

        to create data table-

        DataTable sourceTable = new DataTable();
        sourceTable.Columns.Add("ID");
        sourceTable.Columns.Add("Name");

        DataRow datarow = sourceTable.NewRow();
        datarow["ID"] = reader["ProductId"];
        datarow["Name"] = reader["ProductName"];

        sourceTable.Rows.Add(datarow);
       
        */
        // public void method()
        public static void Main(string[] args)
        {
            try
            {
                DataSet dataSet = new DataSet();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    //DataSet objects are like databases and can hold multiple table and relationships between table
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from student; select * from family_details", connection);
                    dataAdapter.Fill(dataSet);
                }

                DataTable dataTable = dataSet.Tables[0];
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    for (int i = 0; i < dataTable.Columns.Count ; i++)
                    {
                        Console.Write( dataRow[i] + " " );
                    }
                    Console.WriteLine();
                }


                dataSet.Tables[1].TableName = "family_details";

                //DataTable dataTable1 = dataSet.Tables["family_details"]; 

                foreach (DataRow dataRow in dataSet.Tables["family_details"].Rows)
                {
                    for (int i = 0; i < dataSet.Tables["family_details"].Columns.Count ; i++)
                    {
                        Console.Write(dataRow[i] + " ");
                    }
                    Console.WriteLine();
                }

               // to get name of all columns
                foreach( DataColumn dataColumn in dataSet.Tables["family_details"].Columns )
                {
                    Console.Write( dataColumn + " ");
                }
            }
            catch( Exception e)
            {
                Console.WriteLine(e.Message);
            }
            


        }
    }
}

