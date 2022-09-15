using static System.Console;

namespace ShopStructure
{
    public class Bucket
    {
        private Dictionary<Good, (int,int)> bucket = new(); 
        public void AddElement()
        {
            if (bucket.Count == 10)
            {
                WriteLine("Your bucket is full.");
                return;
            }
            var placeholder = Warehouse.GetInstance.Catalogue;
            WriteLine("Type the name and then the desired quantity of goods you want to purchase.");
            Write("Name: ");
            while (true)
            {
                string? name = ReadLine();
                // Checks for empty or incorrect name comparing to the catalogue
                if (name == null || !placeholder.Select(o => o.Name).ToList().Contains(name))
                {
                    WriteLine($"{name} is not in our catalogue.");
                    continue;
                }
                // Checks if an item is already in the bucket
                else if (bucket.Select(o => o.Key.Name).ToList().Contains(name))
                {
                    WriteLine($"{name} have already been added to the bucket.");
                    continue;
                }
                else
                {
                    Write("Amount: ");
                    int amount = System.Convert.ToInt32(ReadLine());
                    WriteLine($"{amount} samples of {name} were succesfully added to the bucket.");
                    bucket.Add(placeholder.Single(o => o.Name == name), (amount,amount*placeholder.Single(o => o.Name == name).Price));
                    break;
                }
            }
        }
        public void RemoveElement()
        {
            if (bucket.Count() == 0)
            {
                WriteLine("Your bucket is empty");
                return;
            }
            WriteLine("Type the name of the good you want to remove from the bucket:");
            while (true)
            {
                string? name = ReadLine();
                // Checks if an item is in the bucket
                if (name == null || !bucket.Select(o => o.Key.Name).ToList().Contains(name))
                {
                    WriteLine($"{name} is not in the bucket.");
                    continue;
                }
                else
                {
                    WriteLine($"{name} was succesfully removed from the bucket.");
                    //placeholder.Single(o => o.Name == name), amount
                    bucket.Remove(bucket.First(o => o.Key.Name == name).Key);
                    break;
                }
            }
        }
        public void ViewBucket()
        {
            WriteLine("You have these goods in your bucket:");
            foreach (Good i in bucket.Keys)
            {
                WriteLine($"{i.Name} x{bucket[i].Item1} -- {bucket[i].Item2:C} ");
            }
        }
        private decimal CalculatePrice()
        {
            decimal accumulator = 0M;
            foreach(var i in bucket.Values)
            {
                accumulator += (i.Item2);
            }
            return accumulator;
        }
        public bool Checkout()
        {
            if (bucket.Count() == 0)
            {
                WriteLine("Your bucket is empty");
                return false;
            }
            ViewBucket();
            WriteLine($"The purchase requires {CalculatePrice():c} in total.");
            WriteLine("Do you confirm your purchase?: Y/N");
            string? choise = ReadLine();
            if (choise == "Y")
            {
                WriteLine($"Thank you for your purchase! Your unique order number is {Random.Shared.Next(0, int.MaxValue)}.");
                return true;
            }    
            else
            {
                WriteLine("Returning to the actions list");
                return false;
            }

        }

    }
}
