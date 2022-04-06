using System;
using UnityEngine;

// Token: 0x0200015A RID: 346
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Classic/ThermalVision")]
public class CameraFilterPack_Classic_ThermalVision : MonoBehaviour
{
	// Token: 0x1700025E RID: 606
	// (get) Token: 0x06000CDB RID: 3291 RVA: 0x0007409E File Offset: 0x0007229E
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

	// Token: 0x06000CDC RID: 3292 RVA: 0x000740D2 File Offset: 0x000722D2
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_Classic_ThermalVision");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CDD RID: 3293 RVA: 0x000740F4 File Offset: 0x000722F4
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

	// Token: 0x06000CDE RID: 3294 RVA: 0x0007422E File Offset: 0x0007242E
	private void Update()
	{
	}

	// Token: 0x06000CDF RID: 3295 RVA: 0x00074230 File Offset: 0x00072430
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001138 RID: 4408
	public Shader SCShader;

	// Token: 0x04001139 RID: 4409
	private float TimeX = 1f;

	// Token: 0x0400113A RID: 4410
	private Material SCMaterial;

	// Token: 0x0400113B RID: 4411
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x0400113C RID: 4412
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x0400113D RID: 4413
	[Range(0f, 1f)]
	public float _Crt = 1f;

	// Token: 0x0400113E RID: 4414
	[Range(0f, 1f)]
	public float _Curve = 1f;

	// Token: 0x0400113F RID: 4415
	[Range(0f, 1f)]
	public float _Color1 = 1f;

	// Token: 0x04001140 RID: 4416
	[Range(0f, 1f)]
	public float _Color2 = 1f;

	// Token: 0x04001141 RID: 4417
	[Range(0f, 1f)]
	public float _Color3 = 1f;
}
