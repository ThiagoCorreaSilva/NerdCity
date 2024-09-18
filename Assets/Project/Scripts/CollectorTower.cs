using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorTower : TowerInfo
{
    [SerializeField] private Button woodPath;
    [SerializeField] private Button stonePath;
    [SerializeField] private GameObject updateInfo;

    [Header("Collector Variables")]
    [SerializeField] private int resourcerRate;
    [SerializeField] private int cycleTime;
    [SerializeField] private int path;
    private bool started;

    private void Start()
    {
        woodPath.onClick.AddListener(WoodPath);
        stonePath.onClick.AddListener(StonePath);

        updateInfo.SetActive(false);
    }

    private void Update()
    {
        if (started)
        {
            started = false;
            StartCoroutine(GiveResource());

            Debug.Log("Comecou a coletar");
        }
    }

    private void WoodPath()
    {
        started = true;
        path = 1;

        woodPath.gameObject.SetActive(false);
        stonePath.gameObject.SetActive(false);
        updateInfo.SetActive(true);
    }

    private void StonePath()
    {
        started = true;
        path = 2;

        woodPath.gameObject.SetActive(false);
        stonePath.gameObject.SetActive(false);
        updateInfo.SetActive(true);
    }

    private IEnumerator GiveResource()
    {
        if (path == 1)
            PlayerStatus.instance.AdddResource("Wood", resourcerRate);
        else
            PlayerStatus.instance.AdddResource("Stone", resourcerRate);

        yield return new WaitForSeconds(cycleTime);
        StartCoroutine(GiveResource());
    }
}