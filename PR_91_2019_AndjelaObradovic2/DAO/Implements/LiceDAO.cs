using PR_91_2019_AndjelaObradovic2.Connection;
using PR_91_2019_AndjelaObradovic2.Model;
using PR_91_2019_AndjelaObradovic2.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_91_2019_AndjelaObradovic2.DAO.Implements
{
    public class LiceDAO : ILiceDAO
    {
        public Lice FindById(string id)
        {
            string query = "select idl, imel, przl, vrstal, mes_prihodil  from lice where idl=:id";
            Lice lice = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    ParameterUtil.AddParameter(command, "id", DbType.String);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "id", id);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            lice = new Lice(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                        }
                    }

                }
            }

            return lice;
        }

        public  List<Lice> FindByVrstaL(string vrstal)
        {
            string query = "select * from lice where vrstal=:vrstal";
            List<Lice> lica = new List<Lice>();

            using(IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "vrstal", DbType.String);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "vrstal", vrstal);
                    using(IDataReader reader = command.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            Lice lice = new Lice(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                            lica.Add(lice);
                        }
                    }
                }
            }

            return lica;
        }

        public int UkupanDugVrsteLica(string vrstal)
        {
            string query = "select sum(dug) from bilansstanja where idl in (select idl from lice where vrstal =:vrstal)";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "vrstal", DbType.String);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "vrstal", vrstal);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }

        }

    }
}
