using Autofac;
using Lib;
using Lib.Abstractions;
using System;

namespace DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<AvengerRepository>().As<IAvengerRepository>();
            builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<SuperheroService>();
            IContainer container = builder.Build();
            SuperheroService superheroService = container.Resolve<SuperheroService>();

            while (!exit)
            {
                Console.WriteLine("1 - Get all Avengers");
                Console.WriteLine("2 - Get a single Avenger");
                Console.WriteLine("0 - Exit");
                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        {
                          //sam pregleda dependencije i dodjeli ih u konstruktor

                            var avengers = superheroService.GetAvengers();
                            Console.WriteLine();
                            foreach (var avenger in avengers)
                            {
                                Console.WriteLine("{0}, who is really {1}, and has {2}.",
                                    avenger.SuperheroName, avenger.RealName, avenger.Power);
                            }
                        }
                        break;
                    case "2":
                        {
                            Console.Write("Enter Avenger name: ");
                            string name = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(name))
                            {
                                //SuperheroService superheroService = new SuperheroService();

                                var avenger = superheroService.GetAvenger(name);
                                if (avenger != null)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("{0}, who is really {1}, and has {2}.",
                                        avenger.SuperheroName, avenger.RealName, avenger.Power);
                                }
                                else
                                    Console.WriteLine("Cannot find {0} Avenger.");
                            }
                        }
                        break;
                    case "0":
                        exit = true;
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
