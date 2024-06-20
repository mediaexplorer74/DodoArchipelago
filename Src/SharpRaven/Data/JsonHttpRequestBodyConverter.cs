using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
#if NET35
using System.Web;
using SharpRaven.Utilities;
#endif
namespace SharpRaven.Data
{
    /// <summary>
    /// HTTP media type converter for JSON.
    /// </summary>
    public class JsonHttpRequestBodyConverter : IHttpRequestBodyConverter
    {
        /// <summary>
        /// Checks whether the specified <paramref name="contentType"/> can be converted by this
        /// <see cref="IHttpRequestBodyConverter"/> implementation or not.
        /// </summary>
        /// <param name="contentType">The media type to match.</param>
        /// <returns>
        /// Returns <c>true</c> if the <see cref="IHttpRequestBodyConverter"/> implementation can convert
        /// the specified <paramref name="contentType"/> cref="contentType"/>; otherwise <c>false</c>.
        /// </returns>
        public bool Matches(string contentType)
        {
            if (String.IsNullOrEmpty(contentType))
            {
                return false;
            }

            var mimeType = contentType.Split(';').First();

            return mimeType.Equals("application/json", StringComparison.OrdinalIgnoreCase) ||
                mimeType.StartsWith("application/json-", StringComparison.OrdinalIgnoreCase) ||
                mimeType.Equals("text/json", StringComparison.OrdinalIgnoreCase) ||
                mimeType.EndsWith("+json", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tries to convert the HTTP request body of the specified <paramref name="httpContext"/> to
        /// a structured type.
        /// </summary>
        /// <param name="httpContext">The HTTP context containing the request body to convert.</param>
        /// <param name="converted">
        /// The converted, structured type for the specified <paramref name="httpContext"/>'s request
        /// body or <c>null</c> if the <paramref name="httpContext"/> is null, or the somehow conversion
        /// fails.
        /// </param>
        /// <returns>
        /// <c>true</c> if the conversion succeeds; otherwise <c>false</c>.
        /// </returns>
#if NET35
        public bool TryConvert(HttpContext httpContext, out object converted)
#else
        public bool TryConvert(dynamic httpContext, out object converted)
#endif
        {
            converted = null;

            if (httpContext == null)
            {
                return false;
            }

            try
            {
                string body = null;

                using (var stream = new MemoryStream())
                {
                    var position = httpContext.Request.InputStream.Position;
                    try
                    {
                        httpContext.Request.InputStream.Seek(0, SeekOrigin.Begin);
                        httpContext.Request.InputStream.CopyTo(stream);
                        body = Encoding.UTF8.GetString(stream.ToArray());
                    }
                    finally
                    {
                        httpContext.Request.InputStream.Position = position;
                    }
                }

                converted = JsonConvert.DeserializeObject<Dictionary<string, object>>(body);

                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return false;
        }
    }
}