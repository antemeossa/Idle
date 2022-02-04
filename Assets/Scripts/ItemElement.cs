using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemElement : MonoBehaviour
{
    public string name;
    public double armor;
    public double damage;
    public int price;
    public Image img;
    public Text nameText;
    public Text priceText;

    public bool isWpn;
    public bool isArmor;
    public bool isActive;
    public bool isPurchased;
    
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = name;
        priceText.text = "Price: " + price;
    }

    public void purchase()
    {

        if (isArmor)
        {
            if (!isPurchased && GameManager.instance.coinCount > price)
            {
                isActive = true;
                isPurchased = true;
                GameManager.instance.activeArmor = GetComponent<ItemElement>();
                GameManager.instance.calculateStats();
                GameManager.instance.coinCount -= price;
            }else if (isPurchased && !isActive)
            {
                isActive = true;
                GameManager.instance.activeArmor = GetComponent<ItemElement>();
                GameManager.instance.calculateStats();

            }
            else if (isPurchased && isActive)
            {
                isActive = false;
                GameManager.instance.calculateStats();
                GameManager.instance.activeArmor = null;
            }

        }

        if (isWpn)
        {
            if (!isPurchased && GameManager.instance.coinCount > price)
            {
                isActive = true;
                isPurchased = true;
                GameManager.instance.activeWpn = GetComponent<ItemElement>();
                GameManager.instance.calculateStats();
                GameManager.instance.coinCount -= price;
            }
            else  if (isPurchased && !isActive)
            {
                isActive = true;
                GameManager.instance.activeWpn = GetComponent<ItemElement>();
                GameManager.instance.calculateStats();

            }
            else if (isPurchased && isActive)
            {
                isActive = false;
                GameManager.instance.calculateStats();
                GameManager.instance.activeWpn = null;
            }

        }
        
    }
}
