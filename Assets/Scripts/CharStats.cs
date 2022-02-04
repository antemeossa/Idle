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
            armorText.text = GameManager.instance.activeArmor.name;
            armorImage = GameManager.instance.activeArmor.img;
        }
        else
        {
            armorText.text = "NONE!";
            armorImage = null;
        }
        

        if (GameManager.instance.activeWpn != null)
        {
            wpnText.text = GameManager.instance.activeWpn.name;
            wpnImage = GameManager.instance.activeWpn.img;
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
            armorText.text = GameManager.instance.activeArmor.name;
            armorImage = GameManager.instance.activeArmor.img;
        }
        else
        {
            armorText.text = "NONE!";
            armorImage = null;
        }


        if (GameManager.instance.activeWpn != null)
        {
            wpnText.text = GameManager.instance.activeWpn.name;
            wpnImage = GameManager.instance.activeWpn.img;
        }
        else
        {
            wpnText.text = "NONE!";
            wpnImage = null;
        }
    }
}
