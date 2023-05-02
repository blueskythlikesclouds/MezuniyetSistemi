using MezuniyetSistemi.Business.Abstract;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Business.Concrete
{
    public class LoggerManager : ILoggerService
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message) => _logger.Debug(message);

        public void LogError(string message) => _logger.Error(message);

        public void LogInformation(string message) => _logger.Info(message);

        public void LogWarning(string message) => _logger.Warn(message);
    }
}
