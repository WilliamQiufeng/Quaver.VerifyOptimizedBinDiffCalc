﻿// See https://aka.ms/new-console-template for more information

using Quaver.API.Maps;

// Replace with your own path to songs
const string path = @"E:\SteamLibrary\steamapps\common\Quaver\Songs";

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
    catch (Exception e) when (!e.Message.Contains("Mismatch"))
    {
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