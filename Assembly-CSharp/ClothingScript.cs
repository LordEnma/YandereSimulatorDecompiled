﻿// Decompiled with JetBrains decompiler
// Type: ClothingScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ClothingScript : MonoBehaviour
{
  public YandereScript Yandere;
  public PromptScript Prompt;
  public GameObject FoldedUniform;
  public bool CanPickUp;

  private void Start() => this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();

  private void Update()
  {
    if (this.CanPickUp)
    {
      if ((double) this.Yandere.Bloodiness == 0.0)
      {
        this.CanPickUp = false;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    else if ((double) this.Yandere.Bloodiness > 0.0)
    {
      this.CanPickUp = true;
      this.Prompt.enabled = true;
    }
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Yandere.Bloodiness = 0.0f;
    Object.Instantiate<GameObject>(this.FoldedUniform, this.transform.position + Vector3.up, Quaternion.identity);
    Object.Destroy((Object) this.gameObject);
  }
}
