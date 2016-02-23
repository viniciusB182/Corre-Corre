using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public UnityEngine.UI.Text Pontos;
    public UnityEngine.UI.Text Recorde;

	// Use this for initialization
	void Start () {
        Pontos.text = PlayerPrefs.GetInt("Pontuacao").ToString();
        Recorde.text = PlayerPrefs.GetInt("Recorde").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
