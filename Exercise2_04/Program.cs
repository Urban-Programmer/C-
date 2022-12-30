﻿public enum TemperatureUnit {
  C, F, K
}

public record Temperature(double Degrees, TemperatureUnit Unit);

public interface ITemperatureConverter
{
  TemperatureUnit Unit {get;}
  Temperature ToC(Temperature temperature);
  Temperature FromC(Temperature temperature);
   
}

public class ComposableTemperatureConverter {
  private readonly ITemperatureConverter[] _converters;

   public ComposableTemperatureConverter(ITemperatureConverter[] converters){
    RequireNotEmpty(converters);
    RequireNoDuplicate(converters);
    _converters = converters;
  } 
  private ITemperatureConverter FindConverter(TemperatureUnit unit){
    foreach (var converter in _converters){
      if(converter.Unit == unit){
        return converter;
      }
      throw new InvalidTemperatureConverterException(unit);
    }
  }

  
  private Temperature ToCelsius(Temperature temperatureFrom){
    var converterFrom = FindConverter(temperatureFrom.Unit);
    return converterFrom.ToC(temperature);
  }

  private Temperature CelsiusToOther(Temperature celsius, TemperatureUnit unitTo){
    var converterTo = FindConverter(unitTo);
    return converterTo.FromC(celsius);
  }

  public Temperature Convert(Temperature temperatureFrom, TemperatureUnit unitTo){
    var celsius = ToCelsius(temperatureFrom);
    return CelsiusToOther(celsius, unitTo);
  }
}

public class InvalidTemperatureConverterException : Exception {
  public InvalidTemperatureConverterException(TemperatureUnit unit) : base ($"Duplicate converter for {unit}."){}
  public InvalidTemperatureConverterException(string message) : base(message){}

  private static void RequireNotEmpty(ITemperatureConverter[] converters){
    if(converters?.Length > 0 == false){
      throw new InvalidTemperatureConverterException("At least one temperature conversion must be supported");
    }
  }
  private static void RequireNoDuplicate(ITemperatureConverter[] converters){
    for (var index1 = 0; index1 < converters.Length-1; index1++){
      var first = converters[index1];
      for (int index2 = index1+1; index2 < converters.Length; index2++){
        var second = converters[index2];
        if (first.Unit == second.Unit){
          throw new InvalidTemperatureConverterException(first.Unit);
        }
      }
    }
  }


}
public class KelvinConverter : ITemperatureConverter{
  public const double AbsoluteZero = -273.15;
  public TemperatureUnit Unit => TemperatureUnit.K;
  public Temperature ToC(Temperature temperature){
    return new(temperature.Degress + AbsoluteZero, TemperatureUnit.C);
  }

  public Temperature FromC(Temperature temperature){
    return new(temperature.Degrees - AbsoluteZero, Unit);
  }
}

public class FahrenheitConverter : ITemperatureConverter{
  public TemperatureUnit Unit => TemperatureUnit.F;
  public Temperature ToC(Temperature temperature){
    return new Temperature(5.0/9 * (temperature.Degrees-32), TemperatureUnit.C);
  }

  public Temperature FromC(Temperature temperature){
    return new(9.0/5 * temperature.Degrees + 32, Unit);
  }

}

public class CelsiusConverter : ITemperatureConverter {
  public TemperatureUnit Unit => TemperatureUnit.C;

  public Temperature ToC(Temperature temperature){
    return temperature;
  }
  
  public Temperature FromC(Temperature temperature){
    return temperature;
  }
}

public static class Solution {
  public static void Main(){
    ITemperatureConverter[] converters = {new FahrenheitConverter(), new KelvinConverter(), new CelsiusConverter()};
    var composableConverter = new ComposableTemperatureConverter(converters);
    var celsius = new Temperature(20.00001, TemperatureUnit.C);
    var celsius1 = composableConverter.Convert(celsius, TemperatureUnit.C);
    var fahrenheit = composableConverter.Convert(celsius1, TemperatureUnit.F);
    var kelvin = composableConverter.Convert(fahrenheit, TemperatureUnit.C);
    var celsiusBlack = composableConverter.Convert(kelvin, TemperatureUnit.C);
    Console.WriteLine($"{celsius} = {fahrenheit}");
  }
}

