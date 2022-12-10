using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform EnemyPrefab;
    public Transform SpawnPoint;
    public TextMeshProUGUI WaveTimerText;
    public float TimeBetweenWaves = 5f;

    private float countdown = 5f;
    private int waveNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetWaveTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeBetweenWaves;
        }
        SetWaveTimerText();
    }

    private void SetWaveTimerText()
    {
        WaveTimerText.text = Mathf.Ceil(countdown).ToString();
    }

    private IEnumerator SpawnWave()
    {
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
