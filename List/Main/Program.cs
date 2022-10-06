using List;

CustomList<int> li = new() { 1 };
li.Add(3);
li.Add(3);
li.Add(3);
li.Add(3);
li.Add(3);
li.Add(3);
for (var i = 0; i< li.Count; i++)
{
    Console.WriteLine(li[i]);
}