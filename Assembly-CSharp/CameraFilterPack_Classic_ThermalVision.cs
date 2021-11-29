using System;
using UnityEngine;

// Token: 0x02000159 RID: 345
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Classic/ThermalVision")]
public class CameraFilterPack_Classic_ThermalVision : MonoBehaviour
{
	// Token: 0x1700025E RID: 606
	// (get) Token: 0x06000CD5 RID: 3285 RVA: 0x0007367E File Offset: 0x0007187E
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

	// Token: 0x06000CD6 RID: 3286 RVA: 0x000736B2 File Offset: 0x000718B2
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_Classic_ThermalVision");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CD7 RID: 3287 RVA: 0x000736D4 File Offset: 0x000718D4
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

	// Token: 0x06000CD8 RID: 3288 RVA: 0x0007380E File Offset: 0x00071A0E
	private void Update()
	{
	}

	// Token: 0x06000CD9 RID: 3289 RVA: 0x00073810 File Offset: 0x00071A10
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001120 RID: 4384
	public Shader SCShader;

	// Token: 0x04001121 RID: 4385
	private float TimeX = 1f;

	// Token: 0x04001122 RID: 4386
	private Material SCMaterial;

	// Token: 0x04001123 RID: 4387
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x04001124 RID: 4388
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x04001125 RID: 4389
	[Range(0f, 1f)]
	public float _Crt = 1f;

	// Token: 0x04001126 RID: 4390
	[Range(0f, 1f)]
	public float _Curve = 1f;

	// Token: 0x04001127 RID: 4391
	[Range(0f, 1f)]
	public float _Color1 = 1f;

	// Token: 0x04001128 RID: 4392
	[Range(0f, 1f)]
	public float _Color2 = 1f;

	// Token: 0x04001129 RID: 4393
	[Range(0f, 1f)]
	public float _Color3 = 1f;
}
