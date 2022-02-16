using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x0200057F RID: 1407
	[Serializable]
	internal abstract class MotionState
	{
		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x060023AE RID: 9134 RVA: 0x001F52E3 File Offset: 0x001F34E3
		public AmplifyMotionCamera Owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060023AF RID: 9135 RVA: 0x001F52EB File Offset: 0x001F34EB
		public bool Initialized
		{
			get
			{
				return this.m_initialized;
			}
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060023B0 RID: 9136 RVA: 0x001F52F3 File Offset: 0x001F34F3
		public bool Error
		{
			get
			{
				return this.m_error;
			}
		}

		// Token: 0x060023B1 RID: 9137 RVA: 0x001F52FB File Offset: 0x001F34FB
		public MotionState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
		{
			this.m_error = false;
			this.m_initialized = false;
			this.m_owner = owner;
			this.m_obj = obj;
			this.m_transform = obj.transform;
		}

		// Token: 0x060023B2 RID: 9138 RVA: 0x001F532B File Offset: 0x001F352B
		internal virtual void Initialize()
		{
			this.m_initialized = true;
		}

		// Token: 0x060023B3 RID: 9139 RVA: 0x001F5334 File Offset: 0x001F3534
		internal virtual void Shutdown()
		{
		}

		// Token: 0x060023B4 RID: 9140 RVA: 0x001F5336 File Offset: 0x001F3536
		internal virtual void AsyncUpdate()
		{
		}

		// Token: 0x060023B5 RID: 9141
		internal abstract void UpdateTransform(CommandBuffer updateCB, bool starting);

		// Token: 0x060023B6 RID: 9142 RVA: 0x001F5338 File Offset: 0x001F3538
		internal virtual void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
		}

		// Token: 0x060023B7 RID: 9143 RVA: 0x001F533A File Offset: 0x001F353A
		internal virtual void RenderDebugHUD()
		{
		}

		// Token: 0x060023B8 RID: 9144 RVA: 0x001F533C File Offset: 0x001F353C
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

		// Token: 0x060023B9 RID: 9145 RVA: 0x001F5484 File Offset: 0x001F3684
		protected static bool MatrixChanged(MotionState.Matrix3x4 a, MotionState.Matrix3x4 b)
		{
			return Vector4.SqrMagnitude(new Vector4(a.m00 - b.m00, a.m01 - b.m01, a.m02 - b.m02, a.m03 - b.m03)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m10 - b.m10, a.m11 - b.m11, a.m12 - b.m12, a.m13 - b.m13)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m20 - b.m20, a.m21 - b.m21, a.m22 - b.m22, a.m23 - b.m23)) > 0f;
		}

		// Token: 0x060023BA RID: 9146 RVA: 0x001F5568 File Offset: 0x001F3768
		protected static void MulPoint3x4_XYZ(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23;
		}

		// Token: 0x060023BB RID: 9147 RVA: 0x001F5618 File Offset: 0x001F3818
		protected static void MulPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x060023BC RID: 9148 RVA: 0x001F56DC File Offset: 0x001F38DC
		protected static void MulAddPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x += mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y += mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z += mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x04004B51 RID: 19281
		public const int AsyncUpdateTimeout = 100;

		// Token: 0x04004B52 RID: 19282
		protected bool m_error;

		// Token: 0x04004B53 RID: 19283
		protected bool m_initialized;

		// Token: 0x04004B54 RID: 19284
		protected Transform m_transform;

		// Token: 0x04004B55 RID: 19285
		protected AmplifyMotionCamera m_owner;

		// Token: 0x04004B56 RID: 19286
		protected AmplifyMotionObjectBase m_obj;

		// Token: 0x04004B57 RID: 19287
		private static HashSet<Material> m_materialWarnings = new HashSet<Material>();

		// Token: 0x020006D1 RID: 1745
		protected struct MaterialDesc
		{
			// Token: 0x0400517B RID: 20859
			public Material material;

			// Token: 0x0400517C RID: 20860
			public MaterialPropertyBlock propertyBlock;

			// Token: 0x0400517D RID: 20861
			public bool coverage;

			// Token: 0x0400517E RID: 20862
			public bool cutoff;
		}

		// Token: 0x020006D2 RID: 1746
		protected struct Matrix3x4
		{
			// Token: 0x06002745 RID: 10053 RVA: 0x002026DC File Offset: 0x002008DC
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

			// Token: 0x06002746 RID: 10054 RVA: 0x00202768 File Offset: 0x00200968
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

			// Token: 0x06002747 RID: 10055 RVA: 0x0020281C File Offset: 0x00200A1C
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

			// Token: 0x06002748 RID: 10056 RVA: 0x002028FC File Offset: 0x00200AFC
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

			// Token: 0x0400517F RID: 20863
			public float m00;

			// Token: 0x04005180 RID: 20864
			public float m01;

			// Token: 0x04005181 RID: 20865
			public float m02;

			// Token: 0x04005182 RID: 20866
			public float m03;

			// Token: 0x04005183 RID: 20867
			public float m10;

			// Token: 0x04005184 RID: 20868
			public float m11;

			// Token: 0x04005185 RID: 20869
			public float m12;

			// Token: 0x04005186 RID: 20870
			public float m13;

			// Token: 0x04005187 RID: 20871
			public float m20;

			// Token: 0x04005188 RID: 20872
			public float m21;

			// Token: 0x04005189 RID: 20873
			public float m22;

			// Token: 0x0400518A RID: 20874
			public float m23;
		}
	}
}
