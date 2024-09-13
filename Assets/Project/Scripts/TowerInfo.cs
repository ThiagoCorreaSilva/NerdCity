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
    private string[] text, text2;

    [Header("Tower Variables")]
    [SerializeField] private string towerName;
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
        towerNameTXT.text = towerName;

        text = towerLevelTXT.text.Split(';');
        towerLevelTXT.text = text[0] + " " + towerLevel.ToString();

        text2 = towerDamageTXT.text.Split(';');
        towerDamageTXT.text = text2[0] + " " + towerDamage.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) LevelUp();
    }

    private void OnMouseDown()
    {
        canvas.gameObject.SetActive(true);
        infoMenu.SetActive(true);
        Debug.Log("Clicado");
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
        towerDamage++;

        towerLevelTXT.text = text[0] + " " + towerLevel.ToString();
        towerDamageTXT.text = text2[0] + " " + towerDamage.ToString();
    }
}