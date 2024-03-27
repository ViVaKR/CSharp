// DataFile
RelocateFile dataFile = new RelocateFile();
string MDF = rows[0][1].ToString();
dataFile.LogicalFileName = rows[0][0].ToString();
dataFile.PhysicalFileName = server.Databases[database.Name].FileGroups[0].Files[0].FileName;

// LogFile
RelocateFile logFile = new RelocateFile();
string LDF = rows[1][1].ToString();
logFile.LogicalFileName = rows[1][0].ToString();
logFile.PhysicalFileName = server.Databases[database.Name].LogFiles[0].FileName;
