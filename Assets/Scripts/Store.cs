using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public List<GameObject> upgradeList;

    public GameObject itemsUI;
    public GameObject upgradesUI;

    private void Start()
    {
        

        upgradesUI.SetActive(true);
        itemsUI.SetActive(false);
    }
    
    public void itemsTab()
    {
        itemsUI.SetActive(true);
        upgradesUI.SetActive(false);
    }

    public void upgradesTab()
    {
        itemsUI.SetActive(false);
        upgradesUI.SetActive(true);
    }
}
