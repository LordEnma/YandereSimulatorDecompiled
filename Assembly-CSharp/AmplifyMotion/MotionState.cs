// Decompiled with JetBrains decompiler
// Type: AmplifyMotion.MotionState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
  [Serializable]
  internal abstract class MotionState
  {
    public const int AsyncUpdateTimeout = 100;
    protected bool m_error;
    protected bool m_initialized;
    protected Transform m_transform;
    protected AmplifyMotionCamera m_owner;
    protected AmplifyMotionObjectBase m_obj;
    private static HashSet<Material> m_materialWarnings = new HashSet<Material>();

    public AmplifyMotionCamera Owner => this.m_owner;

    public bool Initialized => this.m_initialized;

    public bool Error => this.m_error;

    public MotionState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
    {
      this.m_error = false;
      this.m_initialized = false;
      this.m_owner = owner;
      this.m_obj = obj;
      this.m_transform = obj.transform;
    }

    internal virtual void Initialize() => this.m_initialized = true;

    internal virtual void Shutdown()
    {
    }

    internal virtual void AsyncUpdate()
    {
    }

    internal abstract void UpdateTransform(CommandBuffer updateCB, bool starting);

    internal virtual void RenderVectors(
      Camera camera,
      CommandBuffer renderCB,
      float scale,
      Quality quality)
    {
    }

    internal virtual void RenderDebugHUD()
    {
    }

    protected MotionState.MaterialDesc[] ProcessSharedMaterials(Material[] mats)
    {
      MotionState.MaterialDesc[] materialDescArray = new MotionState.MaterialDesc[mats.Length];
      for (int index = 0; index < mats.Length; ++index)
      {
        materialDescArray[index].material = mats[index];
        bool flag = mats[index].GetTag("RenderType", false) == "TransparentCutout" || mats[index].IsKeywordEnabled("_ALPHATEST_ON");
        materialDescArray[index].propertyBlock = new MaterialPropertyBlock();
        materialDescArray[index].coverage = mats[index].HasProperty("_MainTex") & flag;
        materialDescArray[index].cutoff = mats[index].HasProperty("_Cutoff");
        if (flag && !materialDescArray[index].coverage && !MotionState.m_materialWarnings.Contains(materialDescArray[index].material))
        {
          Debug.LogWarning((object) ("[AmplifyMotion] TransparentCutout material \"" + materialDescArray[index].material.name + "\" {" + materialDescArray[index].material.shader.name + "} not using _MainTex standard property."));
          MotionState.m_materialWarnings.Add(materialDescArray[index].material);
        }
      }
      return materialDescArray;
    }

    protected static bool MatrixChanged(MotionState.Matrix3x4 a, MotionState.Matrix3x4 b) => (double) Vector4.SqrMagnitude(new Vector4(a.m00 - b.m00, a.m01 - b.m01, a.m02 - b.m02, a.m03 - b.m03)) > 0.0 || (double) Vector4.SqrMagnitude(new Vector4(a.m10 - b.m10, a.m11 - b.m11, a.m12 - b.m12, a.m13 - b.m13)) > 0.0 || (double) Vector4.SqrMagnitude(new Vector4(a.m20 - b.m20, a.m21 - b.m21, a.m22 - b.m22, a.m23 - b.m23)) > 0.0;

    protected static void MulPoint3x4_XYZ(
      ref Vector3 result,
      ref MotionState.Matrix3x4 mat,
      Vector4 vec)
    {
      result.x = (float) ((double) mat.m00 * (double) vec.x + (double) mat.m01 * (double) vec.y + (double) mat.m02 * (double) vec.z) + mat.m03;
      result.y = (float) ((double) mat.m10 * (double) vec.x + (double) mat.m11 * (double) vec.y + (double) mat.m12 * (double) vec.z) + mat.m13;
      result.z = (float) ((double) mat.m20 * (double) vec.x + (double) mat.m21 * (double) vec.y + (double) mat.m22 * (double) vec.z) + mat.m23;
    }

    protected static void MulPoint3x4_XYZW(
      ref Vector3 result,
      ref MotionState.Matrix3x4 mat,
      Vector4 vec)
    {
      result.x = (float) ((double) mat.m00 * (double) vec.x + (double) mat.m01 * (double) vec.y + (double) mat.m02 * (double) vec.z + (double) mat.m03 * (double) vec.w);
      result.y = (float) ((double) mat.m10 * (double) vec.x + (double) mat.m11 * (double) vec.y + (double) mat.m12 * (double) vec.z + (double) mat.m13 * (double) vec.w);
      result.z = (float) ((double) mat.m20 * (double) vec.x + (double) mat.m21 * (double) vec.y + (double) mat.m22 * (double) vec.z + (double) mat.m23 * (double) vec.w);
    }

    protected static void MulAddPoint3x4_XYZW(
      ref Vector3 result,
      ref MotionState.Matrix3x4 mat,
      Vector4 vec)
    {
      result.x += (float) ((double) mat.m00 * (double) vec.x + (double) mat.m01 * (double) vec.y + (double) mat.m02 * (double) vec.z + (double) mat.m03 * (double) vec.w);
      result.y += (float) ((double) mat.m10 * (double) vec.x + (double) mat.m11 * (double) vec.y + (double) mat.m12 * (double) vec.z + (double) mat.m13 * (double) vec.w);
      result.z += (float) ((double) mat.m20 * (double) vec.x + (double) mat.m21 * (double) vec.y + (double) mat.m22 * (double) vec.z + (double) mat.m23 * (double) vec.w);
    }

    protected struct MaterialDesc
    {
      public Material material;
      public MaterialPropertyBlock propertyBlock;
      public bool coverage;
      public bool cutoff;
    }

    protected struct Matrix3x4
    {
      public float m00;
      public float m01;
      public float m02;
      public float m03;
      public float m10;
      public float m11;
      public float m12;
      public float m13;
      public float m20;
      public float m21;
      public float m22;
      public float m23;

      public Vector4 GetRow(int i)
      {
        switch (i)
        {
          case 0:
            return new Vector4(this.m00, this.m01, this.m02, this.m03);
          case 1:
            return new Vector4(this.m10, this.m11, this.m12, this.m13);
          case 2:
            return new Vector4(this.m20, this.m21, this.m22, this.m23);
          default:
            return new Vector4(0.0f, 0.0f, 0.0f, 1f);
        }
      }

      public static implicit operator MotionState.Matrix3x4(Matrix4x4 from) => new MotionState.Matrix3x4()
      {
        m00 = from.m00,
        m01 = from.m01,
        m02 = from.m02,
        m03 = from.m03,
        m10 = from.m10,
        m11 = from.m11,
        m12 = from.m12,
        m13 = from.m13,
        m20 = from.m20,
        m21 = from.m21,
        m22 = from.m22,
        m23 = from.m23
      };

      public static implicit operator Matrix4x4(MotionState.Matrix3x4 from)
      {
        Matrix4x4 matrix4x4 = new Matrix4x4()
        {
          m00 = from.m00,
          m01 = from.m01,
          m02 = from.m02,
          m03 = from.m03,
          m10 = from.m10,
          m11 = from.m11,
          m12 = from.m12,
          m13 = from.m13,
          m20 = from.m20,
          m21 = from.m21,
          m22 = from.m22,
          m23 = from.m23
        };
        matrix4x4.m30 = matrix4x4.m31 = matrix4x4.m32 = 0.0f;
        matrix4x4.m33 = 1f;
        return matrix4x4;
      }

      public static MotionState.Matrix3x4 operator *(
        MotionState.Matrix3x4 a,
        MotionState.Matrix3x4 b)
      {
        return new MotionState.Matrix3x4()
        {
          m00 = (float) ((double) a.m00 * (double) b.m00 + (double) a.m01 * (double) b.m10 + (double) a.m02 * (double) b.m20),
          m01 = (float) ((double) a.m00 * (double) b.m01 + (double) a.m01 * (double) b.m11 + (double) a.m02 * (double) b.m21),
          m02 = (float) ((double) a.m00 * (double) b.m02 + (double) a.m01 * (double) b.m12 + (double) a.m02 * (double) b.m22),
          m03 = (float) ((double) a.m00 * (double) b.m03 + (double) a.m01 * (double) b.m13 + (double) a.m02 * (double) b.m23) + a.m03,
          m10 = (float) ((double) a.m10 * (double) b.m00 + (double) a.m11 * (double) b.m10 + (double) a.m12 * (double) b.m20),
          m11 = (float) ((double) a.m10 * (double) b.m01 + (double) a.m11 * (double) b.m11 + (double) a.m12 * (double) b.m21),
          m12 = (float) ((double) a.m10 * (double) b.m02 + (double) a.m11 * (double) b.m12 + (double) a.m12 * (double) b.m22),
          m13 = (float) ((double) a.m10 * (double) b.m03 + (double) a.m11 * (double) b.m13 + (double) a.m12 * (double) b.m23) + a.m13,
          m20 = (float) ((double) a.m20 * (double) b.m00 + (double) a.m21 * (double) b.m10 + (double) a.m22 * (double) b.m20),
          m21 = (float) ((double) a.m20 * (double) b.m01 + (double) a.m21 * (double) b.m11 + (double) a.m22 * (double) b.m21),
          m22 = (float) ((double) a.m20 * (double) b.m02 + (double) a.m21 * (double) b.m12 + (double) a.m22 * (double) b.m22),
          m23 = (float) ((double) a.m20 * (double) b.m03 + (double) a.m21 * (double) b.m13 + (double) a.m22 * (double) b.m23) + a.m23
        };
      }
    }
  }
}
