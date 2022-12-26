
int numberToBeGuessed = new Random().Next(0,10);
int remainingChances = 5;
bool numberFound = false;


while (!numberFound){
  Console.WriteLine($"You have {remainingChances} remain");
  Console.Write("Enter a guess 1 through 10: ");
  var number = int.Parse(Console.ReadLine());

  if (number == numberToBeGuessed){
    Console.WriteLine($"Answer is correct! You guess the right number: {numberToBeGuessed}");
    numberFound = true;

  };

  if (remainingChances == 0){
    Console.WriteLine($"No more tries! The answers was {numberToBeGuessed}");
    break;
  }

  remainingChances--;

}