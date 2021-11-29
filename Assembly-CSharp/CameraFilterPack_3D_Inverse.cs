using System;
using UnityEngine;

// Token: 0x0200010F RID: 271
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Inverse")]
public class CameraFilterPack_3D_Inverse : MonoBehaviour
{
	// Token: 0x17000214 RID: 532
	// (get) Token: 0x06000ADA RID: 2778 RVA: 0x00069143 File Offset: 0x00067343
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x06000ADB RID: 2779 RVA: 0x00069177 File Offset: 0x00067377
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_Inverse");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000ADC RID: 2780 RVA: 0x00069198 File Offset: 0x00067398
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			if (this.AutoAnimatedNear)
			{
				this._Distance += Time.deltaTime * this.AutoAnimatedNearSpeed;
				if (this._Distance > 1f)
				{
					this._Distance = -1f;
				}
				if (this._Distance < -1f)
				{
					this._Distance = 1f;
				}
				this.material.SetFloat("_Near", this._Distance);
			}
			else
			{
				this.material.SetFloat("_Near", this._Distance);
			}
			this.material.SetFloat("_Far", this._Size);
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("_LightIntensity", this.LightIntensity);
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			float farClipPlane = base.GetComponent<Camera>().farClipPlane;
			this.material.SetFloat("_FarCamera", 1000f / farClipPlane);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000ADD RID: 2781 RVA: 0x00069345 File Offset: 0x00067545
	private void Update()
	{
	}

	// Token: 0x06000ADE RID: 2782 RVA: 0x00069347 File Offset: 0x00067547
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E81 RID: 3713
	public Shader SCShader;

	// Token: 0x04000E82 RID: 3714
	private float TimeX = 1f;

	// Token: 0x04000E83 RID: 3715
	public bool _Visualize;

	// Token: 0x04000E84 RID: 3716
	private Material SCMaterial;

	// Token: 0x04000E85 RID: 3717
	[Range(0f, 100f)]
	public float _FixDistance = 1.5f;

	// Token: 0x04000E86 RID: 3718
	[Range(-0.99f, 0.99f)]
	public float _Distance = 0.4f;

	// Token: 0x04000E87 RID: 3719
	[Range(0f, 0.5f)]
	public float _Size = 0.5f;

	// Token: 0x04000E88 RID: 3720
	[Range(0f, 1f)]
	public float LightIntensity = 1f;

	// Token: 0x04000E89 RID: 3721
	public bool AutoAnimatedNear;

	// Token: 0x04000E8A RID: 3722
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 0.5f;

	// Token: 0x04000E8B RID: 3723
	public static Color ChangeColorRGB;
}
