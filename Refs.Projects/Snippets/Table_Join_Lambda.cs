public IActionResult Index()
{
    var q = _db.City.Join(_db.Country, r => r.CountryId, p => p.CountryId, (r, p) => new { r.CityName, p.CountryName });

    var q = (from t in db.Teachers
             join sc in db.Schools on t.SchoolId equals sc.SchoolId
             join st in db.Status on t.StatusId equals st.StatusId
             join d in db.Qualifications on t.QualificationId equals d.QualificationId
             select new { t.FirstName, t.Middle, t.LastName, st.StatusName, d.Qualification });

    var cities = new List<ComCity>();
    foreach (var t in q)
    {
        cities.Add(new ComCity()
        {
            CityName = t.CityName,
            Country = new ComCountry() { CountryName = t.CountryName }
        });
    }
    return View(cities);
}
