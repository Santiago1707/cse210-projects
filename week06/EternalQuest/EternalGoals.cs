public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, string description, string points) 
        : base(name, description, points)
    {
        _timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"[ ] {base.GetDetailsString()}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}|{_timesCompleted}";
    }
}