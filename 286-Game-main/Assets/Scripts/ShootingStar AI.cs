using UnityEngine;

public class ShootingStarAI : MonoBehaviour
{
    public GameObject bullet;
    public float projectileSpeed = 100f;
    public Transform spawnPoint;
    public int projectileLife = 10;
    public float fireRate=10f;
    private float nextFire=0f;
    
    public float moveRate = 10f;
    
    private float nextMove=0f;
    public float moveDist=10f;

    private Vector3 nextSpot;
    private float nextX;
    private float nextZ;
    private bool isMove = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextSpot=randomSpot();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //DO NOT FORGET THIS!!!!!!!!!!!!!!!!!!!!!!!!
        //FOR THIS MODEL, IT WAS MADE IN BLENDER! Z AXIS IS UP!!!!!

        //Code for movement, going to have it pick a random direction and "float towards it"
        if(Time.time >= nextMove)
        {                       //X Y Z -> X Z Y I think
            //transform.Translate(0f,0f,0f);
            //Random.Range(-10.0f, 10.0f)
            //float rX=Random.Range(moveDist-transform.position.x,moveDist+transform.position.x);
            //Debug.Log(rX);
            //float rY=Random.Range(moveDist-transform.position.y,moveDist+transform.position.y);
            //Debug.Log(rY);

            /*int c =100;
            while(c<100)
            {   
                if(transform.position.x != rX && rX > 0)
                {
                    transform.Translate(transform.position.x+1,transform.position.y,transform.position.z);
                }

                if(transform.position.x != rX && rX < 0)
                {
                    transform.Translate(transform.position.x-1,transform.position.y,transform.position.z);
                }

                if(transform.position.y != rY && rY > 0)
                {
                    transform.Translate(transform.position.x,transform.position.y+1,transform.position.z);
                }

                if(transform.position.y != rY && rY < 0)
                {
                   transform.Translate(transform.position.x,transform.position.y-1,transform.position.z);
                }

                if(rY == transform.position.y && rX == transform.position.x)
                    break;
                c++;
            }*/

            //transform.position += transform.right * moveDist;
            
            /*if(false)
            {
                Debug.Log("Next Spot Coming!");
                Vector3 nextSpot=randomSpot();
            }
            else
            {
                Debug.Log("Trying to Move");//\nnextX: " + nextX + "\nnextZ: "+nextZ);
                transform.position = Vector3.MoveTowards(transform.position, nextSpot, moveDist * Time.deltaTime);
            }*/

            if(!isMove)
            {
                isMove=true;
                transform.position=Vector3.MoveTowards(transform.position,nextSpot,moveDist);
            }
            else
            {
                isMove=false;
                nextSpot=randomSpot();
            }
            
            nextMove=Time.time+moveRate;
        }
         //Code for continuous firing every nextFire seconds
        if(Time.time >= nextFire) 
        {
            int c=0;
            spawnPoint.rotation=Quaternion.Euler(0f, 0f, 0f);
            while(c <=315)
            {
                GameObject thing=Instantiate(bullet,spawnPoint);
                Rigidbody rb = thing.GetComponent<Rigidbody>();
                thing.transform.SetParent(null);
                rb.AddForce(spawnPoint.forward * projectileSpeed, ForceMode.Impulse); 
                Destroy(thing,projectileLife);
                spawnPoint.rotation=Quaternion.Euler(0f, c+=45, 0f);
            }
            nextFire=Time.time+fireRate;

            /* Matt's biggest sleep deprived mistake #1
            GameObject thing=Instantiate(bullet,spawnPoint);
            Rigidbody rb = thing.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.forward * projectileSpeed, ForceMode.Impulse); 
            Destroy(thing,projectileLife);


            spawnPoint.rotation=Quaternion.Euler(0f, 45f, 0f);
            thing=Instantiate(bullet,spawnPoint);
            rb=thing.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.forward * projectileSpeed,ForceMode.Impulse);
            Destroy(thing,projectileLife);

            spawnPoint.rotation=Quaternion.Euler(0f, 90f, 0f);
            thing=Instantiate(bullet,spawnPoint);
            rb=thing.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.forward * projectileSpeed,ForceMode.Impulse);
            Destroy(thing,projectileLife);

            spawnPoint.rotation=Quaternion.Euler(0f, 135f, 0f);
            thing=Instantiate(bullet,spawnPoint);
            rb=thing.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.forward * projectileSpeed,ForceMode.Impulse);
            Destroy(thing,projectileLife);

            spawnPoint.rotation=Quaternion.Euler(0f, 180f, 0f);
            thing=Instantiate(bullet,spawnPoint);
            rb=thing.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.forward * projectileSpeed,ForceMode.Impulse);
            Destroy(thing,projectileLife);

            spawnPoint.rotation=Quaternion.Euler(0f, 225f, 0f);
            thing=Instantiate(bullet,spawnPoint);
            rb=thing.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.forward * projectileSpeed,ForceMode.Impulse);
            Destroy(thing,projectileLife);

            spawnPoint.rotation=Quaternion.Euler(0f, 270f, 0f);
            thing=Instantiate(bullet,spawnPoint);
            rb=thing.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.forward * projectileSpeed,ForceMode.Impulse);
            Destroy(thing,projectileLife);

            spawnPoint.rotation=Quaternion.Euler(0f, 315f, 0f);
            thing=Instantiate(bullet,spawnPoint);
            rb=thing.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.forward * projectileSpeed,ForceMode.Impulse);
            Destroy(thing,projectileLife);*/
        }

        
        
    }

    private Vector3 randomSpot()
    {
        nextX = Random.Range(moveDist*-1,moveDist);
        nextZ = Random.Range(moveDist*-1,moveDist);

        return new Vector3(nextX,transform.position.y,nextZ);
    }
}
