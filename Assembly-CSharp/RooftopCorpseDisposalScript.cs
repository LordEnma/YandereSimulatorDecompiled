// Decompiled with JetBrains decompiler
// Type: RooftopCorpseDisposalScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RooftopCorpseDisposalScript : MonoBehaviour
{
  public YandereScript Yandere;
  public PromptScript Prompt;
  public Collider MyCollider;
  public Transform DropSpot;

  private void Start()
  {
    if (!SchoolGlobals.RoofFence)
      return;
    Object.Destroy((Object) this.gameObject);
  }

  private void Update()
  {
    if (this.MyCollider.bounds.Contains(this.Yandere.transform.position))
    {
      if ((Object) this.Yandere.Ragdoll != (Object) null)
      {
        if (this.Yandere.Dropping)
          return;
        this.Prompt.enabled = true;
        this.Prompt.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y + 1.66666f, this.Yandere.transform.position.z);
        if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
          return;
        this.DropSpot.position = new Vector3(this.DropSpot.position.x, this.DropSpot.position.y, this.Yandere.transform.position.z);
        this.Yandere.CharacterAnimation.CrossFade(this.Yandere.Carrying ? "f02_carryIdleA_00" : "f02_dragIdle_00");
        this.Yandere.DropSpot = this.DropSpot;
        this.Yandere.Dropping = true;
        this.Yandere.CanMove = false;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.Yandere.Ragdoll.GetComponent<RagdollScript>().BloodPoolSpawner.Falling = true;
      }
      else
      {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    else
    {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
  }
}
