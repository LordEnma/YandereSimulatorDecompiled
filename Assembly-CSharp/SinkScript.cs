// Decompiled with JetBrains decompiler
// Type: SinkScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SinkScript : MonoBehaviour
{
  public YandereScript Yandere;
  public PromptScript Prompt;

  private void Start() => this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();

  private void Update()
  {
    if ((Object) this.Yandere.PickUp != (Object) null)
    {
      if ((Object) this.Yandere.PickUp.Bucket != (Object) null)
      {
        if (this.Yandere.PickUp.Bucket.Dumbbells == 0)
        {
          this.Prompt.enabled = true;
          this.Prompt.Label[0].text = this.Yandere.PickUp.Bucket.Full ? "     Empty Bucket" : "     Fill Bucket";
        }
        else if (this.Prompt.enabled)
        {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      }
      else if ((Object) this.Yandere.PickUp.BloodCleaner != (Object) null)
      {
        if ((double) this.Yandere.PickUp.BloodCleaner.Blood > 0.0)
        {
          this.Prompt.Label[0].text = "     Empty Robot";
          this.Prompt.enabled = true;
        }
        else
        {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      }
      else if (this.Prompt.enabled)
      {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    else if (this.Prompt.enabled)
    {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    if ((Object) this.Yandere.PickUp.Bucket != (Object) null)
    {
      if (!this.Yandere.PickUp.Bucket.Full)
        this.Yandere.PickUp.Bucket.Fill();
      else
        this.Yandere.PickUp.Bucket.Empty();
      this.Prompt.Label[0].text = this.Yandere.PickUp.Bucket.Full ? "     Empty Bucket" : "     Fill Bucket";
    }
    else if ((Object) this.Yandere.PickUp.BloodCleaner != (Object) null)
    {
      this.Yandere.PickUp.BloodCleaner.Blood = 0.0f;
      this.Yandere.PickUp.BloodCleaner.Lens.SetActive(false);
    }
    this.Prompt.Circle[0].fillAmount = 1f;
  }
}
