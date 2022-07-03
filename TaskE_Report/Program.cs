using System;
using System.Collections.Generic;
using System.Linq;

var employeeAmount = int.Parse(Console.ReadLine());
for (var i = 0; i < employeeAmount; i++)
{
    var dayAmount = int.Parse(Console.ReadLine());
    var tasks = Console.ReadLine().Split().Select(int.Parse).ToArray();
    var previousTasks = new HashSet<int> {tasks[0]};
    var efficientEmployee = true;
    for (var j = 1; j < tasks.Length; j++)
    {
        if (tasks[j] != tasks[j - 1])
        {
            if (previousTasks.Contains(tasks[j]))
                efficientEmployee = false;
            else
                previousTasks.Add(tasks[j]);
        }
    }

    Console.WriteLine(efficientEmployee ? "YES" : "NO");
}