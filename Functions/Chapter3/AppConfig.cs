using System;
using System.Collections.Specialized;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Functions.Chapter3
{
    public class AppConfig
    {
        NameValueCollection source;

        //public AppConfig() : this(ConfigurationManager.AppSettings) { }

        public AppConfig(NameValueCollection source)
        {
            this.source = source;
        }

        public Option<T> Get<T>(string name)
        {
            return source.Get(name) == null
            ? None
            : Some((T)Convert.ChangeType(source.Get(name), typeof(T)));
        }

        public T Get<T>(string name, T defaultValue) 
            => Get<T>(name).Match(
                () => defaultValue,
                (value) => value
            );

    }
}