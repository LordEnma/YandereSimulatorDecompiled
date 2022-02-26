using System;
using UnityEngine;

// Token: 0x0200015A RID: 346
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Classic/ThermalVision")]
public class CameraFilterPack_Classic_ThermalVision : MonoBehaviour
{
	// Token: 0x1700025E RID: 606
	// (get) Token: 0x06000CD9 RID: 3289 RVA: 0x00073ADA File Offset: 0x00071CDA
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

	// Token: 0x06000CDA RID: 3290 RVA: 0x00073B0E File Offset: 0x00071D0E
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_Classic_ThermalVision");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CDB RID: 3291 RVA: 0x00073B30 File Offset: 0x00071D30
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
			this.material.SetFloat("_Speed", this.__Speed);
			this.material.SetFloat("Fade", this._Fade);
			this.material.SetFloat("Crt", this._Crt);
			this.material.SetFloat("Curve", this._Curve);
			this.material.SetFloat("Color1", this._Color1);
			this.material.SetFloat("Color2", this._Color2);
			this.material.SetFloat("Color3", this._Color3);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CDC RID: 3292 RVA: 0x00073C6A File Offset: 0x00071E6A
	private void Update()
	{
	}

	// Token: 0x06000CDD RID: 3293 RVA: 0x00073C6C File Offset: 0x00071E6C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001128 RID: 4392
	public Shader SCShader;

	// Token: 0x04001129 RID: 4393
	private float TimeX = 1f;

	// Token: 0x0400112A RID: 4394
	private Material SCMaterial;

	// Token: 0x0400112B RID: 4395
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x0400112C RID: 4396
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x0400112D RID: 4397
	[Range(0f, 1f)]
	public float _Crt = 1f;

	// Token: 0x0400112E RID: 4398
	[Range(0f, 1f)]
	public float _Curve = 1f;

	// Token: 0x0400112F RID: 4399
	[Range(0f, 1f)]
	public float _Color1 = 1f;

	// Token: 0x04001130 RID: 4400
	[Range(0f, 1f)]
	public float _Color2 = 1f;

	// Token: 0x04001131 RID: 4401
	[Range(0f, 1f)]
	public float _Color3 = 1f;
}
