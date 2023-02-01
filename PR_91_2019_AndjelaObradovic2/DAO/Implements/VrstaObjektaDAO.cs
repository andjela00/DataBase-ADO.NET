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
    public class VrstaObjektaDAO : IVrstaObjektaDAO
    {

        public string VrsteObjekataPoId(int id)
        {
            string query = "select nazivvo from vrstaobjekta where idvo=:id";
            string vrsteObjekataPoId = "";


            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "id", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                            while (reader.Read())
                            {
                                vrsteObjekataPoId=(reader.GetString(0));
                            }
                        
                    }
                }
            }


            return vrsteObjekataPoId;
        }
    }
}
