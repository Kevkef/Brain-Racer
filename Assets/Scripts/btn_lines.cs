using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class btn_lines : MonoBehaviour
{
    // Reference to the TMP text component.
    // The TMP_Text class is the base class for both TMP text components.
    // These are <TextMeshPro> and <TextMeshProUGUI>
    public GameObject Car_Items;
    public GameObject Upgrade_Items;
    public GameObject Skins_Items;
    public GameObject Coins_Items;
    public TMP_Text Car_TMP;
    public TMP_Text Upgrade_TMP;
    public TMP_Text Skins_TMP;
    public TMP_Text Coins_TMP;

    private void Show(TMP_Text TextComponent, GameObject gameObject)
    {
        // Assign the underline style to the text component.
        TextComponent.fontStyle = FontStyles.Underline;
        gameObject.SetActive(true);
    }

    private void Sleep(TMP_Text TextComponent, GameObject gameObject)
    {
         TextComponent.fontStyle &= ~FontStyles.Underline;
         gameObject.SetActive(false);
    }

    public void click_skins(){
        click(Skins_TMP, Upgrade_TMP, Skins_Items, Upgrade_Items);
        if(Coins_TMP.fontStyle != FontStyles.Underline)
        {
            Show(Car_TMP, Car_Items);
        }
    }
    public void click_Car(){
        click(Car_TMP,Coins_TMP, Car_Items, Coins_Items);
    }

    public void click_coins(){
        click(Coins_TMP, Car_TMP, Coins_Items, Car_Items);
    }

    public void click_upgrade()
    {
        click(Upgrade_TMP, Skins_TMP, Upgrade_Items, Skins_Items);
    }

    private void click(TMP_Text ShowComponent, TMP_Text SleepComponent, GameObject ShowObject, GameObject sleepObject){
        Show(ShowComponent, ShowObject);
        Sleep(SleepComponent, sleepObject);
    }
}
 
