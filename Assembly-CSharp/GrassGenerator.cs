// Decompiled with JetBrains decompiler
// Type: GrassGenerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof (MeshFilter))]
public class GrassGenerator : MonoBehaviour
{
  [Range(0.1f, 10f)]
  public float QuadSize = 0.1f;
  public float IntersectHeight = 1f;
  public LayerMask IntersectLayers;
  public bool IntersectOffsetCorrection;
  [HideInInspector]
  public List<GrassGenerator.GrassPlane> Planes = new List<GrassGenerator.GrassPlane>();
  [HideInInspector]
  public GrassGenerator.GrassPlane EditedPlane;

  private void OnDrawGizmosSelected()
  {
    if (this.Planes.Count == 0)
      return;
    foreach (GrassGenerator.GrassPlane plane in this.Planes)
    {
      Gizmos.color = Color.gray;
      if (plane == this.EditedPlane)
        Gizmos.color = Color.cyan;
      Gizmos.DrawWireCube(this.transform.position + plane.LocalCenter, new Vector3(plane.Size.x, 0.1f, plane.Size.y));
    }
  }

  [Serializable]
  public class GrassPlane
  {
    public Vector3 LocalCenter;
    public Vector2 Size;
    public bool Intersect;
  }
}
