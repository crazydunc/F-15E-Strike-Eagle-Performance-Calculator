namespace F_15E_Strike_Eagle_Performance_Calculator
{
    public static class Log
    {
        public static void WriteLog(string line)
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var path = folder + @"\v48th OG\F15E_PerfLog.txt";
            var logFolder = Path.GetDirectoryName(path);
            if (!Directory.Exists(logFolder))
            {
                if (logFolder != null) Directory.CreateDirectory(logFolder);
            }

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
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
    }
}
