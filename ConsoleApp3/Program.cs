using Relativity.Logging;
using Relativity.Logging.Configuration;
using Relativity.Logging.Factory;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net;
using Rule = Relativity.Logging.Configuration.Rule;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace Sample
{
	internal class Program
	{
		public static string GetFQDN()
		{
			string domainName = $".{IPGlobalProperties.GetIPGlobalProperties().DomainName}";
			string hostName = Dns.GetHostName();

			// if hostname does not already include domain name
			if (!hostName.EndsWith(domainName))
			{
				hostName += domainName;
			}

			return hostName;
		}

		static void Main(string[] args)
		{
			Console.WriteLine("ClientId: {0}", Environment.GetEnvironmentVariable("ClientId"));
			/*
			try
			{
				throw new ArgumentException();
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine("I'm here");
				throw;
			}
			catch (Exception ex)
			{
				Console.WriteLine("I'm here Exception");
				throw;
			}
			*/
			/*
			string fqdn = GetFQDN();
			string scheme = Uri.UriSchemeHttps;

			UriBuilder uriBuilder = new UriBuilder
			{
				Scheme = scheme,
				Host = fqdn,
				Path = "api"
			};

			uriBuilder.Port = 8995;
			uriBuilder.Path = string.Empty;

			var uri = Path.Combine("https://ctus014000-T027.r1.kcura.com/Relativity.Rest/", "API/");

			Console.WriteLine(uri);
			*/
		}
			/*
			static void Main(string[] args)
			{
				const string system = "Invariant";
				LoggerOptions options = new LoggerOptions
				{
					System = system,
					SubSystem = "Worker",
					Application = "ProcessingWorker"
				};
				KeyValuePair<string, object>[] mtpAdditionalData =
				{
					new KeyValuePair<string, object>("service.name", "relativity-logging-test"),
					new KeyValuePair<string, object>("r1.team.id", "PTCI-5551758")
				};
				options.SetAdditionalDataGetter(new LogsAdditionalDataGetter(mtpAdditionalData));
				// ipaddress and port shall be the same like in https://git.kcura.com/projects/ROC/repos/relone_logentries_agent/browse/templates/windows/logconfig_invariant.xml.erb
				const string splunkSinkName = "Splunk1";
				const string ipaddress = "";
				const int port = 0;
				var splunkLogConfig = new TcpSinkConfig(splunkSinkName, ipaddress, port);
				// endpointUrl and apiKey shall be taken from https://einstein.kcura.com/pages/viewpage.action?spaceKey=DV&title=RelEye+Endpoints
				const string openTelemetrySinkName = "OpenTelemetry1";
				const string endpointUrl = "https://services.ctus.reg.k8s.r1.kcura.com/releye/v1/logs";
				const string apiKey = "I~7s6vtdhzbmgWEak80F2U_NcMQ4fo";
				var openTelemetrySinkConfig =
					new OpenTelemetrySinkConfig(
						openTelemetrySinkName,
						endpointUrl,
						apiKey,
						OpenTelemetrySinkConfig.DefaultBatchSizeLimit,
						OpenTelemetrySinkConfig.DefaultEagerlyEmitFirstEvent,
						TimeSpan.FromSeconds(OpenTelemetrySinkConfig.DefaultPeriodInSeconds),
						OpenTelemetrySinkConfig.DefaultQueueLimit
					);
				// third sink is just for testing purposes
				var fileSinkConfig = new FileSinkConfig("FileSink", @"C:\Temp\Logs", maxFileSizeInMB: 10000);
				LogConfiguration config = new LogConfiguration
				{
					LoggingEnabled = true,
					Sinks = new List<Sink>
					{
						openTelemetrySinkConfig,
						splunkLogConfig,
						fileSinkConfig
					}
				};
				List<string> loggingSinks = new List<string>
				{
					openTelemetrySinkConfig.Name,
					splunkLogConfig.Name,
					fileSinkConfig.Name
				};
				// invariantLogLevel shall be the same like in https://git.kcura.com/projects/ROC/repos/relone_logentries_agent/browse/templates/windows/logconfig_invariant.xml.erb
				const LoggingLevel invariantLogLevel = LoggingLevel.Information;
				config.Rules = new List<Rule>
				{
					new Rule(null, null, "Security", null, loggingSinks, LoggingLevel.Information),
					new Rule(null, system, null, null, loggingSinks, invariantLogLevel),
					new Rule(null, "*", null, null, loggingSinks, LoggingLevel.Warning)
				};
				var logger = LogFactory.GetLogger(options, config);
				logger.LogVerbose("test|Verbose");
				logger.LogDebug("test|Debug");
				logger.LogInformation("test|Information");
				logger.LogWarning("test|Warning");
				logger.LogError("test|Error");
				logger.LogFatal("test|Fatal");
			}
			*/

		}
	public class LogsAdditionalDataGetter : IGetAdditionalData
	{
		private readonly KeyValuePair<string, object>[] _additionalData;
		public LogsAdditionalDataGetter(KeyValuePair<string, object>[] additionalData)
		{
			_additionalData = additionalData;
		}
		public IEnumerable<KeyValuePair<string, object>> GetAdditionalData()
		{
			return _additionalData;
		}
	}
}