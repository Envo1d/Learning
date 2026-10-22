using AHP;

Level first = new();

Component l11 = new Component() { Criterias = new List<Criteria> { { new Criteria { Title = "Economic" } } } };
Component l12 = new Component() { Criterias = new List<Criteria> { { new Criteria { Title = "Environmental" } } } };
Component l13 = new Component() { Criterias = new List<Criteria> { { new Criteria { Title = "Social" } } } };

first.Components.Add(l11);
first.Components.Add(l12);
first.Components.Add(l13);

Level second = new();
second.ParentLevel = first;
first.ChildLevel = second;

Component l21 = new Component()
{
    Criterias = new List<Criteria>
{ new Criteria { Title = "Construction" },
new Criteria {Title="Delivery"},
new Criteria{Title="Time"}},
    ParentComponent = l11
};
Component l22 = new Component()
{
    Criterias = new List<Criteria>
{ new Criteria { Title = "Influence" },
new Criteria {Title="Placement"},
new Criteria{Title="Technology"}},
    ParentComponent = l12
};
Component l23 = new Component()
{
    Criterias = new List<Criteria>
{ new Criteria { Title = "Working Conditions" },
new Criteria {Title="Life"},
new Criteria{Title="Service"}},
    ParentComponent = l13
};

l11.ChildComponent = l21;
l12.ChildComponent = l22;
l13.ChildComponent = l23;

second.Components.Add(l21);
second.Components.Add(l22);
second.Components.Add(l23);

Level alternatives = new();
Component l31 = new Component() { Criterias = new List<Criteria> { { new Criteria { Title = "New Factory", GoalPriorities = new(), GoalPercent = 0 } } } };
Component l32 = new Component() { Criterias = new List<Criteria> { { new Criteria { Title = "Old Factory", GoalPriorities = new(), GoalPercent = 0 } } } };
Component l33 = new Component() { Criterias = new List<Criteria> { { new Criteria { Title = "Modernization", GoalPriorities = new(), GoalPercent = 0 } } } };
alternatives.IsAlternativeLevel = true;

alternatives.Components.Add(l31);
alternatives.Components.Add(l32);
alternatives.Components.Add(l33);

Level criteries = new();
criteries.Levels.Add(first);
criteries.Levels.Add(second);
criteries.ChildLevel = alternatives;
alternatives.ParentLevel = criteries;

Operations op = new Operations();
op.PrintTree(criteries, alternatives);
Console.WriteLine();

if (op.CalculateMatrix(criteries.Levels.ElementAt(0)))
{
    if (op.CalculateMatrix(criteries.Levels.ElementAt(1).Components.ElementAt(0).Criterias))
    {
        if (op.CalculateMatrix(criteries.Levels.ElementAt(1).Components.ElementAt(1).Criterias))
        {
            if (op.CalculateMatrix(criteries.Levels.ElementAt(1).Components.ElementAt(2).Criterias))
            {
                if (op.CalculateGlobalPriority(criteries.Levels.ElementAt(0), criteries.Levels.ElementAt(1)))
                {
                    if (op.CalculateMatrix(alternatives))
                    {
                        if (!op.CalculateResult(alternatives))
                        {
                            Console.WriteLine("Matrix Error");
                        }
                    }
                    else Console.WriteLine("Matrix Error");
                }
                else Console.WriteLine("Matrix Error");
            }
            else Console.WriteLine("Matrix Error");
        }
        else Console.WriteLine("Matrix Error");
    }
    else Console.WriteLine("Matrix Error");
}
else Console.WriteLine("Matrix Error");