using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{

    public GameObject BarrierPreFab; //Objeto a ser spawnado
    public float RateSpawn;     //Intervalo de Spawn
    public float CurrentTime;
    private int Position;
    private float y;

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
                y = -0.19f;
            }
            else
            {
                y = -0.81f;
            }

            CurrentTime = 0;
            GameObject tempPrefab = Instantiate(BarrierPreFab) as GameObject;
            tempPrefab.transform.position = new Vector3(transform.position.x, y);

        }
    }
}
