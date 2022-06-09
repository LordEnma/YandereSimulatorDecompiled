// Decompiled with JetBrains decompiler
// Type: UIGeometry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class UIGeometry
{
  public List<Vector3> verts = new List<Vector3>();
  public List<Vector2> uvs = new List<Vector2>();
  public List<Color> cols = new List<Color>();
  public UIGeometry.OnCustomWrite onCustomWrite;
  private List<Vector3> mRtpVerts = new List<Vector3>();
  private Vector3 mRtpNormal;
  private Vector4 mRtpTan;

  public bool hasVertices => this.verts.Count > 0;

  public bool hasTransformed => this.mRtpVerts != null && this.mRtpVerts.Count > 0 && this.mRtpVerts.Count == this.verts.Count;

  public void Clear()
  {
    this.verts.Clear();
    this.uvs.Clear();
    this.cols.Clear();
    this.mRtpVerts.Clear();
  }

  public void ApplyTransform(Matrix4x4 widgetToPanel, bool generateNormals = true)
  {
    if (this.verts.Count > 0)
    {
      this.mRtpVerts.Clear();
      int index = 0;
      for (int count = this.verts.Count; index < count; ++index)
        this.mRtpVerts.Add(widgetToPanel.MultiplyPoint3x4(this.verts[index]));
      if (!generateNormals)
        return;
      this.mRtpNormal = widgetToPanel.MultiplyVector(Vector3.back).normalized;
      Vector3 normalized = widgetToPanel.MultiplyVector(Vector3.right).normalized;
      this.mRtpTan = new Vector4(normalized.x, normalized.y, normalized.z, -1f);
    }
    else
      this.mRtpVerts.Clear();
  }

  public void WriteToBuffers(
    List<Vector3> v,
    List<Vector2> u,
    List<Color> c,
    List<Vector3> n,
    List<Vector4> t,
    List<Vector4> u2)
  {
    if (this.mRtpVerts == null || this.mRtpVerts.Count <= 0)
      return;
    if (n == null)
    {
      int index = 0;
      for (int count = this.mRtpVerts.Count; index < count; ++index)
      {
        v.Add(this.mRtpVerts[index]);
        u.Add(this.uvs[index]);
        c.Add(this.cols[index]);
      }
    }
    else
    {
      int index = 0;
      for (int count = this.mRtpVerts.Count; index < count; ++index)
      {
        v.Add(this.mRtpVerts[index]);
        u.Add(this.uvs[index]);
        c.Add(this.cols[index]);
        n.Add(this.mRtpNormal);
        t.Add(this.mRtpTan);
      }
    }
    if (u2 != null)
    {
      Vector4 zero = Vector4.zero;
      int index = 0;
      for (int count = this.verts.Count; index < count; ++index)
      {
        zero.x = this.verts[index].x;
        zero.y = this.verts[index].y;
        u2.Add(zero);
      }
    }
    if (this.onCustomWrite == null)
      return;
    this.onCustomWrite(v, u, c, n, t, u2);
  }

  public delegate void OnCustomWrite(
    List<Vector3> v,
    List<Vector2> u,
    List<Color> c,
    List<Vector3> n,
    List<Vector4> t,
    List<Vector4> u2);
}
