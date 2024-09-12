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
    private bool isUnlocked;
    private bool haveTower;

    [Header("Place Variables")]
    [SerializeField] private int unlockPrice;

    private void Start()
    {
        towersMenu.SetActive(false);
        unlockTowerPopUp.SetActive(false);

        unlockTowerButton.onClick.AddListener(UnlockTower);
        closeTowerMenu.onClick.AddListener(() => towersMenu.SetActive(false));
        closeUnlockMenu.onClick.AddListener(() => unlockTowerPopUp.SetActive(false));

        unlockPriceTXT.text = "To unlock this place you need: " + unlockPrice + " souls";

        foreach (Button _button in attackTowers.GetComponentsInChildren<Button>())
        {
            _button.onClick.AddListener(() => BuyTower(_button.GetComponent<ButtonTower>().towerPrefab, _button.GetComponent<ButtonTower>().towerPrice));
        }
    }

    private void Update()
    {
        if (haveTower) return;

        if (Input.GetButtonDown("Fire1"))
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out RaycastHit _hit, 1000f))
            {
                if (_hit.collider.gameObject.layer == LayerMask.NameToLayer("Placeabled"))
                {
                    Debug.Log("Colisao");

                    if (!isUnlocked)
                    {
                        towersMenu.SetActive(false);
                        unlockTowerPopUp.SetActive(true);
                    }

                    else towersMenu.SetActive(true);
                }
            }
        }
    }

    private void UnlockTower()
    {
        isUnlocked = true;
        unlockTowerPopUp.SetActive(false);
        towersMenu.SetActive(true);
    }

    private void BuyTower(GameObject _tower, int _price)
    {
        Debug.Log("Price is: " + _price + "tower is: " + _tower.name);
        towersMenu.SetActive(false);

        Instantiate(_tower, towerPos.position, Quaternion.identity);
        haveTower = true;
    }
}