using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AdaliseGame : MonoBehaviour
{
    public GameObject edrelin;

    public GameObject adaliseGMB;
    public Vector3 adaliseSpawnPosition;

    public TextMeshPro scoreMesh;
    public TextMeshPro highscoreMesh;

    int score;
    int highscore;

    GameObject adalise;


    List<GameObject> edrelinList = new List<GameObject>();

    #region instance
    public static AdaliseGame instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    void OnEnable()
    {
        RestartGame();
    }

    void OnDisable()
    {
        EndGame();
    }
    
    public void Finish()
    {
        EndGame();
        RestartGame();
    }

    public void RestartGame()
    {
        score = -1;
        StartCoroutine(ScoreUpdate());
        adalise = Instantiate(adaliseGMB, adaliseSpawnPosition, Quaternion.identity);
    }

    void EndGame()
    {
        StopAllCoroutines();
        HighscoreUpdate();
        foreach (GameObject e in edrelinList) Destroy(e);
        Destroy(adalise);
    }

    void HighscoreUpdate()
    {
        if (highscore > score) return;

        highscore = score;
        highscoreMesh.text = "Best : " + highscore.ToString();
    }



    void CreateEdrelin()
    {
        GameObject e = Instantiate(edrelin, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        e.transform.position += new Vector3(0, 0, 11);
        edrelinList.Add(e);
    }

    IEnumerator ScoreUpdate()
    {
        score++;
        scoreMesh.text = score.ToString();
        yield return new WaitForSeconds(1f);
        StartCoroutine(ScoreUpdate());
    }

    void OnMouseDown()
    {
        CreateEdrelin();
    }
}
