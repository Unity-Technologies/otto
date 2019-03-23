#if (NET_4_6 || NET_STANDARD_2_0)
using System;
using System.Collections.Generic;
using Unity.AI.Planner;
using Unity.Properties;

namespace WorkaholicDomain
{
    public partial struct Duration : IStructPropertyContainer<Duration>
    {
        public static ValueStructProperty<Duration, System.Int64> TimeProperty { get; private set; }

        private static StructPropertyBag<Duration> s_PropertyBag { get; set; }

        /// <inheritdoc cref="Unity.Properties.IPropertyContainer.PropertyBag" />
        public IPropertyBag PropertyBag => s_PropertyBag;
        /// <inheritdoc cref="Unity.Properties.IPropertyContainer.VersionStorage" />
        public IVersionStorage VersionStorage => null;

        private static void InitializeProperties()
        {
            TimeProperty = new ValueStructProperty<Duration, System.Int64>(
                "Time"
                ,(ref Duration c) => c.m_Time
                ,(ref Duration c, System.Int64 v) => c.m_Time = v
            );
        }

        static partial void InitializeCustomProperties();

        private static void InitializePropertyBag()
        {
            s_PropertyBag = new StructPropertyBag<Duration>(
                TimeProperty
            );
        }

        static Duration()
        {
            InitializeProperties();
            InitializeCustomProperties();
            InitializePropertyBag();
        }

        public System.Int64 Time
        {
            get { return TimeProperty.GetValue(ref this); }
            set { TimeProperty.SetValue(ref this, value); }
        }


        /// <summary>
        /// Pass this object as a reference to the given handler.
        /// </summary>
        /// <param name="byRef">Handler to invoke.</param>
        /// <param name="context">Context argument passed to the handler.</param>
        public void MakeRef<TContext>(ByRef<Duration, TContext> byRef, TContext context)
        {
            byRef(ref this, context);
        }

        /// <summary>
        /// Pass this object as a reference to the given handler, and return the result.
        /// </summary>
        /// <param name="byRef">Handler to invoke.</param>
        /// <param name="context">Context argument passed to the handler.</param>
        /// <returns>The handler's return value.</returns>
        public TReturn MakeRef<TContext, TReturn>(ByRef<Duration, TContext, TReturn> byRef, TContext context)
        {
            return byRef(ref this, context);
        }
    }
}
#endif // (NET_4_6 || NET_STANDARD_2_0)
