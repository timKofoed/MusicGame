using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject nodePrefab;

	public bool GameStarted = false;

    public float delay;

    void Start()
    {
        float i = 2.0f;
        StartCoroutine(startSpawn(i));
        StartCoroutine(startNormalSpawn(i));
    }

	void Update()
	{

        //SpawnNote();

	}
    

    void SpawnNote()
    {
        if (GameStarted == true)
        {

                //Vi er ved at lave en ny "node", så vi skal vælge hvor vi skal placere den
                float value = Random.value;         //Find en ny værdi mellem 0.0f og 1.0f
                int size = spawnPoints.Length - 1;    //(spawnPoints.Length - 1) fordi hvis vi har et array med en længde på 5, så er det sidste element nr. 4.

                //For at kunne bruge matematik korrekt på to tal, skal de begge være af samme type, hvilket i vores tilfælde er (float)
                float placementChoice = value * (float)size;    //"Typecast" vores "size", som er en (int) --> (float), så de begge er floats
                int choice = Mathf.RoundToInt(placementChoice);    //Afrund det valgte float-tal, til nærmeste hele tal, så vi kan bruge det i et array

                //Lav vores nye node på den valgte placering. Hvis dens animation er sat til at auto-spille (default), så burde den virke herfra
                GameObject.Instantiate(nodePrefab, spawnPoints[choice].transform.position, spawnPoints[choice].transform.rotation);
            
            
        }
    }

    IEnumerator startSpawn(float waitTime)
    {
        waitTime = 1.0f;
        yield return new WaitForSeconds(waitTime);
        SpawnNote();
        StartCoroutine(startSpawn(0));
    }

    IEnumerator startNormalSpawn(float waitTime)
    {
        waitTime = 1.5f;
        yield return new WaitForSeconds(waitTime);
        SpawnNote();
        StartCoroutine(startSpawn(0));
    }

}
