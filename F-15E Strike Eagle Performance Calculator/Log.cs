﻿namespace F_15E_Strike_Eagle_Performance_Calculator;

public static class Log
{
    public static void WriteLog(string line)
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        var path = $@"{folder}\F15EPerformanceCalculator\SEPC_Log.txt";
        var logFolder = Path.GetDirectoryName(path);
        if (!Directory.Exists(logFolder))
            if (logFolder != null)
                Directory.CreateDirectory(logFolder);

        if (!File.Exists(path)) File.Create(path).Dispose();
        try
        {
            using var w = File.AppendText(path);
            w.WriteLine("[" + DateTime.Now + "] - " + line);
            w.Close();
        }
        catch (Exception)
        {
            // no action 
        }
    }

    public static void WriteExport(List<string> exportList)
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        var path = $@"{folder}\F15EPerformanceCalculator\F-15ELoadoutExport{DateTime.UtcNow:ddMMyyHHmmss}.txt";
        var logFolder = Path.GetDirectoryName(path);
        if (!Directory.Exists(logFolder))
            if (logFolder != null)
                Directory.CreateDirectory(logFolder);

        if (!File.Exists(path)) File.Create(path).Dispose();
        try
        {
            File.WriteAllLines(path, exportList.ToArray());
            MessageBox.Show($@"Loadout Exported to: {path}", @"Export Successful");
        }
        catch (Exception a)
        {
            WriteLog(a.ToString());
            MessageBox.Show($@"Loadout Export Failed", @"Export Failed");

        }
    }
}