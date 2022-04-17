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
		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060023F4 RID: 9204 RVA: 0x001FAFFF File Offset: 0x001F91FF
		public AmplifyMotionCamera Owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x060023F5 RID: 9205 RVA: 0x001FB007 File Offset: 0x001F9207
		public bool Initialized
		{
			get
			{
				return this.m_initialized;
			}
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x060023F6 RID: 9206 RVA: 0x001FB00F File Offset: 0x001F920F
		public bool Error
		{
			get
			{
				return this.m_error;
			}
		}

		// Token: 0x060023F7 RID: 9207 RVA: 0x001FB017 File Offset: 0x001F9217
		public MotionState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
		{
			this.m_error = false;
			this.m_initialized = false;
			this.m_owner = owner;
			this.m_obj = obj;
			this.m_transform = obj.transform;
		}

		// Token: 0x060023F8 RID: 9208 RVA: 0x001FB047 File Offset: 0x001F9247
		internal virtual void Initialize()
		{
			this.m_initialized = true;
		}

		// Token: 0x060023F9 RID: 9209 RVA: 0x001FB050 File Offset: 0x001F9250
		internal virtual void Shutdown()
		{
		}

		// Token: 0x060023FA RID: 9210 RVA: 0x001FB052 File Offset: 0x001F9252
		internal virtual void AsyncUpdate()
		{
		}

		// Token: 0x060023FB RID: 9211
		internal abstract void UpdateTransform(CommandBuffer updateCB, bool starting);

		// Token: 0x060023FC RID: 9212 RVA: 0x001FB054 File Offset: 0x001F9254
		internal virtual void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
		}

		// Token: 0x060023FD RID: 9213 RVA: 0x001FB056 File Offset: 0x001F9256
		internal virtual void RenderDebugHUD()
		{
		}

		// Token: 0x060023FE RID: 9214 RVA: 0x001FB058 File Offset: 0x001F9258
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

		// Token: 0x060023FF RID: 9215 RVA: 0x001FB1A0 File Offset: 0x001F93A0
		protected static bool MatrixChanged(MotionState.Matrix3x4 a, MotionState.Matrix3x4 b)
		{
			return Vector4.SqrMagnitude(new Vector4(a.m00 - b.m00, a.m01 - b.m01, a.m02 - b.m02, a.m03 - b.m03)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m10 - b.m10, a.m11 - b.m11, a.m12 - b.m12, a.m13 - b.m13)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m20 - b.m20, a.m21 - b.m21, a.m22 - b.m22, a.m23 - b.m23)) > 0f;
		}

		// Token: 0x06002400 RID: 9216 RVA: 0x001FB284 File Offset: 0x001F9484
		protected static void MulPoint3x4_XYZ(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23;
		}

		// Token: 0x06002401 RID: 9217 RVA: 0x001FB334 File Offset: 0x001F9534
		protected static void MulPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x06002402 RID: 9218 RVA: 0x001FB3F8 File Offset: 0x001F95F8
		protected static void MulAddPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x += mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y += mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z += mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x04004C25 RID: 19493
		public const int AsyncUpdateTimeout = 100;

		// Token: 0x04004C26 RID: 19494
		protected bool m_error;

		// Token: 0x04004C27 RID: 19495
		protected bool m_initialized;

		// Token: 0x04004C28 RID: 19496
		protected Transform m_transform;

		// Token: 0x04004C29 RID: 19497
		protected AmplifyMotionCamera m_owner;

		// Token: 0x04004C2A RID: 19498
		protected AmplifyMotionObjectBase m_obj;

		// Token: 0x04004C2B RID: 19499
		private static HashSet<Material> m_materialWarnings = new HashSet<Material>();

		// Token: 0x020006DF RID: 1759
		protected struct MaterialDesc
		{
			// Token: 0x04005254 RID: 21076
			public Material material;

			// Token: 0x04005255 RID: 21077
			public MaterialPropertyBlock propertyBlock;

			// Token: 0x04005256 RID: 21078
			public bool coverage;

			// Token: 0x04005257 RID: 21079
			public bool cutoff;
		}

		// Token: 0x020006E0 RID: 1760
		protected struct Matrix3x4
		{
			// Token: 0x06002794 RID: 10132 RVA: 0x00208610 File Offset: 0x00206810
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

			// Token: 0x06002795 RID: 10133 RVA: 0x0020869C File Offset: 0x0020689C
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

			// Token: 0x06002796 RID: 10134 RVA: 0x00208750 File Offset: 0x00206950
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

			// Token: 0x06002797 RID: 10135 RVA: 0x00208830 File Offset: 0x00206A30
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

			// Token: 0x04005258 RID: 21080
			public float m00;

			// Token: 0x04005259 RID: 21081
			public float m01;

			// Token: 0x0400525A RID: 21082
			public float m02;

			// Token: 0x0400525B RID: 21083
			public float m03;

			// Token: 0x0400525C RID: 21084
			public float m10;

			// Token: 0x0400525D RID: 21085
			public float m11;

			// Token: 0x0400525E RID: 21086
			public float m12;

			// Token: 0x0400525F RID: 21087
			public float m13;

			// Token: 0x04005260 RID: 21088
			public float m20;

			// Token: 0x04005261 RID: 21089
			public float m21;

			// Token: 0x04005262 RID: 21090
			public float m22;

			// Token: 0x04005263 RID: 21091
			public float m23;
		}
	}
}
