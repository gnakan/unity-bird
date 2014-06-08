using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	int numBGPanels = 6; //Number of background image tiles

	void OnTriggerEnter2D(Collider2D collider){


		//looping the background
		float widthOfBGObject = ((BoxCollider2D)collider).size.x;
		Vector3 pos = collider.transform.position;
		pos.x += widthOfBGObject * numBGPanels - widthOfBGObject/2f; //helps adjust the spacing the background
		collider.transform.position = pos;
	}
}
