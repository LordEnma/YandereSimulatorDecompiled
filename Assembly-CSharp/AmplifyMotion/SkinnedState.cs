// Decompiled with JetBrains decompiler
// Type: AmplifyMotion.SkinnedState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
  internal class SkinnedState : MotionState
  {
    private SkinnedMeshRenderer m_renderer;
    private int m_boneCount;
    private Transform[] m_boneTransforms;
    private MotionState.Matrix3x4[] m_bones;
    private int m_weightCount;
    private int[] m_boneIndices;
    private float[] m_boneWeights;
    private int m_vertexCount;
    private Vector4[] m_baseVertices;
    private Vector3[] m_prevVertices;
    private Vector3[] m_currVertices;
    private int m_gpuBoneTexWidth;
    private int m_gpuBoneTexHeight;
    private int m_gpuVertexTexWidth;
    private int m_gpuVertexTexHeight;
    private Material m_gpuSkinDeformMat;
    private Color[] m_gpuBoneData;
    private Texture2D m_gpuBones;
    private Texture2D m_gpuBoneIndices;
    private Texture2D[] m_gpuBaseVertices;
    private RenderTexture m_gpuPrevVertices;
    private RenderTexture m_gpuCurrVertices;
    private Mesh m_clonedMesh;
    private MotionState.Matrix3x4 m_worldToLocalMatrix;
    private MotionState.Matrix3x4 m_prevLocalToWorld;
    private MotionState.Matrix3x4 m_currLocalToWorld;
    private MotionState.MaterialDesc[] m_sharedMaterials;
    private ManualResetEvent m_asyncUpdateSignal;
    private bool m_asyncUpdateTriggered;
    private bool m_starting;
    private bool m_wasVisible;
    private bool m_useFallback;
    private bool m_useGPU;
    private static HashSet<AmplifyMotionObjectBase> m_uniqueWarnings = new HashSet<AmplifyMotionObjectBase>();

    public SkinnedState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
      : base(owner, obj)
    {
      this.m_renderer = this.m_obj.GetComponent<SkinnedMeshRenderer>();
    }

    private void IssueWarning(string message)
    {
      if (SkinnedState.m_uniqueWarnings.Contains(this.m_obj))
        return;
      Debug.LogWarning((object) message);
      SkinnedState.m_uniqueWarnings.Add(this.m_obj);
    }

    private void IssueError(string message)
    {
      this.IssueWarning(message);
      this.m_error = true;
    }

    internal override void Initialize()
    {
      if (!this.m_renderer.sharedMesh.isReadable)
      {
        this.IssueError("[AmplifyMotion] Read/Write Import Setting disabled in object " + this.m_obj.name + ". Skipping.");
      }
      else
      {
        Transform[] bones = this.m_renderer.bones;
        this.m_useFallback = bones == null || bones.Length == 0;
        if (!this.m_useFallback)
          this.m_useGPU = this.m_owner.Instance.CanUseGPU;
        base.Initialize();
        this.m_vertexCount = this.m_renderer.sharedMesh.vertexCount;
        this.m_prevVertices = new Vector3[this.m_vertexCount];
        this.m_currVertices = new Vector3[this.m_vertexCount];
        this.m_clonedMesh = new Mesh();
        if (!this.m_useFallback)
        {
          this.m_weightCount = this.m_renderer.quality != SkinQuality.Auto ? (int) this.m_renderer.quality : (int) QualitySettings.skinWeights;
          this.m_boneTransforms = this.m_renderer.bones;
          this.m_boneCount = this.m_renderer.bones.Length;
          this.m_bones = new MotionState.Matrix3x4[this.m_boneCount];
          Vector4[] baseVertices = new Vector4[this.m_vertexCount * this.m_weightCount];
          int[] boneIndices = new int[this.m_vertexCount * this.m_weightCount];
          float[] boneWeights = this.m_weightCount > 1 ? new float[this.m_vertexCount * this.m_weightCount] : (float[]) null;
          if (this.m_weightCount == 1)
            this.InitializeBone1(baseVertices, boneIndices);
          else if (this.m_weightCount == 2)
            this.InitializeBone2(baseVertices, boneIndices, boneWeights);
          else
            this.InitializeBone4(baseVertices, boneIndices, boneWeights);
          this.m_baseVertices = baseVertices;
          this.m_boneIndices = boneIndices;
          this.m_boneWeights = boneWeights;
          Mesh sharedMesh = this.m_renderer.sharedMesh;
          this.m_clonedMesh.vertices = sharedMesh.vertices;
          this.m_clonedMesh.normals = sharedMesh.vertices;
          this.m_clonedMesh.uv = sharedMesh.uv;
          this.m_clonedMesh.subMeshCount = sharedMesh.subMeshCount;
          for (int submesh = 0; submesh < sharedMesh.subMeshCount; ++submesh)
            this.m_clonedMesh.SetTriangles(sharedMesh.GetTriangles(submesh), submesh);
          if (this.m_useGPU)
          {
            if (!this.InitializeGPUSkinDeform())
            {
              Debug.LogWarning((object) ("[AmplifyMotion] Failed initializing GPU skin deform for object " + this.m_obj.name + ". Falling back to CPU path."));
              this.m_useGPU = false;
            }
            else
            {
              this.m_boneIndices = (int[]) null;
              this.m_boneWeights = (float[]) null;
              this.m_baseVertices = (Vector4[]) null;
              this.m_prevVertices = (Vector3[]) null;
              this.m_currVertices = (Vector3[]) null;
            }
          }
          if (!this.m_useGPU)
          {
            this.m_asyncUpdateSignal = new ManualResetEvent(false);
            this.m_asyncUpdateTriggered = false;
          }
        }
        this.m_sharedMaterials = this.ProcessSharedMaterials(this.m_renderer.sharedMaterials);
        this.m_wasVisible = false;
      }
    }

    internal override void Shutdown()
    {
      if (!this.m_useFallback && !this.m_useGPU)
        this.WaitForAsyncUpdate();
      if (this.m_useGPU)
        this.ShutdownGPUSkinDeform();
      if ((UnityEngine.Object) this.m_clonedMesh != (UnityEngine.Object) null)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.m_clonedMesh);
        this.m_clonedMesh = (Mesh) null;
      }
      this.m_boneTransforms = (Transform[]) null;
      this.m_bones = (MotionState.Matrix3x4[]) null;
      this.m_boneIndices = (int[]) null;
      this.m_boneWeights = (float[]) null;
      this.m_baseVertices = (Vector4[]) null;
      this.m_prevVertices = (Vector3[]) null;
      this.m_currVertices = (Vector3[]) null;
      this.m_sharedMaterials = (MotionState.MaterialDesc[]) null;
    }

    private bool InitializeGPUSkinDeform()
    {
      bool flag = true;
      try
      {
        this.m_gpuBoneTexWidth = this.m_boneCount;
        this.m_gpuBoneTexHeight = 3;
        this.m_gpuVertexTexWidth = Mathf.CeilToInt(Mathf.Sqrt((float) this.m_vertexCount));
        this.m_gpuVertexTexHeight = Mathf.CeilToInt((float) this.m_vertexCount / (float) this.m_gpuVertexTexWidth);
        Material material = new Material(Shader.Find("Hidden/Amplify Motion/GPUSkinDeform"));
        material.hideFlags = HideFlags.DontSave;
        this.m_gpuSkinDeformMat = material;
        this.m_gpuBones = new Texture2D(this.m_gpuBoneTexWidth, this.m_gpuBoneTexHeight, TextureFormat.RGBAFloat, false, true);
        this.m_gpuBones.hideFlags = HideFlags.DontSave;
        this.m_gpuBones.name = "AM-" + this.m_obj.name + "-Bones";
        this.m_gpuBones.filterMode = FilterMode.Point;
        this.m_gpuBoneData = new Color[this.m_gpuBoneTexWidth * this.m_gpuBoneTexHeight];
        this.UpdateBonesGPU();
        TextureFormat textureFormat1 = TextureFormat.RHalf;
        TextureFormat textureFormat2 = this.m_weightCount == 2 ? TextureFormat.RGHalf : textureFormat1;
        this.m_gpuBoneIndices = new Texture2D(this.m_gpuVertexTexWidth, this.m_gpuVertexTexHeight, this.m_weightCount == 4 ? TextureFormat.RGBAHalf : textureFormat2, false, true);
        this.m_gpuBoneIndices.hideFlags = HideFlags.DontSave;
        this.m_gpuBoneIndices.name = "AM-" + this.m_obj.name + "-Bones";
        this.m_gpuBoneIndices.filterMode = FilterMode.Point;
        this.m_gpuBoneIndices.wrapMode = TextureWrapMode.Clamp;
        BoneWeight[] boneWeights = this.m_renderer.sharedMesh.boneWeights;
        Color[] colors = new Color[this.m_gpuVertexTexWidth * this.m_gpuVertexTexHeight];
        for (int index1 = 0; index1 < this.m_vertexCount; ++index1)
        {
          int num = index1 % this.m_gpuVertexTexWidth;
          int index2 = index1 / this.m_gpuVertexTexWidth * this.m_gpuVertexTexWidth + num;
          BoneWeight boneWeight = boneWeights[index1];
          colors[index2] = (Color) new Vector4((float) boneWeight.boneIndex0, (float) boneWeight.boneIndex1, (float) boneWeight.boneIndex2, (float) boneWeight.boneIndex3);
        }
        this.m_gpuBoneIndices.SetPixels(colors);
        this.m_gpuBoneIndices.Apply();
        this.m_gpuBaseVertices = new Texture2D[this.m_weightCount];
        for (int index = 0; index < this.m_weightCount; ++index)
        {
          this.m_gpuBaseVertices[index] = new Texture2D(this.m_gpuVertexTexWidth, this.m_gpuVertexTexHeight, TextureFormat.RGBAFloat, false, true);
          this.m_gpuBaseVertices[index].hideFlags = HideFlags.DontSave;
          this.m_gpuBaseVertices[index].name = "AM-" + this.m_obj.name + "-BaseVerts";
          this.m_gpuBaseVertices[index].filterMode = FilterMode.Point;
        }
        List<Color[]> colorArrayList = new List<Color[]>(this.m_weightCount);
        for (int index = 0; index < this.m_weightCount; ++index)
          colorArrayList.Add(new Color[this.m_gpuVertexTexWidth * this.m_gpuVertexTexHeight]);
        for (int index3 = 0; index3 < this.m_vertexCount; ++index3)
        {
          int num = index3 % this.m_gpuVertexTexWidth;
          int index4 = index3 / this.m_gpuVertexTexWidth * this.m_gpuVertexTexWidth + num;
          for (int index5 = 0; index5 < this.m_weightCount; ++index5)
            colorArrayList[index5][index4] = (Color) this.m_baseVertices[index3 * this.m_weightCount + index5];
        }
        for (int index = 0; index < this.m_weightCount; ++index)
        {
          this.m_gpuBaseVertices[index].SetPixels(colorArrayList[index]);
          this.m_gpuBaseVertices[index].Apply();
        }
        this.m_gpuPrevVertices = new RenderTexture(this.m_gpuVertexTexWidth, this.m_gpuVertexTexHeight, 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
        this.m_gpuPrevVertices.hideFlags = HideFlags.DontSave;
        this.m_gpuPrevVertices.name = "AM-" + this.m_obj.name + "-PrevVerts";
        this.m_gpuPrevVertices.filterMode = FilterMode.Point;
        this.m_gpuPrevVertices.wrapMode = TextureWrapMode.Clamp;
        this.m_gpuPrevVertices.Create();
        this.m_gpuCurrVertices = new RenderTexture(this.m_gpuVertexTexWidth, this.m_gpuVertexTexHeight, 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
        this.m_gpuCurrVertices.hideFlags = HideFlags.DontSave;
        this.m_gpuCurrVertices.name = "AM-" + this.m_obj.name + "-CurrVerts";
        this.m_gpuCurrVertices.filterMode = FilterMode.Point;
        this.m_gpuCurrVertices.wrapMode = TextureWrapMode.Clamp;
        this.m_gpuCurrVertices.Create();
        this.m_gpuSkinDeformMat.SetTexture("_AM_BONE_TEX", (Texture) this.m_gpuBones);
        this.m_gpuSkinDeformMat.SetTexture("_AM_BONE_INDEX_TEX", (Texture) this.m_gpuBoneIndices);
        for (int index = 0; index < this.m_weightCount; ++index)
          this.m_gpuSkinDeformMat.SetTexture("_AM_BASE_VERTEX" + index.ToString() + "_TEX", (Texture) this.m_gpuBaseVertices[index]);
        Vector4 vector4_1 = new Vector4(1f / (float) this.m_gpuBoneTexWidth, 1f / (float) this.m_gpuBoneTexHeight, (float) this.m_gpuBoneTexWidth, (float) this.m_gpuBoneTexHeight);
        Vector4 vector4_2 = new Vector4(1f / (float) this.m_gpuVertexTexWidth, 1f / (float) this.m_gpuVertexTexHeight, (float) this.m_gpuVertexTexWidth, (float) this.m_gpuVertexTexHeight);
        this.m_gpuSkinDeformMat.SetVector("_AM_BONE_TEXEL_SIZE", vector4_1);
        this.m_gpuSkinDeformMat.SetVector("_AM_BONE_TEXEL_HALFSIZE", vector4_1 * 0.5f);
        this.m_gpuSkinDeformMat.SetVector("_AM_VERTEX_TEXEL_SIZE", vector4_2);
        this.m_gpuSkinDeformMat.SetVector("_AM_VERTEX_TEXEL_HALFSIZE", vector4_2 * 0.5f);
        Vector2[] vector2Array = new Vector2[this.m_vertexCount];
        for (int index = 0; index < this.m_vertexCount; ++index)
        {
          int num1 = index % this.m_gpuVertexTexWidth;
          int num2 = index / this.m_gpuVertexTexWidth;
          float x = (float) ((double) num1 / (double) this.m_gpuVertexTexWidth + (double) vector4_2.x * 0.5);
          float y = (float) ((double) num2 / (double) this.m_gpuVertexTexHeight + (double) vector4_2.y * 0.5);
          vector2Array[index] = new Vector2(x, y);
        }
        this.m_clonedMesh.uv2 = vector2Array;
      }
      catch (Exception ex)
      {
        flag = false;
      }
      return flag;
    }

    private void ShutdownGPUSkinDeform()
    {
      if ((UnityEngine.Object) this.m_gpuSkinDeformMat != (UnityEngine.Object) null)
      {
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.m_gpuSkinDeformMat);
        this.m_gpuSkinDeformMat = (Material) null;
      }
      this.m_gpuBoneData = (Color[]) null;
      if ((UnityEngine.Object) this.m_gpuBones != (UnityEngine.Object) null)
      {
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.m_gpuBones);
        this.m_gpuBones = (Texture2D) null;
      }
      if ((UnityEngine.Object) this.m_gpuBoneIndices != (UnityEngine.Object) null)
      {
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.m_gpuBoneIndices);
        this.m_gpuBoneIndices = (Texture2D) null;
      }
      if (this.m_gpuBaseVertices != null)
      {
        for (int index = 0; index < this.m_gpuBaseVertices.Length; ++index)
          UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.m_gpuBaseVertices[index]);
        this.m_gpuBaseVertices = (Texture2D[]) null;
      }
      if ((UnityEngine.Object) this.m_gpuPrevVertices != (UnityEngine.Object) null)
      {
        RenderTexture.active = (RenderTexture) null;
        this.m_gpuPrevVertices.Release();
        UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.m_gpuPrevVertices);
        this.m_gpuPrevVertices = (RenderTexture) null;
      }
      if (!((UnityEngine.Object) this.m_gpuCurrVertices != (UnityEngine.Object) null))
        return;
      RenderTexture.active = (RenderTexture) null;
      this.m_gpuCurrVertices.Release();
      UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.m_gpuCurrVertices);
      this.m_gpuCurrVertices = (RenderTexture) null;
    }

    private void UpdateBonesGPU()
    {
      for (int index = 0; index < this.m_boneCount; ++index)
      {
        for (int i = 0; i < this.m_gpuBoneTexHeight; ++i)
          this.m_gpuBoneData[i * this.m_gpuBoneTexWidth + index] = (Color) this.m_bones[index].GetRow(i);
      }
      this.m_gpuBones.SetPixels(this.m_gpuBoneData);
      this.m_gpuBones.Apply();
    }

    private void UpdateVerticesGPU(CommandBuffer updateCB, bool starting)
    {
      if (!starting && this.m_wasVisible)
      {
        this.m_gpuPrevVertices.DiscardContents();
        updateCB.Blit(new RenderTargetIdentifier((Texture) this.m_gpuCurrVertices), (RenderTargetIdentifier) (Texture) this.m_gpuPrevVertices);
      }
      updateCB.SetGlobalMatrix("_AM_WORLD_TO_LOCAL_MATRIX", (Matrix4x4) this.m_worldToLocalMatrix);
      this.m_gpuCurrVertices.DiscardContents();
      RenderTexture tex = (RenderTexture) null;
      updateCB.Blit(new RenderTargetIdentifier((Texture) tex), (RenderTargetIdentifier) (Texture) this.m_gpuCurrVertices, this.m_gpuSkinDeformMat, Mathf.Min(this.m_weightCount - 1, 2));
      if (!starting && this.m_wasVisible)
        return;
      this.m_gpuPrevVertices.DiscardContents();
      updateCB.Blit(new RenderTargetIdentifier((Texture) this.m_gpuCurrVertices), (RenderTargetIdentifier) (Texture) this.m_gpuPrevVertices);
    }

    private void UpdateBones()
    {
      for (int index = 0; index < this.m_boneCount; ++index)
        this.m_bones[index] = (MotionState.Matrix3x4) ((UnityEngine.Object) this.m_boneTransforms[index] != (UnityEngine.Object) null ? this.m_boneTransforms[index].localToWorldMatrix : Matrix4x4.identity);
      this.m_worldToLocalMatrix = (MotionState.Matrix3x4) this.m_transform.worldToLocalMatrix;
      if (!this.m_useGPU)
        return;
      this.UpdateBonesGPU();
    }

    private void UpdateVerticesFallback(bool starting)
    {
      if (!starting && this.m_wasVisible)
        Array.Copy((Array) this.m_currVertices, (Array) this.m_prevVertices, this.m_vertexCount);
      this.m_renderer.BakeMesh(this.m_clonedMesh);
      if (this.m_clonedMesh.vertexCount == 0 || this.m_clonedMesh.vertexCount != this.m_prevVertices.Length)
      {
        this.IssueError("[AmplifyMotion] Invalid mesh obtained from SkinnedMeshRenderer.BakeMesh in object " + this.m_obj.name + ". Skipping.");
      }
      else
      {
        Array.Copy((Array) this.m_clonedMesh.vertices, (Array) this.m_currVertices, this.m_vertexCount);
        if (!starting && this.m_wasVisible)
          return;
        Array.Copy((Array) this.m_currVertices, (Array) this.m_prevVertices, this.m_vertexCount);
      }
    }

    private void AsyncUpdateVertices(bool starting)
    {
      if (!starting && this.m_wasVisible)
        Array.Copy((Array) this.m_currVertices, (Array) this.m_prevVertices, this.m_vertexCount);
      for (int index = 0; index < this.m_boneCount; ++index)
        this.m_bones[index] = this.m_worldToLocalMatrix * this.m_bones[index];
      if (this.m_weightCount == 1)
        this.UpdateVerticesBone1();
      else if (this.m_weightCount == 2)
        this.UpdateVerticesBone2();
      else
        this.UpdateVerticesBone4();
      if (!starting && this.m_wasVisible)
        return;
      Array.Copy((Array) this.m_currVertices, (Array) this.m_prevVertices, this.m_vertexCount);
    }

    private void InitializeBone1(Vector4[] baseVertices, int[] boneIndices)
    {
      Vector3[] vertices = this.m_renderer.sharedMesh.vertices;
      Matrix4x4[] bindposes = this.m_renderer.sharedMesh.bindposes;
      BoneWeight[] boneWeights = this.m_renderer.sharedMesh.boneWeights;
      for (int index1 = 0; index1 < this.m_vertexCount; ++index1)
      {
        int index2 = index1 * this.m_weightCount;
        int index3 = boneIndices[index2] = boneWeights[index1].boneIndex0;
        Vector3 vector3 = bindposes[index3].MultiplyPoint3x4(vertices[index1]);
        baseVertices[index2] = new Vector4(vector3.x, vector3.y, vector3.z, 1f);
      }
    }

    private void InitializeBone2(Vector4[] baseVertices, int[] boneIndices, float[] boneWeights)
    {
      Vector3[] vertices = this.m_renderer.sharedMesh.vertices;
      Matrix4x4[] bindposes = this.m_renderer.sharedMesh.bindposes;
      BoneWeight[] boneWeights1 = this.m_renderer.sharedMesh.boneWeights;
      for (int index1 = 0; index1 < this.m_vertexCount; ++index1)
      {
        int index2 = index1 * this.m_weightCount;
        int index3 = index2 + 1;
        BoneWeight boneWeight = boneWeights1[index1];
        int index4 = boneIndices[index2] = boneWeight.boneIndex0;
        int index5 = boneIndices[index3] = boneWeight.boneIndex1;
        float weight0 = boneWeight.weight0;
        float weight1 = boneWeight.weight1;
        float num = (float) (1.0 / ((double) weight0 + (double) weight1));
        float w1;
        boneWeights[index2] = w1 = weight0 * num;
        float w2;
        boneWeights[index3] = w2 = weight1 * num;
        Vector3 vector3_1 = w1 * bindposes[index4].MultiplyPoint3x4(vertices[index1]);
        Vector3 vector3_2 = w2 * bindposes[index5].MultiplyPoint3x4(vertices[index1]);
        baseVertices[index2] = new Vector4(vector3_1.x, vector3_1.y, vector3_1.z, w1);
        baseVertices[index3] = new Vector4(vector3_2.x, vector3_2.y, vector3_2.z, w2);
      }
    }

    private void InitializeBone4(Vector4[] baseVertices, int[] boneIndices, float[] boneWeights)
    {
      Vector3[] vertices = this.m_renderer.sharedMesh.vertices;
      Matrix4x4[] bindposes = this.m_renderer.sharedMesh.bindposes;
      BoneWeight[] boneWeights1 = this.m_renderer.sharedMesh.boneWeights;
      for (int index1 = 0; index1 < this.m_vertexCount; ++index1)
      {
        int index2 = index1 * this.m_weightCount;
        int index3 = index2 + 1;
        int index4 = index2 + 2;
        int index5 = index2 + 3;
        BoneWeight boneWeight = boneWeights1[index1];
        int index6 = boneIndices[index2] = boneWeight.boneIndex0;
        int index7 = boneIndices[index3] = boneWeight.boneIndex1;
        int index8 = boneIndices[index4] = boneWeight.boneIndex2;
        int index9 = boneIndices[index5] = boneWeight.boneIndex3;
        float w1 = boneWeights[index2] = boneWeight.weight0;
        float w2 = boneWeights[index3] = boneWeight.weight1;
        float w3 = boneWeights[index4] = boneWeight.weight2;
        float w4 = boneWeights[index5] = boneWeight.weight3;
        Vector3 vector3_1 = w1 * bindposes[index6].MultiplyPoint3x4(vertices[index1]);
        Vector3 vector3_2 = w2 * bindposes[index7].MultiplyPoint3x4(vertices[index1]);
        Vector3 vector3_3 = w3 * bindposes[index8].MultiplyPoint3x4(vertices[index1]);
        Vector3 vector3_4 = w4 * bindposes[index9].MultiplyPoint3x4(vertices[index1]);
        baseVertices[index2] = new Vector4(vector3_1.x, vector3_1.y, vector3_1.z, w1);
        baseVertices[index3] = new Vector4(vector3_2.x, vector3_2.y, vector3_2.z, w2);
        baseVertices[index4] = new Vector4(vector3_3.x, vector3_3.y, vector3_3.z, w3);
        baseVertices[index5] = new Vector4(vector3_4.x, vector3_4.y, vector3_4.z, w4);
      }
    }

    private void UpdateVerticesBone1()
    {
      for (int index = 0; index < this.m_vertexCount; ++index)
        MotionState.MulPoint3x4_XYZ(ref this.m_currVertices[index], ref this.m_bones[this.m_boneIndices[index]], this.m_baseVertices[index]);
    }

    private void UpdateVerticesBone2()
    {
      Vector3 zero = Vector3.zero;
      for (int index1 = 0; index1 < this.m_vertexCount; ++index1)
      {
        int index2 = index1 * 2;
        int index3 = index2 + 1;
        int boneIndex1 = this.m_boneIndices[index2];
        int boneIndex2 = this.m_boneIndices[index3];
        double boneWeight = (double) this.m_boneWeights[index3];
        MotionState.MulPoint3x4_XYZW(ref zero, ref this.m_bones[boneIndex1], this.m_baseVertices[index2]);
        if (boneWeight != 0.0)
          MotionState.MulAddPoint3x4_XYZW(ref zero, ref this.m_bones[boneIndex2], this.m_baseVertices[index3]);
        this.m_currVertices[index1] = zero;
      }
    }

    private void UpdateVerticesBone4()
    {
      Vector3 zero = Vector3.zero;
      for (int index1 = 0; index1 < this.m_vertexCount; ++index1)
      {
        int index2 = index1 * 4;
        int index3 = index2 + 1;
        int index4 = index2 + 2;
        int index5 = index2 + 3;
        int boneIndex1 = this.m_boneIndices[index2];
        int boneIndex2 = this.m_boneIndices[index3];
        int boneIndex3 = this.m_boneIndices[index4];
        int boneIndex4 = this.m_boneIndices[index5];
        double boneWeight1 = (double) this.m_boneWeights[index3];
        float boneWeight2 = this.m_boneWeights[index4];
        float boneWeight3 = this.m_boneWeights[index5];
        MotionState.MulPoint3x4_XYZW(ref zero, ref this.m_bones[boneIndex1], this.m_baseVertices[index2]);
        if (boneWeight1 != 0.0)
          MotionState.MulAddPoint3x4_XYZW(ref zero, ref this.m_bones[boneIndex2], this.m_baseVertices[index3]);
        if ((double) boneWeight2 != 0.0)
          MotionState.MulAddPoint3x4_XYZW(ref zero, ref this.m_bones[boneIndex3], this.m_baseVertices[index4]);
        if ((double) boneWeight3 != 0.0)
          MotionState.MulAddPoint3x4_XYZW(ref zero, ref this.m_bones[boneIndex4], this.m_baseVertices[index5]);
        this.m_currVertices[index1] = zero;
      }
    }

    internal override void AsyncUpdate()
    {
      try
      {
        this.AsyncUpdateVertices(this.m_starting);
      }
      catch (Exception ex)
      {
        this.IssueError("[AmplifyMotion] Failed on SkinnedMeshRenderer data. Please contact support.\n" + ex.Message);
      }
      finally
      {
        this.m_asyncUpdateSignal.Set();
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
        bool isVisible = this.m_renderer.isVisible;
        if (!this.m_error && isVisible | starting)
        {
          this.UpdateBones();
          this.m_starting = !this.m_wasVisible | starting;
          if (!this.m_useFallback)
          {
            if (!this.m_useGPU)
            {
              this.m_asyncUpdateSignal.Reset();
              this.m_asyncUpdateTriggered = true;
              this.m_owner.Instance.WorkerPool.EnqueueAsyncUpdate((MotionState) this);
            }
            else
              this.UpdateVerticesGPU(updateCB, this.m_starting);
          }
          else
            this.UpdateVerticesFallback(this.m_starting);
        }
        this.m_currLocalToWorld = this.m_useFallback ? (MotionState.Matrix3x4) Matrix4x4.TRS(this.m_transform.position, this.m_transform.rotation, Vector3.one) : (MotionState.Matrix3x4) this.m_transform.localToWorldMatrix;
        if (starting || !this.m_wasVisible)
          this.m_prevLocalToWorld = this.m_currLocalToWorld;
        this.m_wasVisible = isVisible;
      }
    }

    private void WaitForAsyncUpdate()
    {
      if (!this.m_asyncUpdateTriggered)
        return;
      if (!this.m_asyncUpdateSignal.WaitOne(100))
        Debug.LogWarning((object) "[AmplifyMotion] Aborted abnormally long Async Skin deform operation. Not a critical error but might indicate a problem. Please contact support.");
      else
        this.m_asyncUpdateTriggered = false;
    }

    internal override void RenderVectors(
      Camera camera,
      CommandBuffer renderCB,
      float scale,
      Quality quality)
    {
      if (!this.m_initialized || this.m_error || !this.m_renderer.isVisible)
        return;
      if (!this.m_useFallback && !this.m_useGPU)
        this.WaitForAsyncUpdate();
      if (!this.m_useGPU)
      {
        if (!this.m_useFallback)
          this.m_clonedMesh.vertices = this.m_currVertices;
        this.m_clonedMesh.normals = this.m_prevVertices;
      }
      bool flag = ((int) this.m_owner.Instance.CullingMask & 1 << this.m_obj.gameObject.layer) != 0;
      int num1 = flag ? this.m_owner.Instance.GenerateObjectId(this.m_obj.gameObject) : (int) byte.MaxValue;
      Matrix4x4 matrix4x4 = !this.m_obj.FixedStep ? this.m_owner.PrevViewProjMatrixRT * (Matrix4x4) this.m_prevLocalToWorld : this.m_owner.PrevViewProjMatrixRT * (Matrix4x4) this.m_currLocalToWorld;
      renderCB.SetGlobalMatrix("_AM_MATRIX_PREV_MVP", matrix4x4);
      renderCB.SetGlobalFloat("_AM_OBJECT_ID", (float) num1 * 0.003921569f);
      renderCB.SetGlobalFloat("_AM_MOTION_SCALE", flag ? scale : 0.0f);
      if (this.m_useGPU)
      {
        Vector4 vector4 = new Vector4(1f / (float) this.m_gpuVertexTexWidth, 1f / (float) this.m_gpuVertexTexHeight, (float) this.m_gpuVertexTexWidth, (float) this.m_gpuVertexTexHeight);
        renderCB.SetGlobalVector("_AM_VERTEX_TEXEL_SIZE", vector4);
        renderCB.SetGlobalVector("_AM_VERTEX_TEXEL_HALFSIZE", vector4 * 0.5f);
        renderCB.SetGlobalTexture("_AM_PREV_VERTEX_TEX", (RenderTargetIdentifier) (Texture) this.m_gpuPrevVertices);
        renderCB.SetGlobalTexture("_AM_CURR_VERTEX_TEX", (RenderTargetIdentifier) (Texture) this.m_gpuCurrVertices);
      }
      int num2 = (this.m_useGPU ? 4 : 0) + (quality == Quality.Mobile ? 0 : 2);
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
        renderCB.DrawMesh(this.m_clonedMesh, (Matrix4x4) this.m_currLocalToWorld, this.m_owner.Instance.SkinnedVectorsMaterial, submeshIndex, shaderPass, sharedMaterial.propertyBlock);
      }
    }
  }
}
