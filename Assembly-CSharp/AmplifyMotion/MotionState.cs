using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x0200058D RID: 1421
	[Serializable]
	internal abstract class MotionState
	{
		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x06002408 RID: 9224 RVA: 0x001FDBD7 File Offset: 0x001FBDD7
		public AmplifyMotionCamera Owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06002409 RID: 9225 RVA: 0x001FDBDF File Offset: 0x001FBDDF
		public bool Initialized
		{
			get
			{
				return this.m_initialized;
			}
		}

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x0600240A RID: 9226 RVA: 0x001FDBE7 File Offset: 0x001FBDE7
		public bool Error
		{
			get
			{
				return this.m_error;
			}
		}

		// Token: 0x0600240B RID: 9227 RVA: 0x001FDBEF File Offset: 0x001FBDEF
		public MotionState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
		{
			this.m_error = false;
			this.m_initialized = false;
			this.m_owner = owner;
			this.m_obj = obj;
			this.m_transform = obj.transform;
		}

		// Token: 0x0600240C RID: 9228 RVA: 0x001FDC1F File Offset: 0x001FBE1F
		internal virtual void Initialize()
		{
			this.m_initialized = true;
		}

		// Token: 0x0600240D RID: 9229 RVA: 0x001FDC28 File Offset: 0x001FBE28
		internal virtual void Shutdown()
		{
		}

		// Token: 0x0600240E RID: 9230 RVA: 0x001FDC2A File Offset: 0x001FBE2A
		internal virtual void AsyncUpdate()
		{
		}

		// Token: 0x0600240F RID: 9231
		internal abstract void UpdateTransform(CommandBuffer updateCB, bool starting);

		// Token: 0x06002410 RID: 9232 RVA: 0x001FDC2C File Offset: 0x001FBE2C
		internal virtual void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
		}

		// Token: 0x06002411 RID: 9233 RVA: 0x001FDC2E File Offset: 0x001FBE2E
		internal virtual void RenderDebugHUD()
		{
		}

		// Token: 0x06002412 RID: 9234 RVA: 0x001FDC30 File Offset: 0x001FBE30
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

		// Token: 0x06002413 RID: 9235 RVA: 0x001FDD78 File Offset: 0x001FBF78
		protected static bool MatrixChanged(MotionState.Matrix3x4 a, MotionState.Matrix3x4 b)
		{
			return Vector4.SqrMagnitude(new Vector4(a.m00 - b.m00, a.m01 - b.m01, a.m02 - b.m02, a.m03 - b.m03)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m10 - b.m10, a.m11 - b.m11, a.m12 - b.m12, a.m13 - b.m13)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m20 - b.m20, a.m21 - b.m21, a.m22 - b.m22, a.m23 - b.m23)) > 0f;
		}

		// Token: 0x06002414 RID: 9236 RVA: 0x001FDE5C File Offset: 0x001FC05C
		protected static void MulPoint3x4_XYZ(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23;
		}

		// Token: 0x06002415 RID: 9237 RVA: 0x001FDF0C File Offset: 0x001FC10C
		protected static void MulPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x06002416 RID: 9238 RVA: 0x001FDFD0 File Offset: 0x001FC1D0
		protected static void MulAddPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x += mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y += mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z += mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x04004C62 RID: 19554
		public const int AsyncUpdateTimeout = 100;

		// Token: 0x04004C63 RID: 19555
		protected bool m_error;

		// Token: 0x04004C64 RID: 19556
		protected bool m_initialized;

		// Token: 0x04004C65 RID: 19557
		protected Transform m_transform;

		// Token: 0x04004C66 RID: 19558
		protected AmplifyMotionCamera m_owner;

		// Token: 0x04004C67 RID: 19559
		protected AmplifyMotionObjectBase m_obj;

		// Token: 0x04004C68 RID: 19560
		private static HashSet<Material> m_materialWarnings = new HashSet<Material>();

		// Token: 0x020006E1 RID: 1761
		protected struct MaterialDesc
		{
			// Token: 0x04005299 RID: 21145
			public Material material;

			// Token: 0x0400529A RID: 21146
			public MaterialPropertyBlock propertyBlock;

			// Token: 0x0400529B RID: 21147
			public bool coverage;

			// Token: 0x0400529C RID: 21148
			public bool cutoff;
		}

		// Token: 0x020006E2 RID: 1762
		protected struct Matrix3x4
		{
			// Token: 0x060027A8 RID: 10152 RVA: 0x0020B2FC File Offset: 0x002094FC
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

			// Token: 0x060027A9 RID: 10153 RVA: 0x0020B388 File Offset: 0x00209588
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

			// Token: 0x060027AA RID: 10154 RVA: 0x0020B43C File Offset: 0x0020963C
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

			// Token: 0x060027AB RID: 10155 RVA: 0x0020B51C File Offset: 0x0020971C
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

			// Token: 0x0400529D RID: 21149
			public float m00;

			// Token: 0x0400529E RID: 21150
			public float m01;

			// Token: 0x0400529F RID: 21151
			public float m02;

			// Token: 0x040052A0 RID: 21152
			public float m03;

			// Token: 0x040052A1 RID: 21153
			public float m10;

			// Token: 0x040052A2 RID: 21154
			public float m11;

			// Token: 0x040052A3 RID: 21155
			public float m12;

			// Token: 0x040052A4 RID: 21156
			public float m13;

			// Token: 0x040052A5 RID: 21157
			public float m20;

			// Token: 0x040052A6 RID: 21158
			public float m21;

			// Token: 0x040052A7 RID: 21159
			public float m22;

			// Token: 0x040052A8 RID: 21160
			public float m23;
		}
	}
}
