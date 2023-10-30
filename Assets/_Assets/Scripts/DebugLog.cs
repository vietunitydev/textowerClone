using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class DebugLog
{
    public static void Log<T>(this IEnumerable<T> caller )
    {
        var message = new StringBuilder();

        foreach ( var item in caller )
        {
            message.AppendLine($"item : {item}");
        }

        Debug.Log($"List: {caller}:\n{message}");

    }
}
