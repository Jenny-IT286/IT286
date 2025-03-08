using UnityEngine;

public class NebulogAI : MonoBehaviour
{   
    public Transform player;
    public GameObject bullet;
    public float projectileSpeed = 100f;
    public Transform spawnPoint;
    public int projectileLife = 10;
    public float fireRate=10f;
    private float nextFire=0f;
    
    public float moveRate = 10f;
    
    //private float nextMove=0f;
    public float moveDist=10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.LookAt(player);

        if(Time.time >= nextFire)
        {
            GameObject thing=Instantiate(bullet,spawnPoint);
            Rigidbody rb = thing.GetComponent<Rigidbody>();
            thing.transform.SetParent(null);
            Vector3 direction = (player.position - spawnPoint.position).normalized;
            rb.AddForce(direction * projectileSpeed, ForceMode.Impulse);
            Destroy(thing,projectileLife);
            nextFire=Time.time+fireRate;
        }
    }
}
