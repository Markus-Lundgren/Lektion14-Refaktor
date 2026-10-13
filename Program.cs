class MenuItem
{
	public string Name { get; private set; }
	public decimal Price { get; private set; }

	public MenuItem(string name, decimal price)
	{
		Name = name;
		Price = price;
	}

	public void Show()
	{
		Console.WriteLine($"{Name} - {Price} kr");
	}
}

class Order
{
	public string EatOptions { get; set; }
	public List<MenuItem> _items = [];

	public void EatHereOrTakeAway()
	{
		Console.WriteLine("Välj alternativ");
		Console.WriteLine("1. Äta här");
		Console.WriteLine("2. Ta med");

		int val = int.Parse(Console.ReadLine());

		if (val == 1)
		{
			EatOptions = "Äta här";
		}
		else
		{
			EatOptions = "Ta med";
		}

		Console.WriteLine($"Du valde att: {EatOptions.ToLower()}");
	}

	public void AddItem(List<MenuItem> menu)
	{
		for (int i = 0; i < menu.Count; i++)
		{
			Console.Write($"{i + 1}.");
			menu[i].Show();
		}

		Console.Write("Ange rättens nummer: ");
		string? nr = Console.ReadLine();

		if (!int.TryParse(nr, out int index) || index < 1 || index > menu.Count)
		{
			Console.WriteLine("Ogiltigt val!");
			return;
		}

		_items.Add(menu[index - 1]);

		Console.Write($"Lade till: ");
		menu[index - 1].Show();
	}

	public void ShowTotal()
	{
		decimal total = 0;
		foreach (var item in _items)
		{
			total += item.Price;
		}
		Console.WriteLine($"Totalt pris: {total} kr");
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

		order.EatHereOrTakeAway();

		do
		{
			order.AddItem(menu);
			Console.WriteLine("Vill du lägga till en rätt till? (j/n) ");
		} while (Console.ReadLine()?.ToLower() == "j");

		order.ShowTotal();
	}
}