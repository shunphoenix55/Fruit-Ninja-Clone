using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[DefaultExecutionOrder(-1)]
public class ClassicGameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text missesText;

    public float maxComboInterval = 1f;

    [Header("Fruits")]
    public GameObject fruitObject;

    public float minYVelocity = 5f; 
    public float maxYVelocity = 10f;

    public float minXVelocity = 0.5f;
    public float maxXVelocity = 2f;

    [Header("Wave")]
    public float waveInterval = 1f;
    public Transform[] spawnBounds;

    public int lineWaveCountMin = 2;
    public int lineWaveCountMax = 5;

    public int continuousWaveCountMin = 6;
    public int continuousWaveCountMax = 10;


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
    private int _misses = 0;
    public int Misses { get { return _misses; }
        set
        {
            if (value < 0)
            {
                _misses = 0;
            }
            else if (value >= 3)
            {
                Time.timeScale = 0;
            }
            else
            {
                _misses = value;
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
            float random = Random.Range(0f, 2f);
            //Debug.Log("Random: " + random);
            if (random <= 1f)
                yield return StartCoroutine(LineWave());
            else if (random <= 2f)
            yield return StartCoroutine(ContinuousWave());

            yield return new WaitForSeconds(waveInterval);
        }
    }

    IEnumerator LineWave()
    {
        for (int i = 0; i < (int)Random.Range(lineWaveCountMin, lineWaveCountMax); i++)
        {
            SpawnFruit();
        } 
        yield return null;
    }

    IEnumerator ContinuousWave()
    {
        for (int i = 0; i < (int)Random.Range(continuousWaveCountMin, continuousWaveCountMax); i++)
        {
            SpawnFruit();
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }

    public void SpawnFruit()
    {
        float spawnX = Random.Range(spawnBounds[0].position.x, spawnBounds[1].position.x);
        GameObject fruit = ObjectPooler.SharedInstance.GetPooledObject(fruitObject.name);
        fruit.SetActive(true);
        fruit.transform.position = new Vector3(spawnX, spawnBounds[0].position.y, spawnBounds[0].position.z);
        Rigidbody fruitRB = fruit.GetComponent<Rigidbody>();

        float fruitXVelocity = Random.Range(maxXVelocity, maxXVelocity);
        float fruitYVelocity = Random.Range(minYVelocity, maxYVelocity);

        Vector3 fruitVelocity = new(maxXVelocity, maxYVelocity, 0);
        fruitRB.velocity = fruitVelocity;
    }

    public void DestroyOutOfBounds(GameObject gameObject)
    {
        gameObject.SetActive(false);
        Misses += 1;
        missesText.text = Misses.ToString();
    }
    
}
