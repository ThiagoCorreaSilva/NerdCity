using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfo : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject infoMenu;
    [SerializeField] private Button closeMenu;
    [SerializeField] private TMP_Text towerNameTXT;
    [SerializeField] private TMP_Text towerLevelTXT;
    [SerializeField] private TMP_Text towerDamageTXT;
    [SerializeField] private Image towerImage;
    private Canvas canvas;

    [Header("Tower Variables")]
    [SerializeField] private float towerDamage;
    [SerializeField] private int towerLevel;
    [SerializeField] private int maxTowerLevel;

    private void Awake()
    {
       canvas = GetComponentInChildren<Canvas>(); 
    }

    private void Start()
    {
        canvas.gameObject.SetActive(false);
        infoMenu.SetActive(false);
        closeMenu.onClick.AddListener(CloseUI);

        towerNameTXT.text = gameObject.name;
        towerLevelTXT.text = towerLevel.ToString();
        towerDamageTXT.text = towerDamage.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) LevelUp();
    }

    private void OnMouseDown()
    {
        canvas.gameObject.SetActive(true);
    }

    private void CloseUI()
    {
        canvas.gameObject.SetActive(false);
        infoMenu.SetActive(false);
    }

    protected virtual void LevelUp()
    {
        if (towerLevel == maxTowerLevel) return;

        towerLevel++;

        string[] _text = towerLevelTXT.text.Split(';');
        towerLevelTXT.text = _text + towerLevel.ToString();
    }
}