using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacing : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject towerSpawned;
    [SerializeField] private Button putTowerButton;
    private bool alreadyPlaced;
    private int rot = 0;

    private void Start()
    {
        putTowerButton.onClick.AddListener(PutTower);
    }

    private void Update()
    {
        if (towerSpawned == null) return;

        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit _hit, 100f))
        {
            if (_hit.collider.gameObject.layer == LayerMask.NameToLayer("Placeabled"))
            {
                towerSpawned.transform.position = new Vector3(_hit.point.x, 0.05f, _hit.point.z);
                alreadyPlaced = false;

                Debug.Log("Pode colocar");
            }
            else
            {
                alreadyPlaced = true;
                Debug.Log("Nao pode colocar");
            }
        }

        if (Input.GetButtonDown("Fire1") && alreadyPlaced)
        {
            towerSpawned.GetComponent<TowerAttack>().canAttack = true;
            towerSpawned = null;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            rot += 90;
            towerSpawned.transform.rotation = Quaternion.Euler(0, rot, 0);
        }

        if (Input.GetKeyDown(KeyCode.X) && towerSpawned != null)
        {
            Destroy(towerSpawned);
            towerSpawned = null;
        }

    }

    private void PutTower()
    {
        towerSpawned = Instantiate(towerPrefab, Vector3.zero, Quaternion.identity);
    }
}