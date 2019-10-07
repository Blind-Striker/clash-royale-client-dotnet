using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Pekka.Core.Helpers
{
    /// <summary>
    ///     Ensure input parameters
    /// </summary>
    public static class Ensure
    {
        /// <summary>
        ///     Checks an argument to ensure it isn't null.
        /// </summary>
        /// <param name="value">The argument value to check</param>
        /// <param name="name">The name of the argument</param>
        public static void ArgumentNotNull(object value, string name)
        {
            if (value != null)
            {
                return;
            }

            throw new ArgumentNullException(name);
        }

        /// <summary>
        ///     Checks a string argument to ensure it isn't null or empty.
        /// </summary>
        /// <param name="value">The argument value to check</param>
        /// <param name="name">The name of the argument</param>
        public static void ArgumentNotNullOrEmptyString(string value, string name)
        {
            ArgumentNotNull(value, name);

            if (!string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            throw new ArgumentException("String cannot be empty", name);
        }

        /// <summary>
        ///     Checks a timespan argument to ensure it is a positive value.
        /// </summary>
        /// <param name="value">The argument value to check</param>
        /// <param name="name">The name of the argument</param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static void GreaterThanZero(TimeSpan value, string name)
        {
            ArgumentNotNull(value, name);

            if (value.TotalMilliseconds > 0)
            {
                return;
            }

            throw new ArgumentException("Timespan must be greater than zero", name);
        }

        /// <summary>
        ///     Checks a integer argument to ensure it is a positive value.
        /// </summary>
        /// <param name="value">The argument value to check</param>
        /// <param name="name">The name of the argument</param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public static void GreaterThanZero(int value, string name)
        {
            if (value > 0)
            {
                return;
            }

            throw new ArgumentException("int must be greater than zero", name);
        }

        /// <summary>
        ///     Checks an enumerable argument to ensure it isn't null or empty.
        /// </summary>
        /// <param name="value">The argument value to check</param>
        /// <param name="name">The name of the argument</param>
        public static void ArgumentNotNullOrEmptyEnumerable<T>(IEnumerable<T> value, string name)
        {
            ArgumentNotNull(value, name);

            if (value.Any())
            {
                return;
            }

            throw new ArgumentException("List cannot be empty", name);
        }

        public static void AtleastOneCriteriaMustBeDefined<T>(T value, string name) where T : class, new()
        {
            ArgumentNotNull(value, name);

            PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            bool allNull = propertyInfos.All(info => info.GetValue(value) == null);

            if (allNull)
            {
                throw new ArgumentException("At least one filtering criteria must be defined");
            }
        }

        public static T IsType<T>(object @object)
        {
            TypeIs(typeof(T), @object);

            return (T) @object;
        }

        public static void TypeIs(Type expectedType, object @object)
        {
            ArgumentNotNull(expectedType, nameof(expectedType));
            ArgumentNotNull(@object, nameof(@object));

            Type type = @object.GetType();

            if (expectedType == type)
            {
                return;
            }

            string fullName1 = $"{expectedType.FullName} ({expectedType.GetTypeInfo().Assembly.GetName().FullName})";
            string fullName2 = $"{type.FullName} ({type.GetTypeInfo().Assembly.GetName().FullName})";

            throw new ArgumentException($"expected: {fullName1}{Environment.NewLine}actual: {fullName2}");
        }
    }
}