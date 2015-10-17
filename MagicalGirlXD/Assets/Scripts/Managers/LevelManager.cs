using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization

    public PointOfInterest[] poi;
    GameObject player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        LoadLevel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void LoadLevel()
    {
       
    }
}
