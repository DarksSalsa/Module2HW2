using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ShopStructure
{
    internal sealed class DBConstructor
    {
        private static readonly DBConstructor Instance = new();
   
        static DBConstructor()
        {
        }

        private DBConstructor()
        {
        }

        public static DBConstructor GetInstance
        {
            get
            {
                return Instance;
            }
        }

        public List<Good> GetDB
        {
            get
            {
                return ConstructDB();
            }
        }
        private List<Good> ConstructDB()
        {
            List<Good> db = new();
            var names = File.ReadAllLines("DB imitation.txt");
            for (var i = 0; i < names.Length; i++)
            {
                db.Add(new Good(names[i], Random.Shared.Next(1, 1000)));
            }
            return db;
        }
    }

}
