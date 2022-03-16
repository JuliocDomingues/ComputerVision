using System;
using System.Diagnostics;

namespace FaceMatching.Services
{
    public class CallScript
    {
        #region Call Script
        public static string RunScript(string pathScript, string pathImage)
        {
            Stopwatch stopwatch = new Stopwatch();

            var name = pathScript.Split('\\');

            stopwatch.Start();

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Users\estagio.sst17\AppData\Local\Programs\Python\Python39\python.exe",

                    Arguments = string.Format("{0} {1}", pathScript, pathImage),
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    LoadUserProfile = true
                },
                EnableRaisingEvents = true
            };


            process.Start();

            process.OutputDataReceived += (s, e) => SetOutputText(e.Data);
            process.ErrorDataReceived += (s, e) => SetErrorText(e.Data);

            process.WaitForExit();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds / 1000;

            return "Runtime of " + name[name.Length - 1] + ": " + time.ToString() + " s";

        }
        #endregion

        #region Sets
        private static void SetOutputText(string data)
        {
            Console.WriteLine(data);
        }

        private static void SetErrorText(string data)
        {
            Console.WriteLine(data);
        }
        #endregion
    }
}
