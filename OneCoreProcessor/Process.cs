namespace OneCoreProcessor;

public class Process
{
    public int Id { get; }
    public string Name { get; }
    public int ExecutedTicks { get; private set; }
    public int RequiredTicks { get; private set; }
    public bool IsCompleted => ExecutedTicks >= RequiredTicks;

    public Process(int id, string name, int requiredTicks)
    {
        Id = id;
        Name = name;
        RequiredTicks = requiredTicks;
        ExecutedTicks = 0;
    }

    public void Execute(int ticks)
    {
        if (ticks < 0) return;
        else
        {
            if (ExecutedTicks + ticks > RequiredTicks)
            {
                ExecutedTicks = RequiredTicks;
            }
            else ExecutedTicks += ticks;
        }
    }
}