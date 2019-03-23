#if (NET_4_6 || NET_STANDARD_2_0)
using System;
using System.Collections.Generic;
using Unity.AI.Planner;
using Unity.Properties;

namespace WorkaholicDomain
{
    public partial struct Need : IStructPropertyContainer<Need>
    {
        public static ValueStructProperty<Need, NeedType> NeedTypeProperty { get; private set; }
        public static ValueStructProperty<Need, System.Int64> UrgencyProperty { get; private set; }
        public static ValueStructProperty<Need, System.Int64> ChangePerSecondProperty { get; private set; }

        private static StructPropertyBag<Need> s_PropertyBag { get; set; }

        /// <inheritdoc cref="Unity.Properties.IPropertyContainer.PropertyBag" />
        public IPropertyBag PropertyBag => s_PropertyBag;
        /// <inheritdoc cref="Unity.Properties.IPropertyContainer.VersionStorage" />
        public IVersionStorage VersionStorage => null;

        private static void InitializeProperties()
        {
            NeedTypeProperty = new ValueStructProperty<Need, NeedType>(
                "NeedType"
                ,(ref Need c) => c.m_NeedType
                ,(ref Need c, NeedType v) => c.m_NeedType = v
            );

            UrgencyProperty = new ValueStructProperty<Need, System.Int64>(
                "Urgency"
                ,(ref Need c) => c.m_Urgency
                ,(ref Need c, System.Int64 v) => c.m_Urgency = v
            );

            ChangePerSecondProperty = new ValueStructProperty<Need, System.Int64>(
                "ChangePerSecond"
                ,(ref Need c) => c.m_ChangePerSecond
                ,(ref Need c, System.Int64 v) => c.m_ChangePerSecond = v
            );
        }

        static partial void InitializeCustomProperties();

        private static void InitializePropertyBag()
        {
            s_PropertyBag = new StructPropertyBag<Need>(
                NeedTypeProperty,
                UrgencyProperty,
                ChangePerSecondProperty
            );
        }

        static Need()
        {
            InitializeProperties();
            InitializeCustomProperties();
            InitializePropertyBag();
        }

        public NeedType NeedType
        {
            get { return NeedTypeProperty.GetValue(ref this); }
            set { NeedTypeProperty.SetValue(ref this, value); }
        }

        public System.Int64 Urgency
        {
            get { return UrgencyProperty.GetValue(ref this); }
            set { UrgencyProperty.SetValue(ref this, value); }
        }

        public System.Int64 ChangePerSecond
        {
            get { return ChangePerSecondProperty.GetValue(ref this); }
            set { ChangePerSecondProperty.SetValue(ref this, value); }
        }


        /// <summary>
        /// Pass this object as a reference to the given handler.
        /// </summary>
        /// <param name="byRef">Handler to invoke.</param>
        /// <param name="context">Context argument passed to the handler.</param>
        public void MakeRef<TContext>(ByRef<Need, TContext> byRef, TContext context)
        {
            byRef(ref this, context);
        }

        /// <summary>
        /// Pass this object as a reference to the given handler, and return the result.
        /// </summary>
        /// <param name="byRef">Handler to invoke.</param>
        /// <param name="context">Context argument passed to the handler.</param>
        /// <returns>The handler's return value.</returns>
        public TReturn MakeRef<TContext, TReturn>(ByRef<Need, TContext, TReturn> byRef, TContext context)
        {
            return byRef(ref this, context);
        }
    }
}
#endif // (NET_4_6 || NET_STANDARD_2_0)
