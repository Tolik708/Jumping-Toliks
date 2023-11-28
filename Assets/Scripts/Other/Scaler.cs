using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
	public GameObject[] objectsToScale;
	
    private void Awake()
    {
		// 720 / 1280 = 0.5625 default aspect ratio the game was designed for
		float diff = ((float)Screen.width / (float)Screen.height) / 0.5625f;
        for(int i = 0; i < objectsToScale.Length; i++)
		{
			objectsToScale[i].transform.localScale = new Vector3(objectsToScale[i].transform.localScale.x * diff, 
																objectsToScale[i].transform.localScale.y * diff, 1);
		}
    }
	
	#if UNITY_EDITOR || DYNAMIC_RESOLUTION
	// Set it from the start becuase first time it calls in Awake()
	private float lastDiff = ((float)Screen.width / (float)Screen.height) / 0.5625f;
	
	private void Update()
	{
		float diff = ((float)Screen.width / (float)Screen.height) / 0.5625f;
        for(int i = 0; i < objectsToScale.Length; i++)
			objectsToScale[i].transform.localScale = new Vector3((objectsToScale[i].transform.localScale.x / lastDiff) * diff, 
																(objectsToScale[i].transform.localScale.y / lastDiff) * diff, 1);
		lastDiff = diff;													
	}
	#endif
}
