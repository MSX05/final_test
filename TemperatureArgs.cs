using System;



// Step 1: Create a class for the EventArgs
public class TemperatureArgs : EventArgs
{
    public double Temperature { get; }

    public TemperatureArgs(double temperature)
    {
        Temperature = temperature;
    }
}

// Step 2: Set up the delegate for the event
public delegate void TemperatureChangedEventHandler(object sender, TemperatureArgs e);

// Step 3: Declare the event in a class
public class Thermometer
{
    // Event declaration
    public event TemperatureChangedEventHandler TemperatureChanged;

    private double _currentTemperature;

    public double CurrentTemperature
    {
        get { return _currentTemperature; }
        set
        {
            if (_currentTemperature != value)
            {
                _currentTemperature = value;
                OnTemperatureChanged(new TemperatureArgs(value)); // Raise the event
            }
        }
    }

    // Step 5: Associate the event with the event handler
    protected virtual void OnTemperatureChanged(TemperatureArgs e)
    {
        TemperatureChanged?.Invoke(this, e);
    }
}

// Step 4: Create code that will be run when the event occurs (Event Handler)
public class Display
{
    public void Subscribe(Thermometer thermometer)
    {
        thermometer.TemperatureChanged += HandleTemperatureChanged;
    }

    public void HandleTemperatureChanged(object sender, TemperatureArgs e)
    {
        Console.WriteLine($"Temperature changed: {e.Temperature} Celsius");
    }
}

class Program
{
    static void Main()
    {
        Thermometer thermometer = new Thermometer();
        Display display = new Display();
        display.Subscribe(thermometer);

        thermometer.CurrentTemperature = 25.5; // Simulating temperature change
    }
}

