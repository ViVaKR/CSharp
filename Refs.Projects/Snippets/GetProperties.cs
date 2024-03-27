PropertyInfo[] propertyInfos;

propertyInfos = typeof(...).GetProperties(BindingFlags.Public);

Array.Sort(propertyInfos, delegate (PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
 {
	return propertyInfo1.Name.CompareTo(propertyInfo2.Name);
});
