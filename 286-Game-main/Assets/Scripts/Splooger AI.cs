using UnityEngine;
using System.Collections;

public class SploogerAI : MonoBehaviour
{
    public Transform player;
    public GameObject bullet;
    public float projectileSpeed = 100f;
    public Transform spawnPoint;
    public int projectileLife = 10;
    //public float fireRate=10f;
    //private float nextFire=0f;
    
    public int distThreshold = 10;
    public float moveRate = 10f;
    
    private float nextMove=0f;
    public float moveDist=10f;
    private bool isMove=true;
    private IEnumerator co;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        co=move();
        StartCoroutine(co);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player);

        if(!isMove)
        {
            StopCoroutine(co);
        }
    }

    IEnumerator move()
    {
        while(true)
        {
            nextMove=Time.deltaTime+moveRate;
        
            if(Vector3.Distance(transform.position,player.position) > distThreshold)
                transform.position=Vector3.MoveTowards(transform.position, player.position, moveDist * Time.deltaTime);
            else
            {
                //Debug.Log("I am going to explode");
                GameObject thing=Instantiate(bullet,spawnPoint);
                Rigidbody rb = thing.GetComponent<Rigidbody>();
                thing.transform.SetParent(null);
                Vector3 direction = (player.position - spawnPoint.position).normalized;
                rb.AddForce(direction * projectileSpeed, ForceMode.Impulse);

                GameObject thing2=Instantiate(bullet,spawnPoint);
                Rigidbody rb2 = thing2.GetComponent<Rigidbody>();
                thing2.transform.SetParent(null);
                Vector3 direction2 = Quaternion.Euler(0, -45, 0) * direction; 
                rb2.AddForce(direction2 * projectileSpeed,ForceMode.Impulse);

                GameObject thing3=Instantiate(bullet,spawnPoint);
                Rigidbody rb3 = thing3.GetComponent<Rigidbody>();
                thing3.transform.SetParent(null);
                Vector3 direction3 = Quaternion.Euler(0, 45, 0) * direction; 
                rb3.AddForce(direction3 * projectileSpeed,ForceMode.Impulse);

                Destroy(thing,projectileLife);
                Destroy(thing2,projectileLife);
                Destroy(thing3,projectileLife);
                Destroy(gameObject);   
                isMove=false;
            }
            yield return new WaitForSeconds(moveRate);
        }

        
    }
}
