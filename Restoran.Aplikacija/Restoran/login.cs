using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Restoran
{
    public class login

    {
        private readonly string _filePath;

        public login(string filePath)
        { 
            _filePath = filePath;
        }
        public login()
        {
            _filePath = "logins.txt";
        }

        public bool Authenticate(string username, string password)
        {
            if (!File.Exists(_filePath))
                throw new FileNotFoundException($"Fajl sa login podacima nije pronađen: {_filePath}");

            var lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length == 2)
                {
                    if (parts[0].Trim() == username && parts[1].Trim() == password)
                        return true;
                }
            }

            return false; // ako ništa nije pronađeno
        }
    }
}
