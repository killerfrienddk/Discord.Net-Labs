﻿using System.Threading.Tasks;

namespace Discord
{
	internal static class TaskHelper
	{
		public static Task CompletedTask { get; }
		static TaskHelper()
		{
			CompletedTask = Task.Delay(0);
		}
	}
}
