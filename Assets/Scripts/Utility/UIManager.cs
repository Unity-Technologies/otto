#if WORKAHOLICDOMAIN_GENERATED
using System;
using System.Collections.Generic;
using Unity.AI.Planner.Agent;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;
using Workaholic;
using WorkaholicDomain;

public class UIManager : MonoBehaviour
{
    public Image UIBarFood;
    public Image UIBarRest;
    public Image UIBarJoy;
    public GameObject AppleIcon;
    public GameObject BottleIcon;
    public int InventoryOffset;

    Otto m_Otto;
    Controller<Otto> m_Controller;
    List<Image> m_Apples = new List<Image>();
    List<Image> m_Bottles = new List<Image>();
    Material m_HungerMat;
    Material m_FatigueMat;
    Material m_ThirstMat;
    int m_NumApples;
    int m_MaxApples = 3;
    int m_NumBottles;
    int m_MaxBottles = 3;

    static readonly int s_Amount = Shader.PropertyToID("_Amount");

    public void Awake()
    {
        m_Otto = GetComponent<Otto>();

        // Make instances of these, so the asset on disk doesn't get modified
        UIBarFood.material = Instantiate(UIBarFood.material);
        UIBarRest.material = Instantiate(UIBarRest.material);
        UIBarJoy.material = Instantiate(UIBarJoy.material);
        m_HungerMat = UIBarFood.material;
        m_FatigueMat = UIBarRest.material;
        m_ThirstMat = UIBarJoy.material;
        m_HungerMat.SetFloat(s_Amount, 1);
        m_ThirstMat.SetFloat(s_Amount, 1);
        m_FatigueMat.SetFloat(s_Amount, 1);
    }

    public void Start()
    {
        for (int i = m_MaxApples - 1; i >= 0; i--)
        {
            var apple = Instantiate(AppleIcon, AppleIcon.transform.parent, true);
            apple.transform.position = AppleIcon.transform.position;
            apple.transform.localScale = new Vector3(1, 1, 1);

            var appleRect = apple.GetComponent<RectTransform>();
            var position = appleRect.position;
            position.x += -1 * InventoryOffset * i;
            appleRect.position = position;
            var appleImage = apple.GetComponent<Image>();
            appleImage.enabled = false;
            apple.SetActive(true);

            m_Apples.Add(appleImage);
        }

        for (int i = m_MaxBottles - 1; i >= 0; i--)
        {
            var bottle = Instantiate(BottleIcon, BottleIcon.transform.parent, true);
            bottle.transform.position = BottleIcon.transform.position;
            bottle.transform.localScale = new Vector3(1, 1, 1);

            var bottleRect = bottle.GetComponent<RectTransform>();
            var position = bottleRect.position;
            position.x += -1 * InventoryOffset * i;
            bottleRect.position = position;
            var bottleImage = bottle.GetComponent<Image>();
            bottleImage.enabled = false;
            bottle.SetActive(true);

            m_Bottles.Add(bottleImage);
        }
    }

    public void Update()
    {
        if (m_Controller == null)
        {
            m_Controller = m_Otto.Controller;
            return;
        }

        var stateEntity = m_Controller.CurrentStateEntity;

        SetNeeds(stateEntity);
        SetInventory(stateEntity);
    }

    void SetNeeds(Entity stateEntity)
    {
        foreach (var domainObjectEntity in m_Otto.GetObjectEntities(stateEntity, typeof(Need)))
        {
            var need = m_Otto.GetObjectTrait<Need>(domainObjectEntity);

            if (need.NeedType == NeedType.Hunger)
                m_HungerMat.SetFloat(s_Amount, 1 - need.Urgency / 100f);
            else if (need.NeedType == NeedType.Thirst)
                m_ThirstMat.SetFloat(s_Amount, 1 - need.Urgency / 100f);
            else if (need.NeedType == NeedType.Fatigue)
                m_FatigueMat.SetFloat(s_Amount, 1 - need.Urgency / 100f);
        }
    }

    void SetInventory(Entity stateEntity)
    {
        foreach (var domainObjectEntity in m_Otto.GetObjectEntities(stateEntity, typeof(Inventory)))
        {
            var inventory = m_Otto.GetObjectTrait<Inventory>(domainObjectEntity);

            if (inventory.SatisfiesNeed == NeedType.Hunger) // Apples
            {
                m_NumApples = (int) inventory.Amount;
                for (var i = 0; i < m_Apples.Count; i++)
                {
                    m_Apples[i].enabled = i >= m_MaxApples - m_NumApples;
                }
            }
            else if (inventory.SatisfiesNeed == NeedType.Thirst) // Bottles
            {
                m_NumBottles = (int) inventory.Amount;
                for (var i = 0; i < m_Bottles.Count; i++)
                {
                    m_Bottles[i].enabled = i >= m_MaxBottles - m_NumBottles;
                }
            }
        }
    }
}
#endif
