using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	[Serializable]
	internal abstract class MotionState
	{
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
				return i switch
				{
					0 => new Vector4(m00, m01, m02, m03), 
					1 => new Vector4(m10, m11, m12, m13), 
					2 => new Vector4(m20, m21, m22, m23), 
					_ => new Vector4(0f, 0f, 0f, 1f), 
				};
			}

			public static implicit operator Matrix3x4(Matrix4x4 from)
			{
				return new Matrix3x4
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
			}

			public static implicit operator Matrix4x4(Matrix3x4 from)
			{
				Matrix4x4 result = default(Matrix4x4);
				result.m00 = from.m00;
				result.m01 = from.m01;
				result.m02 = from.m02;
				result.m03 = from.m03;
				result.m10 = from.m10;
				result.m11 = from.m11;
				result.m12 = from.m12;
				result.m13 = from.m13;
				result.m20 = from.m20;
				result.m21 = from.m21;
				result.m22 = from.m22;
				result.m23 = from.m23;
				result.m30 = (result.m31 = (result.m32 = 0f));
				result.m33 = 1f;
				return result;
			}

			public static Matrix3x4 operator *(Matrix3x4 a, Matrix3x4 b)
			{
				return new Matrix3x4
				{
					m00 = a.m00 * b.m00 + a.m01 * b.m10 + a.m02 * b.m20,
					m01 = a.m00 * b.m01 + a.m01 * b.m11 + a.m02 * b.m21,
					m02 = a.m00 * b.m02 + a.m01 * b.m12 + a.m02 * b.m22,
					m03 = a.m00 * b.m03 + a.m01 * b.m13 + a.m02 * b.m23 + a.m03,
					m10 = a.m10 * b.m00 + a.m11 * b.m10 + a.m12 * b.m20,
					m11 = a.m10 * b.m01 + a.m11 * b.m11 + a.m12 * b.m21,
					m12 = a.m10 * b.m02 + a.m11 * b.m12 + a.m12 * b.m22,
					m13 = a.m10 * b.m03 + a.m11 * b.m13 + a.m12 * b.m23 + a.m13,
					m20 = a.m20 * b.m00 + a.m21 * b.m10 + a.m22 * b.m20,
					m21 = a.m20 * b.m01 + a.m21 * b.m11 + a.m22 * b.m21,
					m22 = a.m20 * b.m02 + a.m21 * b.m12 + a.m22 * b.m22,
					m23 = a.m20 * b.m03 + a.m21 * b.m13 + a.m22 * b.m23 + a.m23
				};
			}
		}

		public const int AsyncUpdateTimeout = 100;

		protected bool m_error;

		protected bool m_initialized;

		protected Transform m_transform;

		protected AmplifyMotionCamera m_owner;

		protected AmplifyMotionObjectBase m_obj;

		private static HashSet<Material> m_materialWarnings = new HashSet<Material>();

		public AmplifyMotionCamera Owner => m_owner;

		public bool Initialized => m_initialized;

		public bool Error => m_error;

		public MotionState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
		{
			m_error = false;
			m_initialized = false;
			m_owner = owner;
			m_obj = obj;
			m_transform = obj.transform;
		}

		internal virtual void Initialize()
		{
			m_initialized = true;
		}

		internal virtual void Shutdown()
		{
		}

		internal virtual void AsyncUpdate()
		{
		}

		internal abstract void UpdateTransform(CommandBuffer updateCB, bool starting);

		internal virtual void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
		}

		internal virtual void RenderDebugHUD()
		{
		}

		protected MaterialDesc[] ProcessSharedMaterials(Material[] mats)
		{
			MaterialDesc[] array = new MaterialDesc[mats.Length];
			for (int i = 0; i < mats.Length; i++)
			{
				array[i].material = mats[i];
				bool flag = mats[i].GetTag("RenderType", searchFallbacks: false) == "TransparentCutout" || mats[i].IsKeywordEnabled("_ALPHATEST_ON");
				array[i].propertyBlock = new MaterialPropertyBlock();
				array[i].coverage = mats[i].HasProperty("_MainTex") && flag;
				array[i].cutoff = mats[i].HasProperty("_Cutoff");
				if (flag && !array[i].coverage && !m_materialWarnings.Contains(array[i].material))
				{
					Debug.LogWarning("[AmplifyMotion] TransparentCutout material \"" + array[i].material.name + "\" {" + array[i].material.shader.name + "} not using _MainTex standard property.");
					m_materialWarnings.Add(array[i].material);
				}
			}
			return array;
		}

		protected static bool MatrixChanged(Matrix3x4 a, Matrix3x4 b)
		{
			if (Vector4.SqrMagnitude(new Vector4(a.m00 - b.m00, a.m01 - b.m01, a.m02 - b.m02, a.m03 - b.m03)) > 0f)
			{
				return true;
			}
			if (Vector4.SqrMagnitude(new Vector4(a.m10 - b.m10, a.m11 - b.m11, a.m12 - b.m12, a.m13 - b.m13)) > 0f)
			{
				return true;
			}
			if (Vector4.SqrMagnitude(new Vector4(a.m20 - b.m20, a.m21 - b.m21, a.m22 - b.m22, a.m23 - b.m23)) > 0f)
			{
				return true;
			}
			return false;
		}

		protected static void MulPoint3x4_XYZ(ref Vector3 result, ref Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23;
		}

		protected static void MulPoint3x4_XYZW(ref Vector3 result, ref Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		protected static void MulAddPoint3x4_XYZW(ref Vector3 result, ref Matrix3x4 mat, Vector4 vec)
		{
			result.x += mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y += mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z += mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}
	}
}
