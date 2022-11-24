// Decompiled with JetBrains decompiler
// Type: MiniMapEntity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class MiniMapEntity
{
  public bool showDetails;
  public UnityEngine.Sprite icon;
  public bool rotateWithObject = true;
  public Vector3 upAxis;
  public float rotation;
  public Vector2 size;
  public bool clampInBorder;
  public float clampDist;
  public List<GameObject> mapObjects;
}
