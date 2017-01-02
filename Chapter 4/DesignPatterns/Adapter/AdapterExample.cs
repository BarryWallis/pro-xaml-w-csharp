using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter
{
    public class AdapterExample
    {
        /// <summary>
        /// Create and return a DataSet from a SQL query.
        /// </summary>
        /// <returns>The DataSet with the data from the SQL query.</returns>
        public static DataSet GetDataSet()
        {
            SqlConnection connection = new SqlConnection("[cnn string]");
            SqlCommand command = new SqlCommand("[SQL Query]")
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet;
        }
    }
}
