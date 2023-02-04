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

		private Matrix3x4 m_prevLocalToWorld;

		private Matrix3x4 m_currLocalToWorld;

		private int m_targetVertexCount;

		private int[] m_targetRemap;

		private Vector3[] m_prevVertices;

		private Vector3[] m_currVertices;

		private Mesh m_clonedMesh;

		private MaterialDesc[] m_sharedMaterials;

		private bool m_starting;

		private bool m_wasVisible;

		private static HashSet<AmplifyMotionObjectBase> m_uniqueWarnings = new HashSet<AmplifyMotionObjectBase>();

		public ClothState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
			: base(owner, obj)
		{
			m_cloth = m_obj.GetComponent<Cloth>();
		}

		private void IssueError(string message)
		{
			if (!m_uniqueWarnings.Contains(m_obj))
			{
				Debug.LogWarning(message);
				m_uniqueWarnings.Add(m_obj);
			}
			m_error = true;
		}

		internal override void Initialize()
		{
			if (m_cloth.vertices == null)
			{
				IssueError("[AmplifyMotion] Invalid " + m_cloth.GetType().Name + " vertices in object " + m_obj.name + ". Skipping.");
				return;
			}
			Mesh sharedMesh = m_cloth.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh;
			if (sharedMesh == null || sharedMesh.vertices == null || sharedMesh.triangles == null)
			{
				IssueError("[AmplifyMotion] Invalid Mesh on Cloth-enabled object " + m_obj.name);
				return;
			}
			base.Initialize();
			m_renderer = m_cloth.gameObject.GetComponent<Renderer>();
			int vertexCount = sharedMesh.vertexCount;
			Vector3[] vertices = sharedMesh.vertices;
			Vector2[] uv = sharedMesh.uv;
			int[] triangles = sharedMesh.triangles;
			m_targetRemap = new int[vertexCount];
			if (m_cloth.vertices.Length == sharedMesh.vertices.Length)
			{
				for (int i = 0; i < vertexCount; i++)
				{
					m_targetRemap[i] = i;
				}
			}
			else
			{
				Dictionary<Vector3, int> dictionary = new Dictionary<Vector3, int>();
				int num = 0;
				for (int j = 0; j < vertexCount; j++)
				{
					if (dictionary.TryGetValue(vertices[j], out var value))
					{
						m_targetRemap[j] = value;
						continue;
					}
					m_targetRemap[j] = num;
					dictionary.Add(vertices[j], num++);
				}
			}
			m_targetVertexCount = vertexCount;
			m_prevVertices = new Vector3[m_targetVertexCount];
			m_currVertices = new Vector3[m_targetVertexCount];
			m_clonedMesh = new Mesh();
			m_clonedMesh.vertices = vertices;
			m_clonedMesh.normals = vertices;
			m_clonedMesh.uv = uv;
			m_clonedMesh.triangles = triangles;
			m_sharedMaterials = ProcessSharedMaterials(m_renderer.sharedMaterials);
			m_wasVisible = false;
		}

		internal override void Shutdown()
		{
			UnityEngine.Object.Destroy(m_clonedMesh);
		}

		internal override void UpdateTransform(CommandBuffer updateCB, bool starting)
		{
			if (!m_initialized)
			{
				Initialize();
				return;
			}
			if (!starting && m_wasVisible)
			{
				m_prevLocalToWorld = m_currLocalToWorld;
			}
			bool isVisible = m_renderer.isVisible;
			if (!m_error && (isVisible || starting) && !starting && m_wasVisible)
			{
				Array.Copy(m_currVertices, m_prevVertices, m_targetVertexCount);
			}
			m_currLocalToWorld = Matrix4x4.TRS(m_transform.position, m_transform.rotation, Vector3.one);
			if (starting || !m_wasVisible)
			{
				m_prevLocalToWorld = m_currLocalToWorld;
			}
			m_starting = starting;
			m_wasVisible = isVisible;
		}

		internal override void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
			if (!m_initialized || m_error || !m_renderer.isVisible)
			{
				return;
			}
			bool flag = ((int)m_owner.Instance.CullingMask & (1 << m_obj.gameObject.layer)) != 0;
			int num = (flag ? m_owner.Instance.GenerateObjectId(m_obj.gameObject) : 255);
			Vector3[] vertices = m_cloth.vertices;
			for (int i = 0; i < m_targetVertexCount; i++)
			{
				m_currVertices[i] = vertices[m_targetRemap[i]];
			}
			if (m_starting || !m_wasVisible)
			{
				Array.Copy(m_currVertices, m_prevVertices, m_targetVertexCount);
			}
			m_clonedMesh.vertices = m_currVertices;
			m_clonedMesh.normals = m_prevVertices;
			Matrix4x4 value = ((!m_obj.FixedStep) ? (m_owner.PrevViewProjMatrixRT * (Matrix4x4)m_prevLocalToWorld) : (m_owner.PrevViewProjMatrixRT * (Matrix4x4)m_currLocalToWorld));
			renderCB.SetGlobalMatrix("_AM_MATRIX_PREV_MVP", value);
			renderCB.SetGlobalFloat("_AM_OBJECT_ID", (float)num * 0.003921569f);
			renderCB.SetGlobalFloat("_AM_MOTION_SCALE", flag ? scale : 0f);
			int num2 = ((quality != 0) ? 2 : 0);
			for (int j = 0; j < m_sharedMaterials.Length; j++)
			{
				MaterialDesc materialDesc = m_sharedMaterials[j];
				int shaderPass = num2 + (materialDesc.coverage ? 1 : 0);
				if (materialDesc.coverage)
				{
					Texture mainTexture = materialDesc.material.mainTexture;
					if (mainTexture != null)
					{
						materialDesc.propertyBlock.SetTexture("_MainTex", mainTexture);
					}
					if (materialDesc.cutoff)
					{
						materialDesc.propertyBlock.SetFloat("_Cutoff", materialDesc.material.GetFloat("_Cutoff"));
					}
				}
				renderCB.DrawMesh(m_clonedMesh, m_currLocalToWorld, m_owner.Instance.ClothVectorsMaterial, j, shaderPass, materialDesc.propertyBlock);
			}
		}
	}
}
