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
    public class ObjekatDAO : IObjekatDAO
    {
        public int CenaObjekataPoLicima(string id)
        {
            int cena = 0;
            string query = "select sum(vrednost) from objekat group by idl having idl =:id";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.String);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "id", id);

                    cena = Convert.ToInt32(command.ExecuteScalar());

                }
            }
                
           return cena;
        }

        public IEnumerable<Objekat> ObjektiPoLicima(string idl)
        {
            string query = "select ido, idl, idvo, povrsina, adresa, vrednost from objekat where idl=:idl";
            List<Objekat> objekti = new List<Objekat>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idl", DbType.String);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idl", idl);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Objekat objekat = new Objekat(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)
                                                            , reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5));
                            objekti.Add(objekat);                        
                        }
                    }

                }

            }
                return objekti;
        }

        public List<Objekat> ObjektiPoVrstiLica(string vrstal)
        {
            string query = "select * from objekat where idl in (select idl from lice where vrstal =:vrstal) ";
            List<Objekat> objektiPoVrstiLica = new List<Objekat>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "vrstal", DbType.String);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "vrstal", vrstal);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Objekat objekat = new Objekat(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)
                                                            , reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5));
                            objektiPoVrstiLica.Add(objekat);
                        }
                    }
                }
            }

           return objektiPoVrstiLica;
        }

        public int IzbrojObjektePoVrstiLica(string vrstal)
        {
            string query = "select count(*) from objekat where idl in (select idl from lice where vrstal =:vrstal) ";

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

        public List<Objekat> SviObjektiPoVrsti( string vrstaObjekta)
        {
            string query = "select * from objekat where idvo in (select idvo from vrstaobjekta where nazivvo = :vrstaObjekta)";
            List<Objekat> sviObjektiPoVrsti = new List<Objekat>();
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "vrstaObjekta", DbType.String);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "vrstaObjekta", vrstaObjekta);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Objekat objekat = new Objekat(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)
                                                            , reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5));
                            sviObjektiPoVrsti.Add(objekat);
                        }
                    }
                }
            }
            return sviObjektiPoVrsti;
        }

        public double ProsecnaVrednostObjektaPoTipu(string vrstaObjekta)
        {
            string query = "select avg(vrednost) from objekat where idvo in (select idvo from vrstaobjekta where nazivvo = :vrstaObjekta)";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "vrstaObjekta", DbType.String);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "vrstaObjekta", vrstaObjekta);

                    return Convert.ToDouble(command.ExecuteScalar());
                }
            }
        }

        public int Count()
        {
            string query = "select count(*) from objekat";
            int count = 0;

            using ( IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    count = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return count;
        }

        public int Delete(Objekat entity)
        {
            int id = entity.IDO;
            string query = "delete from objekat where ido=:id";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "id", id);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteAll()
        {
            string query = "delete from objekat";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteById(int id)
        {
            string query = "delete from objekat where ido=:id";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "id", id);
                    return command.ExecuteNonQuery();

                }

            }
        }

        public bool ExistsById(int id)
        {
            string query = "select * from objekat where ido=:id";
            bool val = false;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);

                    if (command.ExecuteScalar() != null)
                    {
                        val = true;
                    }

                    return val;
                }
            }
        }

        public IEnumerable<Objekat> FindAll()
        {
            string query = "select ido,idl,idvo,povrsina,adresa,vrednost from objekat";
            List<Objekat> objekti = new List<Objekat>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection()) 
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand()) 
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        do
                        {
                            Objekat objekat = new Objekat(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                                                          reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5));
                            objekti.Add(objekat);

                        }
                        while (!(reader.Read()));
                    }
                }
            }

            return objekti;
        }

        public IEnumerable<Objekat> FindAllById(IEnumerable<int> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ido, idl,idvo, povrsina, adresa, vrednost from objekat where idl in (");
            foreach (int ido in ids)
            {
                sb.Append(":id" + ids + ",");
            }
            sb.Remove(sb.Length - 1, 1); // delete last ','
            sb.Append(")");

            List<Objekat> objekti = new List<Objekat>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (int id in ids)
                    {
                        ParameterUtil.AddParameter(command, "id" + id, DbType.Int32);
                    }
                    command.Prepare();

                    foreach (int id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "id" + id, id);
                    }
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Objekat objekat = new Objekat(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                                                          reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5));
                            objekti.Add(objekat);
                        }
                    }
                }
            }

            return objekti;
        }

        public Objekat FindById(int id)
        {
            string query = "select * from objekat where ido=:id";
            Objekat objekat=null;

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
                            objekat = new Objekat(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                                                          reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5));
                        }
                    }

                }
            }

            return objekat;
        }

        public int Save(Objekat entity)
        {
            string insertSql = "insert into objekat (idl, idvo,  povrsina, adresa, vrednost) " +
                "values (:idl , :idvo, :povrsina, :adresa, :vrednost)";
            string updateSql = "update objekat set ido=:ido, idl=:idl, " +
                "povrsina=:povrsina, adresa=:adresa, vrednost=:vrednost where idvo=:idvo";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = ExistsById(entity.IDO) ? updateSql : insertSql;
                    ParameterUtil.AddParameter(command, "idl", DbType.String, 2);
                    ParameterUtil.AddParameter(command, "idvo", DbType.Int32);
                    ParameterUtil.AddParameter(command, "povrsina", DbType.Int32);
                    ParameterUtil.AddParameter(command, "adresa", DbType.String, 50);
                    ParameterUtil.AddParameter(command, "vrednost", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idl", entity.IDL);
                    ParameterUtil.SetParameterValue(command, "idvo", entity.IDVO);
                    ParameterUtil.SetParameterValue(command, "povrsina", entity.Povrsina);
                    ParameterUtil.SetParameterValue(command, "adresa", entity.Adresa);
                    ParameterUtil.SetParameterValue(command, "vrednost", entity.Vrednost);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int SaveAll(IEnumerable<Objekat> entities)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction();

                int numSaved = 0;

                
                foreach (Objekat objekat in entities)
                {
                    
                    numSaved += Save(objekat);
                }

                
                transaction.Commit();

                return numSaved;
            }
        }
    }
}
