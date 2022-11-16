// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Cameras.ProtectCameraFromWallClip
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
  public class ProtectCameraFromWallClip : MonoBehaviour
  {
    public float clipMoveTime = 0.05f;
    public float returnTime = 0.4f;
    public float sphereCastRadius = 0.1f;
    public bool visualiseInEditor;
    public float closestDistance = 0.5f;
    public string dontClipTag = "Player";
    private Transform m_Cam;
    private Transform m_Pivot;
    private float m_OriginalDist;
    private float m_MoveVelocity;
    private float m_CurrentDist;
    private Ray m_Ray;
    private RaycastHit[] m_Hits;
    private ProtectCameraFromWallClip.RayHitComparer m_RayHitComparer;

    public bool protecting { get; private set; }

    private void Start()
    {
      this.m_Cam = this.GetComponentInChildren<Camera>().transform;
      this.m_Pivot = this.m_Cam.parent;
      this.m_OriginalDist = this.m_Cam.localPosition.magnitude;
      this.m_CurrentDist = this.m_OriginalDist;
      this.m_RayHitComparer = new ProtectCameraFromWallClip.RayHitComparer();
    }

    private void LateUpdate()
    {
      float target = this.m_OriginalDist;
      this.m_Ray.origin = this.m_Pivot.position + this.m_Pivot.forward * this.sphereCastRadius;
      this.m_Ray.direction = -this.m_Pivot.forward;
      Collider[] colliderArray = Physics.OverlapSphere(this.m_Ray.origin, this.sphereCastRadius);
      bool flag1 = false;
      bool flag2 = false;
      for (int index = 0; index < colliderArray.Length; ++index)
      {
        if (!colliderArray[index].isTrigger && (!((UnityEngine.Object) colliderArray[index].attachedRigidbody != (UnityEngine.Object) null) || !colliderArray[index].attachedRigidbody.CompareTag(this.dontClipTag)))
        {
          flag1 = true;
          break;
        }
      }
      if (flag1)
      {
        this.m_Ray.origin += this.m_Pivot.forward * this.sphereCastRadius;
        this.m_Hits = Physics.RaycastAll(this.m_Ray, this.m_OriginalDist - this.sphereCastRadius);
      }
      else
        this.m_Hits = Physics.SphereCastAll(this.m_Ray, this.sphereCastRadius, this.m_OriginalDist + this.sphereCastRadius);
      Array.Sort((Array) this.m_Hits, (IComparer) this.m_RayHitComparer);
      float num = float.PositiveInfinity;
      for (int index = 0; index < this.m_Hits.Length; ++index)
      {
        if ((double) this.m_Hits[index].distance < (double) num && !this.m_Hits[index].collider.isTrigger && (!((UnityEngine.Object) this.m_Hits[index].collider.attachedRigidbody != (UnityEngine.Object) null) || !this.m_Hits[index].collider.attachedRigidbody.CompareTag(this.dontClipTag)))
        {
          num = this.m_Hits[index].distance;
          target = -this.m_Pivot.InverseTransformPoint(this.m_Hits[index].point).z;
          flag2 = true;
        }
      }
      if (flag2)
        Debug.DrawRay(this.m_Ray.origin, -this.m_Pivot.forward * (target + this.sphereCastRadius), Color.red);
      this.protecting = flag2;
      this.m_CurrentDist = Mathf.SmoothDamp(this.m_CurrentDist, target, ref this.m_MoveVelocity, (double) this.m_CurrentDist > (double) target ? this.clipMoveTime : this.returnTime);
      this.m_CurrentDist = Mathf.Clamp(this.m_CurrentDist, this.closestDistance, this.m_OriginalDist);
      this.m_Cam.localPosition = -Vector3.forward * this.m_CurrentDist;
    }

    public class RayHitComparer : IComparer
    {
      public int Compare(object x, object y) => ((RaycastHit) x).distance.CompareTo(((RaycastHit) y).distance);
    }
  }
}
