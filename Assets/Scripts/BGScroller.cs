using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

    public float mScrollSpeed;
    public float mTileLengthZ;
    private Vector3 mStartPosition;

	// Use this for initialization
	void Start () {
        mStartPosition = transform.position; //initial start position 
	}
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * mScrollSpeed, mTileLengthZ);
        transform.position = mStartPosition + Vector3.forward * newPosition;
	}
}
