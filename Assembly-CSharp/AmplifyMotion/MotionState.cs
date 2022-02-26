using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x02000580 RID: 1408
	[Serializable]
	internal abstract class MotionState
	{
		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x060023B7 RID: 9143 RVA: 0x001F5EC3 File Offset: 0x001F40C3
		public AmplifyMotionCamera Owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060023B8 RID: 9144 RVA: 0x001F5ECB File Offset: 0x001F40CB
		public bool Initialized
		{
			get
			{
				return this.m_initialized;
			}
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060023B9 RID: 9145 RVA: 0x001F5ED3 File Offset: 0x001F40D3
		public bool Error
		{
			get
			{
				return this.m_error;
			}
		}

		// Token: 0x060023BA RID: 9146 RVA: 0x001F5EDB File Offset: 0x001F40DB
		public MotionState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
		{
			this.m_error = false;
			this.m_initialized = false;
			this.m_owner = owner;
			this.m_obj = obj;
			this.m_transform = obj.transform;
		}

		// Token: 0x060023BB RID: 9147 RVA: 0x001F5F0B File Offset: 0x001F410B
		internal virtual void Initialize()
		{
			this.m_initialized = true;
		}

		// Token: 0x060023BC RID: 9148 RVA: 0x001F5F14 File Offset: 0x001F4114
		internal virtual void Shutdown()
		{
		}

		// Token: 0x060023BD RID: 9149 RVA: 0x001F5F16 File Offset: 0x001F4116
		internal virtual void AsyncUpdate()
		{
		}

		// Token: 0x060023BE RID: 9150
		internal abstract void UpdateTransform(CommandBuffer updateCB, bool starting);

		// Token: 0x060023BF RID: 9151 RVA: 0x001F5F18 File Offset: 0x001F4118
		internal virtual void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
		}

		// Token: 0x060023C0 RID: 9152 RVA: 0x001F5F1A File Offset: 0x001F411A
		internal virtual void RenderDebugHUD()
		{
		}

		// Token: 0x060023C1 RID: 9153 RVA: 0x001F5F1C File Offset: 0x001F411C
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

		// Token: 0x060023C2 RID: 9154 RVA: 0x001F6064 File Offset: 0x001F4264
		protected static bool MatrixChanged(MotionState.Matrix3x4 a, MotionState.Matrix3x4 b)
		{
			return Vector4.SqrMagnitude(new Vector4(a.m00 - b.m00, a.m01 - b.m01, a.m02 - b.m02, a.m03 - b.m03)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m10 - b.m10, a.m11 - b.m11, a.m12 - b.m12, a.m13 - b.m13)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m20 - b.m20, a.m21 - b.m21, a.m22 - b.m22, a.m23 - b.m23)) > 0f;
		}

		// Token: 0x060023C3 RID: 9155 RVA: 0x001F6148 File Offset: 0x001F4348
		protected static void MulPoint3x4_XYZ(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23;
		}

		// Token: 0x060023C4 RID: 9156 RVA: 0x001F61F8 File Offset: 0x001F43F8
		protected static void MulPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x060023C5 RID: 9157 RVA: 0x001F62BC File Offset: 0x001F44BC
		protected static void MulAddPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x += mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y += mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z += mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x04004B61 RID: 19297
		public const int AsyncUpdateTimeout = 100;

		// Token: 0x04004B62 RID: 19298
		protected bool m_error;

		// Token: 0x04004B63 RID: 19299
		protected bool m_initialized;

		// Token: 0x04004B64 RID: 19300
		protected Transform m_transform;

		// Token: 0x04004B65 RID: 19301
		protected AmplifyMotionCamera m_owner;

		// Token: 0x04004B66 RID: 19302
		protected AmplifyMotionObjectBase m_obj;

		// Token: 0x04004B67 RID: 19303
		private static HashSet<Material> m_materialWarnings = new HashSet<Material>();

		// Token: 0x020006D4 RID: 1748
		protected struct MaterialDesc
		{
			// Token: 0x04005190 RID: 20880
			public Material material;

			// Token: 0x04005191 RID: 20881
			public MaterialPropertyBlock propertyBlock;

			// Token: 0x04005192 RID: 20882
			public bool coverage;

			// Token: 0x04005193 RID: 20883
			public bool cutoff;
		}

		// Token: 0x020006D5 RID: 1749
		protected struct Matrix3x4
		{
			// Token: 0x06002757 RID: 10071 RVA: 0x00203384 File Offset: 0x00201584
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

			// Token: 0x06002758 RID: 10072 RVA: 0x00203410 File Offset: 0x00201610
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

			// Token: 0x06002759 RID: 10073 RVA: 0x002034C4 File Offset: 0x002016C4
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

			// Token: 0x0600275A RID: 10074 RVA: 0x002035A4 File Offset: 0x002017A4
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

			// Token: 0x04005194 RID: 20884
			public float m00;

			// Token: 0x04005195 RID: 20885
			public float m01;

			// Token: 0x04005196 RID: 20886
			public float m02;

			// Token: 0x04005197 RID: 20887
			public float m03;

			// Token: 0x04005198 RID: 20888
			public float m10;

			// Token: 0x04005199 RID: 20889
			public float m11;

			// Token: 0x0400519A RID: 20890
			public float m12;

			// Token: 0x0400519B RID: 20891
			public float m13;

			// Token: 0x0400519C RID: 20892
			public float m20;

			// Token: 0x0400519D RID: 20893
			public float m21;

			// Token: 0x0400519E RID: 20894
			public float m22;

			// Token: 0x0400519F RID: 20895
			public float m23;
		}
	}
}
