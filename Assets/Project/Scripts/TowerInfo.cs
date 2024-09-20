using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerInfo : MonoBehaviour
{
    [Header("Tower Variables")]
    [SerializeField] protected GameObject[] nextLevelObject;
    [SerializeField] protected string towerName;
    [SerializeField] protected string resourceType;
    [SerializeField] protected float towerDamage;
    [SerializeField] protected int towerLevel;
    [SerializeField] protected int maxTowerLevel;
    protected int levelRequires;

    [Header("UI")]
    [SerializeField] protected GameObject infoMenu;
    [SerializeField] protected GameObject levelUpMenu;
    [SerializeField] protected Button closeMenu;
    [SerializeField] protected Button levelUp;
    [SerializeField] protected TMP_Text towerNameTXT;
    [SerializeField] protected TMP_Text towerLevelTXT;
    [SerializeField] protected TMP_Text towerDamageTXT;
    [SerializeField] protected TMP_Text levelUpRequiresTXT;
    [SerializeField] protected TMP_Text updateInfoTXT;
    [SerializeField] protected Image towerImage;
    protected Canvas canvas;
    protected string[] text, text2;

    protected virtual void Awake()
    {
       canvas = GetComponentInChildren<Canvas>(); 
    }

    protected virtual void Start()
    {
        levelUpMenu.SetActive(false);
        canvas.gameObject.SetActive(false);
        infoMenu.SetActive(false);

        closeMenu.onClick.AddListener(CloseUI);
        levelUp.onClick.AddListener(LevelUp);

        towerNameTXT.text = gameObject.name;
        towerNameTXT.text = towerName;

        levelRequires = Random.Range(5, 20);
        levelUpRequiresTXT.text = levelRequires.ToString();

        text = towerLevelTXT.text.Split(';');
        towerLevelTXT.text = text[0] + " " + towerLevel.ToString();

        text2 = towerDamageTXT.text.Split(';');
        towerDamageTXT.text = text2[0] + " " + towerDamage.ToString();

        updateInfoTXT.text = Mathf.RoundToInt(towerDamage + 6 * 1.5f).ToString() + " more damage in the next level";
    }

    protected virtual void Update()
    {
        if (WaveController.instance.waveIsActive) CloseUI();
    }

    protected virtual void OnMouseDown()
    {
        canvas.gameObject.SetActive(true);
        infoMenu.SetActive(true);
        levelUpMenu.SetActive(true);

        Debug.Log("Clicado");
    }

    private void CloseUI()
    {
        canvas.gameObject.SetActive(false);
        infoMenu.SetActive(false);
    }

    protected virtual void LevelUp()
    {
        if (towerLevel > maxTowerLevel)
        {
            towerLevelTXT.text = "MAX LEVEL";
            levelUpMenu.SetActive(false);

            return;
        }

        if (PlayerStatus.instance.playerResouces[resourceType] - levelRequires < 0) return;

        towerLevel++;

        towerDamage += Mathf.RoundToInt(towerDamage + 6 * 1.5f);
        updateInfoTXT.text = Mathf.RoundToInt(towerDamage + 6 * 1.5f).ToString() + " more damage in the next level";

        towerLevelTXT.text = text[0] + " " + towerLevel.ToString();
        towerDamageTXT.text = text2[0] + " " + towerDamage.ToString();

        levelRequires += Mathf.RoundToInt(levelRequires + (levelRequires * 1.64f) * 1.45f);
        levelUpRequiresTXT.text = levelRequires.ToString();

        PlayerStatus.instance.RemoveResource(resourceType, levelRequires);
    }
}