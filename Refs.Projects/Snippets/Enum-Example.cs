IEnumerable<Region> regions = .... // your query to get the regions
IEnumerable<RegionVM> model = regions.GroupBy(x => x.LanguageName).Select(x > new RegionVM()
{
    Name = x.Key,
    Count = x.Count()
}.AsEnumerable();
return View(model)

IEnumerable<int> values = Enum.GetValues(typeof(PromotionTypes))
                              .OfType<PromotionTypes>()
                              .Select(s => (int)s);
if(values.Contains(yournumber))
{
      //...
}


enum Status
{
    OK = 0,
    Warning = 64,
    Error = 256
}

static void Main(string[] args)
{
    bool exists;

    // Testing for Integer Values
    exists = Enum.IsDefined(typeof(Status), 0);     // exists = true
    exists = Enum.IsDefined(typeof(Status), 1);     // exists = false

    // Testing for Constant Names
    exists = Enum.IsDefined(typeof(Status), "OK");      // exists = true
    exists = Enum.IsDefined(typeof(Status), "NotOK");   // exists = false
}
