﻿// Decompiled with JetBrains decompiler
// Type: UISnapshotPoint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Internal/Snapshot Point")]
public class UISnapshotPoint : MonoBehaviour
{
  public bool isOrthographic = true;
  public float nearClip = -100f;
  public float farClip = 100f;
  [Range(10f, 80f)]
  public int fieldOfView = 35;
  public float orthoSize = 30f;
  public Texture2D thumbnail;

  private void Start()
  {
    if (!(this.tag != "EditorOnly"))
      return;
    this.tag = "EditorOnly";
  }
}