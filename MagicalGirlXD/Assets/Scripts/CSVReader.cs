using System.Collections;
using System.IO;
using System.Collections.Generic;

public class CSVReader {

    StreamReader csv;

    public CSVReader(string path)
    {
        csv = new StreamReader(File.OpenRead(path));
    }

    public List<string[]> Read()
    {
        List<string[]> file = new List<string[]>();
        string line;
        while((line = csv.ReadLine()) != null)
        {
            file.Add(line.Split(','));
        }

        return file;
    }
}
