using System.Reflection.Metadata.Ecma335;
using static System.Console;
namespace ShopStructure
{
    public static class RunShop
    {
        public static void Shopping()
        {
            WriteLine("Welcome to our shop! Please select your action: ");
            WriteLine("View our catalogue: VC");
            WriteLine("Add goods into bucket: A");
            WriteLine("Remove goods from the bucket: R");
            WriteLine("View your bucket: VB");
            WriteLine("Checkout: C");
            WriteLine("Exit: E");
            Bucket bu = new();
            while (true)
            {
                string? choise = ReadLine();
                switch (choise)
                {
                    case "VC":
                        Warehouse.GetInstance.GetCatalogue();
                        break;
                    case "A":
                        bu.AddElement();
                        break;
                    case "R":
                        bu.RemoveElement();
                        break;
                    case "VB":
                        bu.ViewBucket();
                        break;
                    case "C":
                        {
                            if (bu.Checkout())
                            {
                                return;
                            }
                            break;
                        }
                    case "E":
                        return;
                    default:
                        WriteLine("There is no such action implemented now");
                        break;
                }
                WriteLine("Please select your action:");
            }
        }
    }
}
