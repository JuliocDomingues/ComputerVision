using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace FaceMatching.Services
{
    public class CallScript
    {
        public static string RunScript(string pathImage)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Users\estagio.sst17\AppData\Local\Programs\Python\Python39\python.exe",

                    Arguments = string.Format("{0} {1}", @"C:\Users\estagio.sst17\Documents\studycsharp\ComputerVision\FaceMatching\FaceMatching\FaceMatching\Script\main.py", pathImage),
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

            return "Time of execution: " + time.ToString() + " s";

        }


        private static void SetOutputText(string data)
        {
            Console.WriteLine(data);
        }

        private static void SetErrorText(string data)
        {
            Console.WriteLine(data);
        }
    }
}
