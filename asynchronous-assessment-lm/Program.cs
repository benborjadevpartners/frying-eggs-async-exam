using System;
using System.Threading.Tasks;

/**
 * INSTRUCTIONS:
 *  1. Modify the codes below and make it asynchronous
 *  2. After your modification, explain what makes it asynchronous
**/

/*
 * Answer:
 * 1. Code Modified
 * 2. Main can now be modified to have keyword async. This allows it to 'await' different parts of the main method. 
 * - all sub-methods have a signature to return a Task<>. This makes it asynchronous.
 * - all the sub-methods inside main are now awaited. 
 * - each sub-method has a Task.Run inside it to make it asynchronous
 * - Coffee , Frying, Toasting and Pouring Juice can all be Asynchronous with each other
 */


namespace asynchronous_assessment_lm
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cup = await PourCoffee();
            Console.WriteLine("Coffee is ready");

            var eggs = await FryEggs(2);
            Console.WriteLine("Eggs are ready");

            //assuming we only have 1 pan . but if there are multiple burners and pans, no more checking if eggs are ready
            if ( eggs != null )
            {
                var bacon = await FryBacon(3);
                Console.WriteLine("Bacon is ready");
            }
            
            var toast = await ToastBread(2);
            // you only apply butter and jam after toasting
            if ( toast != null )
            {
                ApplyButter(toast);
                ApplyJam(toast);
                Console.WriteLine("toast is ready");
            }
            

            var orange = await PourOJ();
            Console.WriteLine("Orange juice is ready");
            Console.WriteLine("Breakfast is ready!");

        }        

        private static Task<Juice> PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return Task.Run ( () => new Juice());
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Task<Toast> ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return Task.Run( () => new Toast());
        }

        private static Task<Bacon> FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();


            return Task.Run ( () => new Bacon());
        }

        private static Task<Egg> FryEggs(int count)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {count} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");
            
            return Task.Run(() => new Egg());
        }

        private static Task<Coffee> PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return Task.Run( () => new Coffee());
        }

        private class Coffee
        {
        }

        private class Egg
        {
        }

        private class Bacon
        {
        }

        private class Toast
        {
        }

        private class Juice
        {
        }
    }
}
