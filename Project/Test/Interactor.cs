using System;
using TreeStructure;


namespace Test
{
    internal class Interactor
    {
        public static void Interact()
        {
            string userChoice = string.Empty;

            Tree tree = new Tree();

            while (userChoice != "Exit")
            {
                userChoice = Console.ReadLine();
                
                switch (userChoice)
                {
                    case "Add":
                        Console.WriteLine("Write a value that will be added to the tree.");

                        try
                        {
                            int value = int.Parse(Console.ReadLine());

                            if (tree.TryFind(value) != null)
                            {
                                Console.WriteLine($"{value} already exists in tree."); break;
                            }

                            tree.BinaryEnter(value);

                            Console.WriteLine("Value succesfully added.");

                        }
                        catch
                        {
                            Console.WriteLine("Write value correctly.");
                        }
                        break;
                    case "Delete":
                        Console.WriteLine("Write a value that will be deleted from the tree.");
                        try
                        {
                            int value = int.Parse(Console.ReadLine());

                            if (tree.TryFind(value) == null)
                            {
                                Console.WriteLine($"Couldn't find {value} in tree."); break;
                            }else
                            {
                                tree.Delete(value);

                                Console.WriteLine("Value succesfully deleted.");
                            }

                            

                        }
                        catch
                        {
                            Console.WriteLine("Write value correctly.");
                        }
                        break;
                    case "TryFind":
                        try
                        {
                            int value = int.Parse(Console.ReadLine());

                            if (tree.TryFind(value) == null)
                            {
                                Console.WriteLine($"{value} doesn't exist in tree."); break;
                            }else
                            {
                                Console.WriteLine($"Tree contains {tree.TryFind(value).Value}.");
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Write value correctly.");
                        }
                        break;
                    case "Print": tree.Print();
                        break;
                    case "Clear": Console.Clear();
                        break;
                    default: Console.WriteLine("Unknown command.");
                        break;

                }
            }
        }
    }
}
