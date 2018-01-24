using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            string query = $"select LastName, BirthDate from Employees" +
$"where BirthDate BETWEEN '1950-12-08' AND '1980-01-01'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet dataSet = new DataSet();
                //adapter.Fill(dataSet);
                //foreach (DataRow row in dataSet.Tables[0].Rows)
                //{
                //    Console.WriteLine(row.ItemArray[2] + " " + row.ItemArray[5]);
                //}

                //string querySecond = $"select LastName, Country from Employees";
                //SqlDataAdapter adapterSecond = new SqlDataAdapter(querySecond, connection);
                //adapterSecond.Fill(dataSet);
                //foreach (DataRow row in dataSet.Tables[0].Rows)
                //{
                //    Console.WriteLine(row.ItemArray[0]+"\t"+ row.ItemArray[1]);
                //}

                string querySecond = $"select * from Products ORDER BY UnitsInStock";
                SqlDataAdapter adapterSecond = new SqlDataAdapter(querySecond, connection);
                adapterSecond.Fill(dataSet);
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine(row.ItemArray[0] + "\t" + row.ItemArray[1]);
                }


                connection.Close();
                Console.ReadLine();







            }



        }
    }
}
