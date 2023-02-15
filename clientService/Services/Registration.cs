using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace clientService.Services;
public class Registration : IRegistration
{
    public async Task<bool> RegisterNETDLL(string dllPath)
    {
        try
        {
            Process regasm = new Process();
            StringBuilder output = new StringBuilder();
            StringBuilder error = new StringBuilder();

            using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
            using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
            {
                regasm.StartInfo.FileName = @"C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\regasm.exe";
                regasm.StartInfo.Arguments = $"/tlb {dllPath}";
                regasm.StartInfo.UseShellExecute = false;
                regasm.StartInfo.RedirectStandardOutput = true;
                regasm.Start();
            
                regasm.BeginOutputReadLine();
                if (regasm.WaitForExit(5000))
                {
                        Console.WriteLine(".NET DLL: " + dllPath + string.Format(" registered successfuly: {0}", regasm.ExitCode) );
                }
                else
                {
                        Console.WriteLine(".NET DLL: " + dllPath + string.Format(" timed out {0}", regasm.ExitCode));
                }
            }
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<bool> RegisterVBDLL(string dllPath)
    {
        try
        {
            Process regsvr32 = new Process();
            regsvr32.StartInfo.FileName = "regsvr32.exe";
            regsvr32.StartInfo.Arguments = $"/s {dllPath}";
            regsvr32.StartInfo.UseShellExecute = false;
            regsvr32.StartInfo.RedirectStandardOutput = true;
            regsvr32.Start();
            regsvr32.WaitForExit();
            Console.WriteLine("VB6 DLL: " + dllPath + " registered successfuly");
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
