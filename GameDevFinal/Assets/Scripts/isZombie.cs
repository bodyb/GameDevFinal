using UnityEngine;
using UnityEngine.AI;

public class isZombie : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public float health = 1;
    public float damage = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        //transform.rotation = player.transform.rotation.;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        //Debug.Log(health);

    }
}
