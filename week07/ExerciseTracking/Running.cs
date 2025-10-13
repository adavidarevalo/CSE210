using System;

public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        // Speed (mph) = (distance / minutes) * 60
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        // Pace (min per mile) = minutes / distance
        return GetMinutes() / GetDistance();
    }

    protected override string GetActivityType()
    {
        return "Running";
    }
}