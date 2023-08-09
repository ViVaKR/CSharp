DirectoryInfo sourceDir = new DirectoryInfo(sourcePath);
if (!sourceDir.Exists)
{
    sourceDir.Create();
}

DirectoryInfo compressDir = new DirectoryInfo(compressPath);
if (!compressDir.Exists)
{
    compressDir.Create();
}

DirectoryInfo extractDir = new DirectoryInfo(extractPath);
if (!extractDir.Exists)
{
    extractDir.Create();
}

foreach (FileInfo info in compressDir.GetFiles())
{
    if (info.Extension == ".zip")
    {
        info.Delete();
    }
}

ZipFile.CreateFromDirectory(sourcePath, Path.Combine(compressPath, @"files.zip"));
