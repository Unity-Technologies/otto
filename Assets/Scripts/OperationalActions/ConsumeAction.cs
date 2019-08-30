#if PLANNER_ACTIONS_GENERATED
using System;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Collections;
using UnityEngine;
using Workaholic;
using AI.Planner.Domains;
using AI.Planner.Domains.Enums;

public class ConsumeAction : OttoAction
{
    static readonly int k_Consumables = Animator.StringToHash("Consumables");
    static readonly int k_EatFromPocket = Animator.StringToHash("EatFromPocket");
    static readonly int k_DrinkFromPocket = Animator.StringToHash("DrinkFromPocket");

    ConsumableType m_ConsumableType;
    NeedType       m_NeedType;
    long           m_NeedReduction;


    public override void BeginExecution(StateData state, ActionKey action, Otto actor)
    {
        base.BeginExecution(state, action, actor);

        var inventory = state.GetTraitOnObjectAtIndex<Inventory>(action[1]);

        m_ConsumableType = inventory.ConsumableType;
        m_NeedType       = inventory.SatisfiesNeed;
        m_NeedReduction  = inventory.NeedReduction;

        m_Animator.SetTrigger(k_Consumables);
        m_Animator.SetTrigger(m_ConsumableType == ConsumableType.Apple ? k_EatFromPocket : k_DrinkFromPocket);
    }

    public override void EndExecution(StateData state, ActionKey action, Otto actor)
    {
        base.EndExecution(state, action, actor);

        var domainObjects = new NativeList<(DomainObject, int)>(4, Allocator.TempJob);
        foreach (var (_, domainObjectIndex) in state.GetDomainObjects(domainObjects, typeof(Inventory)))
        {
            var inventory = state.GetTraitOnObjectAtIndex<Inventory>(domainObjectIndex);
            inventory.Amount -= inventory.ConsumableType == m_ConsumableType ? 1 : 0;
            state.SetTraitOnObjectAtIndex(inventory, domainObjectIndex);
        }

        domainObjects.Clear();
        foreach (var (_, domainObjectIndex) in state.GetDomainObjects(domainObjects, typeof(Need)))
        {
            var need = state.GetTraitOnObjectAtIndex<Need>(domainObjectIndex);
            need.Urgency -= need.NeedType == m_NeedType ? m_NeedReduction : 0;
            state.SetTraitOnObjectAtIndex(need, domainObjectIndex);
        }
        domainObjects.Dispose();
    }
}
#endif
