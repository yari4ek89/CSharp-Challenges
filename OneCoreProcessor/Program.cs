namespace OneCoreProcessor;

class Program
{
    static void Main(string[] args)
    {
        int quantum = 4;
        int totalTicks = 0;
        Process browserProcess = new Process(0, "Browser", 5);
        Process discordProcess = new Process(1, "Discord", 3);
        Process gameProcess = new Process(2, "Game", 7);
        Queue<Process> processesQueue = new Queue<Process>();
        processesQueue.Enqueue(browserProcess);
        processesQueue.Enqueue(discordProcess);
        processesQueue.Enqueue(gameProcess);

        while (processesQueue.Count > 0)
        {
            Process firstProcess = processesQueue.Peek();
            int ticksBefore = firstProcess.ExecutedTicks;
            firstProcess.Execute(quantum);
            int ticksAfter = firstProcess.ExecutedTicks;
            totalTicks += ticksAfter - ticksBefore;
            if (!firstProcess.IsCompleted)
            {
                processesQueue.Dequeue();
                processesQueue.Enqueue(firstProcess);
                System.Console.WriteLine($"[CPU] {firstProcess.Name} | {firstProcess.ExecutedTicks}/{firstProcess.RequiredTicks}");
            }
            else
            {
                processesQueue.Dequeue();
                System.Console.WriteLine($"[CPU] {firstProcess.Name} | {firstProcess.ExecutedTicks}/{firstProcess.RequiredTicks} | DONE");
            }
        }
        System.Console.WriteLine($"\nCPU STATS:\nTotal ticks: {totalTicks}");
    }
}
