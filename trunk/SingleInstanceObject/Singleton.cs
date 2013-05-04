using System.Reflection;
using System;

namespace SingleInstanceObject
{
    public class Singleton<T>
    {
        delegate T Instantiator();
        delegate void Seter(T value);

        static volatile Instantiator _instantiator = new Instantiator(Instantiate_SubstituteInstantiator_Get);
        static Seter _seter = new Seter(SetValue);
        static T _t;

        /// <summary>
        /// For cases where constructor has couple params and need for manual initialization.
        /// </summary>
        /// <param name="value">Instance</param>
        static void SetValue(T value)
        {
            if (_t == null)
            {
                lock (_instantiator)
                {
                    if (_t == null)
                    {
                        _t = value;
                        _instantiator = new Instantiator(ReturnValue);
                        _seter = new Seter(SeterUnavailable);
                    }
                }
            }
        }

        /// <summary>
        /// Instantiates object on first use.
        /// </summary>
        /// <returns></returns>
        static T Instantiate_SubstituteInstantiator_Get()
        {
            ConstructorInfo constructor = null;

            // Binding flags exclude public constructors.
            constructor = typeof(T).GetConstructor(BindingFlags.Instance |
                          BindingFlags.NonPublic | BindingFlags.Public, null, new Type[0], null);

            if (constructor == null || constructor.IsAssembly)
            {
                // Also exclude internal constructors.
                throw new Exception(string.Format("A private or " +
                      "protected constructor is missing for '{0}'.", typeof(T).Name));
            }

            SetValue(
                (T)constructor.Invoke(null)
                );

            return _t;
        }

        static T ReturnValue()
        {
            return _t;
        }

        static void SeterUnavailable(T value)
        {
            //Debug.Assert(false, "The singleton is already instantiated.");
            _t = default(T);
            SetValue(value);
        }

        public static T Instance
        {
            get
            { return _instantiator(); }
            set
            { _seter(value); }
        }

        /// <summary>
        /// Instantiates the singleton
        /// </summary>
        public static void Touch()
        {
            _instantiator();
        }
    }
}
