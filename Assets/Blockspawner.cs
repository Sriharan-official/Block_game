using UnityEngine;

public class Blockspawner : MonoBehaviour
{
    public Transform[] spawnpoint;
    public GameObject blockprefab;
    private float timetospawn = 2f;
    public float timebtwspawn = 3f;
    public float mintime = 1f;
    public float decreasetime  = 0.25f;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timetospawn)
        {
            Spawnblock();
            timetospawn = Time.time + timebtwspawn;
            if(timebtwspawn > mintime)
            {
                timebtwspawn -= decreasetime; 
            }

        }

    }
    
    void Spawnblock()
    {
        int randomIndex = Random.Range(0, spawnpoint.Length);

        for (int x = 0; x < spawnpoint.Length; x++)
        {
            if (randomIndex != x)
            {
                Instantiate(blockprefab, spawnpoint[x].position, Quaternion.identity);
            }
        }
    }
}
