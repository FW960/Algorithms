using System;
using LinkedListNode;

public static class Visualizer
{
	public static void Interact()
	{
		string userChoice = string.Empty;

        LinkedListNode.Node node = new LinkedListNode.Node();

        LinkedListNode.Node forCommands = node;

		do
		{
			userChoice = Console.ReadLine();

			switch (userChoice)
			{
				case "RemoveNode":
                    try
                    {
                        Console.Write("Write node index to be deleted: ");
                        int index = int.Parse(Console.ReadLine());
                        try
                        {
							node.RemoveNode(index);

							Console.WriteLine("Node have been successfully deleted.");
                        }
                        catch
                        {
							Console.WriteLine($"Couldn't find node with index: {index}.");
                        }
                    }
                    catch
                    {
						Console.WriteLine("Write node index correctly.");
                    }
                    break;
				case "AddNode": Console.Write("Write new node value: ");
                    try
                    {
						

						int value = int.Parse(Console.ReadLine()); 

						if (node.Value == 0)
                        {
							node.Value = value;

							Console.WriteLine("Node have been successfully added."); break;
						}
						forCommands.AddNode(value); forCommands = forCommands.NextNode;

						Console.WriteLine("Node have been successfully added.");
					}
                    catch
                    {
						Console.WriteLine("Write node value correctly.");
					}
                    break;
				case "TryFind":
					Console.WriteLine("Write node value you are looking for: ");
					try
                    {
						int value = int.Parse(Console.ReadLine()); LinkedListNode.Node isFound = node.FindNode(value);

						if (isFound == null)
							Console.WriteLine("Node doesn't contain that value.");
						else Console.WriteLine($"Node contains: {isFound.Value}.");

					}
                    catch
                    {
						Console.WriteLine("Write node value correctly.");
					}
                    break;
				case "GetLength": Console.WriteLine($"Node length is: {node.GetCount()}");
					break;
				default:
					Console.WriteLine("Write command correctly.");
					break;
			};


		} while (userChoice != "Exit");

	}
}
