using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfo : MonoBehaviour
{
    [Header("Tower Variables")]
    [SerializeField] protected string towerName;
    [SerializeField] protected float towerDamage;
    [SerializeField] protected int towerLevel;
    [SerializeField] protected int maxTowerLevel;

    [Header("UI")]
    [SerializeField] protected GameObject infoMenu;
    [SerializeField] protected Button closeMenu;
    [SerializeField] protected TMP_Text towerNameTXT;
    [SerializeField] protected TMP_Text towerLevelTXT;
    [SerializeField] protected TMP_Text towerDamageTXT;
    [SerializeField] protected Image towerImage;
    protected Canvas canvas;
    private string[] text, text2;

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
        // APENAS PARA TESTAR O METODO LEVELUP
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Level aumentado");
            LevelUp();
        }
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
        towerDamage += Mathf.RoundToInt(towerDamage + 6 * 1.5f);

        towerLevelTXT.text = text[0] + " " + towerLevel.ToString();
        towerDamageTXT.text = text2[0] + " " + towerDamage.ToString();
    }
}