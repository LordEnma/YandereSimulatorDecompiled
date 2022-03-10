using System;
using UnityEngine;

// Token: 0x0200015A RID: 346
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Classic/ThermalVision")]
public class CameraFilterPack_Classic_ThermalVision : MonoBehaviour
{
	// Token: 0x1700025E RID: 606
	// (get) Token: 0x06000CD9 RID: 3289 RVA: 0x00073C22 File Offset: 0x00071E22
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

	// Token: 0x06000CDA RID: 3290 RVA: 0x00073C56 File Offset: 0x00071E56
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_Classic_ThermalVision");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CDB RID: 3291 RVA: 0x00073C78 File Offset: 0x00071E78
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

	// Token: 0x06000CDC RID: 3292 RVA: 0x00073DB2 File Offset: 0x00071FB2
	private void Update()
	{
	}

	// Token: 0x06000CDD RID: 3293 RVA: 0x00073DB4 File Offset: 0x00071FB4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001131 RID: 4401
	public Shader SCShader;

	// Token: 0x04001132 RID: 4402
	private float TimeX = 1f;

	// Token: 0x04001133 RID: 4403
	private Material SCMaterial;

	// Token: 0x04001134 RID: 4404
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x04001135 RID: 4405
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x04001136 RID: 4406
	[Range(0f, 1f)]
	public float _Crt = 1f;

	// Token: 0x04001137 RID: 4407
	[Range(0f, 1f)]
	public float _Curve = 1f;

	// Token: 0x04001138 RID: 4408
	[Range(0f, 1f)]
	public float _Color1 = 1f;

	// Token: 0x04001139 RID: 4409
	[Range(0f, 1f)]
	public float _Color2 = 1f;

	// Token: 0x0400113A RID: 4410
	[Range(0f, 1f)]
	public float _Color3 = 1f;
}
