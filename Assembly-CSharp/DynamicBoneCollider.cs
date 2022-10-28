// Decompiled with JetBrains decompiler
// Type: DynamicBoneCollider
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("Dynamic Bone/Dynamic Bone Collider")]
public class DynamicBoneCollider : MonoBehaviour
{
  public Vector3 m_Center = Vector3.zero;
  public float m_Radius = 0.5f;
  public float m_Height;
  public DynamicBoneCollider.Direction m_Direction;
  public DynamicBoneCollider.Bound m_Bound;

  private void OnValidate()
  {
    this.m_Radius = Mathf.Max(this.m_Radius, 0.0f);
    this.m_Height = Mathf.Max(this.m_Height, 0.0f);
  }

  public void Collide(ref Vector3 particlePosition, float particleRadius)
  {
    float num1 = this.m_Radius * Mathf.Abs(this.transform.lossyScale.x);
    float num2 = this.m_Height * 0.5f - this.m_Radius;
    if ((double) num2 <= 0.0)
    {
      if (this.m_Bound == DynamicBoneCollider.Bound.Outside)
        DynamicBoneCollider.OutsideSphere(ref particlePosition, particleRadius, this.transform.TransformPoint(this.m_Center), num1);
      else
        DynamicBoneCollider.InsideSphere(ref particlePosition, particleRadius, this.transform.TransformPoint(this.m_Center), num1);
    }
    else
    {
      Vector3 center1 = this.m_Center;
      Vector3 center2 = this.m_Center;
      switch (this.m_Direction)
      {
        case DynamicBoneCollider.Direction.X:
          center1.x -= num2;
          center2.x += num2;
          break;
        case DynamicBoneCollider.Direction.Y:
          center1.y -= num2;
          center2.y += num2;
          break;
        case DynamicBoneCollider.Direction.Z:
          center1.z -= num2;
          center2.z += num2;
          break;
      }
      if (this.m_Bound == DynamicBoneCollider.Bound.Outside)
        DynamicBoneCollider.OutsideCapsule(ref particlePosition, particleRadius, this.transform.TransformPoint(center1), this.transform.TransformPoint(center2), num1);
      else
        DynamicBoneCollider.InsideCapsule(ref particlePosition, particleRadius, this.transform.TransformPoint(center1), this.transform.TransformPoint(center2), num1);
    }
  }

  private static void OutsideSphere(
    ref Vector3 particlePosition,
    float particleRadius,
    Vector3 sphereCenter,
    float sphereRadius)
  {
    float num1 = sphereRadius + particleRadius;
    float num2 = num1 * num1;
    Vector3 vector3 = particlePosition - sphereCenter;
    float sqrMagnitude = vector3.sqrMagnitude;
    if ((double) sqrMagnitude <= 0.0 || (double) sqrMagnitude >= (double) num2)
      return;
    float num3 = Mathf.Sqrt(sqrMagnitude);
    particlePosition = sphereCenter + vector3 * (num1 / num3);
  }

  private static void InsideSphere(
    ref Vector3 particlePosition,
    float particleRadius,
    Vector3 sphereCenter,
    float sphereRadius)
  {
    float num1 = sphereRadius - particleRadius;
    float num2 = num1 * num1;
    Vector3 vector3 = particlePosition - sphereCenter;
    float sqrMagnitude = vector3.sqrMagnitude;
    if ((double) sqrMagnitude <= (double) num2)
      return;
    float num3 = Mathf.Sqrt(sqrMagnitude);
    particlePosition = sphereCenter + vector3 * (num1 / num3);
  }

  private static void OutsideCapsule(
    ref Vector3 particlePosition,
    float particleRadius,
    Vector3 capsuleP0,
    Vector3 capsuleP1,
    float capsuleRadius)
  {
    float num1 = capsuleRadius + particleRadius;
    float num2 = num1 * num1;
    Vector3 rhs = capsuleP1 - capsuleP0;
    Vector3 lhs = particlePosition - capsuleP0;
    float num3 = Vector3.Dot(lhs, rhs);
    if ((double) num3 <= 0.0)
    {
      float sqrMagnitude = lhs.sqrMagnitude;
      if ((double) sqrMagnitude <= 0.0 || (double) sqrMagnitude >= (double) num2)
        return;
      float num4 = Mathf.Sqrt(sqrMagnitude);
      particlePosition = capsuleP0 + lhs * (num1 / num4);
    }
    else
    {
      float sqrMagnitude1 = rhs.sqrMagnitude;
      if ((double) num3 >= (double) sqrMagnitude1)
      {
        Vector3 vector3 = particlePosition - capsuleP1;
        float sqrMagnitude2 = vector3.sqrMagnitude;
        if ((double) sqrMagnitude2 <= 0.0 || (double) sqrMagnitude2 >= (double) num2)
          return;
        float num5 = Mathf.Sqrt(sqrMagnitude2);
        particlePosition = capsuleP1 + vector3 * (num1 / num5);
      }
      else
      {
        if ((double) sqrMagnitude1 <= 0.0)
          return;
        float num6 = num3 / sqrMagnitude1;
        Vector3 vector3 = lhs - rhs * num6;
        float sqrMagnitude3 = vector3.sqrMagnitude;
        if ((double) sqrMagnitude3 <= 0.0 || (double) sqrMagnitude3 >= (double) num2)
          return;
        float num7 = Mathf.Sqrt(sqrMagnitude3);
        particlePosition += vector3 * ((num1 - num7) / num7);
      }
    }
  }

  private static void InsideCapsule(
    ref Vector3 particlePosition,
    float particleRadius,
    Vector3 capsuleP0,
    Vector3 capsuleP1,
    float capsuleRadius)
  {
    float num1 = capsuleRadius - particleRadius;
    float num2 = num1 * num1;
    Vector3 rhs = capsuleP1 - capsuleP0;
    Vector3 lhs = particlePosition - capsuleP0;
    float num3 = Vector3.Dot(lhs, rhs);
    if ((double) num3 <= 0.0)
    {
      float sqrMagnitude = lhs.sqrMagnitude;
      if ((double) sqrMagnitude <= (double) num2)
        return;
      float num4 = Mathf.Sqrt(sqrMagnitude);
      particlePosition = capsuleP0 + lhs * (num1 / num4);
    }
    else
    {
      float sqrMagnitude1 = rhs.sqrMagnitude;
      if ((double) num3 >= (double) sqrMagnitude1)
      {
        Vector3 vector3 = particlePosition - capsuleP1;
        float sqrMagnitude2 = vector3.sqrMagnitude;
        if ((double) sqrMagnitude2 <= (double) num2)
          return;
        float num5 = Mathf.Sqrt(sqrMagnitude2);
        particlePosition = capsuleP1 + vector3 * (num1 / num5);
      }
      else
      {
        if ((double) sqrMagnitude1 <= 0.0)
          return;
        float num6 = num3 / sqrMagnitude1;
        Vector3 vector3 = lhs - rhs * num6;
        float sqrMagnitude3 = vector3.sqrMagnitude;
        if ((double) sqrMagnitude3 <= (double) num2)
          return;
        float num7 = Mathf.Sqrt(sqrMagnitude3);
        particlePosition += vector3 * ((num1 - num7) / num7);
      }
    }
  }

  private void OnDrawGizmosSelected()
  {
    if (!this.enabled)
      return;
    Gizmos.color = this.m_Bound != DynamicBoneCollider.Bound.Outside ? Color.magenta : Color.yellow;
    float radius = this.m_Radius * Mathf.Abs(this.transform.lossyScale.x);
    float num = this.m_Height * 0.5f - this.m_Radius;
    if ((double) num <= 0.0)
    {
      Gizmos.DrawWireSphere(this.transform.TransformPoint(this.m_Center), radius);
    }
    else
    {
      Vector3 center1 = this.m_Center;
      Vector3 center2 = this.m_Center;
      switch (this.m_Direction)
      {
        case DynamicBoneCollider.Direction.X:
          center1.x -= num;
          center2.x += num;
          break;
        case DynamicBoneCollider.Direction.Y:
          center1.y -= num;
          center2.y += num;
          break;
        case DynamicBoneCollider.Direction.Z:
          center1.z -= num;
          center2.z += num;
          break;
      }
      Gizmos.DrawWireSphere(this.transform.TransformPoint(center1), radius);
      Gizmos.DrawWireSphere(this.transform.TransformPoint(center2), radius);
    }
  }

  public enum Direction
  {
    X,
    Y,
    Z,
  }

  public enum Bound
  {
    Outside,
    Inside,
  }
}
