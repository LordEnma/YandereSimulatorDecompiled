using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x02000581 RID: 1409
	[Serializable]
	internal abstract class MotionState
	{
		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x060023BD RID: 9149 RVA: 0x001F689B File Offset: 0x001F4A9B
		public AmplifyMotionCamera Owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060023BE RID: 9150 RVA: 0x001F68A3 File Offset: 0x001F4AA3
		public bool Initialized
		{
			get
			{
				return this.m_initialized;
			}
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060023BF RID: 9151 RVA: 0x001F68AB File Offset: 0x001F4AAB
		public bool Error
		{
			get
			{
				return this.m_error;
			}
		}

		// Token: 0x060023C0 RID: 9152 RVA: 0x001F68B3 File Offset: 0x001F4AB3
		public MotionState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj)
		{
			this.m_error = false;
			this.m_initialized = false;
			this.m_owner = owner;
			this.m_obj = obj;
			this.m_transform = obj.transform;
		}

		// Token: 0x060023C1 RID: 9153 RVA: 0x001F68E3 File Offset: 0x001F4AE3
		internal virtual void Initialize()
		{
			this.m_initialized = true;
		}

		// Token: 0x060023C2 RID: 9154 RVA: 0x001F68EC File Offset: 0x001F4AEC
		internal virtual void Shutdown()
		{
		}

		// Token: 0x060023C3 RID: 9155 RVA: 0x001F68EE File Offset: 0x001F4AEE
		internal virtual void AsyncUpdate()
		{
		}

		// Token: 0x060023C4 RID: 9156
		internal abstract void UpdateTransform(CommandBuffer updateCB, bool starting);

		// Token: 0x060023C5 RID: 9157 RVA: 0x001F68F0 File Offset: 0x001F4AF0
		internal virtual void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
		}

		// Token: 0x060023C6 RID: 9158 RVA: 0x001F68F2 File Offset: 0x001F4AF2
		internal virtual void RenderDebugHUD()
		{
		}

		// Token: 0x060023C7 RID: 9159 RVA: 0x001F68F4 File Offset: 0x001F4AF4
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

		// Token: 0x060023C8 RID: 9160 RVA: 0x001F6A3C File Offset: 0x001F4C3C
		protected static bool MatrixChanged(MotionState.Matrix3x4 a, MotionState.Matrix3x4 b)
		{
			return Vector4.SqrMagnitude(new Vector4(a.m00 - b.m00, a.m01 - b.m01, a.m02 - b.m02, a.m03 - b.m03)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m10 - b.m10, a.m11 - b.m11, a.m12 - b.m12, a.m13 - b.m13)) > 0f || Vector4.SqrMagnitude(new Vector4(a.m20 - b.m20, a.m21 - b.m21, a.m22 - b.m22, a.m23 - b.m23)) > 0f;
		}

		// Token: 0x060023C9 RID: 9161 RVA: 0x001F6B20 File Offset: 0x001F4D20
		protected static void MulPoint3x4_XYZ(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23;
		}

		// Token: 0x060023CA RID: 9162 RVA: 0x001F6BD0 File Offset: 0x001F4DD0
		protected static void MulPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x = mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y = mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z = mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x060023CB RID: 9163 RVA: 0x001F6C94 File Offset: 0x001F4E94
		protected static void MulAddPoint3x4_XYZW(ref Vector3 result, ref MotionState.Matrix3x4 mat, Vector4 vec)
		{
			result.x += mat.m00 * vec.x + mat.m01 * vec.y + mat.m02 * vec.z + mat.m03 * vec.w;
			result.y += mat.m10 * vec.x + mat.m11 * vec.y + mat.m12 * vec.z + mat.m13 * vec.w;
			result.z += mat.m20 * vec.x + mat.m21 * vec.y + mat.m22 * vec.z + mat.m23 * vec.w;
		}

		// Token: 0x04004B7E RID: 19326
		public const int AsyncUpdateTimeout = 100;

		// Token: 0x04004B7F RID: 19327
		protected bool m_error;

		// Token: 0x04004B80 RID: 19328
		protected bool m_initialized;

		// Token: 0x04004B81 RID: 19329
		protected Transform m_transform;

		// Token: 0x04004B82 RID: 19330
		protected AmplifyMotionCamera m_owner;

		// Token: 0x04004B83 RID: 19331
		protected AmplifyMotionObjectBase m_obj;

		// Token: 0x04004B84 RID: 19332
		private static HashSet<Material> m_materialWarnings = new HashSet<Material>();

		// Token: 0x020006D5 RID: 1749
		protected struct MaterialDesc
		{
			// Token: 0x040051AD RID: 20909
			public Material material;

			// Token: 0x040051AE RID: 20910
			public MaterialPropertyBlock propertyBlock;

			// Token: 0x040051AF RID: 20911
			public bool coverage;

			// Token: 0x040051B0 RID: 20912
			public bool cutoff;
		}

		// Token: 0x020006D6 RID: 1750
		protected struct Matrix3x4
		{
			// Token: 0x0600275D RID: 10077 RVA: 0x00203D5C File Offset: 0x00201F5C
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

			// Token: 0x0600275E RID: 10078 RVA: 0x00203DE8 File Offset: 0x00201FE8
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

			// Token: 0x0600275F RID: 10079 RVA: 0x00203E9C File Offset: 0x0020209C
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

			// Token: 0x06002760 RID: 10080 RVA: 0x00203F7C File Offset: 0x0020217C
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

			// Token: 0x040051B1 RID: 20913
			public float m00;

			// Token: 0x040051B2 RID: 20914
			public float m01;

			// Token: 0x040051B3 RID: 20915
			public float m02;

			// Token: 0x040051B4 RID: 20916
			public float m03;

			// Token: 0x040051B5 RID: 20917
			public float m10;

			// Token: 0x040051B6 RID: 20918
			public float m11;

			// Token: 0x040051B7 RID: 20919
			public float m12;

			// Token: 0x040051B8 RID: 20920
			public float m13;

			// Token: 0x040051B9 RID: 20921
			public float m20;

			// Token: 0x040051BA RID: 20922
			public float m21;

			// Token: 0x040051BB RID: 20923
			public float m22;

			// Token: 0x040051BC RID: 20924
			public float m23;
		}
	}
}
