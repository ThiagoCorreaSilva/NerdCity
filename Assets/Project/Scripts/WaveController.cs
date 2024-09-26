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
    [SerializeField] private Transform enemysStorage;
    [SerializeField] private int waveCount;
    [SerializeField] private int enemysSpawned;
    public int enemysDeaths;
    public int maxEnemys;
    public bool canStart;
    public bool waveIsActive;
    private int enemysToPause;
    private CollectorTower collectorTower;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        enemysToPause = Random.Range(5, 10);
        canStart = true;

        startWaveButton.onClick.AddListener(StartWave);

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

        if (collectorTower == null) FindObjectOfType<CollectorTower>();

        collectorTower.started = true;
        StartCoroutine(WaveSystem());
    }

    private IEnumerator WaveSystem()
    {
        if (enemysSpawned == maxEnemys) yield break;

        for (int i = 0; i < maxEnemys; i++)
        {
            if (enemysSpawned == enemysToPause)
            {
                Debug.Log("Pausa no spawn");

                enemysToPause += Random.Range(4, 10);
                yield return new WaitForSeconds(4);
            }

            GameObject _enemy = Instantiate(enemyPreFab, spawnPoint.position, Quaternion.identity);

            _enemy.transform.parent = enemysStorage;
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
        if (collectorTower != null) StopCoroutine(collectorTower.GiveResource());

        enemysSpawned = 0;
        enemysDeaths = 0;
        maxEnemys += Random.Range(5, 10);
        waveIsActive = false;

        waveCount++;
        waveText.text = text[0] + " " + waveCount;
    }
}