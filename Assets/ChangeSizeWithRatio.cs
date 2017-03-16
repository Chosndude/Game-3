using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSizeWithRatio : MonoBehaviour {

	// Use this for initialization
	void Start () {
            float height = Camera.main.orthographicSize * 2.0f;
            float width = height * Screen.width / Screen.height;
            transform.localScale = new Vector3(width/20, height/10, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
