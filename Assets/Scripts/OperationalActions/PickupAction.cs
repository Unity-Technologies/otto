#if PLANNER_ACTIONS_GENERATED
using System;
using AI.Planner.Domains;
using AI.Planner.Domains.Enums;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Collections;
using Unity.Entities;
using Workaholic;
using UnityEngine;

public class PickupAction : OttoAction
{
    static readonly int k_Consumables = Animator.StringToHash("Consumables");
    static readonly int k_PocketFood = Animator.StringToHash("PocketFood");
    static readonly int k_PocketDrink = Animator.StringToHash("PocketDrink");
    ConsumableType      m_ConsumableType;

    public override void BeginExecution(StateData state, ActionKey action, Otto actor)
    {
        base.BeginExecution(state, action, actor);

        AnimationComplete = false;
        m_Animator.SetTrigger(k_Consumables);

        var dispenser = state.GetTraitOnObjectAtIndex<Dispenser>(action[1]);

        m_ConsumableType = dispenser.ConsumableType;
        m_Animator.SetTrigger(m_ConsumableType == ConsumableType.Apple ? k_PocketFood : k_PocketDrink);
    }

    public override void EndExecution(StateData state, ActionKey action, Otto actor)
    {
        var domainObjects = new NativeList<(DomainObject, int)>(4, Allocator.TempJob);
        foreach (var (_, domainObjectIndex) in state.GetDomainObjects(domainObjects, new ComponentType[] {typeof(Inventory)}))
        {
            var inventory = state.GetTraitOnObjectAtIndex<Inventory>(domainObjectIndex);
            inventory.Amount += inventory.ConsumableType == m_ConsumableType ? 1 : 0;
            state.SetTraitOnObjectAtIndex(inventory, domainObjectIndex);
        }
        domainObjects.Dispose();

        base.EndExecution(state, action, actor);
    }
}
#endif
