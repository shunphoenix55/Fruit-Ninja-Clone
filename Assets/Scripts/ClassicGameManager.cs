using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[DefaultExecutionOrder(-1)]
public class ClassicGameManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public float maxComboInterval = 1f;

    [Header("Wave")]
    public float waveInterval = 1f;
    public Transform[] spawnBounds;
    public int singleWaveCount;

    public int continuousWaveCount;


    private int _score;
    public int Score { get { return _score; }
        set
        {
            if (value <0)
            {
                _score = 0;
            }
            else
            {
                _score = value;
            }
        }
    }
    private int comboCounter;
    private float comboTimer;

    // Make singleton
    public static ClassicGameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private void Update()
    {
        #region combos
        comboTimer += Time.deltaTime;
        if (comboTimer > maxComboInterval)
        {
            FinishCombo();
        }
        #endregion
    }

    public void UpdateScore(int val)
    {
        Score += val;
        scoreText.text = Score.ToString();
    }

    public void UpdateCombo()
    {
        if (comboCounter == 0)
        {
            comboCounter++;
            comboTimer = 0f;
        }

        else if (comboTimer <= maxComboInterval)
        {
            comboCounter++;
        }

    }

    public void FinishCombo()
    {
        if (comboCounter >= 3)
        {
            UpdateScore(comboCounter);
        }
        comboCounter = 0;
        comboTimer = 0f;
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            //StartCoroutine(SingleWave());
            yield return new WaitForSeconds(waveInterval);
        }
    }

    IEnumerator SingleWave()
    {
        float spawnX = Random.Range(spawnBounds[0].position.x, spawnBounds[1].position.x);
        for (int i = 0; i < singleWaveCount; i++)
        {

        } 
        yield return null;
    }

    
}
