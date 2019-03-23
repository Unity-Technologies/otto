#if (NET_4_6 || NET_STANDARD_2_0)
using System;
using System.Collections.Generic;
using Unity.AI.Planner;
using Unity.Properties;

namespace WorkaholicDomain
{
    public partial struct Time : IStructPropertyContainer<Time>
    {
        public static ValueStructProperty<Time, System.Int64> ValueProperty { get; private set; }

        private static StructPropertyBag<Time> s_PropertyBag { get; set; }

        /// <inheritdoc cref="Unity.Properties.IPropertyContainer.PropertyBag" />
        public IPropertyBag PropertyBag => s_PropertyBag;
        /// <inheritdoc cref="Unity.Properties.IPropertyContainer.VersionStorage" />
        public IVersionStorage VersionStorage => null;

        private static void InitializeProperties()
        {
            ValueProperty = new ValueStructProperty<Time, System.Int64>(
                "Value"
                ,(ref Time c) => c.m_Value
                ,(ref Time c, System.Int64 v) => c.m_Value = v
            );
        }

        static partial void InitializeCustomProperties();

        private static void InitializePropertyBag()
        {
            s_PropertyBag = new StructPropertyBag<Time>(
                ValueProperty
            );
        }

        static Time()
        {
            InitializeProperties();
            InitializeCustomProperties();
            InitializePropertyBag();
        }

        public System.Int64 Value
        {
            get { return ValueProperty.GetValue(ref this); }
            set { ValueProperty.SetValue(ref this, value); }
        }


        /// <summary>
        /// Pass this object as a reference to the given handler.
        /// </summary>
        /// <param name="byRef">Handler to invoke.</param>
        /// <param name="context">Context argument passed to the handler.</param>
        public void MakeRef<TContext>(ByRef<Time, TContext> byRef, TContext context)
        {
            byRef(ref this, context);
        }

        /// <summary>
        /// Pass this object as a reference to the given handler, and return the result.
        /// </summary>
        /// <param name="byRef">Handler to invoke.</param>
        /// <param name="context">Context argument passed to the handler.</param>
        /// <returns>The handler's return value.</returns>
        public TReturn MakeRef<TContext, TReturn>(ByRef<Time, TContext, TReturn> byRef, TContext context)
        {
            return byRef(ref this, context);
        }
    }
}
#endif // (NET_4_6 || NET_STANDARD_2_0)
