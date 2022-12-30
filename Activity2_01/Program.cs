using static System.Math;

public struct Circle {
  public double Radius { get; }

  public Circle(double radius) {
    Radius = radius;
  }
  public double Area => PI * Radius * Radius; 

  public static Circle operator +(Circle obj1, Circle obj2){
  var newArea = obj1.Area + obj2.Area;
  var newRadius = Sqrt((newArea/PI));

  return new Circle(newRadius);
  }

}



public static class Solution{
  public static void Main(){
    var circle1 = new Circle(3);
    var circle2 = new Circle(3);
    var circle3 = circle1 + circle2;


    Console.WriteLine($"Circle 1 radius: {circle1.Radius} , Plus Circle 2 radius {circle2.Radius} \n Equals {circle3.Radius}");
  }
}