using System;
using System.Reflection;

namespace HttpClientGenerator.Caching
{
    /// <summary>
    /// Specifies caching with times extracted from <see cref="ClientCachingAttribute"/>,
    /// applied to the executing method.
    /// </summary>
    public class AttributeBasedCachingStrategy : ICachingStrategy
    {
        private readonly TimeSpan _defaultTtl;

        /// <summary>
        /// Constructs instance of caching strategy.
        /// </summary>
        public AttributeBasedCachingStrategy()
            : this(TimeSpan.Zero)
        {
        }

        /// <summary>
        /// Constructs instance of caching strategy.
        /// </summary>
        /// <param name="defaultTtl">Default caching time</param>
        public AttributeBasedCachingStrategy(TimeSpan defaultTtl)
        {
            _defaultTtl = defaultTtl;
        }

        /// <inheritdoc />
        public TimeSpan GetCachingTime(MethodInfo targetMethod, object[] args)
        {
            var clientCachingAttribute = targetMethod.GetCustomAttribute<ClientCachingAttribute>();
            // ReSharper disable once ConstantConditionalAccessQualifier
            var attributeCachingTime = clientCachingAttribute?.CachingTime;
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            return attributeCachingTime == null || attributeCachingTime < TimeSpan.Zero 
                ? _defaultTtl
                : attributeCachingTime.Value;
        }
    }
}