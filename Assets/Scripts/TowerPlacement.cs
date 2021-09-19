using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private Tower _placedTower;

    //variabel ini bakal double check untuk mengetahui apakah udah ada tower di place tsb
    private bool towerAlreadthere;

    // Start is called before the first frame update
    void Start()
    {
        towerAlreadthere = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fungsi yang terpanggil sekali ketika ada object Rigidbody yang menyentuh area collider

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_placedTower != null)
        {
            return;
        }

        Tower tower = collision.GetComponent<Tower>();
        if (tower != null || towerAlreadthere)
        {
            tower.SetPlacePosition(transform.position);
            _placedTower = tower;
            towerAlreadthere = true;
        }   
    }

    // Kebalikan dari OnTriggerEnter2D, fungsi ini terpanggil sekali ketika object tersebut meninggalkan area collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_placedTower == null || towerAlreadthere)
        {
            return;
        }
        towerAlreadthere = false;
        _placedTower.SetPlacePosition(null);
        _placedTower = null;
    }
}
