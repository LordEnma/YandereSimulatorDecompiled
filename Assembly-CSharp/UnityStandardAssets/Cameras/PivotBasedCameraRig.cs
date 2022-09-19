// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Cameras.PivotBasedCameraRig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Cameras
{
  public abstract class PivotBasedCameraRig : AbstractTargetFollower
  {
    protected Transform m_Cam;
    protected Transform m_Pivot;
    protected Vector3 m_LastTargetPosition;

    protected virtual void Awake()
    {
      this.m_Cam = this.GetComponentInChildren<Camera>().transform;
      this.m_Pivot = this.m_Cam.parent;
    }
  }
}
