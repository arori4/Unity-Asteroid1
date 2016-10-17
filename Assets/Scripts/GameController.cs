using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] mHazards;
    public Vector3 mSpawnValues;
    public int mHazardCount;
    public float mSpawnWait;
    public float mStartWait;
    public float mWaveWait;

    //UI Elements
    public UnityEngine.UI.Text mScoreText;
    public UnityEngine.UI.Text mRestartText;
    public UnityEngine.UI.Text mGameOverText;
    private int mScore;
    private bool mGameOver;
    private bool mRestart;

    // Use this for initialization
    void Start() {
        StartCoroutine (SpawnWaves());

        //Set score
        mScore = 0;
        UpdateScore();

        //Set flags and text for restart
        mGameOver = false;
        mRestart = false;
        mRestartText.text = "";
        mGameOverText.text = "";
    }

    // Update is called once per frame
    void Update() {
        if (mRestart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    //Coroutine
    IEnumerator SpawnWaves() {

        yield return new WaitForSeconds(mStartWait); //pause

        while (true) {
            for (int i = 0; i < mHazardCount; i++) {
                //Choose a random hazard
                GameObject hazard = mHazards[Random.Range(0, mHazards.Length)];

                Vector3 spawnPosition = new Vector3(Random.Range(-mSpawnValues.x, mSpawnValues.x), mSpawnValues.y, mSpawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(mSpawnWait);
            }

            yield return new WaitForSeconds(mWaveWait); //pause

            if (mGameOver) {
                mRestartText.text = "Press 'R' for Restart";
                mRestart = true;
                break;
            }
        }
    }

    public void addScore(int newScoreValue){
        mScore += newScoreValue;
        UpdateScore();
    }

    void UpdateScore() {
        mScoreText.text = "Score: " + mScore;
    }

    public void gameOver() {
        mGameOverText.text = "Game Over";
        mGameOver = true;
    }
}
