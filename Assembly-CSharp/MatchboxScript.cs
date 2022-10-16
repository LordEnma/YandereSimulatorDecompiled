// Decompiled with JetBrains decompiler
// Type: MatchboxScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MatchboxScript : MonoBehaviour
{
  public YandereScript Yandere;
  public PromptScript Prompt;
  public PickUpScript PickUp;
  public GameObject Match;
  public AudioSource MyAudio;
  public int Ammo;

  private void Update()
  {
    if (this.Prompt.PauseScreen.Show)
      return;
    if ((Object) this.Prompt.Yandere.PickUp == (Object) this.PickUp)
    {
      if (this.Prompt.HideButton[0])
      {
        this.Prompt.Yandere.Arc.SetActive(true);
        this.Prompt.HideButton[0] = false;
        this.Prompt.HideButton[3] = true;
      }
      if ((double) this.Prompt.Circle[0].fillAmount >= 1.0 || (double) this.Prompt.Circle[0].fillAmount <= 0.0)
        return;
      this.Prompt.Circle[0].fillAmount = 0.0f;
      this.MyAudio.Play();
      Rigidbody component = Object.Instantiate<GameObject>(this.Match, this.Prompt.Yandere.ItemParent.position, this.Prompt.Yandere.transform.rotation).GetComponent<Rigidbody>();
      component.isKinematic = false;
      component.useGravity = true;
      component.AddRelativeForce(Vector3.up * 250f);
      component.AddRelativeForce(Vector3.forward * 250f);
      this.Prompt.Yandere.SuspiciousActionTimer = 1f;
      --this.Ammo;
      if (this.Ammo >= 1)
        return;
      this.Prompt.Yandere.Arc.SetActive(false);
      this.Prompt.Yandere.PickUp.Drop();
      Object.Destroy((Object) this.gameObject);
    }
    else
    {
      if (!this.Prompt.Yandere.Arc.activeInHierarchy || this.Prompt.HideButton[0])
        return;
      this.Prompt.Yandere.Arc.SetActive(false);
      this.Prompt.HideButton[0] = true;
      this.Prompt.HideButton[3] = false;
    }
  }
}
