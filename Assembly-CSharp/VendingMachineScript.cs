// Decompiled with JetBrains decompiler
// Type: VendingMachineScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class VendingMachineScript : MonoBehaviour
{
  public AudioSource MyAudio;
  public PromptScript Prompt;
  public Transform CanSpawn;
  public GameObject[] Cans;
  public bool SnackMachine;
  public bool Sabotaged;
  public int Price;

  private void Start()
  {
    this.Prompt.Text[0] = !this.SnackMachine ? "Buy Drink for $" + this.Price.ToString() + ".00" : "Buy Snack for $" + this.Price.ToString() + ".00";
    this.Prompt.Label[0].text = "     " + this.Prompt.Text[0];
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    if ((double) this.Prompt.Yandere.Inventory.Money >= (double) this.Price)
    {
      if (!this.Sabotaged)
      {
        Object.Instantiate<GameObject>(this.Cans[Random.Range(0, this.Cans.Length)], this.CanSpawn.position, this.CanSpawn.rotation);
        this.MyAudio.Play();
        this.MyAudio.pitch = Random.Range(0.9f, 1.1f);
      }
      if (this.SnackMachine && SchemeGlobals.GetSchemeStage(4) == 3)
      {
        SchemeGlobals.SetSchemeStage(4, 4);
        this.Prompt.Yandere.PauseScreen.Schemes.UpdateInstructions();
      }
      this.Prompt.Yandere.Inventory.Money -= (float) this.Price;
      this.Prompt.Yandere.Inventory.UpdateMoney();
    }
    else
    {
      this.Prompt.Yandere.StudentManager.TutorialWindow.ShowMoneyMessage = true;
      this.Prompt.Yandere.NotificationManager.CustomText = "Not enough money!";
      this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
  }
}
