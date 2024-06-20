
using System;
using System.Collections.Generic;
using System.Linq;
#if NET35
using System.Web;
#endif
namespace SharpRaven.Data
{
    /// <summary>
    /// HTTP media type converter for HTML forms.
    /// </summary>
    public class FormHttpRequestBodyConverter : IHttpRequestBodyConverter
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
        public virtual bool Matches(string contentType)
        {
            if (string.IsNullOrEmpty(contentType))
            {
                return false;
            }

            var mimeType = contentType.Split(';').First();

            return mimeType.Equals("application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase);
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
                var dictionary = new Dictionary<string, string>();
                var collection = httpContext.Request.Form;
                var keys = Enumerable.ToArray(collection.AllKeys);

                foreach (object key in keys)
                {
                    if (key == null)
                        continue;

                    var stringKey = key as string ?? key.ToString();
                    var value = collection[stringKey];
                    var stringValue = value as string;

                    dictionary.Add(stringKey, stringValue);
                }

                converted = dictionary;

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