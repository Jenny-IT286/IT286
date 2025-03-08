using UnityEngine;

public class JimbusAudio : MonoBehaviour
{
    public AudioSource Jimbus;
    public float seconds = 7;
    private float timer = 0;
   
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= seconds)
        {
            Jimbus.Play();
            timer = 0;
        }
    }
}
