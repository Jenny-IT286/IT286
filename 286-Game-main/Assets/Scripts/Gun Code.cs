using UnityEngine;

public class GunCode : MonoBehaviour
{
    public GameObject bullet;
    public float projectileSpeed = 100f;
    public Transform spawnPoint;
    public int projectileLife = 10;
    public float fireRate=10f;
    private float nextFire=0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Z) && Time.time >= nextFire) 
        {
            spawnPoint.rotation=Quaternion.Euler(0f, 0f, 0f);
            GameObject thing=Instantiate(bullet,spawnPoint);
            Rigidbody rb = thing.GetComponent<Rigidbody>();
            thing.transform.SetParent(null);
            rb.AddForce(spawnPoint.forward * projectileSpeed, ForceMode.Impulse);
            Destroy(thing,projectileLife);
            nextFire=Time.time+fireRate;
            
        }
    }
}
