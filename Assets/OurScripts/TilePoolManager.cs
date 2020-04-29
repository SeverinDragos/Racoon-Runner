using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePoolManager : MonoBehaviour
{
    private enum INDEXES : int
    {
        NO_REWARD_IND,
        REWARD_IND,
        PERK_IND,

        NR_OF_ELEMS
    };

    private enum PROBABILITIES : int
    {
        NO_REWARD_PROB = 20,
        REWARD_PROB = 30,
        PERK_PROB = 20
    };

    // Tiles lists filled from within Unity
    public GameObject[] noRewardRoads;
    public GameObject[] rewardRoads;
    public GameObject[] perkRoads;

    private List<List<GameObject>> allTiles;
    private Queue<GameObject> activeTiles;


    private int[] probTreshold = new int[] {
        (int)PROBABILITIES.NO_REWARD_PROB,
        (int)PROBABILITIES.NO_REWARD_PROB
            + (int)PROBABILITIES.REWARD_PROB,
        (int)PROBABILITIES.NO_REWARD_PROB
            + (int)PROBABILITIES.REWARD_PROB
            + (int)PROBABILITIES.PERK_PROB
    };

    private Transform playerTransform;
    private float spawnZ = -9.0f;
    private float tileLength = 9.0f;
    private int amnTilesOnScreen = 7;
    private float safeZone = 15.0f;
    private int initialBlankRoads = 4;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        allTiles = new List<List<GameObject>>();
        InitiateTiles();

        activeTiles = new Queue<GameObject>();

        for (int i = 0; i < initialBlankRoads; i ++)
        {
            SpawnTile(true);
        }

        for (int i = initialBlankRoads; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > spawnZ - amnTilesOnScreen * tileLength)
        {
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(bool emptyTile = false)
    {
        GameObject go;
        if(emptyTile)
        {
            go = Instantiate(noRewardRoads[0]) as GameObject;
            go.transform.SetParent(transform);
        }
        else
        {
            Pair<int, int> randIndex = GetRandomIndex();
            go = allTiles[randIndex.First][randIndex.Second];
            while (go.activeSelf)
            {
                randIndex = GetRandomIndex();
                go = allTiles[randIndex.First][randIndex.Second];
                Debug.Log("Did it for " + randIndex.First.ToString() + " and " + randIndex.Second.ToString());
            }
        }
        
        go.transform.position = Vector3.forward * spawnZ;
        go.SetActive(true);

        spawnZ += tileLength;
        activeTiles.Enqueue(go);
    }
    
    private void DeleteTile()
    {
        GameObject popped = activeTiles.Dequeue();
        popped.SetActive(false);
    }

    private Pair<int, int> GetRandomIndex()
    {
        int collectionIndex = 0, elementIndex;
        int rand = Random.Range(1, 100);

        // Pick the index amoung the probabilities intervals
        for (int ind = 0; ind < probTreshold.Length; ind ++)
        {
            if(rand  <= probTreshold[ind])
            {
                collectionIndex = ind;
                break;
            }
        }
        elementIndex = Random.Range(1, allTiles[collectionIndex].Count) - 1;
        
        return new Pair<int, int>(collectionIndex, elementIndex);
    }

    private void DeactivateList(List<GameObject> objectList)
    {
        for (int ind = 0; ind < objectList.Count; ind ++)
        {
            objectList[ind].SetActive(false);
            objectList[ind].transform.SetParent(transform);
        }
    }

    private void InitiateTiles()
    {
        int index = 0;
        allTiles.Add(new List<GameObject>());
        foreach (GameObject go in noRewardRoads)
        {
            allTiles[index].Add(Instantiate(go));
        }
        DeactivateList(allTiles[index]);

        index += 1;
        allTiles.Add(new List<GameObject>());
        foreach (GameObject go in rewardRoads)
        {
            allTiles[index].Add(Instantiate(go));
        }
        DeactivateList(allTiles[index]);

        index += 1;
        allTiles.Add(new List<GameObject>());
        foreach (GameObject go in perkRoads)
        {
            allTiles[index].Add(Instantiate(go));
        }
        DeactivateList(allTiles[index]);
    }

}

public class Pair<T, U>
{
    public T First { get; set; }
    public U Second { get; set; }

    public Pair() {}

    public Pair(T first, U second)
    {
        this.First = first;
        this.Second = second;
    }

}