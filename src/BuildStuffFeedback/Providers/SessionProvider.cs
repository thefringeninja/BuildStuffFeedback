using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BuildStuffFeedback.Models;
using BuildStuffFeedback.Models.Admin;
using Dapper;

namespace BuildStuffFeedback.Providers
{
    public class SessionProvider : ISessionProvider
    {
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
                return connection.Query<Session>("SELECT * FROM Sessions WHERE SessionId = @SessionId",
                    new {SessionId = id}).SingleOrDefault();
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

        public async Task AddBulkFeedback(int sessionId, Level level, int count)
        {
            var rating = (int)level;
            const string query = "INSERT INTO Feedbacks (SessionId, Rating) VALUES(@sessionId, @rating);";

            using (var connection = OpenConnection())
            using (var transaction = connection.BeginTransaction())
            {
                for (var i = 0; i < count; i++)
                {
                    await connection.QueryAsync(query, new
                    {
                        sessionId,
                        rating
                    });
                }

                transaction.Commit();
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