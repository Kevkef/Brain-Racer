using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class btn_lines : MonoBehaviour
{
    // Reference to the TMP text component.
    // The TMP_Text class is the base class for both TMP text components.
    // These are <TextMeshPro> and <TextMeshProUGUI>

    public TMP_Text Cars_TMP;
    public TMP_Text Upgrade_TMP;
    public TMP_Text Skins_TMP;
    public TMP_Text Coins_TMP;

    private void awake( TMP_Text TextComponent)
    {
        // Assign the underline style to the text component.
        TextComponent.fontStyle = FontStyles.Underline;
    }

    private void sleep(TMP_Text TextComponent)
    {
         TextComponent.fontStyle &= ~FontStyles.Underline;
    }

    public void click_skins(){
        click(Skins_TMP, Upgrade_TMP);
        if(Coins_TMP.fontStyle != FontStyles.Underline)
        {
            awake(Cars_TMP);
        }
    }
    public void click_cars(){
        click(Cars_TMP,Coins_TMP);
    }

    public void click_coins(){
        click(Coins_TMP, Cars_TMP);
    }

    public void click_upgrade()
    {
        click(Upgrade_TMP, Skins_TMP);
    }

    private void click(TMP_Text AwakeComponent, TMP_Text SleepComponent){
        awake(AwakeComponent);
        sleep(SleepComponent);
    }
}
 
