using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorTower : TowerInfo
{
    [SerializeField] private Button woodPath;
    [SerializeField] private Button stonePath;

    [Header("Collector Variables")]
    [SerializeField] private int resourcerRate;
    [SerializeField] private int cycleTime;
    [SerializeField] private int path;
    private bool started;

    protected override void Start()
    {
        base.Start();

        woodPath.onClick.AddListener(WoodPath);
        stonePath.onClick.AddListener(StonePath);
    }

    protected override void Update()
    {
        base.Update();

        if (started)
        {
            started = false;
            levelUpMenu.SetActive(true);

            StartCoroutine(GiveResource());

            Debug.Log("Comecou a coletar");
        }
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        levelUpMenu.SetActive(false);
    }

    private void WoodPath()
    {
        started = true;
        path = 1;
        resourceType = "Wood";

        woodPath.gameObject.SetActive(false);
        stonePath.gameObject.SetActive(false);
    }

    private void StonePath()
    {
        started = true;
        path = 2;
        resourceType = "Stone";

        woodPath.gameObject.SetActive(false);
        stonePath.gameObject.SetActive(false);
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

    protected override void LevelUp()
    {
        if (towerLevel > maxTowerLevel)
        {
            towerLevelTXT.text = "MAX LEVEL";
            levelUpMenu.SetActive(false);

            return;
        }

        if (PlayerStatus.instance.playerResouces[resourceType] - levelRequires < 0) return;

        towerLevel++;
        towerLevelTXT.text = text[0] + " " + towerLevel.ToString();

        levelRequires = Mathf.RoundToInt(levelRequires + (levelRequires * 2.54f) * 3.65f);
        levelUpRequiresTXT.text = levelRequires.ToString();

        PlayerStatus.instance.RemoveResource(resourceType, levelRequires);
        resourcerRate = Mathf.RoundToInt(resourcerRate * 2.48f);
    }
}