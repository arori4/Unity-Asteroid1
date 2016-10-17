using UnityEngine;
using System.Collections;

public class EnemyWeaponController : MonoBehaviour {

    public GameObject mShot;
    public Transform mShotSpawnTransform;
    public float mDelay;
    public float mFireRate;

    private AudioSource mAudioSource;

	// Use this for initialization
	void Start () {
        mAudioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", mDelay, mFireRate); //repetitively invoke a function
        //TODO: fireRate is random range
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Fire() {
        Instantiate(mShot, mShotSpawnTransform.position, mShotSpawnTransform.rotation);
        mAudioSource.Play();
    }
}
