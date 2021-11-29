using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x02000579 RID: 1401
	[Serializable]
	internal abstract class MotionState
	{
		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x0600237D RID: 9085 RVA: 0x001F0CDF File Offset: 0x001EEEDF
		public AmplifyMotionCamera Owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x0600237E RID: 9086 RVA: 0x001F0CE7 File Offset: 0x001EEEE7
		public bool Initialized
		{
			get
			{
				return this.m_initialized;
			}
		}

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x0600237F RID: 9087 RVA: 0x001F0CEF File Offset: 0x001EEEEF
		public bool Error
		{
			get
			{
				return this.m_error;
			}
		}

		// Token: 0x06002380 RID: 9088 RVA: 0x001F0CF7 File Offset: 0x001EEEF7
		public MotionState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
		{
			this.m_error = false;
			this.m_initialized = false;
			this.m_owner = owner;
			this.m_obj = obj;
			this.m_transform = obj.transform;
		}

		// Token: 0x06002381 RID: 9089 RVA: 0x001F0D27 File Offset: 0x001EEF27
		internal virtual void Initialize()
		{
			this.m_initialized = true;
		}

		// Token: 0x06002382 RID: 9090 RVA: 0x001F0D30 File Offset: 0x001EEF30
		internal virtual void Shutdown()
		{
		}

		// Token: 0x06002383 RID: 9091 RVA: 0x001F0D32 File Offset: 0x001EEF32
		internal virtual void AsyncUpdate()
		{
		}

		// Token: 0x06002384 RID: 9092
		internal abstract void UpdateTransform(CommandBuffer updateCB, bool starting);

		// Token: 0x06002385 RID: 9093 RVA: 0x001F0D34 File Offset: 0x001EEF34
		internal virtual void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
		}

		// Token: 0x06002386 RID: 9094 RVA: 0x001F0D36 File Offset: 0x001EEF36
		internal virtual void RenderDebugHUD()
		{
		}

		// Token: 0x06002387 RID: 9095 RVA: 0x001F0D38 File Offset: 0x001EEF38
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

		// Token: 0x06002388 RID: 9096 RVA: 0x001F0E80 File Offset: 0x001EF080
		protected static bool MatrixChanged(MotionState.Matrix3x4 a, MotionState.Matrix3x4 b)
		{
			return Vector4.SqrMagnitude(new Vector4(a.m00 - b.m00, a.m01 - b.m01, a.m02 - b.m02, a.m03 - b.m03)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m10 - b.m10, a.m11 - b.m11, a.m12 - b.m12, a.m13 - b.m13)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m20 - b.m20, a.m21 - b.m21, a.m22 - b.m22, a.m23 - b.m23)) > 0f;
		}

		// Token: 0x06002389 RID: 9097 RVA: 0x001F0F64 File Offset: 0x001EF164
		protected static void MulPoint3x4_XYZ(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23;
		}

		// Token: 0x0600238A RID: 9098 RVA: 0x001F1014 File Offset: 0x001EF214
		protected static void MulPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x0600238B RID: 9099 RVA: 0x001F10D8 File Offset: 0x001EF2D8
		protected static void MulAddPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x += mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y += mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z += mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x04004AD1 RID: 19153
		public const int AsyncUpdateTimeout = 100;

		// Token: 0x04004AD2 RID: 19154
		protected bool m_error;

		// Token: 0x04004AD3 RID: 19155
		protected bool m_initialized;

		// Token: 0x04004AD4 RID: 19156
		protected Transform m_transform;

		// Token: 0x04004AD5 RID: 19157
		protected AmplifyMotionCamera m_owner;

		// Token: 0x04004AD6 RID: 19158
		protected AmplifyMotionObjectBase m_obj;

		// Token: 0x04004AD7 RID: 19159
		private static HashSet<Material> m_materialWarnings = new HashSet<Material>();

		// Token: 0x020006D0 RID: 1744
		protected struct MaterialDesc
		{
			// Token: 0x0400511D RID: 20765
			public Material material;

			// Token: 0x0400511E RID: 20766
			public MaterialPropertyBlock propertyBlock;

			// Token: 0x0400511F RID: 20767
			public bool coverage;

			// Token: 0x04005120 RID: 20768
			public bool cutoff;
		}

		// Token: 0x020006D1 RID: 1745
		protected struct Matrix3x4
		{
			// Token: 0x06002728 RID: 10024 RVA: 0x001FE798 File Offset: 0x001FC998
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

			// Token: 0x06002729 RID: 10025 RVA: 0x001FE824 File Offset: 0x001FCA24
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

			// Token: 0x0600272A RID: 10026 RVA: 0x001FE8D8 File Offset: 0x001FCAD8
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

			// Token: 0x0600272B RID: 10027 RVA: 0x001FE9B8 File Offset: 0x001FCBB8
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

			// Token: 0x04005121 RID: 20769
			public float m00;

			// Token: 0x04005122 RID: 20770
			public float m01;

			// Token: 0x04005123 RID: 20771
			public float m02;

			// Token: 0x04005124 RID: 20772
			public float m03;

			// Token: 0x04005125 RID: 20773
			public float m10;

			// Token: 0x04005126 RID: 20774
			public float m11;

			// Token: 0x04005127 RID: 20775
			public float m12;

			// Token: 0x04005128 RID: 20776
			public float m13;

			// Token: 0x04005129 RID: 20777
			public float m20;

			// Token: 0x0400512A RID: 20778
			public float m21;

			// Token: 0x0400512B RID: 20779
			public float m22;

			// Token: 0x0400512C RID: 20780
			public float m23;
		}
	}
}
