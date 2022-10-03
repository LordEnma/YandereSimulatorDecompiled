// Decompiled with JetBrains decompiler
// Type: AmplifyMotion.ParticleState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
  internal class ParticleState : MotionState
  {
    public ParticleSystem m_particleSystem;
    public ParticleSystemRenderer m_renderer;
    private Mesh m_mesh;
    private ParticleSystem.RotationOverLifetimeModule rotationOverLifetime;
    private ParticleSystem.RotationBySpeedModule rotationBySpeed;
    private ParticleSystem.Particle[] m_particles;
    private Dictionary<uint, ParticleState.Particle> m_particleDict;
    private List<uint> m_listToRemove;
    private Stack<ParticleState.Particle> m_particleStack;
    private int m_capacity;
    private MotionState.MaterialDesc[] m_sharedMaterials;
    private bool m_moved;
    private bool m_wasVisible;
    private static HashSet<AmplifyMotionObjectBase> m_uniqueWarnings = new HashSet<AmplifyMotionObjectBase>();

    public ParticleState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
      : base(owner, obj)
    {
      this.m_particleSystem = this.m_obj.GetComponent<ParticleSystem>();
      this.m_renderer = this.m_particleSystem.GetComponent<ParticleSystemRenderer>();
      this.rotationOverLifetime = this.m_particleSystem.rotationOverLifetime;
      this.rotationBySpeed = this.m_particleSystem.rotationBySpeed;
    }

    private void IssueError(string message)
    {
      if (!ParticleState.m_uniqueWarnings.Contains(this.m_obj))
      {
        Debug.LogWarning((object) message);
        ParticleState.m_uniqueWarnings.Add(this.m_obj);
      }
      this.m_error = true;
    }

    private Mesh CreateBillboardMesh()
    {
      int[] numArray = new int[6]{ 0, 1, 2, 2, 3, 0 };
      Vector3[] vector3Array = new Vector3[4]
      {
        new Vector3(-0.5f, -0.5f, 0.0f),
        new Vector3(0.5f, -0.5f, 0.0f),
        new Vector3(0.5f, 0.5f, 0.0f),
        new Vector3(-0.5f, 0.5f, 0.0f)
      };
      Vector2[] vector2Array = new Vector2[4]
      {
        new Vector2(0.0f, 0.0f),
        new Vector2(1f, 0.0f),
        new Vector2(1f, 1f),
        new Vector2(0.0f, 1f)
      };
      return new Mesh()
      {
        vertices = vector3Array,
        uv = vector2Array,
        triangles = numArray
      };
    }

    private Mesh CreateStretchedBillboardMesh()
    {
      int[] numArray = new int[6]{ 0, 1, 2, 2, 3, 0 };
      Vector3[] vector3Array = new Vector3[4]
      {
        new Vector3(0.0f, -0.5f, -1f),
        new Vector3(0.0f, -0.5f, 0.0f),
        new Vector3(0.0f, 0.5f, 0.0f),
        new Vector3(0.0f, 0.5f, -1f)
      };
      Vector2[] vector2Array = new Vector2[4]
      {
        new Vector2(1f, 1f),
        new Vector2(0.0f, 1f),
        new Vector2(0.0f, 0.0f),
        new Vector2(1f, 0.0f)
      };
      return new Mesh()
      {
        vertices = vector3Array,
        uv = vector2Array,
        triangles = numArray
      };
    }

    internal override void Initialize()
    {
      if ((Object) this.m_renderer == (Object) null)
      {
        this.IssueError("[AmplifyMotion] Missing/Invalid Particle Renderer in object " + this.m_obj.name + ". Skipping.");
      }
      else
      {
        base.Initialize();
        this.m_mesh = this.m_renderer.renderMode != ParticleSystemRenderMode.Mesh ? (this.m_renderer.renderMode != ParticleSystemRenderMode.Stretch ? this.CreateBillboardMesh() : this.CreateStretchedBillboardMesh()) : this.m_renderer.mesh;
        this.m_sharedMaterials = this.ProcessSharedMaterials(this.m_renderer.sharedMaterials);
        this.m_capacity = this.m_particleSystem.main.maxParticles;
        this.m_particleDict = new Dictionary<uint, ParticleState.Particle>(this.m_capacity);
        this.m_particles = new ParticleSystem.Particle[this.m_capacity];
        this.m_listToRemove = new List<uint>(this.m_capacity);
        this.m_particleStack = new Stack<ParticleState.Particle>(this.m_capacity);
        for (int index = 0; index < this.m_capacity; ++index)
          this.m_particleStack.Push(new ParticleState.Particle());
        this.m_wasVisible = false;
      }
    }

    private void RemoveDeadParticles()
    {
      this.m_listToRemove.Clear();
      Dictionary<uint, ParticleState.Particle>.Enumerator enumerator = this.m_particleDict.GetEnumerator();
      while (enumerator.MoveNext())
      {
        KeyValuePair<uint, ParticleState.Particle> current = enumerator.Current;
        if (current.Value.refCount <= 0)
        {
          this.m_particleStack.Push(current.Value);
          if (!this.m_listToRemove.Contains(current.Key))
            this.m_listToRemove.Add(current.Key);
        }
        else
          current.Value.refCount = 0;
      }
      for (int index = 0; index < this.m_listToRemove.Count; ++index)
        this.m_particleDict.Remove(this.m_listToRemove[index]);
    }

    internal override void UpdateTransform(CommandBuffer updateCB, bool starting)
    {
      int maxParticles = this.m_particleSystem.main.maxParticles;
      if (!this.m_initialized || this.m_capacity != maxParticles)
      {
        this.Initialize();
      }
      else
      {
        KeyValuePair<uint, ParticleState.Particle> current;
        if (!starting && this.m_wasVisible)
        {
          Dictionary<uint, ParticleState.Particle>.Enumerator enumerator = this.m_particleDict.GetEnumerator();
          while (enumerator.MoveNext())
          {
            current = enumerator.Current;
            ParticleState.Particle particle = current.Value;
            particle.prevLocalToWorld = particle.currLocalToWorld;
          }
        }
        this.m_moved = true;
        int particles = this.m_particleSystem.GetParticles(this.m_particles);
        Matrix4x4 matrix4x4_1 = Matrix4x4.TRS(this.m_transform.position, this.m_transform.rotation, Vector3.one);
        bool flag1 = this.rotationOverLifetime.enabled && this.rotationOverLifetime.separateAxes || this.rotationBySpeed.enabled && this.rotationBySpeed.separateAxes;
        for (int index = 0; index < particles; ++index)
        {
          uint randomSeed = this.m_particles[index].randomSeed;
          bool flag2 = false;
          ParticleState.Particle particle;
          if (!this.m_particleDict.TryGetValue(randomSeed, out particle) && this.m_particleStack.Count > 0)
          {
            this.m_particleDict[randomSeed] = particle = this.m_particleStack.Pop();
            flag2 = true;
          }
          if (particle != null)
          {
            float currentSize = this.m_particles[index].GetCurrentSize(this.m_particleSystem);
            Vector3 s = new Vector3(currentSize, currentSize, currentSize);
            ParticleSystem.MainModule main;
            Matrix4x4 matrix4x4_2;
            if (this.m_renderer.renderMode == ParticleSystemRenderMode.Mesh)
            {
              Quaternion q = !flag1 ? Quaternion.AngleAxis(this.m_particles[index].rotation, this.m_particles[index].axisOfRotation) : Quaternion.Euler(this.m_particles[index].rotation3D);
              Matrix4x4 matrix4x4_3 = Matrix4x4.TRS(this.m_particles[index].position, q, s);
              main = this.m_particleSystem.main;
              matrix4x4_2 = main.simulationSpace != ParticleSystemSimulationSpace.World ? matrix4x4_1 * matrix4x4_3 : matrix4x4_3;
            }
            else if (this.m_renderer.renderMode == ParticleSystemRenderMode.Billboard)
            {
              main = this.m_particleSystem.main;
              if (main.simulationSpace == ParticleSystemSimulationSpace.Local)
                this.m_particles[index].position = matrix4x4_1.MultiplyPoint(this.m_particles[index].position);
              Quaternion quaternion = !flag1 ? Quaternion.AngleAxis(this.m_particles[index].rotation, Vector3.back) : Quaternion.Euler(-this.m_particles[index].rotation3D.x, -this.m_particles[index].rotation3D.y, this.m_particles[index].rotation3D.z);
              matrix4x4_2 = Matrix4x4.TRS(this.m_particles[index].position, this.m_owner.Transform.rotation * quaternion, s);
            }
            else
              matrix4x4_2 = Matrix4x4.identity;
            particle.refCount = 1;
            particle.currLocalToWorld = (MotionState.Matrix3x4) matrix4x4_2;
            if (flag2)
              particle.prevLocalToWorld = particle.currLocalToWorld;
          }
        }
        if (starting || !this.m_wasVisible)
        {
          Dictionary<uint, ParticleState.Particle>.Enumerator enumerator = this.m_particleDict.GetEnumerator();
          while (enumerator.MoveNext())
          {
            current = enumerator.Current;
            ParticleState.Particle particle = current.Value;
            particle.prevLocalToWorld = particle.currLocalToWorld;
          }
        }
        this.RemoveDeadParticles();
        this.m_wasVisible = this.m_renderer.isVisible;
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
      if (flag && (!flag || !this.m_moved))
        return;
      int num1 = flag ? this.m_owner.Instance.GenerateObjectId(this.m_obj.gameObject) : (int) byte.MaxValue;
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
        Dictionary<uint, ParticleState.Particle>.Enumerator enumerator = this.m_particleDict.GetEnumerator();
        while (enumerator.MoveNext())
        {
          KeyValuePair<uint, ParticleState.Particle> current = enumerator.Current;
          Matrix4x4 matrix4x4 = this.m_owner.PrevViewProjMatrixRT * (Matrix4x4) current.Value.prevLocalToWorld;
          renderCB.SetGlobalMatrix("_AM_MATRIX_PREV_MVP", matrix4x4);
          renderCB.DrawMesh(this.m_mesh, (Matrix4x4) current.Value.currLocalToWorld, this.m_owner.Instance.SolidVectorsMaterial, submeshIndex, shaderPass, sharedMaterial.propertyBlock);
        }
      }
    }

    protected class Particle
    {
      public int refCount;
      public MotionState.Matrix3x4 prevLocalToWorld;
      public MotionState.Matrix3x4 currLocalToWorld;
    }
  }
}
