using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacing : MonoBehaviour
{
    [Header("UI Variables")]
    [SerializeField] private GameObject towersMenu;
    [SerializeField] private GameObject unlockTowerPopUp;
    [SerializeField] private GameObject attackTowers;
    [SerializeField] private Transform towerPos;
    [SerializeField] private TMP_Text unlockPriceTXT;
    [SerializeField] private Button unlockTowerButton;
    [SerializeField] private Button closeUnlockMenu;
    [SerializeField] private Button closeTowerMenu;
    private Canvas canvas;
    private bool isUnlocked;
    private bool haveTower;

    [Header("Place Variables")]
    [SerializeField] private int unlockPrice;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();

    }

    private void Start()
    {
        canvas.gameObject.SetActive(false);
        towersMenu.SetActive(false);
        unlockTowerPopUp.SetActive(false);

        unlockTowerButton.onClick.AddListener(UnlockTower);
        closeTowerMenu.onClick.AddListener(() => towersMenu.SetActive(false));
        closeUnlockMenu.onClick.AddListener(() => unlockTowerPopUp.SetActive(false));

        foreach (Button _button in attackTowers.GetComponentsInChildren<Button>())
        {
            _button.onClick.AddListener(() => BuyTower(_button.GetComponent<ButtonTower>().towerPrefab, _button.GetComponent<ButtonTower>().towerPrice));
        }
    }

    private void OnMouseDown()
    {
        if (haveTower) return;

        canvas.gameObject.SetActive(true);

        if (!isUnlocked)
        {
            unlockPriceTXT.text = "To unlock this place you need: " + unlockPrice + " souls";
            unlockTowerPopUp.SetActive(true);
        }
        else
        {
            towersMenu.SetActive(true);
        }
    }

    private void UnlockTower()
    {
        PlayerStatus.instance.RemoveSouls(unlockPrice);

        unlockTowerPopUp.SetActive(false);
        towersMenu.SetActive(true);
        isUnlocked = true;

        Debug.Log("Lugar desbloqueada");
    }

    private void BuyTower(GameObject _tower, int _price)
    {
        Debug.Log("Price is: " + _price + "tower is: " + _tower.name);
        towersMenu.SetActive(false);

        Instantiate(_tower, new Vector3(towerPos.position.x, towerPos.position.y + 0.5f, towerPos.position.z), Quaternion.identity);
        haveTower = true;
    }
}