using System;
using Unity.Entities;
using UnityEngine.AI.Planner.Agent;
#if WORKAHOLICDOMAIN_GENERATED
using WorkaholicDomain;
#endif

namespace Workaholic
{
    public class Otto : BaseAgent<Otto>
    {
        public bool Dead { get; set; }

        protected override void Update()
        {
            if (!Dead)
                Controller.Update();
        }

#if WORKAHOLICDOMAIN_GENERATED
        protected override float Heuristic(Entity stateEntity)
        {
            var totalNeedsUrgency = 0L;

            // Resources
            foreach (var domainObjectEntity in GetObjectEntities(stateEntity, typeof(Need)))
            {
                var needTrait = m_EntityManager.GetComponentData<Need>(domainObjectEntity);
                totalNeedsUrgency += needTrait.Urgency;
            }

            float value = 50;

            // Score based on total urgency over all needs (0 -> 300).
            if (totalNeedsUrgency > 50)
                value = 0;
            if (totalNeedsUrgency > 100)
                value = -30;
            if (totalNeedsUrgency > 150)
                value = -50;
            if (totalNeedsUrgency > 200)
                value = -150;

            foreach (var domainObjectEntity in GetObjectEntities(stateEntity, typeof(Inventory)))
            {
                var inventoryTrait = m_EntityManager.GetComponentData<Inventory>(domainObjectEntity);
                value += inventoryTrait.Amount * 10;
            }

            return value;
        }
#endif
    }
}
