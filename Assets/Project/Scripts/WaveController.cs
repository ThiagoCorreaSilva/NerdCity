using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    public static WaveController instance;

    [Header("UI")]
    [SerializeField] private Button startWaveButton;
    [SerializeField] private TMP_Text waveText;
    private string[] text;

    [Header("Wave Variables")]
    [SerializeField] private GameObject enemyPreFab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int waveCount;
    [SerializeField] private int enemysSpawned;
    public int enemysDeaths;
    public int maxEnemys;
    public bool canStart;
    public bool waveIsActive;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startWaveButton.onClick.AddListener(StartWave);
        canStart = true;

        text = waveText.text.Split(';');
        waveText.text = text[0] + " " + waveCount;
    }

    private void Update()
    {
        if (enemysDeaths == maxEnemys && waveIsActive) WaveEnd();
    }

    private void StartWave()
    {
        if (!canStart) return;

        startWaveButton.gameObject.SetActive(false);

        waveIsActive = true;
        StartCoroutine(WaveSystem());
    }

    private IEnumerator WaveSystem()
    {
        if (enemysSpawned == maxEnemys) yield break;

        for (int i = 0; i < maxEnemys; i++)
        {
            GameObject _enemy = Instantiate(enemyPreFab, spawnPoint.position, Quaternion.identity);
            _enemy.GetComponent<EnemyIA>().speed = Random.Range(3, _enemy.GetComponent<EnemyIA>().maxSpeed);
            _enemy.GetComponent<EnemyIA>().maxLife = Random.Range(20, 100);

            enemysSpawned++;

            Debug.Log("Enemy Spawned");

            yield return new WaitForSeconds(Random.Range(0.2f, 1));
        }
    }

    public void WaveEnd()
    {
        startWaveButton.gameObject.SetActive(true);

        enemysSpawned = 0;
        enemysDeaths = 0;
        maxEnemys += 15;
        waveIsActive = false;

        waveCount++;
        waveText.text = text[0] + " " + waveCount;
    }
}