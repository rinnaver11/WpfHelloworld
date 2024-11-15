using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHelloworld
{
    public class RequestHandler
    {
        private DatabaseHandler _database;

        public RequestHandler(DatabaseHandler database)
        {
            _database = database;
        }

        public string LoginAttempt(string login, string passwd)
        {
            return _database.ContainsItem(login, passwd) ? "Login successful!" : "User not found!";
        }
    }
}
