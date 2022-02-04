using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharStats : MonoBehaviour
{
    public double armor;
    public double damage;

    public Text armorStatText;
    public Text wpnStatText;    

    public ItemElement activeWpn;
    public ItemElement activeArmor;

    public Text armorText;
    public Text wpnText;

    public Image armorImage;
    public Image wpnImage;

    private void Start()
    {
        armor = GameManager.instance.armor;
        damage = GameManager.instance.dmg;

        armorStatText.text = "Armor: " + armor;
        wpnStatText.text = "Damage: " + damage;

        
        

        if(GameManager.instance.activeArmor != null)
        {
            activeArmor = GameManager.instance.activeArmor;
            armorText.text = activeArmor.GetComponent<ItemElement>().name;
            armorImage = activeArmor.GetComponent<ItemElement>().img;
        }
        else
        {
            armorText.text = "NONE!";
            armorImage = null;
        }
        

        if (GameManager.instance.activeWpn != null)
        {
            activeWpn = GameManager.instance.activeWpn;
            wpnText.text = activeWpn.GetComponent<ItemElement>().name;
            wpnImage = activeWpn.GetComponent<ItemElement>().img;            
        }
        else
        {
            wpnText.text = "NONE!";
            wpnImage = null;
        }
        
             
        

    }

    public void calcStatsOnClick()
    {
        armor = GameManager.instance.armor;
        damage = GameManager.instance.dmg;

        armorStatText.text = "Armor: " + armor;
        wpnStatText.text = "Damage: " + damage;




        if (GameManager.instance.activeArmor != null)
        {
            activeArmor = GameManager.instance.activeArmor;
            armorText.text = activeArmor.GetComponent<ItemElement>().name;
            armorImage = activeArmor.GetComponent<ItemElement>().img;
        }
        else
        {
            armorText.text = "NONE!";
            armorImage = null;
        }


        if (GameManager.instance.activeWpn != null)
        {
            activeWpn = GameManager.instance.activeWpn;
            wpnText.text = activeWpn.GetComponent<ItemElement>().name;
            wpnImage = activeWpn.GetComponent<ItemElement>().img;
        }
        else
        {
            wpnText.text = "NONE!";
            wpnImage = null;
        }
    }
}
