using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Myth.Millionaire.Core.Extensions {
    public static class PropertyCompareExtension {
        public static ICollection<string> CompareProperties<T>(this T left, T right) where T : class{
            LinkedList<string> result = new LinkedList<string>();
            using (LogWriter fs = new LogWriter("D:/output", "compare")) {
                Action<string> resultCallback = s => { fs.WriteLine(s); };
                ComparePropertiesImpl(left, right, string.Empty, new Queue(), resultCallback);
            }

            return result;
        }

        private static void ComparePropertiesImpl<T>(this T left, T right, string path, Queue instanceQueue, Action<string> resultCallback) where T : class {
            if (left == null) {
                return;
            }
            Type type = left.GetType();
            foreach (object o in instanceQueue) {
                if (!ReferenceEquals(left, o)) continue;
                // resultCallback($"{path} of {type.Name} is already exist, ignored.");
                return;
            }
            instanceQueue.Enqueue(left);
            PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo propertyInfo in propertyInfos) {
                try {
                    if (propertyInfo.CanRead) {
                        Type propertyType = propertyInfo.PropertyType;
                        string propertyName = propertyInfo.Name;

                        if (checkRecursivePath(path, propertyName)) {
                            // resultCallback($"Recursive path found: {path}");
                            return;
                        }

                        string fullPropertyPath = path + "." + propertyName;
                        MethodInfo getMethodInfo = propertyInfo.GetMethod;
                        if (getMethodInfo.GetParameters().Length > 0) {
                            // resultCallback($"Indexer found: {fullPropertyPath}");
                            continue;
                        }
                        object leftValue = propertyInfo.GetValue(left);
                        object rightValue = propertyInfo.GetValue(right);
                        if (propertyType.IsPrimitive || propertyType == typeof(string)) {
                            if (leftValue != null) {
                                if (!leftValue.Equals(rightValue)) {
                                    resultCallback($"{fullPropertyPath} left: {leftValue} right: {rightValue}");
                                }
                            }
                        }
                        else {
                            ComparePropertiesImpl(leftValue, rightValue, fullPropertyPath, instanceQueue, resultCallback);
                        }
                    }
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                }
                
            }
        }

        private static bool checkRecursivePath(string fullPath, string propertyName) {
            return fullPath.EndsWith($".{propertyName}.{propertyName}");
        }
    }

    class LogWriter : IDisposable {
        private const int LineLimit = 10000;
        private string PathPrefix { get; }

        private StreamWriter _writer;
        private int _index = 0;
        private int _currentLineCount = 0;
        public LogWriter(string folderPath, string fileName) {
            PathPrefix = Path.Combine(folderPath, fileName);
        }

        public void WriteLine(string line) {
            if (_writer == null) {
                MakeNewStream();
            }
            _writer.WriteLine(line);
            _currentLineCount++;
            if (_currentLineCount >= LineLimit) {
                Dispose();
            }
        }

        public void MakeNewStream() {
            _index++;
            _writer = new StreamWriter(PathPrefix + $"-{_index:000}.log");
            _currentLineCount = 0;
        }

        public void Dispose() {
            if (_writer != null) { 

            _writer.Close();
            _writer = null;
        }
    }
    }
}