var menuBuilder = new System.Text.StringBuilder();

menuBuilder.AppendLine("Welcome to el Burger");
menuBuilder.AppendLine(string.Empty);
menuBuilder.AppendLine("1) Burgers and Fries - 5 USD");
menuBuilder.AppendLine("2) Cheeseburger- 7 USD");
menuBuilder.AppendLine("3) Double-cheeseburger - 9 USD");
menuBuilder.AppendLine("4) Coke - 2 USD");
menuBuilder.AppendLine("Note that every burger option comes with fries and ketchup!");

Console.WriteLine(menuBuilder.ToString());
Console.WriteLine("please type one of the following options to order: ");

var option = Console.ReadKey();

switch (option.KeyChar.ToString()){
  case "1":
    {
      Console.WriteLine("\nAlright, some burgers on the go. Please pay the cashier.");
      break;
    }
  case "2":
  {
    Console.WriteLine("\nThank you for ordering cheeseburger. Please pay the cashier.");
      break;
  }
  case "3":{
    Console.WriteLine("\nThank you for ordering double cheeseburger. Please pay the cashier.");
      break;
  }
  case "4":{
    Console.WriteLine("\nThank you for ordering coke. Please pay the cashier.");
    break;
  }
  default:
  {
    Console.WriteLine("\nThank you for ordering double cheeseburger. Please pay the cashier.");
    break;
  }   
}