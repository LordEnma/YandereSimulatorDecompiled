// Decompiled with JetBrains decompiler
// Type: AmplifyMotion.SolidState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
  internal class SolidState : MotionState
  {
    private MeshRenderer m_meshRenderer;
    private MotionState.Matrix3x4 m_prevLocalToWorld;
    private MotionState.Matrix3x4 m_currLocalToWorld;
    private Mesh m_mesh;
    private MotionState.MaterialDesc[] m_sharedMaterials;
    public bool m_moved;
    private bool m_wasVisible;
    private static HashSet<AmplifyMotionObjectBase> m_uniqueWarnings = new HashSet<AmplifyMotionObjectBase>();

    public SolidState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
      : base(owner, obj)
    {
      this.m_meshRenderer = this.m_obj.GetComponent<MeshRenderer>();
    }

    private void IssueError(string message)
    {
      if (!SolidState.m_uniqueWarnings.Contains(this.m_obj))
      {
        Debug.LogWarning((object) message);
        SolidState.m_uniqueWarnings.Add(this.m_obj);
      }
      this.m_error = true;
    }

    internal override void Initialize()
    {
      MeshFilter component = this.m_obj.GetComponent<MeshFilter>();
      if ((Object) component == (Object) null || (Object) component.sharedMesh == (Object) null)
      {
        this.IssueError("[AmplifyMotion] Invalid MeshFilter/Mesh in object " + this.m_obj.name + ". Skipping.");
      }
      else
      {
        base.Initialize();
        this.m_mesh = component.sharedMesh;
        this.m_sharedMaterials = this.ProcessSharedMaterials(this.m_meshRenderer.sharedMaterials);
        this.m_wasVisible = false;
      }
    }

    internal override void UpdateTransform(CommandBuffer updateCB, bool starting)
    {
      if (!this.m_initialized)
      {
        this.Initialize();
      }
      else
      {
        if (!starting && this.m_wasVisible)
          this.m_prevLocalToWorld = this.m_currLocalToWorld;
        this.m_currLocalToWorld = (MotionState.Matrix3x4) this.m_transform.localToWorldMatrix;
        this.m_moved = true;
        if (!this.m_owner.Overlay)
          this.m_moved = starting || MotionState.MatrixChanged(this.m_currLocalToWorld, this.m_prevLocalToWorld);
        if (starting || !this.m_wasVisible)
          this.m_prevLocalToWorld = this.m_currLocalToWorld;
        this.m_wasVisible = this.m_meshRenderer.isVisible;
      }
    }

    internal override void RenderVectors(
      Camera camera,
      CommandBuffer renderCB,
      float scale,
      Quality quality)
    {
      if (!this.m_initialized || this.m_error || !this.m_meshRenderer.isVisible)
        return;
      bool flag = ((int) this.m_owner.Instance.CullingMask & 1 << this.m_obj.gameObject.layer) != 0;
      if (flag && (!flag || !this.m_moved))
        return;
      int num1 = flag ? this.m_owner.Instance.GenerateObjectId(this.m_obj.gameObject) : (int) byte.MaxValue;
      Matrix4x4 matrix4x4 = !this.m_obj.FixedStep ? this.m_owner.PrevViewProjMatrixRT * (Matrix4x4) this.m_prevLocalToWorld : this.m_owner.PrevViewProjMatrixRT * (Matrix4x4) this.m_currLocalToWorld;
      renderCB.SetGlobalMatrix("_AM_MATRIX_PREV_MVP", matrix4x4);
      renderCB.SetGlobalFloat("_AM_OBJECT_ID", (float) num1 * 0.003921569f);
      renderCB.SetGlobalFloat("_AM_MOTION_SCALE", flag ? scale : 0.0f);
      int num2 = quality == Quality.Mobile ? 0 : 2;
      for (int submeshIndex = 0; submeshIndex < this.m_sharedMaterials.Length; ++submeshIndex)
      {
        MotionState.MaterialDesc sharedMaterial = this.m_sharedMaterials[submeshIndex];
        int shaderPass = num2 + (sharedMaterial.coverage ? 1 : 0);
        if (sharedMaterial.coverage)
        {
          Texture mainTexture = sharedMaterial.material.mainTexture;
          if ((Object) mainTexture != (Object) null)
            sharedMaterial.propertyBlock.SetTexture("_MainTex", mainTexture);
          if (sharedMaterial.cutoff)
            sharedMaterial.propertyBlock.SetFloat("_Cutoff", sharedMaterial.material.GetFloat("_Cutoff"));
        }
        renderCB.DrawMesh(this.m_mesh, this.m_transform.localToWorldMatrix, this.m_owner.Instance.SolidVectorsMaterial, submeshIndex, shaderPass, sharedMaterial.propertyBlock);
      }
    }
  }
}
