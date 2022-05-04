using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x0200058C RID: 1420
	[Serializable]
	internal abstract class MotionState
	{
		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060023FE RID: 9214 RVA: 0x001FC587 File Offset: 0x001FA787
		public AmplifyMotionCamera Owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x060023FF RID: 9215 RVA: 0x001FC58F File Offset: 0x001FA78F
		public bool Initialized
		{
			get
			{
				return this.m_initialized;
			}
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06002400 RID: 9216 RVA: 0x001FC597 File Offset: 0x001FA797
		public bool Error
		{
			get
			{
				return this.m_error;
			}
		}

		// Token: 0x06002401 RID: 9217 RVA: 0x001FC59F File Offset: 0x001FA79F
		public MotionState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
		{
			this.m_error = false;
			this.m_initialized = false;
			this.m_owner = owner;
			this.m_obj = obj;
			this.m_transform = obj.transform;
		}

		// Token: 0x06002402 RID: 9218 RVA: 0x001FC5CF File Offset: 0x001FA7CF
		internal virtual void Initialize()
		{
			this.m_initialized = true;
		}

		// Token: 0x06002403 RID: 9219 RVA: 0x001FC5D8 File Offset: 0x001FA7D8
		internal virtual void Shutdown()
		{
		}

		// Token: 0x06002404 RID: 9220 RVA: 0x001FC5DA File Offset: 0x001FA7DA
		internal virtual void AsyncUpdate()
		{
		}

		// Token: 0x06002405 RID: 9221
		internal abstract void UpdateTransform(CommandBuffer updateCB, bool starting);

		// Token: 0x06002406 RID: 9222 RVA: 0x001FC5DC File Offset: 0x001FA7DC
		internal virtual void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
		}

		// Token: 0x06002407 RID: 9223 RVA: 0x001FC5DE File Offset: 0x001FA7DE
		internal virtual void RenderDebugHUD()
		{
		}

		// Token: 0x06002408 RID: 9224 RVA: 0x001FC5E0 File Offset: 0x001FA7E0
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

		// Token: 0x06002409 RID: 9225 RVA: 0x001FC728 File Offset: 0x001FA928
		protected static bool MatrixChanged(MotionState.Matrix3x4 a, MotionState.Matrix3x4 b)
		{
			return Vector4.SqrMagnitude(new Vector4(a.m00 - b.m00, a.m01 - b.m01, a.m02 - b.m02, a.m03 - b.m03)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m10 - b.m10, a.m11 - b.m11, a.m12 - b.m12, a.m13 - b.m13)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m20 - b.m20, a.m21 - b.m21, a.m22 - b.m22, a.m23 - b.m23)) > 0f;
		}

		// Token: 0x0600240A RID: 9226 RVA: 0x001FC80C File Offset: 0x001FAA0C
		protected static void MulPoint3x4_XYZ(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23;
		}

		// Token: 0x0600240B RID: 9227 RVA: 0x001FC8BC File Offset: 0x001FAABC
		protected static void MulPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x0600240C RID: 9228 RVA: 0x001FC980 File Offset: 0x001FAB80
		protected static void MulAddPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x += mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y += mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z += mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x04004C3B RID: 19515
		public const int AsyncUpdateTimeout = 100;

		// Token: 0x04004C3C RID: 19516
		protected bool m_error;

		// Token: 0x04004C3D RID: 19517
		protected bool m_initialized;

		// Token: 0x04004C3E RID: 19518
		protected Transform m_transform;

		// Token: 0x04004C3F RID: 19519
		protected AmplifyMotionCamera m_owner;

		// Token: 0x04004C40 RID: 19520
		protected AmplifyMotionObjectBase m_obj;

		// Token: 0x04004C41 RID: 19521
		private static HashSet<Material> m_materialWarnings = new HashSet<Material>();

		// Token: 0x020006E0 RID: 1760
		protected struct MaterialDesc
		{
			// Token: 0x04005272 RID: 21106
			public Material material;

			// Token: 0x04005273 RID: 21107
			public MaterialPropertyBlock propertyBlock;

			// Token: 0x04005274 RID: 21108
			public bool coverage;

			// Token: 0x04005275 RID: 21109
			public bool cutoff;
		}

		// Token: 0x020006E1 RID: 1761
		protected struct Matrix3x4
		{
			// Token: 0x0600279E RID: 10142 RVA: 0x00209CAC File Offset: 0x00207EAC
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

			// Token: 0x0600279F RID: 10143 RVA: 0x00209D38 File Offset: 0x00207F38
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

			// Token: 0x060027A0 RID: 10144 RVA: 0x00209DEC File Offset: 0x00207FEC
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

			// Token: 0x060027A1 RID: 10145 RVA: 0x00209ECC File Offset: 0x002080CC
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

			// Token: 0x04005276 RID: 21110
			public float m00;

			// Token: 0x04005277 RID: 21111
			public float m01;

			// Token: 0x04005278 RID: 21112
			public float m02;

			// Token: 0x04005279 RID: 21113
			public float m03;

			// Token: 0x0400527A RID: 21114
			public float m10;

			// Token: 0x0400527B RID: 21115
			public float m11;

			// Token: 0x0400527C RID: 21116
			public float m12;

			// Token: 0x0400527D RID: 21117
			public float m13;

			// Token: 0x0400527E RID: 21118
			public float m20;

			// Token: 0x0400527F RID: 21119
			public float m21;

			// Token: 0x04005280 RID: 21120
			public float m22;

			// Token: 0x04005281 RID: 21121
			public float m23;
		}
	}
}
