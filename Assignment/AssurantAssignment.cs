using System;
using System.IO;

namespace Assignment
{
    class AssurantAssignment
    {
        static void Main(string[] args)
        {
            // create global variables to be used throughout component.
            decimal shirt = 480.00M;
            decimal jeans = 110.00M;
            decimal watch = 1090.00M;
            decimal belt = 460.00M;

            decimal gucciDisc = 15;
            decimal vetDisc = 10;
            
            string orderState;
            int orderStateInt;

            string couponStatus;
            string couponCode;

            decimal gaTax = 7.00M;
            decimal flTax = 6.00M;
            decimal nyTax = 8.88M;
            decimal nmTax = 8.94M;
            decimal nvTax = 8.27M;

            DateTime gucciStart = new DateTime(2019,11,06);
            DateTime gucciEnd = new DateTime(2019,11,12);
            DateTime vetStart = new DateTime(2019,11,07);
            DateTime vetEnd = new DateTime(2019,11,11);
            DateTime currentDate = DateTime.Now;

            //code to add final output of calculator into a file. 
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream ("./FinalCalculatorOutput.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter (ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine ("Cannot open FinalCalculatorOutput.txt for writing");
                Console.WriteLine (e.Message);
                return;
            }

            //A static mock order has been created for all users to represent what a possible order could look like. In a fully functioning component, this data will be retrieved and dynamically built through selected items from a database.
            Console.WriteLine("The line items in your current order are: \n1. Black Gucci Shirt (Luxury Item): ${0}\n2. Dope King Denim Jeans: ${1}\n3. Gucci G-Timeless Dail Watch (Luxury Item): ${2}\n4. Gucci Web Belt w/Interlocking G (Luxury Item): ${3}", shirt, jeans, watch, belt);
            
            //Here the user chooses their state to determine the tax rules implemented on the order.
            Console.WriteLine("\nWhat state are you in? (Enter 1 for GA, 2 for FL, 3 for NY, 4 for NM or 5 for NV)");
            orderState = Console.ReadLine();
            
            //Parse orderState into int for error handling.
            orderStateInt = Int32.Parse(orderState);

            if (orderStateInt >= 1 && orderStateInt <= 5){

                if (orderState == "1"){
                //This is to display a list of coupons and promotions that can be applied to an order. 
                Console.WriteLine("\nCurrent store sales and promotions are: \n{0}% off coupon for all Gucci belts with code 'GUCCI15' between 11/06/2019-11/12/2019\n{1}% off store wide promotional sale for Veteran's Day with code 'VET2019' between 11/07/2019-11/11/2019", gucciDisc, vetDisc);

                //In the event that a user sees a coupon/promotion that they would like to add order, this allows them the option to do so
                Console.WriteLine("\nIs there a coupon/discount to be applied to the purchase?\nEnter 1 for a coupon discount, 2 for promotional storewide savings or 3 for no discount.");
                couponStatus = Console.ReadLine();

                    //Logic for users who want to use a coupon.
                    if (couponStatus == "1"){
                        Console.WriteLine("\nPlease enter your coupon code.");
                        couponCode = Console.ReadLine();

                    

                        if (couponCode == "GUCCI15"){
                            if(currentDate >= gucciStart && currentDate <= gucciEnd){

                                decimal gucciGA = gucciDiscountTaxPost(gucciDisc, shirt, jeans, watch, belt, "Georgia", gaTax);
                                Console.WriteLine(gucciGA);
                            }
                        }
                    }
                    else if (couponStatus == "2"){
                        Console.WriteLine("\nPlease enter your coupon code.");
                        couponCode = Console.ReadLine();

                        if (couponCode == "VET2019"){
                            if(currentDate >= vetStart && currentDate <= vetEnd){

                                decimal vetGA = vetPromotionTaxPost(vetDisc, shirt, jeans, watch, belt, "Georgia", gaTax);
                                Console.WriteLine(vetGA);
                            }
                        }
                    }
                    else if (couponStatus == "3"){
                        decimal noDisc = noDiscount(shirt, jeans, watch, belt, "Georgia", gaTax);
                    }
                    else {
                        Console.WriteLine("You did make a valid selection for if there is a coupon/discount.");
                    }
                }
                else if (orderState == "2"){
                    //This is to display a list of coupons and promotions that can be applied to an order. 
                Console.WriteLine("\nCurrent store sales and promotions are: \n{0}% off coupon for all Gucci belts with code 'GUCCI15' between 11/06/2019-11/12/2019\n{1}% off store wide promotional sale for Veteran's Day with code 'VET2019' between 11/07/2019-11/11/2019", gucciDisc, vetDisc);

                //In the event that a user sees a coupon/promotion that they would like to add order, this allows them the option to do so
                Console.WriteLine("\nIs there a coupon/discount to be applied to the purchase?\nEnter 1 for a coupon discount, 2 for promotional storewide savings or 3 for no discount.");
                couponStatus = Console.ReadLine();

                    //Logic for users who want to use a coupon.
                    if (couponStatus == "1"){
                        Console.WriteLine("\nPlease enter your coupon code.");
                        couponCode = Console.ReadLine();

                    

                        if (couponCode == "GUCCI15"){
                            if(currentDate >= gucciStart && currentDate <= gucciEnd){

                                decimal gucciFL = gucciDiscountTaxPre(gucciDisc, shirt, jeans, watch, belt, "Florida", flTax);
                                Console.WriteLine(gucciFL);
                            }
                        }
                    }
                    else if (couponStatus == "2"){
                        Console.WriteLine("\nPlease enter your promo code.");
                        couponCode = Console.ReadLine();

                        if (couponCode == "VET2019"){
                            if(currentDate >= vetStart && currentDate <= vetEnd){

                            decimal vetFL = vetPromotionTaxPre(vetDisc, shirt, jeans, watch, belt, "Florida", flTax);
                                Console.WriteLine(vetFL);
                            }
                        }
                    }
                    else if (couponStatus == "3"){
                        decimal noDisc = noDiscount(shirt, jeans, watch, belt, "Florida", flTax);
                    }
                    else {
                        Console.WriteLine("You did make a valid selection for if there is a coupon/discount.");
                    }
                } 
                else if (orderState == "3"){
                    //This is to display a list of coupons and promotions that can be applied to an order. 
                Console.WriteLine("\nCurrent store sales and promotions are: \n{0}% off coupon for all Gucci belts with code 'GUCCI15' between 11/06/2019-11/12/2019\n{1}% off store wide promotional sale for Veteran's Day with code 'VET2019' between 11/07/2019-11/11/2019", gucciDisc, vetDisc);

                //In the event that a user sees a coupon/promotion that they would like to add order, this allows them the option to do so
                Console.WriteLine("\nIs there a coupon/discount to be applied to the purchase?\nEnter 1 for a coupon discount, 2 for promotional storewide savings or 3 for no discount.");
                couponStatus = Console.ReadLine();

                    //Logic for users who want to use a coupon.
                    if (couponStatus == "1"){
                        Console.WriteLine("\nPlease enter your coupon code.");
                        couponCode = Console.ReadLine();

                    

                        if (couponCode == "GUCCI15"){
                            if(currentDate >= gucciStart && currentDate <= gucciEnd){

                                decimal gucciNY = gucciDiscountTaxPost(gucciDisc, shirt, jeans, watch, belt, "New York", nyTax);
                                Console.WriteLine(gucciNY);
                            }
                        }
                    }
                    else if (couponStatus == "2"){
                        Console.WriteLine("\nPlease enter your coupon code.");
                        couponCode = Console.ReadLine();

                        if (couponCode == "VET2019"){
                            if(currentDate >= vetStart && currentDate <= vetEnd){

                            decimal vetNY = vetPromotionTaxPost(vetDisc, shirt, jeans, watch, belt, "New York", nyTax);
                                Console.WriteLine(vetNY);
                            }
                        }
                    }
                    else if (couponStatus == "3"){
                        decimal noDisc = noDiscount(shirt, jeans, watch, belt, "New York", nyTax);
                    }
                    else {
                        Console.WriteLine("You did make a valid selection for if there is a coupon/discount.");
                    }
                }
                else if (orderState == "4"){
                    //This is to display a list of coupons and promotions that can be applied to an order. 
                Console.WriteLine("\nCurrent store sales and promotions are: \n{0}% off coupon for all Gucci belts with code 'GUCCI15' between 11/06/2019-11/12/2019\n{1}% off store wide promotional sale for Veteran's Day with code 'VET2019' between 11/07/2019-11/11/2019", gucciDisc, vetDisc);

                //In the event that a user sees a coupon/promotion that they would like to add order, this allows them the option to do so
                Console.WriteLine("\nIs there a coupon/discount to be applied to the purchase?\nEnter 1 for a coupon discount, 2 for promotional storewide savings or 3 for no discount.");
                couponStatus = Console.ReadLine();

                    //Logic for users who want to use a coupon.
                    if (couponStatus == "1"){
                        Console.WriteLine("\nPlease enter your coupon code.");
                        couponCode = Console.ReadLine();

                    

                        if (couponCode == "GUCCI15"){
                            if(currentDate >= gucciStart && currentDate <= gucciEnd){

                                decimal gucciNM = gucciDiscountTaxPre(gucciDisc, shirt, jeans, watch, belt, "New Mexico", nmTax);
                                Console.WriteLine(gucciNM);
                            }
                        }
                    }
                    else if (couponStatus == "2"){
                        Console.WriteLine("\nPlease enter your coupon code.");
                        couponCode = Console.ReadLine();

                        if (couponCode == "VET2019"){
                            if(currentDate >= vetStart && currentDate <= vetEnd){

                            decimal vetNM = vetPromotionTaxPre(vetDisc, shirt, jeans, watch, belt, "New Mexico", nmTax);
                                Console.WriteLine(vetNM);
                            }
                        }
                    }
                    else if (couponStatus == "3"){
                        decimal noDisc = noDiscount(shirt, jeans, watch, belt, "New Mexico", nmTax);
                    }
                    else {
                        Console.WriteLine("You did make a valid selection for if there is a coupon/discount.");
                    }
                }
                else if (orderState == "5"){
                    //This is to display a list of coupons and promotions that can be applied to an order. 
                Console.WriteLine("\nCurrent store sales and promotions are: \n{0}% off coupon for all Gucci belts with code 'GUCCI15' between 11/06/2019-11/12/2019\n{1}% off store wide promotional sale for Veteran's Day with code 'VET2019' between 11/07/2019-11/11/2019", gucciDisc, vetDisc);

                //In the event that a user sees a coupon/promotion that they would like to add order, this allows them the option to do so
                Console.WriteLine("\nIs there a coupon/discount to be applied to the purchase?\nEnter 1 for a coupon discount, 2 for promotional storewide savings or 3 for no discount.");
                couponStatus = Console.ReadLine();

                    //Logic for users who want to use a coupon.
                    if (couponStatus == "1"){
                        Console.WriteLine("\nPlease enter your coupon code.");
                        couponCode = Console.ReadLine();

                    

                        if (couponCode == "GUCCI15"){
                            if(currentDate >= gucciStart && currentDate <= gucciEnd){

                                decimal gucciNV = gucciDiscountTaxPre(gucciDisc, shirt, jeans, watch, belt, "Nevada", nvTax);
                                Console.WriteLine(gucciNV);
                            }
                        }
                    }
                    else if (couponStatus == "2"){
                        Console.WriteLine("\nPlease enter your coupon code.");
                        couponCode = Console.ReadLine();

                        if (couponCode == "VET2019"){
                            if(currentDate >= vetStart && currentDate <= vetEnd){

                            decimal vetNV = vetPromotionTaxPre(vetDisc, shirt, jeans, watch, belt, "Nevada", nvTax);
                                Console.WriteLine(vetNV);
                            }
                        }
                    }
                    else if (couponStatus == "3"){
                        decimal noDisc = noDiscount(shirt, jeans, watch, belt, "Nevada", nvTax);
                    }
                    else {
                        Console.WriteLine("You did make a valid selection for if there is a coupon/discount.");
                    }
                }  
            
            }
            else {
                Console.WriteLine("You did make a valid entry for the State location of your store.");

            }
        }
        public static decimal gucciDiscountTaxPost(decimal gucciDisc, decimal shirt, decimal jeans, decimal watch, decimal belt, string orderState, decimal tax){

            FileStream ostrm ;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;

            ostrm = new FileStream ("./FinalCalculatorOutput.txt", FileMode.OpenOrCreate);
            writer = new StreamWriter(ostrm);

            decimal discPerc; 
            decimal discOff;
            decimal discBelt;
            discPerc = gucciDisc/100;
            discOff = (belt * discPerc);
            discBelt = belt - discOff;

            //Tax logic for discount after tax user
            belt = discBelt;
            decimal taxPerc = tax/100;
            decimal preTax = shirt + belt + jeans + watch;
            decimal taxesTotal = preTax*taxPerc;
            decimal total = preTax + taxesTotal;

            Console.SetOut (writer);
            {
            Console.WriteLine("The current taxes in {0} is {1}%", orderState, tax);
            Console.WriteLine("\nTotals for this order are:\n\nOrder Total pre-tax: ${0}\nDiscount off of your order : ${1}\nTotal taxes paid on order: ${2}\nTotal Due for Order: ${3}", Math.Round(preTax,2), Math.Round(discOff,2), Math.Round(taxesTotal, 2), Math.Round(total,2));
            Console.SetOut (oldOut);
            writer.Close();
            ostrm.Close();

            //also prints the results of calculator into console.
            Console.WriteLine("\nYou received a {0}% discount off of your Gucci Belt!\nThe new prices of the line items are: \n1. Black Gucci Shirt (Luxury Item): ${1}\n2. Dope King Denim Jeans: ${2}\n3. Gucci G-Timeless Dail Watch (Luxury Item): ${3}\n4. Gucci Web Belt w/Interlocking G (Luxury Item): ${4}", gucciDisc, shirt, jeans, watch, belt);
            Console.WriteLine("\nThe current taxes in {0} is {1}%", orderState, tax);
            Console.WriteLine("\nTotals for this order are:\n\nOrder Total pre-tax: ${0}\nDiscount off of your order : ${1}\nTotal Due for Order: ${2}", Math.Round(preTax,2), Math.Round(discOff,2), Math.Round(total,2));
            Console.WriteLine("Results of calculator has also been placed in 'FinalCalculatorOuput.txt' file for logging purposes.");
            Console.Write("The taxes that you paid on your order are: $"); return Math.Round(taxesTotal,2);
            }
             
        }

        public static decimal gucciDiscountTaxPre(decimal gucciDisc, decimal shirt, decimal jeans, decimal watch, decimal belt, string orderState, decimal tax){

            //variable to create and open file to write calculator results into
            FileStream ostrm ;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;

            ostrm = new FileStream ("./FinalCalculatorOutput.txt", FileMode.OpenOrCreate);
            writer = new StreamWriter(ostrm);

            decimal discPerc; 
            decimal discOff;
            decimal discBelt;
            discPerc = gucciDisc/100;
            discOff = belt * discPerc;
            discBelt = belt - discOff;

            //Tax logic for discount before tax user
            belt = discBelt;
            decimal taxPerc = tax/100;
            decimal preTax = shirt + belt + jeans + watch;
            decimal taxesTotal = preTax*taxPerc;
            decimal total = preTax + taxesTotal - discOff;

            Console.SetOut (writer);
            {
            Console.WriteLine("The current taxes in {0} is {1}%", orderState, tax);
            Console.WriteLine("\nTotals for this order are:\n\nOrder Total pre-tax: ${0}\nDiscount off of your order : ${1}\nTotal taxes paid on order: ${2}\nTotal Due for Order: ${3}", Math.Round(preTax,2), Math.Round(discOff,2), Math.Round(taxesTotal, 2), Math.Round(total,2));
            Console.SetOut (oldOut);
            writer.Close();
            ostrm.Close();

            //also prints the results of calculator into console.
            Console.WriteLine("\nYou received a {0}% discount off of your Gucci Belt!\nThe new prices of the line items are: \n1. Black Gucci Shirt (Luxury Item): ${1}\n2. Dope King Denim Jeans: ${2}\n3. Gucci G-Timeless Dail Watch (Luxury Item): ${3}\n4. Gucci Web Belt w/Interlocking G (Luxury Item): ${4}", gucciDisc, shirt, jeans, watch, belt);
            Console.WriteLine("\nThe current taxes in {0} is {1}%", orderState, tax);
            Console.WriteLine("\nTotals for this order are:\n\nOrder Total pre-tax: ${0}\nDiscount off of your order : ${1}\nTotal Due for Order: ${2}", Math.Round(preTax,2), Math.Round(discOff,2), Math.Round(total,2));
            Console.WriteLine("Results of calculator has also been placed in 'FinalCalculatorOuput.txt' file for logging purposes.");
            Console.Write("The taxes that you paid on your order are: $"); return Math.Round(taxesTotal,2);
            }     
        }

       public static decimal vetPromotionTaxPost(decimal vetDisc, decimal shirt, decimal jeans, decimal watch, decimal belt, string orderState, decimal tax){
            
            //variable to create and open file to write calculator results into
            FileStream ostrm ;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;

            ostrm = new FileStream ("./FinalCalculatorOutput.txt", FileMode.OpenOrCreate);
            writer = new StreamWriter(ostrm);

            //Tax logic for discount after tax user
            decimal discTotal;
            decimal discPerc; 
            discPerc = vetDisc/100;
            decimal taxPerc = tax/100;
            decimal preTax = shirt + belt + jeans + watch;
            decimal discOff = preTax * discPerc;
            decimal total = preTax - discOff;
            decimal taxesTotal = total * taxPerc;
            discTotal = total + taxesTotal;

            Console.SetOut (writer);
            {
            Console.WriteLine("The current taxes in {0} is {1}%", orderState, tax);
            Console.WriteLine("\nTotals for this order are:\n\nOrder Total pre-tax: ${0}\nDiscount off of your order : ${1}\nTotal taxes paid on order: ${2}\nTotal Due for Order: ${3}", Math.Round(preTax,2), Math.Round(discOff,2), Math.Round(taxesTotal, 2), Math.Round(discTotal,2));
            Console.SetOut (oldOut);
            writer.Close();
            ostrm.Close();
            
            //also prints the results of calculator into console.
            Console.WriteLine("\nYou received a {0}% promotional discount off of your order!", vetDisc);
            Console.WriteLine("The current taxes in {0} is {1}%", orderState, tax);
            Console.WriteLine("\nTotals for this order are:\n\nOrder Total pre-tax: ${0}\nDiscount off of your order : ${1}\nTotal Due for Order: ${2}", Math.Round(preTax,2), Math.Round(discOff,2), Math.Round(discTotal,2));
            Console.WriteLine("Results of calculator has also been placed in 'FinalCalculatorOuput.txt' file for logging purposes.");
            Console.Write("The taxes that you paid on your order are: $"); return Math.Round(taxesTotal,2);
            }
       } 

       public static decimal vetPromotionTaxPre(decimal vetDisc, decimal shirt, decimal jeans, decimal watch, decimal belt, string orderState, decimal tax){
            
            //variable to create and open file to write calculator results into
            FileStream ostrm ;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;

            ostrm = new FileStream ("./FinalCalculatorOutput.txt", FileMode.OpenOrCreate);
            writer = new StreamWriter(ostrm);
            
            //Tax logic for discount before tax user
            decimal discTotal;
            decimal discPerc; 
            discPerc = vetDisc/100;
            decimal taxPerc = tax/100;
            decimal preTax = shirt + belt + jeans + watch;
            decimal taxesTotal = preTax * taxPerc;
            decimal total = preTax + taxesTotal;
            decimal discOff = total * discPerc;
            discTotal = total - discOff;

            Console.SetOut (writer);
            {
            Console.WriteLine("The current taxes in {0} is {1}%", orderState, tax);
            Console.WriteLine("\nTotals for this order are:\n\nOrder Total pre-tax: ${0}\nDiscount off of your order : ${1}\nTotal taxes paid on order: ${2}\nTotal Due for Order: ${3}", Math.Round(preTax,2), Math.Round(discOff,2), Math.Round(taxesTotal,2), Math.Round(discTotal,2));
            Console.SetOut (oldOut);
            writer.Close();
            ostrm.Close();
            
            //also prints the results of calculator into console.
            Console.WriteLine("\nYou received a {0}% promotional discount off of your order!", vetDisc);
            Console.WriteLine("The current taxes in {0} is {1}%", orderState, tax);
            Console.WriteLine("\nTotals for this order are:\n\nOrder Total pre-tax: ${0}\nDiscount off of your order : ${1}\nTotal Due for Order: ${2}", Math.Round(preTax,2), Math.Round(discOff,2), Math.Round(discTotal,2));
            Console.WriteLine("Results of calculator has also been placed in 'FinalCalculatorOuput.txt' file for logging purposes.");
            Console.Write("The taxes that you paid on your order are: $"); return Math.Round(taxesTotal,2);
            }
       } 

       public static decimal noDiscount(decimal shirt, decimal jeans, decimal watch, decimal belt, string orderState, decimal tax){
            
            //variable to create and open file to write calculator results into
            FileStream ostrm ;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;

            ostrm = new FileStream ("./FinalCalculatorOutput.txt", FileMode.OpenOrCreate);
            writer = new StreamWriter(ostrm);
            
            //Tax logic for none discount orders
            decimal taxPerc = tax/100;
            decimal preTax = shirt + belt + jeans + watch;
            decimal taxesTotal = preTax * taxPerc;
            decimal total = preTax + taxesTotal;

            Console.SetOut (writer);
            {
            Console.WriteLine("The current taxes in {0} is {1}%\nTotals for this order are:\n\nOrder Total pre-tax: ${2}\nTotal taxes paid on order: ${3}\nTotal Due for Order: ${4}\nNo discount was applied to this order.", orderState, tax, Math.Round(preTax,2), Math.Round(taxesTotal,2), Math.Round(total,2)); 
            Console.SetOut (oldOut);
            writer.Close();
            ostrm.Close();
            //also prints the results of calculator into console.
            Console.WriteLine("\nThe current taxes in {0} is {1}%\nTotals for this order are:\n\nOrder Total pre-tax: ${2}\nTotal Due for Order: ${3}\nNo discount was applied to this order.", orderState, tax, Math.Round(preTax,2), Math.Round(total,2)); 
            Console.WriteLine("Results of calculator has also been placed in 'FinalCalculatorOuput.txt' file for logging purposes.");
            Console.Write("The taxes that you paid on your order are: $"); return Math.Round(taxesTotal,2);
            }
       }
    }
}
