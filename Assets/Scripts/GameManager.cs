using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public Text coinText;
    public double coinCount;
    public GameObject mainCanvas;
    public GameObject store;
    public GameObject charPanel;
    public Text coinPerSecText;
    public int coinPerSecInt;
    public UpgradeElement activeUpgrade;
    private bool oneSecPassed;

    public ItemElement activeWpn;
    public ItemElement activeArmor;
    public double armor;
    public double dmg;


    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    private void Start()
    {
        coinCount = 0;
        coinPerSecInt = 1;
        store.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
        charPanel.SetActive(false);

    }

    private void Update()
    {
        coinText.text = "Coins: " + coinCount;
        coinPerSecText.text = "Coin Per Sec: " + coinPerSecInt + "/s";

        StartCoroutine(oneSec());
    }

    public void calculateStats()
    {
        if(activeArmor != null)
        {
            armor = activeArmor.GetComponent<ItemElement>().armor;
        }

        if (activeWpn != null)
        {
            dmg = activeWpn.GetComponent<ItemElement>().damage;
        }
    }
    public void coinPerSecf()
    {
        if (activeUpgrade != null)
        {
            coinPerSecInt = activeUpgrade.multiplier;
        }
        else
        {
            coinPerSecInt = 1;
        }

        
        
    }

    public void coinCalculatorPerSec()
    {
        coinCount += coinPerSecInt;
    }

    IEnumerator oneSec()
    {
        while (!oneSecPassed)
        {
            oneSecPassed = true;
            coinCalculatorPerSec();
            yield return new WaitForSeconds(1);
            oneSecPassed = false;
        }
    }

    public void Click()
    {
        coinCount++;
    }

    public void clickStore()
    {
        store.gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);

    }

    public void clickStoreClose()
    {
        store.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);

    }

    public void clickCharPanel()
    {
        charPanel.GetComponent<CharStats>().calcStatsOnClick();

        charPanel.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
    }

    public void clickCharClose()
    {
        charPanel.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
    }
}
