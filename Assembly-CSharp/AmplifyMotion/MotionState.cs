using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x0200058B RID: 1419
	[Serializable]
	internal abstract class MotionState
	{
		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060023ED RID: 9197 RVA: 0x001FA5A3 File Offset: 0x001F87A3
		public AmplifyMotionCamera Owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060023EE RID: 9198 RVA: 0x001FA5AB File Offset: 0x001F87AB
		public bool Initialized
		{
			get
			{
				return this.m_initialized;
			}
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x060023EF RID: 9199 RVA: 0x001FA5B3 File Offset: 0x001F87B3
		public bool Error
		{
			get
			{
				return this.m_error;
			}
		}

		// Token: 0x060023F0 RID: 9200 RVA: 0x001FA5BB File Offset: 0x001F87BB
		public MotionState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
		{
			this.m_error = false;
			this.m_initialized = false;
			this.m_owner = owner;
			this.m_obj = obj;
			this.m_transform = obj.transform;
		}

		// Token: 0x060023F1 RID: 9201 RVA: 0x001FA5EB File Offset: 0x001F87EB
		internal virtual void Initialize()
		{
			this.m_initialized = true;
		}

		// Token: 0x060023F2 RID: 9202 RVA: 0x001FA5F4 File Offset: 0x001F87F4
		internal virtual void Shutdown()
		{
		}

		// Token: 0x060023F3 RID: 9203 RVA: 0x001FA5F6 File Offset: 0x001F87F6
		internal virtual void AsyncUpdate()
		{
		}

		// Token: 0x060023F4 RID: 9204
		internal abstract void UpdateTransform(CommandBuffer updateCB, bool starting);

		// Token: 0x060023F5 RID: 9205 RVA: 0x001FA5F8 File Offset: 0x001F87F8
		internal virtual void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
		}

		// Token: 0x060023F6 RID: 9206 RVA: 0x001FA5FA File Offset: 0x001F87FA
		internal virtual void RenderDebugHUD()
		{
		}

		// Token: 0x060023F7 RID: 9207 RVA: 0x001FA5FC File Offset: 0x001F87FC
		protected MotionState.MaterialDesc[] ProcessSharedMaterials(Material[] mats)
		{
			MotionState.MaterialDesc[] array = new MotionState.MaterialDesc[mats.Length];
			for (int i = 0; i < mats.Length; i++)
			{
				array[i].material = mats[i];
				bool flag = mats[i].GetTag("RenderType", false) == "TransparentCutout" || mats[i].IsKeywordEnabled("_ALPHATEST_ON");
				array[i].propertyBlock = new MaterialPropertyBlock();
				array[i].coverage = (mats[i].HasProperty("_MainTex") && flag);
				array[i].cutoff = mats[i].HasProperty("_Cutoff");
				if (flag && !array[i].coverage && !MotionState.m_materialWarnings.Contains(array[i].material))
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"[AmplifyMotion] TransparentCutout material \"",
						array[i].material.name,
						"\" {",
						array[i].material.shader.name,
						"} not using _MainTex standard property."
					}));
					MotionState.m_materialWarnings.Add(array[i].material);
				}
			}
			return array;
		}

		// Token: 0x060023F8 RID: 9208 RVA: 0x001FA744 File Offset: 0x001F8944
		protected static bool MatrixChanged(MotionState.Matrix3x4 a, MotionState.Matrix3x4 b)
		{
			return Vector4.SqrMagnitude(new Vector4(a.m00 - b.m00, a.m01 - b.m01, a.m02 - b.m02, a.m03 - b.m03)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m10 - b.m10, a.m11 - b.m11, a.m12 - b.m12, a.m13 - b.m13)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m20 - b.m20, a.m21 - b.m21, a.m22 - b.m22, a.m23 - b.m23)) > 0f;
		}

		// Token: 0x060023F9 RID: 9209 RVA: 0x001FA828 File Offset: 0x001F8A28
		protected static void MulPoint3x4_XYZ(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23;
		}

		// Token: 0x060023FA RID: 9210 RVA: 0x001FA8D8 File Offset: 0x001F8AD8
		protected static void MulPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x060023FB RID: 9211 RVA: 0x001FA99C File Offset: 0x001F8B9C
		protected static void MulAddPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x += mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y += mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z += mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x04004C13 RID: 19475
		public const int AsyncUpdateTimeout = 100;

		// Token: 0x04004C14 RID: 19476
		protected bool m_error;

		// Token: 0x04004C15 RID: 19477
		protected bool m_initialized;

		// Token: 0x04004C16 RID: 19478
		protected Transform m_transform;

		// Token: 0x04004C17 RID: 19479
		protected AmplifyMotionCamera m_owner;

		// Token: 0x04004C18 RID: 19480
		protected AmplifyMotionObjectBase m_obj;

		// Token: 0x04004C19 RID: 19481
		private static HashSet<Material> m_materialWarnings = new HashSet<Material>();

		// Token: 0x020006DF RID: 1759
		protected struct MaterialDesc
		{
			// Token: 0x04005242 RID: 21058
			public Material material;

			// Token: 0x04005243 RID: 21059
			public MaterialPropertyBlock propertyBlock;

			// Token: 0x04005244 RID: 21060
			public bool coverage;

			// Token: 0x04005245 RID: 21061
			public bool cutoff;
		}

		// Token: 0x020006E0 RID: 1760
		protected struct Matrix3x4
		{
			// Token: 0x0600278D RID: 10125 RVA: 0x00207BB4 File Offset: 0x00205DB4
			public Vector4 GetRow(int i)
			{
				if (i == 0)
				{
					return new Vector4(this.m00, this.m01, this.m02, this.m03);
				}
				if (i == 1)
				{
					return new Vector4(this.m10, this.m11, this.m12, this.m13);
				}
				if (i == 2)
				{
					return new Vector4(this.m20, this.m21, this.m22, this.m23);
				}
				return new Vector4(0f, 0f, 0f, 1f);
			}

			// Token: 0x0600278E RID: 10126 RVA: 0x00207C40 File Offset: 0x00205E40
			public static implicit operator MotionState.Matrix3x4(Matrix4x4 from)
			{
				return new MotionState.Matrix3x4
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

			// Token: 0x0600278F RID: 10127 RVA: 0x00207CF4 File Offset: 0x00205EF4
			public static implicit operator Matrix4x4(MotionState.Matrix3x4 from)
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

			// Token: 0x06002790 RID: 10128 RVA: 0x00207DD4 File Offset: 0x00205FD4
			public static MotionState.Matrix3x4 operator *(MotionState.Matrix3x4 a, MotionState.Matrix3x4 b)
			{
				return new MotionState.Matrix3x4
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

			// Token: 0x04005246 RID: 21062
			public float m00;

			// Token: 0x04005247 RID: 21063
			public float m01;

			// Token: 0x04005248 RID: 21064
			public float m02;

			// Token: 0x04005249 RID: 21065
			public float m03;

			// Token: 0x0400524A RID: 21066
			public float m10;

			// Token: 0x0400524B RID: 21067
			public float m11;

			// Token: 0x0400524C RID: 21068
			public float m12;

			// Token: 0x0400524D RID: 21069
			public float m13;

			// Token: 0x0400524E RID: 21070
			public float m20;

			// Token: 0x0400524F RID: 21071
			public float m21;

			// Token: 0x04005250 RID: 21072
			public float m22;

			// Token: 0x04005251 RID: 21073
			public float m23;
		}
	}
}
