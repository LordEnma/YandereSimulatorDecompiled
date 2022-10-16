﻿// Decompiled with JetBrains decompiler
// Type: HomeTriggerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomeTriggerScript : MonoBehaviour
{
  public HomeCameraScript HomeCamera;
  public UILabel Label;
  public bool FadeIn;
  public int ID;

  private void Start() => this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0.0f);

  private void OnTriggerEnter(Collider other)
  {
    if (!(other.tag == "Player"))
      return;
    this.HomeCamera.ID = this.ID;
    this.FadeIn = true;
  }

  private void OnTriggerExit(Collider other)
  {
    if (!(other.tag == "Player"))
      return;
    this.HomeCamera.ID = 0;
    this.FadeIn = false;
  }

  private void Update() => this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, Mathf.MoveTowards(this.Label.color.a, this.FadeIn ? 1f : 0.0f, Time.deltaTime * 10f));

  public void Disable()
  {
    this.Label.color = new Color(this.Label.color.r, this.Label.color.g, this.Label.color.b, 0.0f);
    this.gameObject.SetActive(false);
  }
}
