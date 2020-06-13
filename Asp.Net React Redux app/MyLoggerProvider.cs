using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Asp.Net_React_Redux_app {
    public class MyLoggerProvider : ILoggerProvider {
        public void Dispose() { }

        public ILogger CreateLogger(string categoryName) {
            return new MyLogger();
        }

        private class MyLogger : ILogger {
            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception exception,
                Func<TState, Exception, string> formatter
            ) {
                File.AppendAllText("log.txt", formatter(state, exception));
                Console.WriteLine(formatter(state, exception));
            }

            public bool IsEnabled(LogLevel logLevel) {
                return true;
            }

            public IDisposable BeginScope<TState>(TState state) {
                return null;
            }
        }
    }
}