using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject toSpawn;
    public int limit;
    public int spawnRate = 10;
    private int timer=0;
    public int min = -10;
    public int max =10;
    private int c;

    public int delay = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        c=0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time >= delay && c < limit && Time.time >= timer)
        {
            Instantiate(toSpawn,new Vector3(Random.Range(min,max),2,Random.Range(min,max)), Quaternion.Euler(0f, 0f, 0f)).name="Shooting Star Clone " + (c+1);
            c++;
            timer+=spawnRate;
        }
    }
}
