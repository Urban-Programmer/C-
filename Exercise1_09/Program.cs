
static bool isPrime(int number){
  if (number == 0 || number == 1) return false;

  bool isPrime = true;

  int count = 2;

  while (count <= Math.Sqrt(number)){
    if (number % count == 0 ){
      isPrime = false;
      break;
    }
      count++;
  }
  return isPrime;
}

Console.Write("Enter a number to see if it's prime: ");
var answer = int.Parse(Console.ReadLine());
Console.WriteLine($"The {answer} , Prime is {isPrime(answer)} ");