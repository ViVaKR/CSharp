
 Enum.GetName(typeof(...), "...").ToString();

Dictionary<int, string> _var = Enum.GetValues(typeof(...)).Cast<...>().ToDictionary(x => (int)x, x => x.ToString());
IOrderedQueryable<string> _규격 = Db.<...>.GroupBy(x => x.규격).Select(x => x.Key).OrderBy(x => x);
