using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject mExplosion;
    public GameObject mPlayerExplosion;
    public GameObject mExplosionLight;
    public int mScoreValue;

    private GameController mGameController;

    void Start() {
        GameObject obj = GameObject.FindWithTag("GameController"); //find first game object with tag 
        if (obj != null) {
            mGameController = obj.GetComponent<GameController>();
        } 
        else {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("GameBoundary") || other.CompareTag("Enemy")) {
            return;
        }
        if (other.CompareTag("Player")){
            Instantiate(mPlayerExplosion, transform.position, transform.rotation);
            mGameController.gameOver();
        }
        if (other.tag == "Bolt") {
            mGameController.addScore(mScoreValue);            
        }

        Destroy(other.gameObject);
        Destroy(gameObject);//destroy self

        //finally create explosion
        if (mExplosion != null) {
            Instantiate(mExplosion, transform.position, transform.rotation);
            Instantiate(mExplosionLight, transform.position, transform.rotation);
        }
    }


}
