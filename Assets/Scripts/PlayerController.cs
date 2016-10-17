using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

    public Rigidbody mRigidbody;
    public float mSpeed;
    public float mTilt;
    public Boundary mBoundary;

    public GameObject mShot;
    public Transform mShotSpawnTransform;
    public float mFireRate;
    private float mNextFire;
    
	// Use this for initialization
	void Start () {
        mRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > mNextFire){
            GameObject clone = Instantiate(mShot, mShotSpawnTransform.position, mShotSpawnTransform.rotation) as GameObject;
            mNextFire = Time.time + mFireRate;

            //Play Sound
            GetComponent<AudioSource>().Play();
        }
	}

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal") * mSpeed;
        float moveVertical = Input.GetAxis("Vertical") * mSpeed;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        mRigidbody.velocity = movement;

        mRigidbody.position = new Vector3(
            Mathf.Clamp(mRigidbody.position.x, mBoundary.xMin, mBoundary.xMax), 
            0, 
            Mathf.Clamp(mRigidbody.position.z, mBoundary.zMin, mBoundary.zMax));

        mRigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, mRigidbody.velocity.x * -mTilt);
    }
}

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
