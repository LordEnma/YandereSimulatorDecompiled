﻿// Decompiled with JetBrains decompiler
// Type: FallingOsanaScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FallingOsanaScript : MonoBehaviour
{
  public StudentScript Osana;
  public GameObject GroundImpact;

  private void Update()
  {
    if ((double) this.transform.position.y > 0.0)
      this.transform.position += new Vector3(0.0f, -1.0001f, 0.0f);
    if ((double) this.transform.position.y >= 0.0)
      return;
    this.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
    Object.Instantiate<GameObject>(this.GroundImpact, this.transform.position, Quaternion.identity);
  }
}