using System.Collections;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))] // Import Unity's Arteficial Intelligence, for enemy movement.

public class Enemies : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent pathfinder;            // Import AI as pathfinder.
    Transform target;                                  // Create transform variable to stor players position.
    public Transform enemyposition;                    // create transform varible to store enemy position.

	void Start ()
    {
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();       // set pathfinder to meshspace for enemy movement.
        target = GameObject.FindGameObjectWithTag("Player").transform;  // set player as target.
       
        StartCoroutine(updatepath());
    }
	
	void Update ()
    {
	}

    IEnumerator updatepath()                       // use IEunerator function type.
    {
        float refreshrate = 0.25f;                 // set refresh rate to 0.25 (no of times checks occur).
     
        while (target != null)                     // while the player is active.
        {
            if (target.position.z < (enemyposition.position.z + 20))    // if player within 20 points of enemy....
            {
                Vector3 targetposition = new Vector3(target.position.x, 3, target.position.z);
                pathfinder.SetDestination(targetposition);              // set player's position as target and isntruct enemies to move towards player.
                yield return new WaitForSeconds(refreshrate);
            }
            else                                                        // otherwise....
            {
                Vector3 targetposition = new Vector3(enemyposition.position.x, enemyposition.position.y, enemyposition.position.z);
                pathfinder.SetDestination(targetposition);              // tell enemies to remain in their current positions.
                yield return new WaitForSeconds(refreshrate);
            }
        }
    }
}