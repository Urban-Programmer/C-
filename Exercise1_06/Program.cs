Console.WriteLine("Enter your username, must have at least 6 chars");

var username = Console.ReadLine();

if (username.Length < 6){
  Console.WriteLine($"The username {username} is not valid");
}
else{
  Console.WriteLine("Enter a password that has at least 6 characters, 1 digit");
  var password = Console.ReadLine();

  if (password.Length < 6 || !password.Any(c => char.IsDigit(c))){
    Console.WriteLine("Password must include 1 number, and be greater than 6 characters");
  }
}