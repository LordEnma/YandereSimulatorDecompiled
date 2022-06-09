// Decompiled with JetBrains decompiler
// Type: AmplifyMotion.ClothState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
  internal class ClothState : MotionState
  {
    private Cloth m_cloth;
    private Renderer m_renderer;
    private MotionState.Matrix3x4 m_prevLocalToWorld;
    private MotionState.Matrix3x4 m_currLocalToWorld;
    private int m_targetVertexCount;
    private int[] m_targetRemap;
    private Vector3[] m_prevVertices;
    private Vector3[] m_currVertices;
    private Mesh m_clonedMesh;
    private MotionState.MaterialDesc[] m_sharedMaterials;
    private bool m_starting;
    private bool m_wasVisible;
    private static HashSet<AmplifyMotionObjectBase> m_uniqueWarnings = new HashSet<AmplifyMotionObjectBase>();

    public ClothState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
      : base(owner, obj)
    {
      this.m_cloth = this.m_obj.GetComponent<Cloth>();
    }

    private void IssueError(string message)
    {
      if (!ClothState.m_uniqueWarnings.Contains(this.m_obj))
      {
        Debug.LogWarning((object) message);
        ClothState.m_uniqueWarnings.Add(this.m_obj);
      }
      this.m_error = true;
    }

    internal override void Initialize()
    {
      if (this.m_cloth.vertices == null)
      {
        this.IssueError("[AmplifyMotion] Invalid " + ((object) this.m_cloth).GetType().Name + " vertices in object " + this.m_obj.name + ". Skipping.");
      }
      else
      {
        Mesh sharedMesh = this.m_cloth.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh;
        if ((UnityEngine.Object) sharedMesh == (UnityEngine.Object) null || sharedMesh.vertices == null || sharedMesh.triangles == null)
        {
          this.IssueError("[AmplifyMotion] Invalid Mesh on Cloth-enabled object " + this.m_obj.name);
        }
        else
        {
          base.Initialize();
          this.m_renderer = this.m_cloth.gameObject.GetComponent<Renderer>();
          int vertexCount = sharedMesh.vertexCount;
          Vector3[] vertices = sharedMesh.vertices;
          Vector2[] uv = sharedMesh.uv;
          int[] triangles = sharedMesh.triangles;
          this.m_targetRemap = new int[vertexCount];
          if (this.m_cloth.vertices.Length == sharedMesh.vertices.Length)
          {
            for (int index = 0; index < vertexCount; ++index)
              this.m_targetRemap[index] = index;
          }
          else
          {
            Dictionary<Vector3, int> dictionary = new Dictionary<Vector3, int>();
            int num1 = 0;
            for (int index = 0; index < vertexCount; ++index)
            {
              int num2;
              if (dictionary.TryGetValue(vertices[index], out num2))
              {
                this.m_targetRemap[index] = num2;
              }
              else
              {
                this.m_targetRemap[index] = num1;
                dictionary.Add(vertices[index], num1++);
              }
            }
          }
          this.m_targetVertexCount = vertexCount;
          this.m_prevVertices = new Vector3[this.m_targetVertexCount];
          this.m_currVertices = new Vector3[this.m_targetVertexCount];
          this.m_clonedMesh = new Mesh();
          this.m_clonedMesh.vertices = vertices;
          this.m_clonedMesh.normals = vertices;
          this.m_clonedMesh.uv = uv;
          this.m_clonedMesh.triangles = triangles;
          this.m_sharedMaterials = this.ProcessSharedMaterials(this.m_renderer.sharedMaterials);
          this.m_wasVisible = false;
        }
      }
    }

    internal override void Shutdown() => UnityEngine.Object.Destroy((UnityEngine.Object) this.m_clonedMesh);

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
        bool isVisible = this.m_renderer.isVisible;
        if (!this.m_error && isVisible | starting && !starting && this.m_wasVisible)
          Array.Copy((Array) this.m_currVertices, (Array) this.m_prevVertices, this.m_targetVertexCount);
        this.m_currLocalToWorld = (MotionState.Matrix3x4) Matrix4x4.TRS(this.m_transform.position, this.m_transform.rotation, Vector3.one);
        if (starting || !this.m_wasVisible)
          this.m_prevLocalToWorld = this.m_currLocalToWorld;
        this.m_starting = starting;
        this.m_wasVisible = isVisible;
      }
    }

    internal override void RenderVectors(
      Camera camera,
      CommandBuffer renderCB,
      float scale,
      Quality quality)
    {
      if (!this.m_initialized || this.m_error || !this.m_renderer.isVisible)
        return;
      bool flag = ((int) this.m_owner.Instance.CullingMask & 1 << this.m_obj.gameObject.layer) != 0;
      int num1 = flag ? this.m_owner.Instance.GenerateObjectId(this.m_obj.gameObject) : (int) byte.MaxValue;
      Vector3[] vertices = this.m_cloth.vertices;
      for (int index = 0; index < this.m_targetVertexCount; ++index)
        this.m_currVertices[index] = vertices[this.m_targetRemap[index]];
      if (this.m_starting || !this.m_wasVisible)
        Array.Copy((Array) this.m_currVertices, (Array) this.m_prevVertices, this.m_targetVertexCount);
      this.m_clonedMesh.vertices = this.m_currVertices;
      this.m_clonedMesh.normals = this.m_prevVertices;
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
          if ((UnityEngine.Object) mainTexture != (UnityEngine.Object) null)
            sharedMaterial.propertyBlock.SetTexture("_MainTex", mainTexture);
          if (sharedMaterial.cutoff)
            sharedMaterial.propertyBlock.SetFloat("_Cutoff", sharedMaterial.material.GetFloat("_Cutoff"));
        }
        renderCB.DrawMesh(this.m_clonedMesh, (Matrix4x4) this.m_currLocalToWorld, this.m_owner.Instance.ClothVectorsMaterial, submeshIndex, shaderPass, sharedMaterial.propertyBlock);
      }
    }
  }
}
