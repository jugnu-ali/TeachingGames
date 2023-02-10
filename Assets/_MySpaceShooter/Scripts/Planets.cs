using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    public List<GameObject> planetList;
    [SerializeField] float speed;

    [SerializeField] int spawnDurationGap;

    int currentCount = 0;

    GameObject currentPlanet = null;

    // Start is called before the first frame update
    void Start()
    {
        //planetInGame = new List<GameObject>();
        InvokeRepeating("SpawnPlanet", 2, spawnDurationGap);
    }

    void SpawnPlanet()
    {
        if(currentCount < planetList.Count)
        {
            currentPlanet = Instantiate(planetList[currentCount]);
            ++currentCount;
            Destroy(currentPlanet, spawnDurationGap - 2);
        }
        else
        {
            CancelInvoke("SpawnPlanet");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPlanet != null)
        {
            currentPlanet.transform.Translate(-(Vector3.up * speed * Time.deltaTime));
        }
    }
}
