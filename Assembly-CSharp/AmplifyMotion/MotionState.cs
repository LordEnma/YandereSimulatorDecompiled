using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x02000585 RID: 1413
	[Serializable]
	internal abstract class MotionState
	{
		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060023D5 RID: 9173 RVA: 0x001F8803 File Offset: 0x001F6A03
		public AmplifyMotionCamera Owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060023D6 RID: 9174 RVA: 0x001F880B File Offset: 0x001F6A0B
		public bool Initialized
		{
			get
			{
				return this.m_initialized;
			}
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x060023D7 RID: 9175 RVA: 0x001F8813 File Offset: 0x001F6A13
		public bool Error
		{
			get
			{
				return this.m_error;
			}
		}

		// Token: 0x060023D8 RID: 9176 RVA: 0x001F881B File Offset: 0x001F6A1B
		public MotionState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
		{
			this.m_error = false;
			this.m_initialized = false;
			this.m_owner = owner;
			this.m_obj = obj;
			this.m_transform = obj.transform;
		}

		// Token: 0x060023D9 RID: 9177 RVA: 0x001F884B File Offset: 0x001F6A4B
		internal virtual void Initialize()
		{
			this.m_initialized = true;
		}

		// Token: 0x060023DA RID: 9178 RVA: 0x001F8854 File Offset: 0x001F6A54
		internal virtual void Shutdown()
		{
		}

		// Token: 0x060023DB RID: 9179 RVA: 0x001F8856 File Offset: 0x001F6A56
		internal virtual void AsyncUpdate()
		{
		}

		// Token: 0x060023DC RID: 9180
		internal abstract void UpdateTransform(CommandBuffer updateCB, bool starting);

		// Token: 0x060023DD RID: 9181 RVA: 0x001F8858 File Offset: 0x001F6A58
		internal virtual void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
		}

		// Token: 0x060023DE RID: 9182 RVA: 0x001F885A File Offset: 0x001F6A5A
		internal virtual void RenderDebugHUD()
		{
		}

		// Token: 0x060023DF RID: 9183 RVA: 0x001F885C File Offset: 0x001F6A5C
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

		// Token: 0x060023E0 RID: 9184 RVA: 0x001F89A4 File Offset: 0x001F6BA4
		protected static bool MatrixChanged(MotionState.Matrix3x4 a, MotionState.Matrix3x4 b)
		{
			return Vector4.SqrMagnitude(new Vector4(a.m00 - b.m00, a.m01 - b.m01, a.m02 - b.m02, a.m03 - b.m03)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m10 - b.m10, a.m11 - b.m11, a.m12 - b.m12, a.m13 - b.m13)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m20 - b.m20, a.m21 - b.m21, a.m22 - b.m22, a.m23 - b.m23)) > 0f;
		}

		// Token: 0x060023E1 RID: 9185 RVA: 0x001F8A88 File Offset: 0x001F6C88
		protected static void MulPoint3x4_XYZ(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23;
		}

		// Token: 0x060023E2 RID: 9186 RVA: 0x001F8B38 File Offset: 0x001F6D38
		protected static void MulPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x060023E3 RID: 9187 RVA: 0x001F8BFC File Offset: 0x001F6DFC
		protected static void MulAddPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x += mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y += mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z += mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x04004BDD RID: 19421
		public const int AsyncUpdateTimeout = 100;

		// Token: 0x04004BDE RID: 19422
		protected bool m_error;

		// Token: 0x04004BDF RID: 19423
		protected bool m_initialized;

		// Token: 0x04004BE0 RID: 19424
		protected Transform m_transform;

		// Token: 0x04004BE1 RID: 19425
		protected AmplifyMotionCamera m_owner;

		// Token: 0x04004BE2 RID: 19426
		protected AmplifyMotionObjectBase m_obj;

		// Token: 0x04004BE3 RID: 19427
		private static HashSet<Material> m_materialWarnings = new HashSet<Material>();

		// Token: 0x020006D9 RID: 1753
		protected struct MaterialDesc
		{
			// Token: 0x0400520C RID: 21004
			public Material material;

			// Token: 0x0400520D RID: 21005
			public MaterialPropertyBlock propertyBlock;

			// Token: 0x0400520E RID: 21006
			public bool coverage;

			// Token: 0x0400520F RID: 21007
			public bool cutoff;
		}

		// Token: 0x020006DA RID: 1754
		protected struct Matrix3x4
		{
			// Token: 0x06002775 RID: 10101 RVA: 0x00205CC4 File Offset: 0x00203EC4
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

			// Token: 0x06002776 RID: 10102 RVA: 0x00205D50 File Offset: 0x00203F50
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

			// Token: 0x06002777 RID: 10103 RVA: 0x00205E04 File Offset: 0x00204004
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

			// Token: 0x06002778 RID: 10104 RVA: 0x00205EE4 File Offset: 0x002040E4
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

			// Token: 0x04005210 RID: 21008
			public float m00;

			// Token: 0x04005211 RID: 21009
			public float m01;

			// Token: 0x04005212 RID: 21010
			public float m02;

			// Token: 0x04005213 RID: 21011
			public float m03;

			// Token: 0x04005214 RID: 21012
			public float m10;

			// Token: 0x04005215 RID: 21013
			public float m11;

			// Token: 0x04005216 RID: 21014
			public float m12;

			// Token: 0x04005217 RID: 21015
			public float m13;

			// Token: 0x04005218 RID: 21016
			public float m20;

			// Token: 0x04005219 RID: 21017
			public float m21;

			// Token: 0x0400521A RID: 21018
			public float m22;

			// Token: 0x0400521B RID: 21019
			public float m23;
		}
	}
}
