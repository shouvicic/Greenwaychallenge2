using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAvoMart
{
    
    public class Program
    {
        static void Main(string[] args)
        {           
            string inputStr = Console.ReadLine();
            var finalAmount= CheckoutBill(inputStr);
            Console.WriteLine(string.Format("Total Bill Amount = ${0}", finalAmount));
            Console.ReadLine();
        }

        public static double CheckoutBill(string inputStr)
        {
            double finalAmount = 0;
            if (!string.IsNullOrEmpty(inputStr))
            {
                inputStr = inputStr.Substring(1, inputStr.Length - 2).Replace(" ", "");
                String[] arrOfStr = inputStr.Split(',');

                var fruitDict = new Dictionary<string, int>();
                foreach (var fruit in arrOfStr)
                {
                    if (fruitDict.ContainsKey(fruit)) fruitDict[fruit]++;
                    else fruitDict[fruit] = 1;
                }
                finalAmount = AmountToPay(fruitDict);
            }
            return finalAmount;           
        }

        public static void CreateMapping()
        {

        }

        public static double AmountToPay(Dictionary<string, int> fruitDict)
        {
            double finalAmount = 0;
            OffersDTO offersDTO;
            GetOfferListing(out offersDTO);
            foreach (var item in fruitDict)
            {
                int applicableQuantity = 0;
                if (item.Key == Fruits.Apple.ToString())
                {
                    int prelimAmt = item.Value / (offersDTO.Quantity + 1);
                    applicableQuantity = (prelimAmt + prelimAmt) + (item.Value % (offersDTO.Quantity + 1));
                    finalAmount = applicableQuantity * FruitsPrice.Apple;
                }
                else if (item.Key == Fruits.Avocado.ToString())
                {
                    finalAmount = finalAmount + (FruitsPrice.Avocado * item.Value);
                }
            }
            return finalAmount;
        }

        public static void GetOfferListing(out OffersDTO offersDTO)
        {
            offersDTO = new OffersDTO
            {
                FruitName = FruitsPrice.Apple.ToString(),
                Quantity = 2,
                Free =1
            };

        }

        struct FruitsPrice
        {
            public const double Apple = 0.25;
            public const double Avocado = 0.1;
        }
    }

    public class OffersDTO
    {
        //FruitName, Quantity, Free
        public string FruitName { get; set; }
        public int Quantity { get; set; }
        public int Free { get; set; }
    }

    enum Fruits
    {
        Apple,
        Avocado
    }


}
