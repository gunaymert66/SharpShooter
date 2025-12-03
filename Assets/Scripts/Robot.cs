using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    NavMeshAgent navmashagent;
    FirstPersonController player;
    [SerializeField] Transform Target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
    }
    private void Awake()
    {
        navmashagent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        navmashagent.SetDestination(player.transform.position);
    }
}
