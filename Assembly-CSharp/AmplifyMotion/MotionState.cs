using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x0200057E RID: 1406
	[Serializable]
	internal abstract class MotionState
	{
		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x060023A2 RID: 9122 RVA: 0x001F4913 File Offset: 0x001F2B13
		public AmplifyMotionCamera Owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x060023A3 RID: 9123 RVA: 0x001F491B File Offset: 0x001F2B1B
		public bool Initialized
		{
			get
			{
				return this.m_initialized;
			}
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x060023A4 RID: 9124 RVA: 0x001F4923 File Offset: 0x001F2B23
		public bool Error
		{
			get
			{
				return this.m_error;
			}
		}

		// Token: 0x060023A5 RID: 9125 RVA: 0x001F492B File Offset: 0x001F2B2B
		public MotionState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
		{
			this.m_error = false;
			this.m_initialized = false;
			this.m_owner = owner;
			this.m_obj = obj;
			this.m_transform = obj.transform;
		}

		// Token: 0x060023A6 RID: 9126 RVA: 0x001F495B File Offset: 0x001F2B5B
		internal virtual void Initialize()
		{
			this.m_initialized = true;
		}

		// Token: 0x060023A7 RID: 9127 RVA: 0x001F4964 File Offset: 0x001F2B64
		internal virtual void Shutdown()
		{
		}

		// Token: 0x060023A8 RID: 9128 RVA: 0x001F4966 File Offset: 0x001F2B66
		internal virtual void AsyncUpdate()
		{
		}

		// Token: 0x060023A9 RID: 9129
		internal abstract void UpdateTransform(CommandBuffer updateCB, bool starting);

		// Token: 0x060023AA RID: 9130 RVA: 0x001F4968 File Offset: 0x001F2B68
		internal virtual void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
		}

		// Token: 0x060023AB RID: 9131 RVA: 0x001F496A File Offset: 0x001F2B6A
		internal virtual void RenderDebugHUD()
		{
		}

		// Token: 0x060023AC RID: 9132 RVA: 0x001F496C File Offset: 0x001F2B6C
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

		// Token: 0x060023AD RID: 9133 RVA: 0x001F4AB4 File Offset: 0x001F2CB4
		protected static bool MatrixChanged(MotionState.Matrix3x4 a, MotionState.Matrix3x4 b)
		{
			return Vector4.SqrMagnitude(new Vector4(a.m00 - b.m00, a.m01 - b.m01, a.m02 - b.m02, a.m03 - b.m03)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m10 - b.m10, a.m11 - b.m11, a.m12 - b.m12, a.m13 - b.m13)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m20 - b.m20, a.m21 - b.m21, a.m22 - b.m22, a.m23 - b.m23)) > 0f;
		}

		// Token: 0x060023AE RID: 9134 RVA: 0x001F4B98 File Offset: 0x001F2D98
		protected static void MulPoint3x4_XYZ(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23;
		}

		// Token: 0x060023AF RID: 9135 RVA: 0x001F4C48 File Offset: 0x001F2E48
		protected static void MulPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x060023B0 RID: 9136 RVA: 0x001F4D0C File Offset: 0x001F2F0C
		protected static void MulAddPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x += mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y += mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z += mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x04004B3F RID: 19263
		public const int AsyncUpdateTimeout = 100;

		// Token: 0x04004B40 RID: 19264
		protected bool m_error;

		// Token: 0x04004B41 RID: 19265
		protected bool m_initialized;

		// Token: 0x04004B42 RID: 19266
		protected Transform m_transform;

		// Token: 0x04004B43 RID: 19267
		protected AmplifyMotionCamera m_owner;

		// Token: 0x04004B44 RID: 19268
		protected AmplifyMotionObjectBase m_obj;

		// Token: 0x04004B45 RID: 19269
		private static HashSet<Material> m_materialWarnings = new HashSet<Material>();

		// Token: 0x020006D0 RID: 1744
		protected struct MaterialDesc
		{
			// Token: 0x04005169 RID: 20841
			public Material material;

			// Token: 0x0400516A RID: 20842
			public MaterialPropertyBlock propertyBlock;

			// Token: 0x0400516B RID: 20843
			public bool coverage;

			// Token: 0x0400516C RID: 20844
			public bool cutoff;
		}

		// Token: 0x020006D1 RID: 1745
		protected struct Matrix3x4
		{
			// Token: 0x06002739 RID: 10041 RVA: 0x00201D0C File Offset: 0x001FFF0C
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

			// Token: 0x0600273A RID: 10042 RVA: 0x00201D98 File Offset: 0x001FFF98
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

			// Token: 0x0600273B RID: 10043 RVA: 0x00201E4C File Offset: 0x0020004C
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

			// Token: 0x0600273C RID: 10044 RVA: 0x00201F2C File Offset: 0x0020012C
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

			// Token: 0x0400516D RID: 20845
			public float m00;

			// Token: 0x0400516E RID: 20846
			public float m01;

			// Token: 0x0400516F RID: 20847
			public float m02;

			// Token: 0x04005170 RID: 20848
			public float m03;

			// Token: 0x04005171 RID: 20849
			public float m10;

			// Token: 0x04005172 RID: 20850
			public float m11;

			// Token: 0x04005173 RID: 20851
			public float m12;

			// Token: 0x04005174 RID: 20852
			public float m13;

			// Token: 0x04005175 RID: 20853
			public float m20;

			// Token: 0x04005176 RID: 20854
			public float m21;

			// Token: 0x04005177 RID: 20855
			public float m22;

			// Token: 0x04005178 RID: 20856
			public float m23;
		}
	}
}
