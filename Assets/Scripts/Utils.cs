using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LogType {
    INFO,
    ERROR,
    WARNING
}
namespace Utility {
    public class Utils {
        public static void DebugDictioanry<T, V>(Dictionary<T, V> dictionary) {
            Utils.Log("\nSize: " + dictionary.Count);
            foreach (KeyValuePair<T, V> item in dictionary) {
                Utils.Log(string.Format("Key: {0}, Value: {1}", item.Key, item.Value));
            }
        }

        public static void Log(object msg, LogType logType = LogType.INFO) {
            Debug.Log(GetPrefix(logType) + msg.ToString() + GetPostFix());
        }

        private static string GetPrefix(LogType logType) {
            string format = "<color={0}>";
            string arg = "blue";
            switch (logType) {
                case LogType.ERROR:
                    arg = "red";
                    break;
                case LogType.WARNING:
                    arg = "yellow";
                    break;
                case LogType.INFO:
                default:
                    break;
            }
            return string.Format(format, arg);
        }

        private static string GetPostFix() {
            return "</color>";
        }
    }
}
