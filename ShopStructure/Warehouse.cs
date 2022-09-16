using static System.Console;

namespace ShopStructure
{
    public sealed class Warehouse
    {
        private static readonly Warehouse Instance = new();
        public readonly Good[] Catalogue = DBConstructor.GetInstance.GetDB;

        static Warehouse()
        {
        }
        private Warehouse()
        {
        }

        public static Warehouse GetInstance
        {
            get
            {
                return Instance;
            }
        }
        public void GetCatalogue()
        {
            WriteLine("----------Presenting our catalogue----------");
            for (int i = 0; i < Catalogue.Count(); i++)
            {
                Console.WriteLine($"{Catalogue[i].Name} ----- {Catalogue[i].Price:c}");
            }
        }
        
    }
}