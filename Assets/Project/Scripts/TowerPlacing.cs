using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacing : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject towerSpawned;
    [SerializeField] private Button putTowerButton;

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
                Debug.Log("Da para colocar");
                towerSpawned.transform.position = new Vector3(_hit.point.x, 2.5f, _hit.point.z);
            }
        }

        if (Input.GetButtonDown("Fire1")) towerSpawned = null;
    }

    private void PutTower()
    {
        towerSpawned = Instantiate(towerPrefab, Vector3.zero, Quaternion.identity);
    }
}