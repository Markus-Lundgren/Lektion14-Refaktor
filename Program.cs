class MenuItem
{
	public string Name { get; private set; }
	public decimal Price { get; private set; }

	public MenuItem(string name, decimal price)
	{
		Name = name;
		Price = price;
	}
}

class Order
{
	public string EatOptions { get; set; }
	private List<MenuItem> _items = [];
	public void AddItem(MenuItem item)
	{
		_items.Add(item);
	}
	public decimal ShowTotal()
	{
		decimal total = 0;
		foreach (var item in _items)
		{
			total += item.Price;
		}
		return total;
	}
}

class Program
{
	static void Main()
	{
		List<MenuItem> menu = [
			new MenuItem("Pizza", 80),
			new MenuItem("Pasta", 70),
			new MenuItem("Salad", 50)
		];

		var order = new Order();

		Console.WriteLine("Välj alternativ");
		Console.WriteLine("1. Äta här");
		Console.WriteLine("2. Ta med");

		int val = int.Parse(Console.ReadLine());

		if (val == 1)
		{
			order.EatOptions = "Äta här";
		}
		else
		{
			order.EatOptions = "Ta med";
		}

		Console.WriteLine($"Du valde att: {order.EatOptions.ToLower()}");

		do
		{
			for (int i = 0; i < menu.Count; i++)
			{
				Console.Write($"{i + 1}.");
				Console.WriteLine($"{menu[i].Name} - {menu[i].Price} kr");
			}

			Console.Write("Ange rättens nummer: ");
			string? nr = Console.ReadLine();

			if (!int.TryParse(nr, out int index) || index < 1 || index > menu.Count)
			{
				Console.WriteLine("Ogiltigt val!");
				return;
			}

			order.AddItem(menu[index - 1]);

			Console.Write($"Lade till: ");
			Console.WriteLine($"{menu[index - 1].Name} - {menu[index - 1].Price} kr");

			Console.WriteLine("Vill du lägga till en rätt till? (j/n) ");
		} while (Console.ReadLine()?.ToLower() == "j");


		Console.WriteLine($"Totalt pris: {order.ShowTotal()} kr");
	}
}