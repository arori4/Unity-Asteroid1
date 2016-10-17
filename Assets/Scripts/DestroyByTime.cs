using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float mLifeTime;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, mLifeTime);
	}
}
