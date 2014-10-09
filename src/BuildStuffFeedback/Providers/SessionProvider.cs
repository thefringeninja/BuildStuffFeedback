using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BuildStuffFeedback.Models;
using PetaPoco;

namespace BuildStuffFeedback.Providers
{
    public class SessionProvider : ISessionProvider
    {
        private readonly Database _database;

        public SessionProvider()
        {
            _database = GetDatabase();
        }

        private static Database GetDatabase()
        {
            // A sqlite database is just a file.
            String fileName =  @"..\..\Db\buildstuff.db";
            
            String connectionString = "Data Source=" + fileName;
            DbProviderFactory sqlFactory = new SQLiteFactory();
            Database db = new Database(connectionString, sqlFactory);
            return db;
        }

        public IEnumerable<Session> GetAllSessions()
        {
            String sql = "select * from Sessions";
            return _database.Query<Session>(sql);

        }

        public Session GetSession(string id)
        {
            String sql = string.Format("select * from Sessions where sessionId = {0}",id);
            return _database.Single<Session>(sql);
        }

        public void AddFeedback(Feedback feedback)
        {
            _database.Insert(feedback);
        }

        public void AddSession(Session session)
        {
            _database.Insert(session);
        }
    }

    public interface ISessionProvider
    {
        IEnumerable<Session> GetAllSessions();
        Session GetSession(string Id);
        void AddFeedback(Feedback feedback);

    }
}
