﻿// Decompiled with JetBrains decompiler
// Type: PoliceWalk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PoliceWalk : MonoBehaviour
{
  private void Update()
  {
    Vector3 position = this.transform.position;
    position.z += Time.deltaTime;
    this.transform.position = position;
  }
}