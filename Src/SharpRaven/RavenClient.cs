using System;
using System.Text;
using SharpRaven.Data;
using System.Net;
using System.IO;
using SharpRaven.Utilities;
using SharpRaven.Logging;

namespace SharpRaven
{
	public class RavenClient
	{

		/// <summary>
		/// The DSN currently being used to log exceptions.
		/// </summary>
		public DSN CurrentDSN { get; set; }

		/// <summary>
		/// Interface for providing a 'log scrubber' that removes 
		/// sensitive information from exceptions sent to sentry.
		/// </summary>
		public IScrubber LogScrubber { get; set; }

		/// <summary>
		/// Enable Gzip Compression?
		/// Defaults to true.
		/// </summary>
		public bool Compression { get; set; }

		/// <summary>
		/// Logger. Default is "root"
		/// </summary>
		public string Logger { get; set; }

		public RavenClient(string dsn)
		{
			CurrentDSN = new DSN(dsn);
			Compression = true;
			Logger = "root";
		}

		public RavenClient(DSN dsn)
		{
			CurrentDSN = dsn;
			Compression = true;
			Logger = "root";
		}

		public int CaptureException(Exception e)
		{
			JsonPacket packet = new JsonPacket(CurrentDSN.ProjectID, e);
			packet.Logger = Logger;
			Send(packet, CurrentDSN);
			return 0;
		}

		public int CaptureException(Exception e, string[][] tags, object extra = null)
		{
			var packet = new JsonPacket(CurrentDSN.ProjectID, e);
			packet.Tags = tags;
			packet.Extra = extra;

			Send(packet, CurrentDSN);

			return 0;
		}

		public int CaptureMessage(string message, string level = ErrorLevel.Info, string[][] tags = null, object extra = null)
		{
			JsonPacket packet = new JsonPacket(CurrentDSN.ProjectID);
			packet.Message = message;
			packet.Level = level;
			packet.Tags = tags;
			packet.Extra = extra;

			Send(packet, CurrentDSN);

			return 0;
		}

		public bool Send(JsonPacket jp, DSN dsn)
		{
			//try
			{
				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(dsn.SentryURI);
				request.Method = "POST";
				request.Accept = "application/json";
				request.ContentType = "application/json; charset=utf-8";
				//request.Headers.Add("X-Sentry-Auth", PacketBuilder.CreateAuthenticationHeader(dsn));
				//ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
				//request.UserAgent = "RavenSharp/1.0";
				//request.Timeout = 2000;

				//Console.WriteLine("Header: " + PacketBuilder.CreateAuthenticationHeader(dsn));
				//Console.WriteLine("Packet: " + jp.Serialize());

				// Write the messagebody.
				/*
				using (Stream s = request.GetRequestStream())
				{
					string data = jp.Serialize();
					if (LogScrubber != null)
						data = LogScrubber.Scrub(data);
					byte[] byteArray = Encoding.UTF8.GetBytes(data);

					s.Write(byteArray, 0, byteArray.Length);
				}

				using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
				{
				}
				*/

			}/*
			catch (WebException e)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("[ERROR] ");
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine(e.Message);

				if (e.Response != null)
				{
					string messageBody = String.Empty;
					using (StreamReader sw = new StreamReader(e.Response.GetResponseStream()))
					{
						messageBody = sw.ReadToEnd();
					}
					Console.WriteLine("[MESSAGE BODY] " + messageBody);
				}

				return false;
			}*/

			return true;
		}

		#region Deprecated methods

		/**
         *  These methods have been deprectaed in favour of the ones
         *  that have the same names as the other sentry clients, this
         *  is purely for the sake of consistency
         */

		[Obsolete("The more common CaptureException method should be used")]
		public int CaptureEvent(Exception e)
		{
			return this.CaptureException(e);
		}

		[Obsolete("The more common CaptureException method should be used")]
		public int CaptureEvent(Exception e, string[][] tags)
		{
			return this.CaptureException(e, tags);
		}

        public void Capture(SentryEvent sentryEvent)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
