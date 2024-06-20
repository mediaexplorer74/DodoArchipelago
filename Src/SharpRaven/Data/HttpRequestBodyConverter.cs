
using System.Collections.Generic;
#if NET35
using System.Web;
#endif
namespace SharpRaven.Data
{
    /// <summary>
    /// Static utility class for converting an HTTP request body through implementations of
    /// the <see cref="IHttpRequestBodyConverter"/> interface.
    /// </summary>
    public static class HttpRequestBodyConverter
    {
        /// <summary>
        /// Converts the HTTP request body of the specified <paramref name="httpContext"/> to
        /// a structured type.
        /// </summary>
        /// <param name="httpContext">The HTTP context containing the request body to convert.</param>
        /// <returns>
        /// A structured type for the specified <paramref name="httpContext"/>'s request body
        /// or <c>null</c> if the <paramref name="httpContext"/> is null, or the somehow conversion fails.
        /// </returns>
#if NET35
        public static object Convert(HttpContext httpContext)
#else
        public static object Convert(dynamic httpContext)
#endif
        {
            var mediaTypes = new Dictionary<string, IHttpRequestBodyConverter>
            {
                { "FormMediaType", new FormHttpRequestBodyConverter() },
                { "MultiPartFormMediaType", new MultiPartFormHttpRequestBodyConverter() },
                { "JsonMediaType", new JsonHttpRequestBodyConverter() },
                { "DefaultMediaType", new DefaultHttpRequestBodyConverter() }
            };

            foreach (var item in mediaTypes)
            {
                var mediaType = item.Value;

                if (!mediaType.Matches(httpContext.Request.ContentType))
                    continue;

                object data;
                if (mediaType.TryConvert(httpContext, out data))
                    return data;
            }

            return null;
        }
    }
}