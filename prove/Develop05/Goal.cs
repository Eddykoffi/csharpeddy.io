public abstract class Goal
{
    private string name;
    private int value;

    public string Name { get { return name; } }
    public int Value { get { return value; } }

    public Goal(string name, int value)
    {
        this.name = name;
        this.value = value;
    }

    public virtual void DisplayStatus()
    {
        Console.WriteLine($"Goal: {name} | Value: {value}");
    }

    public abstract void CompleteGoal();

    public abstract void RecordEvent();

    public virtual string Serialize()
    {
        return $"{GetType().Name},{name},{value}";
    }

    public virtual void Deserialize(string data)
    {
        string[] parts = data.Split(',');
        if (parts.Length >= 3)
        {
            name = parts[1];
            value = int.Parse(parts[2]);
        }
    }
}
