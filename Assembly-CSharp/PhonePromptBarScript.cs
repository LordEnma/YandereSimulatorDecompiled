﻿// Decompiled with JetBrains decompiler
// Type: PhonePromptBarScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PhonePromptBarScript : MonoBehaviour
{
  public UIPanel Panel;
  public bool Show;
  public UILabel Label;

  private void Start()
  {
    this.transform.localPosition = new Vector3(this.transform.localPosition.x, 630f, this.transform.localPosition.z);
    this.Panel.enabled = false;
  }

  private void Update()
  {
    float t = Time.unscaledDeltaTime * 10f;
    if (!this.Show)
    {
      if (!this.Panel.enabled)
        return;
      this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Lerp(this.transform.localPosition.y, 631f, t), this.transform.localPosition.z);
      if ((double) this.transform.localPosition.y >= 630.0)
        return;
      this.transform.localPosition = new Vector3(this.transform.localPosition.x, 631f, this.transform.localPosition.z);
      this.Panel.enabled = false;
    }
    else
      this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Lerp(this.transform.localPosition.y, 530f, t), this.transform.localPosition.z);
  }
}