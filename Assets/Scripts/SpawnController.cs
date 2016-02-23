using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{

    public GameObject              BarrierPreFab; //Objeto a ser spawnado
    public float                   RateSpawn;     //Intervalo de Spawn
    private float                  CurrentTime;
    private int                    Position;
    private float                  y;
    public float                   posA;
    public float                   posB;

    // Use this for initialization
    void Start()
    {
        CurrentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
        if (CurrentTime >= RateSpawn)
        {
            Position = Random.Range(1, 100);

            if (Position > 50)
            {
                y = posA;
            }
            else
            {
                y = posB;
                
            }

            CurrentTime = 0;
            GameObject tempPrefab = Instantiate(BarrierPreFab) as GameObject;
            tempPrefab.transform.position = new Vector3(transform.position.x, y);

        }
    }
}
