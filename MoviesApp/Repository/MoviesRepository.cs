
using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Repository
{
    public class MoviesRepository
    {
        private readonly string connectionString = "Server=INPCD0228\\SQLEXPRESS;DataBase=DeltaxMovies;Integrated Security = SSPI;MultipleActiveResultSets=true";
        public List<MoviesModel> GetAllMovies()
        {
            List<MoviesModel> Movies = new List<MoviesModel>();
            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand("pr_GetAllMovies", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new MoviesModel();
                    item.MovieId = (Int32)reader["MovieId"];
                    item.MovieName = reader["MovieName"].ToString();
                    item.ProducerName = reader["ProducerName"].ToString();
                    item.MoviePlot = reader["MoviePlot"].ToString();
                    item.MoviePoster = reader["MoviePoster"].ToString();
                    item.MovieYear = (DateTime)reader["MovieYear"];
                    Movies.Add(item);
                }
                reader.Close();
                foreach (var i in Movies) {
                    
                    using (var cmd = new SqlCommand("pr_GetAllActorsByMovieId", conn)
                    {
                        CommandType = CommandType.StoredProcedure,
                    })
                    {
                        cmd.Parameters.Add("@MovieId", SqlDbType.Int).Value = i.MovieId;
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        i.Actors = new List<ActorModel>();
                        while (dataReader.Read())
                        {
                            var item = new ActorModel();
                            item.ActorName = dataReader["ActorName"].ToString();
                            i.Actors.Add(item);
                        }
                    }
                }
            }

            return Movies;
        }

        internal bool UpdateMovie(MoviesModel movie)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("pr_UpdateMovie", conn)
            {
                CommandType = CommandType.StoredProcedure,
            })
            {
                cmd.Parameters.Add("@MovieName", SqlDbType.VarChar).Value = movie.MovieName;
                cmd.Parameters.Add("@MoviePlot", SqlDbType.VarChar).Value = movie.MoviePlot;
                cmd.Parameters.Add("@MoviePoster", SqlDbType.VarChar).Value = movie.MoviePoster;
                cmd.Parameters.Add("@MovieYear", SqlDbType.DateTime).Value = movie.MovieYear;
                cmd.Parameters.Add("@ProducerId", SqlDbType.Int).Value = movie.ProducerId;
                cmd.Parameters.Add("@MovieId", SqlDbType.Int).Value = movie.MovieId;
                
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    
                    foreach (var i in movie.Actors)
                    {
                        using (var sqlCommand = new SqlCommand("pr_CreateNewMovieActor", conn)
                        {
                            CommandType = CommandType.StoredProcedure,
                        })
                        {
                            sqlCommand.Parameters.Add("@MovieId", SqlDbType.Int).Value = movie.MovieId;
                            sqlCommand.Parameters.Add("@ActorId", SqlDbType.Int).Value = i.ActorId;
                            sqlCommand.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal bool AddNewMovie(MoviesModel movie)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("pr_CreateNewMovie", conn)
            {
                CommandType = CommandType.StoredProcedure,
            })
            {
                cmd.Parameters.Add("@MovieName", SqlDbType.VarChar).Value = movie.MovieName;
                cmd.Parameters.Add("@MoviePlot", SqlDbType.VarChar).Value = movie.MoviePlot;
                cmd.Parameters.Add("@MoviePoster", SqlDbType.VarChar).Value = movie.MoviePoster;
                cmd.Parameters.Add("@MovieYear", SqlDbType.DateTime).Value = movie.MovieYear;
                cmd.Parameters.Add("@ProducerId", SqlDbType.Int).Value = movie.ProducerId;

                cmd.Parameters.Add("@MovieId", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    int movieId = Convert.ToInt32(cmd.Parameters["@MovieId"].Value);
                    foreach(var i in movie.Actors)
                    {
                        using (var sqlCommand = new SqlCommand("pr_CreateNewMovieActor", conn)
                        {
                            CommandType = CommandType.StoredProcedure,
                        })
                        {
                            sqlCommand.Parameters.Add("@MovieId", SqlDbType.Int).Value = movieId;
                            sqlCommand.Parameters.Add("@ActorId", SqlDbType.Int).Value = i.ActorId;
                            sqlCommand.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal bool AddNewActor(ActorModel actor)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("pr_CreateNewActor", conn)
            {
                CommandType = CommandType.StoredProcedure,
            })
            {
                cmd.Parameters.Add("@ActorName", SqlDbType.VarChar).Value = actor.ActorName;
                cmd.Parameters.Add("@ActorSex", SqlDbType.VarChar).Value = actor.ActorSex;
                cmd.Parameters.Add("@ActorBio", SqlDbType.VarChar).Value = actor.ActorBio;
                cmd.Parameters.Add("@ActorDOB", SqlDbType.DateTime).Value = actor.ActorDOB;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }

        internal bool AddNewProducer(ProducersModel producer)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("pr_CreateNewProducer", conn)
            {
                CommandType = CommandType.StoredProcedure,
            })
            {
                cmd.Parameters.Add("@ProducerName", SqlDbType.VarChar).Value = producer.ProducerName;
                cmd.Parameters.Add("@ProducerBio", SqlDbType.VarChar).Value = producer.ProducerBio;
                cmd.Parameters.Add("@ProducerSex", SqlDbType.VarChar).Value = producer.ProducerSex;
                cmd.Parameters.Add("@ProducerDOB", SqlDbType.DateTime).Value = producer.ProducerDOB;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
                }
        
        }
        

        internal IEnumerable<ProducersModel> GetAllProducers()
        {
            List<ProducersModel> Producers = new List<ProducersModel>();
            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand("pr_GetAllProducers", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new ProducersModel();
                    item.ProducerId = (Int32)reader["ProducerId"];
                    item.ProducerName = reader["ProducerName"].ToString();
                    item.ProducerSex = reader["ProducerSex"].ToString();
                    item.ProducerBio = reader["ProducerBio"].ToString();
                    item.ProducerDOB = (DateTime)reader["ProducerDOB"];
                    Producers.Add(item);
                }
                reader.Close();
            }

            return Producers;
        }

        internal IEnumerable<ActorModel> GetAllActors()
        {
            List<ActorModel> Actors = new List<ActorModel>();
            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand("pr_GetAllActors", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new ActorModel();
                    item.ActorId = (Int32)reader["ActorId"];
                    item.ActorName = reader["ActorName"].ToString();
                    item.ActorSex = reader["ActorSex"].ToString();
                    item.ActorBio = reader["ActorBio"].ToString();
                    item.ActorDOB = (DateTime)reader["ActorDOB"];
                    Actors.Add(item);
                }
                reader.Close();
            }

            return Actors;
        }
    }
}
