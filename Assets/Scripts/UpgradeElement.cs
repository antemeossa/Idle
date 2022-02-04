using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeElement : MonoBehaviour
{
    public Text storeElementText;
    public Text priceText;
    public string text;
    public int price;
    public int multiplier;
    public bool isActive;
    public bool isPurchased;
    void Start()
    {
        storeElementText.text = text;
        priceText.text = "Price: " + price;
        isPurchased = false;
    }

    public void purchaseButton()
    {
        
            if (!isPurchased && GameManager.instance.coinCount >= price)
            {
                isPurchased = true;
                
                GameManager.instance.coinCount -= price;
                GameManager.instance.coinPerSecf();
            }
            
            if (!isActive && isPurchased)
            {
                isActive = true;
                GameManager.instance.activeUpgrade = GetComponent<UpgradeElement>();
                GameManager.instance.coinPerSecf();

            }
            else if(isActive && isPurchased)
            {
                isActive = false;
                GameManager.instance.activeUpgrade = null;
                GameManager.instance.coinPerSecf();
                
            }
        }
    

    
}
