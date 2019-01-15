using System.Data.OleDb;
using EelsAndEscalators.ClassicEandE;
using System.Collections.Generic;

namespace EelsAndEscalators.Test
{
    public class DBProvider
    {
        public void Test()
        {
            var listescalator = new List<ClassicEscalator>();
            var list = new List<ClassicEel>();

            OleDbConnection connection = new OleDbConnection
                (@"Provider = Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\HNI\Documents\Database1.accdb");
            connection.Open();
            OleDbDataReader reader = null;
            OleDbCommand commandeel = new OleDbCommand
                ("SELECT toplocation, bottomlocation FROM Eel",  connection);
          
            reader = commandeel.ExecuteReader();

            while (reader.Read())
            {
                var testeel = new ClassicEel();
                var top = reader[0];
                var bottom = reader[1];
                testeel.top_location = (int)top;
                testeel.bottom_location = (int)bottom;
                list.Add(testeel);
            }
            reader.Close();
            OleDbCommand commandescalator = new OleDbCommand
                ("SELECT toplocation, bottomlocation FROM Escalator", connection);

            reader = commandescalator.ExecuteReader();

            while (reader.Read())
            {
                var classicEscalator = new ClassicEscalator();

                var top = reader[0];
                var bottom = reader[1];
                classicEscalator.top_location = (int)top;
                classicEscalator.bottom_location = (int)bottom;
                listescalator.Add(classicEscalator);
            }

            reader.Close();
            connection.Close();
        }
    }
}
