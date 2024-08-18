// See https://aka.ms/new-console-template for more information

using Quaver.API.Maps;

// Replace with your own path to songs
var path = args.Length > 0 ? args[0] : @"E:\SteamLibrary\steamapps\common\Quaver\Songs";


var count = 0;
Parallel.ForEach(Directory.EnumerateFiles(path, "*.qua", SearchOption.AllDirectories), Check);
return;

void Check(string quaFile)
{
    Qua qua;
    try
    {
        qua = Qua.Parse(quaFile);
    }
    catch (Exception)
    {
        // We are not interested in the parsing bit. Just ignore invalid qua files.
        return;
    }

    // if (qua.GetKeyCount() != 4)
    //     return false;

    // if (qua.HitObjects.Count > 20000)
    // {
    //     Console.Error.WriteLine($"Skipping Qua: {quaFile}");
    // }

    Console.WriteLine($"Checking {quaFile}");
    qua.SolveDifficulty();
    count++;
    Console.WriteLine($"Solved {count}: {quaFile}");
}