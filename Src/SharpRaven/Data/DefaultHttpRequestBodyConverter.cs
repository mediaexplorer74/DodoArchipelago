
using System;
using System.IO;
using System.Text;
#if NET35
using System.Web;
using SharpRaven.Utilities;
#endif

namespace SharpRaven.Data
{
    /// <summary>
    /// The default HTTP media type converter; just returns the HTTP request body as a <see cref="string"/>.
    /// </summary>
    public class DefaultHttpRequestBodyConverter : IHttpRequestBodyConverter
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
            return true;
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
                using (var stream = new MemoryStream())
                {
                    var position = httpContext.Request.InputStream.Position;
                    try
                    {
                        httpContext.Request.InputStream.Seek(0, SeekOrigin.Begin);
                        httpContext.Request.InputStream.CopyTo(stream);
                        converted = Encoding.UTF8.GetString(stream.ToArray());

                        return true;
                    }
                    finally
                    {
                        httpContext.Request.InputStream.Position = position;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return false;
        }
    }
}