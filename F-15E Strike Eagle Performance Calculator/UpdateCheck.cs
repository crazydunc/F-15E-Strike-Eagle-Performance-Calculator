using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace F_15E_Strike_Eagle_Performance_Calculator
{
    public class UpdateCheck
    {

        public async Task<(string, string, string)> CheckLatestGit()
        {
            Log.WriteLog($"Starting Update Check");

            string url = "https://api.github.com/repos/crazydunc/F-15E-Strike-Eagle-Performance-Calculator/releases/latest";
            string tagName = "";
            string html_url = "";
            string downloadUrl = "";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");

                    var content = await client.GetStringAsync(url);
                    var releaseInfo = JsonConvert.DeserializeAnonymousType(content, new
                    {
                        tag_name = "",
                        html_url = "",
                        assets = new[] {
                            new {
                                browser_download_url = ""
                            }
                        }
                    });

                    tagName = releaseInfo.tag_name; 
                    html_url = releaseInfo.html_url;
                    downloadUrl = releaseInfo.assets[0].browser_download_url;
                    Log.WriteLog($"Server Gave: Version: {tagName}");
                    Version versionNow = Assembly.GetEntryAssembly().GetName().Version;
                    Log.WriteLog($"Self Version: {versionNow}");

                    if (Version.TryParse(tagName, out Version versionServer))
                    {
                        Log.WriteLog($"Valid Parse of Self Version {versionNow} . Checking against server {versionServer}");
                        if (versionServer > versionNow)
                        {
                            DialogResult result = MessageBox.Show("A newer version is available on the server. Do you want to Open the release on Github?", "Update Available", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                            if (result == DialogResult.OK)
                            {
                                Log.WriteLog($"User Opened Git Link");

                                ProcessStartInfo psi = new ProcessStartInfo
                                {
                                    FileName = html_url,
                                    UseShellExecute = true
                                };
                                Process.Start(psi);
                            }
                            else
                            {
                                Log.WriteLog($"User Declined to Open Git Link");

                            }
                        }
                        else
                        {
                            Log.WriteLog($"No Update Required.");

                        }
                    }
                    else
                    {
                        Log.WriteLog($"Failed to Parse {tagName}");

                    }
                }
                catch (HttpRequestException e)
                {
                    Log.WriteLog(e.Message);
                }
            }
            return (tagName, html_url, downloadUrl);
        }
    }
}
