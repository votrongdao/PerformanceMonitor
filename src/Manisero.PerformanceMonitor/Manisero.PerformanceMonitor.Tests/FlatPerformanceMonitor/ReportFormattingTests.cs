using System;
using System.Threading;
using Manisero.PerformanceMonitor.Monitors;
using NUnit.Framework;

namespace Manisero.PerformanceMonitor.Tests.FlatPerformanceMonitor
{
	public class ReportFormattingTests
	{
		private FlatPerformanceMonitor<string> Execute()
		{
			// Arrange
			var monitor = new FlatPerformanceMonitor<string>();
			var task1 = "task1";
			var task2 = "task2";

			// Act
			monitor.StartTask(task1);
			monitor.StartTask(task2);
			Thread.Sleep(20);
			monitor.StopTask(task1);
			monitor.StopTask(task2);

			return monitor;
		}

		[Test]
		public void formats_default_report()
		{
			var monitor = Execute();

			// Assert
			var report = monitor.GetResult().FormatReport();
			Console.Write(report);
		}

		[Test]
		public void formats_report_without_header()
		{
			var monitor = Execute();

			// Assert
			var report = monitor.GetResult().FormatReport(false);
			Console.Write(report);
		}

		[Test]
		public void formats_report_with_custom_task_name_formatter()
		{
			var monitor = Execute();

			// Assert
			var report = monitor.GetResult().FormatReport(taskNameFormatter: x => x.ToUpper());
			Console.Write(report);
		}

		[Test]
		public void formats_report_with_custom_task_duration_formatter()
		{
			var monitor = Execute();

			// Assert
			var report = monitor.GetResult().FormatReport(taskDurationFormatter: x => x.ToString());
			Console.Write(report);
		}
	}
}
