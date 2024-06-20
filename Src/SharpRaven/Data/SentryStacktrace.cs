using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace SharpRaven.Data
{
	public class SentryStacktrace
	{
		public SentryStacktrace(Exception e)
		{
			StackTrace trace = new StackTrace(e, true);
			this.Frames = new List<ExceptionFrame>();

			string[] formattedStackTrace = e.ToString().Split('\n');
			/*
			for (int i = 0; i < trace.FrameCount; i++)
			{
				StackFrame frame = trace.GetFrame(i);
				if (!string.IsNullOrEmpty(frame.GetFileName()))
					Frames.Add(new ExceptionFrame()
					{
						AbsolutePath = frame.GetFileName(),
						Filename = Path.GetFileName(frame.GetFileName()),
						Function = frame.GetMethod().Name,
						Source = formattedStackTrace[i + 1],
						LineNumber = frame.GetFileLineNumber(),
					});
			}
			*/
		}

		[JsonProperty(PropertyName = "frames")]
		public List<ExceptionFrame> Frames;

	}
}