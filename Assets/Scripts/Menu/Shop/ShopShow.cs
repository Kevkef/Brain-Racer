using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopShow : MonoBehaviour
{
    // Reference to the TMP text component.
    // The TMP_Text class is the base class for both TMP text components.
    // These are <TextMeshPro> and <TextMeshProUGUI>
    public GameObject carItems;
    public GameObject upgradeItems;
    public GameObject skinsItems;
    public GameObject coinsItems;
    public GameObject audioItems;
    public GameObject minigamesItems;
    public TMP_Text carTMP;
    public TMP_Text upgradeTMP;
    public TMP_Text skinsTMP;
    public TMP_Text coinsTMP;
    public TMP_Text audioTMP;
    public TMP_Text minigamesTMP;
    public AudioManager audioManager;
    public AudioClip audioClip;

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

    public void ClickSkins(){
        click(skinsTMP, upgradeTMP, skinsItems, upgradeItems,minigamesTMP, minigamesItems,audioTMP, audioItems);
        if(coinsTMP.fontStyle != FontStyles.Underline)
        {
            Show(carTMP, carItems);
        }
    }
    public void ClickCar(){
        click(carTMP,coinsTMP, carItems, coinsItems, minigamesTMP, minigamesItems,audioTMP, audioItems);
    }

    public void ClickCoins(){
        click(coinsTMP, carTMP, coinsItems, carItems, minigamesTMP, minigamesItems,audioTMP, audioItems);
    }

    public void ClickUpgrade()
    {
        click(upgradeTMP, skinsTMP, upgradeItems, skinsItems,minigamesTMP, minigamesItems,audioTMP, audioItems);
    }
    public void ClickAudio()
    {
        click(audioTMP, skinsTMP, audioItems, skinsItems, minigamesTMP, minigamesItems, upgradeTMP, upgradeItems);
    }
    public void ClickMinigames()
    {
        click(minigamesTMP, skinsTMP, minigamesItems, skinsItems, audioTMP, audioItems, upgradeTMP, upgradeItems);
    }
    private void click(TMP_Text showComponent, TMP_Text sleepComponent0, GameObject showObject, GameObject sleepObject0, TMP_Text sleepComponent1, GameObject sleepObject1,TMP_Text sleepComponent2, GameObject sleepObject2){
        audioManager.PlaySFX(audioClip);
        Show(showComponent, showObject);
        Sleep(sleepComponent0, sleepObject0);
        Sleep(sleepComponent1, sleepObject1);
        Sleep(sleepComponent2, sleepObject2);
    }
}
 
