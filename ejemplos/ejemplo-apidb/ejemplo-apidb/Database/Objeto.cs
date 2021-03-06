using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ejemplo_apidb.Database
{
    class Objeto
    {
        protected string tipo;
        
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private List<Parametro> parametros = new List<Parametro>();

        public List<Parametro> Parametros
        {
            get { return parametros; }
            set { parametros = value; }
        }

        private static string conectionString;

        protected static MySqlConnection databaseMySqlConnection()
        {
            MySqlConnection con = new MySqlConnection(ConnectionString());

            return con;
        }

        public static void ConectionString(string server, string port, string database, string user, string password)
        {
            conectionString = "server=" + server + ";user=" + user + ";database=" + database + ";port=" + port + ";password=" + password + ";";
        }

        public static string ConnectionString()
        {
            return conectionString;
        }
        
        public static void Insert(Objeto obj)
        {
            MySqlConnection connectionLive = databaseMySqlConnection();

            MySqlCommand command = new MySqlCommand("Insert" + obj.Tipo, connectionLive);

            command.CommandType = CommandType.StoredProcedure;

            Query(obj, connectionLive, command);
        }

        public static void Update(Objeto obj)
        {
            MySqlConnection connectionLive = databaseMySqlConnection();

            MySqlCommand command = new MySqlCommand("Update" + obj.Tipo, connectionLive);

            command.CommandType = CommandType.StoredProcedure;

            Query(obj, connectionLive, command);
        }

        public static void Delete(Objeto obj)
        {
            MySqlConnection connectionLive = databaseMySqlConnection();

            MySqlCommand command = new MySqlCommand("Delete" + obj.Tipo, connectionLive);

            command.CommandType = CommandType.StoredProcedure;

            Query(obj, connectionLive, command);
        }

        private static void Query(Objeto obj, MySqlConnection con, MySqlCommand com)
        {
            foreach (Parametro param in obj.Parametros)
            {
                com.Parameters.AddWithValue(param.Arg, param.Value);
            }

            try
            {
                con.Open();

                com.ExecuteNonQuery();

                con.Close();
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.ToString());
                throw new Exception(ex.ToString());
            }
        }       
    }
}
