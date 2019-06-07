using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera fpscam;                           // create variable for camera object.
    public GameObject mainProjectile;               // create variable for projectile object.
    private GameObject enemy;                       // create variable for enemy object.
    public ParticleSystem mainParticleSystem;       // create instantiation of particle system.

    public int damage = 10;                      // create Damege variable.
    public int life = 30;                      // create life variable.
    public float range = 20f;                       // create effective fire range variable.

    new string name;

    void Start()
    {
        mainProjectile.SetActive(false);           // Start with projectile off.
    }

    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();                               // if the fire button is clicked run shoot function.
        }

       if (mainParticleSystem.IsAlive() == false)
        {
            mainProjectile.SetActive(false);      // if particle system not active, set projected to not active.
        }
	}

    void Shoot()             // when shoot is called....
    {
        mainProjectile.SetActive(true);         // set projecttile to active.
        RaycastHit Hit;                         // create variable to store hit detects.

        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out Hit, range))
        {
            for (int x = 0; x < 27; x++)    // run through the name of all the enemies.
            {
                name = "Enemy" + "(" + x.ToString() + ")";   // an alex hack... dont try at home kids.
                enemy = GameObject.Find(name);                      // store to enemy as a game object.

                if (Hit.transform.name == name) // if the name of the hit came object equalls an enemy's.....
                {
                    life = life - damage;

                    if (life < 0)
                    {
                        GameObject.Destroy(enemy);         // destroy the enemy gam object.
                        Debug.Log(name);                   // display the name of the distroyed game object.
                        life = 30;
                    }
                }
            }
        }
    }
}
