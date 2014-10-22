using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BuildStuffFeedback.Models;
using Dapper;

namespace BuildStuffFeedback.Providers
{
    public class SessionProvider : ISessionProvider
    {
        private readonly IDbConnection connection;


        public IEnumerable<Session> GetAllSessions()
        {
            using (IDbConnection connection = OpenConnection())
            {
                String sql = "select * from Sessions";

                return connection.Query<Session>(sql);
            }
        }

        public Session GetSession(string id)
        {
            using (IDbConnection connection = OpenConnection())
            {
                return connection.Query<Session>("SELECT * FROM Sessions WHERE Id = @Id",
                    new {Id = id}).SingleOrDefault();
            }
        }

        public void AddFeedback(Feedback feedback)
        {
            var sqlQuery = "INSERT INTO Feedbacks (SessionId, Rating, Comments) " +
                           "VALUES(@SessionId, @Rating, @Comments);";

            using (IDbConnection connection = OpenConnection())
            {
               connection.Query(sqlQuery, feedback);
            }

        }

        //public void AddSession(Session session)
        //{
        //    _database.Insert(session);
        //}

        private IDbConnection OpenConnection()
        {
            return
                new SqlConnection(ConfigurationManager.ConnectionStrings["BuildStuffConnectionString"].ConnectionString);
        }

      
    }

    public interface ISessionProvider
    {
        IEnumerable<Session> GetAllSessions();
        Session GetSession(string Id);
        void AddFeedback(Feedback feedback);
    }
}