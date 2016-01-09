using System;

public static class Logger
{
    private static void Log(String level, object message)
    {
        var date = DateTime.Now;
        UnityEngine.Debug.Log(date.ToString() + " - " + level + " - " + message.ToString());
    }

    public static void Debug(object message)
    {
        Log("DEBUG", message);
    }

    public static void Info(object message)
    {
        Log("INFO", message);
    }
}