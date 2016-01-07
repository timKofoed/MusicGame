using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

    [SerializeField]
    private GameObject colaBottlePrefab;

    [SerializeField]
    private GameObject colaBubblePrefab;

    public float spawnProbability = 0.2f;
    public float spawnInterval = 1.4f;

    // Use this for initialization
    void Start ()
    {
        StartSpawning(spawnProbability, spawnInterval);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void StartSpawning(float spawnProbability, float spawnInterval)
    {
        StartCoroutine(SpawnBubblesContinuously(spawnProbability, spawnInterval));
    }

    private IEnumerator SpawnBubblesContinuously(float probablility, float interval)
    {
        bool stopLoop = false;
        while (!stopLoop)
        {
            // Spawn a prefab in the permitted range [-20..70]
            float newX = Random.Range(-20.0f, 70.0f);
            Vector3 newPos = new Vector3(newX, 0.0f, 0.0f);

            if(Random.Range(0.0f, 1.0f) < probablility)
            {
                GameObject newBubble;
                newBubble = GameObject.Instantiate(colaBubblePrefab, newPos, Quaternion.identity) as GameObject;
            }
                

            // wait
            yield return new WaitForSeconds(interval);

            // repeat
        }

    }
}
