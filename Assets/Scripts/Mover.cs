using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public Rigidbody mRigidbody;
    public float mSpeed;

    // Use this for initialization
    void Start (){
        mRigidbody = GetComponent<Rigidbody>();

        mRigidbody.velocity = transform.forward * mSpeed;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
