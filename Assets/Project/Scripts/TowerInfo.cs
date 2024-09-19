using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    protected string[] text, text2;

    private void Awake()
    {
       canvas = GetComponentInChildren<Canvas>(); 
    }

    protected virtual void Start()
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

    protected virtual void Update()
    {
        // APENAS PARA TESTAR O METODO LEVELUP
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Level aumentado");
            LevelUp();
        }

        if (Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject() && canvas.gameObject.activeSelf)
        {
            canvas.gameObject.SetActive(false);
            Debug.Log("Fora de um objeto");
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