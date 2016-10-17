using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

    public float mMaxTumble;
    private Rigidbody mRigidbody;

	// Use this for initialization
	void Start (){
        mRigidbody = GetComponent<Rigidbody>();
        mRigidbody.angularVelocity = Random.insideUnitSphere * mMaxTumble; //random Vector3 value
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
