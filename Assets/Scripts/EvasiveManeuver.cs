using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour {

    public Vector2 mStartWait; //why use vector2? make it a range, already data structure with 2 vars
    public float mDodge;
    public Vector2 mManeuverTime;
    public Vector2 mManeuverWait;
    public float mSmoothing;
    public Boundary mBoundary;
    public float mTilt;

    private float mTargetManeuver;
    private Rigidbody mRigidbody;
    private float mCurrentSpeed;

	void Start () {
        mRigidbody = GetComponent<Rigidbody>();
        mCurrentSpeed = mRigidbody.velocity.z;
        StartCoroutine(Evade ());
	}
	
    IEnumerator Evade() {
        //set a target value on x axis
        //and move over to it slowly
        yield return new WaitForSeconds(Random.Range(mStartWait.x, mStartWait.y));

        while (true) {
            mTargetManeuver = Random.Range(1, mDodge) * -Mathf.Sign(transform.position.x); //dodge, going left if on right side (opposite)
            yield return new WaitForSeconds(Random.Range(mManeuverTime.x, mManeuverTime.y));
            mTargetManeuver = 0; //move straight
            yield return new WaitForSeconds(Random.Range(mManeuverWait.x, mManeuverWait.y));
        }

    }

	void FixedUpdate () {
        float newManeuver = Mathf.MoveTowards(mRigidbody.velocity.x, mTargetManeuver, Time.deltaTime * mSmoothing);
        mRigidbody.velocity = new Vector3(newManeuver, 0.0f, mCurrentSpeed);

        //clamp inside bounds
        mRigidbody.position = new Vector3(
            Mathf.Clamp(mRigidbody.position.x, mBoundary.xMin, mBoundary.xMax),
            0,
            Mathf.Clamp(mRigidbody.position.z, mBoundary.zMin, mBoundary.zMax)
        );

        mRigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, mRigidbody.velocity.x * -mTilt);

        //clamp rigidbody position inside screen
    }
}
