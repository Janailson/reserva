using System;
using System.Configuration;
using System.IO;
using System.Diagnostics;

/// <summary>
/// Grava um registro para log de erro do banco de dados
/// </summary>
public class Log
{
    public Log(Exception e)
    {
        string sDiretorio = ConfigurationSettings.AppSettings["LogDirectory"].ToString();

        if (!Directory.Exists(@sDiretorio))
            Directory.CreateDirectory(@sDiretorio);

        StackTrace stacktrace = new StackTrace();
        StackFrame[] stackframes = stacktrace.GetFrames();

        string Classe = stacktrace.GetFrame(1).GetMethod().ReflectedType.Name;
        string Metodo = stacktrace.GetFrame(1).GetMethod().Name;

        StreamWriter oSw = File.AppendText(@sDiretorio + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
        oSw.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm.ss") + " > Class{ " + Classe + " } : Listar{ " + Metodo + " } - Message{ " + e.Message + " }");
        oSw.Flush();
        oSw.Close();
        oSw = null;
    }

    public Log(Exception e, string Sql)
    {
        string sDiretorio = ConfigurationSettings.AppSettings["LogDirectory"].ToString();

        if (!Directory.Exists(@sDiretorio))
            Directory.CreateDirectory(@sDiretorio);

        StackTrace stacktrace = new StackTrace();
        StackFrame[] stackframes = stacktrace.GetFrames();

        string Classe = stacktrace.GetFrame(1).GetMethod().ReflectedType.Name;
        string Metodo = stacktrace.GetFrame(1).GetMethod().Name;

        StreamWriter oSw = File.AppendText(@sDiretorio + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
        oSw.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm.ss") + " > Class{ " + Classe + " } : Listar{ " + Metodo + " } - Message{ " + e.Message + " }" + (!string.IsNullOrEmpty(Sql) ? " - Sintax{ " + Sql + " }" : ""));
        oSw.Flush();
        oSw.Close();
        oSw = null;
    }
}