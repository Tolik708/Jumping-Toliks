using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnBuild : MonoBehaviour
{
    void Awake()
    {
        #if !UNITY_EDITOR
		Destroy(gameObject);
		#endif
    }
}
