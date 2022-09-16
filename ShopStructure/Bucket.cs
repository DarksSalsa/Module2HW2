using System.Xml.Linq;
using static System.Console;

namespace ShopStructure
{
    public class Bucket
    {
        private (Good, int, int)[]  bucket = new (Good, int, int)[20]; 
        public void AddElement()
        {
            if (bucket.Length == 10)
            {
                WriteLine("Your bucket is full.");
                return;
            }
            var placeholder = Warehouse.GetInstance.Catalogue;
            WriteLine("Type the name and then the desired quantity of goods you want to purchase.");
            Write("Name: ");
            for (int i = 0; i < bucket.Length; i++)
                if (bucket[i] != default)
                {
                    break;
                }
                else
                {
                    string? name = ReadLine();
                    Write("Amount: ");
                    int amount = System.Convert.ToInt32(ReadLine());
                    WriteLine($"{amount} samples of {name} were succesfully added to the bucket.");
                    bucket[0] = (placeholder.Single(o => o.Name == name), amount, amount * placeholder.Single(o => o.Name == name).Price);
                    return;
                }
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
                for (int i = 0; i < bucket.Length; i++)
                {
                    if (bucket[i] != default && bucket[i].Item1.Name == name)
                    {
                        WriteLine($"{name} have already been added to the bucket.");
                        continue;
                    }
                }
                Write("Amount: ");
                int amount = System.Convert.ToInt32(ReadLine());
                WriteLine($"{amount} samples of {name} were succesfully added to the bucket.");
                for (int i = 0; i < bucket.Length; i++)
                {
                    if (bucket[i] == default)
                    {
                        bucket[i] = (placeholder.Single(o => o.Name == name), amount, amount * placeholder.Single(o => o.Name == name).Price);
                        break;
                    }
                }
                break;
            }
        }
        public void RemoveElement()
        {
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != default)
                {
                    break;
                }
                else if (i == bucket.Length - 1)
                {
                    WriteLine("Your bucket is empty");
                    return;
                }
            }
            WriteLine("Type the name of the good you want to remove from the bucket:");
            while (true)
            {
                string? name = ReadLine();
                // Checks if an item is in the bucket
                for (int i = 0; i< bucket.Length; i++)
                {
                    if (bucket[i] != default && bucket[i].Item1.Name == name)
                    {
                        WriteLine($"{name} was succesfully removed from the bucket.");
                        bucket[i] = default;
                        break;
                    }
                    else if (i == bucket.Length -1)
                    {
                        WriteLine("There is no item with such name in the bucket");
                        return;
                    }
                }
                break;
            }
        }
        public void ViewBucket()
        {
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i]!= default)
                {
                    break;
                }
                else if(i == bucket.Length -1)
                {
                    WriteLine("Your bucket is empty");
                    return;
                }
            }
            WriteLine("You have these goods in your bucket:");
            foreach (var i in bucket)
            {
                if (i != default)
                {
                    WriteLine($"{i.Item1.Name} x{i.Item2} -- {i.Item3:C} ");
                }
            }
        }
        private decimal CalculatePrice()
        {
            decimal accumulator = 0M;
            foreach(var i in bucket)
            {
                accumulator += (i.Item3);
            }
            return accumulator;
        }
        public bool Checkout()
        {
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != default)
                {
                    break;
                }
                else if (i == bucket.Length - 1)
                {
                    WriteLine("Your bucket is empty");
                    return false;
                }
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
