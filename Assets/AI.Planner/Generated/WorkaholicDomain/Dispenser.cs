#if (NET_4_6 || NET_STANDARD_2_0)
using System;
using System.Collections.Generic;
using Unity.AI.Planner;
using Unity.Properties;

namespace WorkaholicDomain
{
    public partial struct Dispenser : IStructPropertyContainer<Dispenser>
    {
        public static ValueStructProperty<Dispenser, ConsumableType> ConsumableTypeProperty { get; private set; }

        private static StructPropertyBag<Dispenser> s_PropertyBag { get; set; }

        /// <inheritdoc cref="Unity.Properties.IPropertyContainer.PropertyBag" />
        public IPropertyBag PropertyBag => s_PropertyBag;
        /// <inheritdoc cref="Unity.Properties.IPropertyContainer.VersionStorage" />
        public IVersionStorage VersionStorage => null;

        private static void InitializeProperties()
        {
            ConsumableTypeProperty = new ValueStructProperty<Dispenser, ConsumableType>(
                "ConsumableType"
                ,(ref Dispenser c) => c.m_ConsumableType
                ,(ref Dispenser c, ConsumableType v) => c.m_ConsumableType = v
            );
        }

        static partial void InitializeCustomProperties();

        private static void InitializePropertyBag()
        {
            s_PropertyBag = new StructPropertyBag<Dispenser>(
                ConsumableTypeProperty
            );
        }

        static Dispenser()
        {
            InitializeProperties();
            InitializeCustomProperties();
            InitializePropertyBag();
        }

        public ConsumableType ConsumableType
        {
            get { return ConsumableTypeProperty.GetValue(ref this); }
            set { ConsumableTypeProperty.SetValue(ref this, value); }
        }


        /// <summary>
        /// Pass this object as a reference to the given handler.
        /// </summary>
        /// <param name="byRef">Handler to invoke.</param>
        /// <param name="context">Context argument passed to the handler.</param>
        public void MakeRef<TContext>(ByRef<Dispenser, TContext> byRef, TContext context)
        {
            byRef(ref this, context);
        }

        /// <summary>
        /// Pass this object as a reference to the given handler, and return the result.
        /// </summary>
        /// <param name="byRef">Handler to invoke.</param>
        /// <param name="context">Context argument passed to the handler.</param>
        /// <returns>The handler's return value.</returns>
        public TReturn MakeRef<TContext, TReturn>(ByRef<Dispenser, TContext, TReturn> byRef, TContext context)
        {
            return byRef(ref this, context);
        }
    }
}
#endif // (NET_4_6 || NET_STANDARD_2_0)
