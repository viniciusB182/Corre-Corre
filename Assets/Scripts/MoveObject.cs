using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

    public float Speed;
    private float x;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        x = transform.position.x;
        x += Speed * Time.deltaTime;

        transform.position = new Vector3(x, transform.position.y);

        if(x <= -7)
        {
            Destroy(transform.gameObject);
        }
	}
}
