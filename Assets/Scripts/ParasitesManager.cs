using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasitesManager : MonoBehaviour
{
    public List<GameObject> plants;
    public int minimumTimeNextRound;
    public int maxTimeNextRound;
    private int _randomTimeNextRound;
    private List<GameObject> randomPlantsList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(initializeListPlants());
    }

    IEnumerator TimeToWaitNextRound()
    {
        foreach(GameObject plant in plants)
        {
            yield return new WaitForSeconds(_randomTimeNextRound);
            //Debug.Log("prova");
            spawnParasites();
        }
        StartCoroutine(initializeListPlants());
    }

    void spawnParasites()
    {
        //Debug.Log("Spawn");
        randomPlantsList[Random.Range(0, plants.Count)].SetActive(false);
    }

    IEnumerator initializeListPlants()
    {
        while (randomPlantsList.Count < plants.Count)
        {
            int randomIndex = Random.Range(0, plants.Count);
            if (!randomPlantsList.Contains(plants[randomIndex]))
                randomPlantsList.Add(plants[randomIndex]);
        }

        //Debug.Log("lista: " + randomPlantsList[1]);
        _randomTimeNextRound = Random.Range(minimumTimeNextRound, maxTimeNextRound);
        //start coroutine
        yield return StartCoroutine("TimeToWaitNextRound");
    }
}
