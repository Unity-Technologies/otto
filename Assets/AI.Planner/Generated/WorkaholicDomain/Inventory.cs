#if (NET_4_6 || NET_STANDARD_2_0)
using System;
using System.Collections.Generic;
using Unity.AI.Planner;
using Unity.Properties;

namespace WorkaholicDomain
{
    public partial struct Inventory : IStructPropertyContainer<Inventory>
    {
        public static ValueStructProperty<Inventory, ConsumableType> ConsumableTypeProperty { get; private set; }
        public static ValueStructProperty<Inventory, System.Int64> AmountProperty { get; private set; }
        public static ValueStructProperty<Inventory, NeedType> SatisfiesNeedProperty { get; private set; }
        public static ValueStructProperty<Inventory, System.Int64> NeedReductionProperty { get; private set; }

        private static StructPropertyBag<Inventory> s_PropertyBag { get; set; }

        /// <inheritdoc cref="Unity.Properties.IPropertyContainer.PropertyBag" />
        public IPropertyBag PropertyBag => s_PropertyBag;
        /// <inheritdoc cref="Unity.Properties.IPropertyContainer.VersionStorage" />
        public IVersionStorage VersionStorage => null;

        private static void InitializeProperties()
        {
            ConsumableTypeProperty = new ValueStructProperty<Inventory, ConsumableType>(
                "ConsumableType"
                ,(ref Inventory c) => c.m_ConsumableType
                ,(ref Inventory c, ConsumableType v) => c.m_ConsumableType = v
            );

            AmountProperty = new ValueStructProperty<Inventory, System.Int64>(
                "Amount"
                ,(ref Inventory c) => c.m_Amount
                ,(ref Inventory c, System.Int64 v) => c.m_Amount = v
            );

            SatisfiesNeedProperty = new ValueStructProperty<Inventory, NeedType>(
                "SatisfiesNeed"
                ,(ref Inventory c) => c.m_SatisfiesNeed
                ,(ref Inventory c, NeedType v) => c.m_SatisfiesNeed = v
            );

            NeedReductionProperty = new ValueStructProperty<Inventory, System.Int64>(
                "NeedReduction"
                ,(ref Inventory c) => c.m_NeedReduction
                ,(ref Inventory c, System.Int64 v) => c.m_NeedReduction = v
            );
        }

        static partial void InitializeCustomProperties();

        private static void InitializePropertyBag()
        {
            s_PropertyBag = new StructPropertyBag<Inventory>(
                ConsumableTypeProperty,
                AmountProperty,
                SatisfiesNeedProperty,
                NeedReductionProperty
            );
        }

        static Inventory()
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

        public System.Int64 Amount
        {
            get { return AmountProperty.GetValue(ref this); }
            set { AmountProperty.SetValue(ref this, value); }
        }

        public NeedType SatisfiesNeed
        {
            get { return SatisfiesNeedProperty.GetValue(ref this); }
            set { SatisfiesNeedProperty.SetValue(ref this, value); }
        }

        public System.Int64 NeedReduction
        {
            get { return NeedReductionProperty.GetValue(ref this); }
            set { NeedReductionProperty.SetValue(ref this, value); }
        }


        /// <summary>
        /// Pass this object as a reference to the given handler.
        /// </summary>
        /// <param name="byRef">Handler to invoke.</param>
        /// <param name="context">Context argument passed to the handler.</param>
        public void MakeRef<TContext>(ByRef<Inventory, TContext> byRef, TContext context)
        {
            byRef(ref this, context);
        }

        /// <summary>
        /// Pass this object as a reference to the given handler, and return the result.
        /// </summary>
        /// <param name="byRef">Handler to invoke.</param>
        /// <param name="context">Context argument passed to the handler.</param>
        /// <returns>The handler's return value.</returns>
        public TReturn MakeRef<TContext, TReturn>(ByRef<Inventory, TContext, TReturn> byRef, TContext context)
        {
            return byRef(ref this, context);
        }
    }
}
#endif // (NET_4_6 || NET_STANDARD_2_0)
