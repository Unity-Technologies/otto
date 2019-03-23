#if WORKAHOLICDOMAIN_GENERATED
using System;
using Unity.AI.Planner;
using Unity.Entities;
using UnityEngine;
using Workaholic;
using WorkaholicDomain;

public class PickupAction : OttoAction
{
    static readonly int k_Consumables = Animator.StringToHash("Consumables");
    static readonly int k_PocketFood = Animator.StringToHash("PocketFood");
    static readonly int k_PocketDrink = Animator.StringToHash("PocketDrink");
    ConsumableType      m_ConsumableType;

    public override void BeginExecution(Entity stateEntity, ActionContext action, Otto actor)
    {
        base.BeginExecution(stateEntity, action, actor);

        AnimationComplete = false;
        m_Animator.SetTrigger(k_Consumables);

        var dispenser = action.GetTrait<Dispenser>(1);

        m_ConsumableType = dispenser.ConsumableType;
        m_Animator.SetTrigger(m_ConsumableType == ConsumableType.Apple ? k_PocketFood : k_PocketDrink);
    }

    public override void EndExecution(Entity stateEntity, ActionContext action, Otto actor)
    {
        foreach (var domainObjectEntity in actor.GetObjectEntities(stateEntity, typeof(Inventory)))
        {
            var inventory = actor.GetObjectTrait<Inventory>(domainObjectEntity);
            inventory.Amount += inventory.ConsumableType == m_ConsumableType ? 1 : 0;
            actor.SetObjectTrait(domainObjectEntity, inventory);
        }

        base.EndExecution(stateEntity, action, actor);
    }
}
#endif
