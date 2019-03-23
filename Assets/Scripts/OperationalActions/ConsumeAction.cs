#if WORKAHOLICDOMAIN_GENERATED
using System;
using Unity.AI.Planner;
using Unity.Entities;
using UnityEngine;
using Workaholic;
using WorkaholicDomain;

public class ConsumeAction : OttoAction
{
    static readonly int k_Consumables = Animator.StringToHash("Consumables");
    static readonly int k_EatFromPocket = Animator.StringToHash("EatFromPocket");
    static readonly int k_DrinkFromPocket = Animator.StringToHash("DrinkFromPocket");

    ConsumableType m_ConsumableType;
    NeedType       m_NeedType;
    long           m_NeedReduction;


    public override void BeginExecution(Entity stateEntity, ActionContext action, Otto actor)
    {
        base.BeginExecution(stateEntity, action, actor);

        var ecsAction = action;
        var inventory = ecsAction.GetTrait<Inventory>(1);

        m_ConsumableType = inventory.ConsumableType;
        m_NeedType       = inventory.SatisfiesNeed;
        m_NeedReduction  = inventory.NeedReduction;

        m_Animator.SetTrigger(k_Consumables);
        m_Animator.SetTrigger(m_ConsumableType == ConsumableType.Apple ? k_EatFromPocket : k_DrinkFromPocket);
    }

    public override void EndExecution(Entity stateEntity, ActionContext action, Otto actor)
    {
        base.EndExecution(stateEntity, action, actor);

        foreach (var domainObjectEntity in actor.GetObjectEntities(stateEntity, typeof(Inventory)))
        {
            var inventory = actor.GetObjectTrait<Inventory>(domainObjectEntity);
            inventory.Amount -= inventory.ConsumableType == m_ConsumableType ? 1 : 0;
            actor.SetObjectTrait(domainObjectEntity, inventory);
        }

        foreach (var domainObjectEntity in actor.GetObjectEntities(stateEntity, typeof(Need)))
        {
            var need = actor.GetObjectTrait<Need>(domainObjectEntity);
            need.Urgency -= need.NeedType == m_NeedType ? m_NeedReduction : 0;
            actor.SetObjectTrait(domainObjectEntity, need);
        }
    }
}
#endif
