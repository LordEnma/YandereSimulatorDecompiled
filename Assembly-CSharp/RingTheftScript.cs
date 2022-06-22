// Decompiled with JetBrains decompiler
// Type: RingTheftScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RingTheftScript : MonoBehaviour
{
  public PromptScript Prompt;
  public GameObject BasuRing;
  public GameObject[] Rings;
  public bool Eighties;
  public bool Stolen;

  private void Start()
  {
    if (GameGlobals.Eighties)
    {
      this.BasuRing.SetActive(false);
      this.Eighties = true;
    }
    else
    {
      this.transform.localPosition = new Vector3(11.272f, 0.8306667f, -1.3f);
      foreach (GameObject ring in this.Rings)
      {
        if ((Object) ring != (Object) null)
          ring.SetActive(false);
      }
    }
    this.gameObject.SetActive(false);
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
    if (!this.Prompt.Yandere.Inventory.Ring)
    {
      if (!this.Prompt.Yandere.StudentManager.YandereVisible)
      {
        if (this.Eighties)
        {
          this.Rings[DateGlobals.Week].SetActive(false);
        }
        else
        {
          SchemeGlobals.SetSchemeStage(2, 5);
          this.Prompt.Yandere.StudentManager.Schemes.UpdateInstructions();
          this.BasuRing.SetActive(false);
        }
        this.Prompt.Yandere.Inventory.Ring = true;
        this.Stolen = true;
        this.Prompt.Label[0].text = "     Return Stolen Ring";
      }
      else
      {
        this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
        this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
    }
    else
    {
      if (this.Eighties)
        this.Rings[DateGlobals.Week].SetActive(true);
      else
        this.BasuRing.SetActive(true);
      this.Prompt.Yandere.Inventory.Ring = false;
      this.Stolen = false;
      this.Prompt.Label[0].text = "     Steal Ring";
    }
  }
}
