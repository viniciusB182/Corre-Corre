using UnityEngine;
using System.Collections;

public class MoveOffSet : MonoBehaviour {

    private Material currentMaterial;
    public float     Speed;
    private float    OffSet;

	// Use this for initialization
	void Start () {
        currentMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        OffSet += Speed * Time.deltaTime;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(OffSet, 0));
	}
}
