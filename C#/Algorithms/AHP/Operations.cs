namespace AHP
{
    public class Operations
    {
        private float Coefficient(int size)
        {
            return size switch
            {
                1 => 0,
                2 => 0,
                3 => 0.58f,
                4 => 0.90f,
                5 => 1.12f,
                6 => 1.24f,
                7 => 1.32f,
                8 => 1.41f,
                9 => 1.45f,
                10 => 1.49f,
                _ => 0
            };
        }

        public void PrintTree(Level criterias, Level alternatives)
        {
            int i = 1;
            foreach (Level level in criterias.Levels)
            {
                Console.WriteLine($"\t\tLevel-{i}");
                foreach (var component in level.Components)
                {
                    foreach (var criteria in component.Criterias)
                        Console.Write($"{criteria.Title}\t");
                    Console.WriteLine();
                }
                i++;
            }

            Console.WriteLine($"\t\tLevel-Alternatives");
            foreach (var component in alternatives.Components)
            {
                foreach (var criteria in component.Criterias)
                    Console.Write($"{criteria.Title}\t");
                Console.WriteLine();
            }
        }

        public bool CalculateMatrix(object values)
        {
            if (values is Level)
            {
                int matrixSize = (values as Level).Components.Count;
                if (!(values as Level).IsAlternativeLevel)
                {
                    Console.Write("\t\t\t");
                    foreach (var comp in (values as Level).Components)
                    {
                        foreach (var item in comp.Criterias)
                        {
                            Console.Write($"{item.Title}\t");
                        }
                    }
                    Console.WriteLine();
                    List<List<double>> param = new();
                    int k = 0;
                    foreach (var comp in (values as Level).Components)
                    {

                        foreach (var item in comp.Criterias)
                        {

                            Console.Write($"\t{item.Title}\t");
                            param.Add(new List<double>());
                            for (int i = 0; i < matrixSize; i++)
                            {
                                int pos = Console.CursorLeft;
                                double tmp;
                            Ent1:
                                try
                                {
                                    tmp = Convert.ToDouble(Console.ReadLine());
                                }
                                catch (Exception ex) { goto Ent1; }
                                if (tmp < 0)
                                    tmp = 1 / Math.Abs(tmp);
                                param.ElementAt(k).Add(tmp);
                                Console.CursorTop--;
                                Console.CursorLeft = pos + 1;
                                Console.Write("\t");
                            }
                            Console.WriteLine();
                        }
                        k += 1;
                    }
                    List<double> paramsRes = new();
                    foreach (var item in param)
                    {
                        double tmp = 1;
                        foreach (var res in item)
                            tmp *= res;
                        paramsRes.Add(Math.Pow(tmp, (1.0 / Convert.ToDouble(matrixSize))));
                    }
                    double paramSum = 0;
                    foreach (var item in paramsRes)
                    {
                        paramSum += item;
                    }
                    for (int i = 0; i < (values as Level).Components.Count; i++)
                    {
                        (values as Level).Components.ElementAt(i).Criterias.ElementAt(0).LocalProirity = paramsRes.ElementAt(i) / paramSum;
                    }
                    List<double> Aj = new();
                    for (int i = 0; i < param.Count; i++)
                    {
                        double res = 0;
                        for (int j = 0; j < param.Count; j++)
                        {
                            res += param[j][i];
                        }
                        Aj.Add(res);
                    }
                    double lambdaMax = 0;
                    for (int i = 0; i < (values as Level).Components.Count; i++)
                    {
                        double tmp = (double)(values as Level).Components.ElementAt(i).Criterias.ElementAt(0).LocalProirity * Aj.ElementAt(i);
                        lambdaMax += tmp;
                    }
                    double IC = (lambdaMax - matrixSize) / (matrixSize - 1);
                    double OC = IC / Coefficient(matrixSize);
                    Console.WriteLine($"OC: {Math.Round(OC, 4)}");
                    if (OC <= 0.10)
                        return true;
                    else return false;
                }
                else
                {
                    foreach (var prevLevelCriteria in (values as Level).ParentLevel.Levels.Last().Components)
                    {
                        foreach (var criteria in prevLevelCriteria.Criterias)
                        {
                            Console.Write($"\t{criteria.Title}\t");
                            foreach (var comp in (values as Level).Components)
                            {
                                foreach (var item in comp.Criterias)
                                {
                                    Console.Write($"{item.Title}\t");
                                }
                            }
                            Console.WriteLine();
                            List<List<double>> param = new();
                            int k = 0;
                            foreach (var comp in (values as Level).Components)
                            {

                                foreach (var item in comp.Criterias)
                                {

                                    Console.Write($"\t{item.Title}\t");
                                    param.Add(new List<double>());
                                    for (int i = 0; i < matrixSize; i++)
                                    {
                                        int pos = Console.CursorLeft;
                                        double tmp;
                                    Ent2:
                                        try
                                        {
                                            tmp = Convert.ToDouble(Console.ReadLine());
                                        }
                                        catch (Exception ex) { goto Ent2; }
                                        if (tmp < 0)
                                            tmp = 1 / Math.Abs(tmp);
                                        param.ElementAt(k).Add(tmp);
                                        Console.CursorTop--;
                                        Console.CursorLeft = pos + 1;
                                        Console.Write("\t");
                                    }
                                    Console.WriteLine();
                                }
                                k += 1;
                            }
                            List<double> paramsRes = new();
                            foreach (var item in param)
                            {
                                double tmp = 1;
                                foreach (var res in item)
                                    tmp *= res;
                                paramsRes.Add(Math.Pow(tmp, (1.0 / Convert.ToDouble(matrixSize))));
                            }
                            double paramSum = 0;
                            foreach (var item in paramsRes)
                            {
                                paramSum += item;
                            }
                            for (int i = 0; i < (values as Level).Components.Count; i++)
                            {
                                (values as Level).Components.ElementAt(i).Criterias.ElementAt(0).GoalPriorities.Add(paramsRes.ElementAt(i) / paramSum);
                            }
                            List<double> Aj = new();
                            for (int i = 0; i < param.Count; i++)
                            {
                                double res = 0;
                                for (int j = 0; j < param.Count; j++)
                                {
                                    res += param[j][i];
                                }
                                Aj.Add(res);
                            }
                            double lambdaMax = 0;
                            for (int i = 0; i < (values as Level).Components.Count; i++)
                            {
                                double tmp = (double)(values as Level).Components.ElementAt(i).Criterias.ElementAt(0).GoalPriorities.Last() * Aj.ElementAt(i);
                                lambdaMax += tmp;
                            }
                            double IC = (lambdaMax - matrixSize) / (matrixSize - 1);
                            double OC = IC / Coefficient(matrixSize);
                            Console.WriteLine($"OC: {Math.Round(OC, 4)}");
                            if (OC > 0.10)
                                return false;
                        }
                    }
                    return true;
                }
            }
            else if (values is List<Criteria>)
            {
                int matrixSize = (values as List<Criteria>).Count;
                Console.Write("\t\t\t");
                foreach (var item in (values as List<Criteria>))
                {
                    Console.Write($"{item.Title}\t");
                }
                Console.WriteLine();
                List<List<double>> param = new();
                int k = 0;
                foreach (var item in (values as List<Criteria>))
                {

                    Console.Write($"\t{item.Title}\t");
                    param.Add(new List<double>());
                    for (int i = 0; i < matrixSize; i++)
                    {
                        int pos = Console.CursorLeft;
                        double tmp;
                    Ent3:
                        try
                        {
                            tmp = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (Exception ex) { goto Ent3; }
                        if (tmp < 0)
                            tmp = 1 / Math.Abs(tmp);
                        param.ElementAt(k).Add(tmp);
                        Console.CursorTop--;
                        Console.CursorLeft = pos + 1;
                        Console.Write("\t");
                    }
                    k += 1;
                    Console.WriteLine();
                }
                List<double> paramsRes = new();
                foreach (var item in param)
                {
                    double tmp = 1;
                    foreach (var res in item)
                        tmp *= res;
                    paramsRes.Add(Math.Pow(tmp, (1.0 / Convert.ToDouble(matrixSize))));
                }
                double paramSum = 0;
                foreach (var item in paramsRes)
                {
                    paramSum += item;
                }
                for (int i = 0; i < (values as List<Criteria>).Count; i++)
                {
                    (values as List<Criteria>).ElementAt(i).LocalProirity = paramsRes.ElementAt(i) / paramSum;
                }
                List<double> Aj = new();
                for (int i = 0; i < param.Count; i++)
                {
                    double res = 0;
                    for (int j = 0; j < param.Count; j++)
                    {
                        res += param[j][i];
                    }
                    Aj.Add(res);
                }
                double lambdaMax = 0;
                for (int i = 0; i < (values as List<Criteria>).Count; i++)
                {
                    double tmp = (double)(values as List<Criteria>).ElementAt(i).LocalProirity * Aj.ElementAt(i);
                    lambdaMax += tmp;
                }
                double IC = (lambdaMax - matrixSize) / (matrixSize - 1);
                double OC = IC / Coefficient(matrixSize);
                Console.WriteLine($"OC: {Math.Round(OC, 4)}");
                if (OC <= 0.10)
                    return true;
                else return false;
            }
            return false;
        }

        public bool CalculateGlobalPriority(Level first, Level second)
        {
            foreach (var compo in first.Components)
            {
                foreach (var item in compo.Criterias)
                {
                    if (!item.LocalProirity.HasValue)
                        return false;
                }
            }
            foreach (var compo in second.Components)
            {
                foreach (var item in compo.Criterias)
                {
                    if (!item.LocalProirity.HasValue)
                        return false;
                }
            }

            foreach (var compo in second.Components)
            {
                foreach (var item in compo.Criterias)
                {
                    item.GlobalPriority = item.LocalProirity * compo.ParentComponent.Criterias.ElementAt(0).LocalProirity;
                }
            }

            return true;
        }

        public bool CalculateResult(Level alternatives)
        {
            if (alternatives.Components.ElementAt(0).Criterias.ElementAt(0).GoalPriorities.Count == 0)
                return false;
            int counter = 0;
            foreach (var prevLevelCriteria in alternatives.ParentLevel.Levels.Last().Components)
            {
                foreach (var criteria in prevLevelCriteria.Criterias)
                {
                    foreach (var comp in alternatives.Components)
                    {
                        foreach (var item in comp.Criterias)
                        {
                            item.GoalPercent += item.GoalPriorities.ElementAt(counter) * criteria.GlobalPriority;
                        }
                    }
                    counter++;
                }
            }

            foreach (var comp in alternatives.Components)
            {
                foreach (var item in comp.Criterias)
                {
                    Console.WriteLine($"{item.Title} - {Math.Round((double)item.GoalPercent, 4)}");
                }
            }

            return true;
        }
    }
}
