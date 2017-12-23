using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sellers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Task[] tasks = new Task[10];

            for (int i = 0; i < tasks.Length; i++)
            {
                var sim = new Simulation(1000, 1000);
                tasks[i] = sim.RunSimulation();
            }
            await Task.WhenAll(tasks);
            sw.Stop();
            Console.WriteLine($"All at once: {sw.ElapsedMilliseconds} m");

            sw.Reset();
            sw.Start();

            for (int i = 0; i < tasks.Length; i++)
            {
                var sim = new Simulation(1000, 1000);
                await sim.RunSimulation();
            }
            sw.Stop();
            Console.WriteLine($"One at a time: {sw.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}
