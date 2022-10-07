using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class friendmoney : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;

    public float radius;
    public static int _friendmoney = 50;
    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        if (BorrowMoney.canBorrow == false)
        {
            if (!agent.hasPath)
            {
                agent.SetDestination(GetPoint.Instance.GetRandomPoint(transform, radius));
            }
        }
        if (merchant.canBuy == false)
        {
            if (!agent.hasPath)
            {
                agent.SetDestination(GetPoint.Instance.GetRandomPoint(transform, radius));
            }
        }
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

#endif
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_friendmoney == 0)
        {
            Destroy(GetComponent<Collider>().gameObject);
        }
    }
}
