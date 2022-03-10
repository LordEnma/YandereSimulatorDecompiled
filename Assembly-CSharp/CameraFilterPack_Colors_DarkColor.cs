using System;
using UnityEngine;

// Token: 0x0200016C RID: 364
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/DarkColor")]
public class CameraFilterPack_Colors_DarkColor : MonoBehaviour
{
	// Token: 0x17000270 RID: 624
	// (get) Token: 0x06000D47 RID: 3399 RVA: 0x00075BC7 File Offset: 0x00073DC7
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

	// Token: 0x06000D48 RID: 3400 RVA: 0x00075BFB File Offset: 0x00073DFB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_DarkColor");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D49 RID: 3401 RVA: 0x00075C1C File Offset: 0x00073E1C
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
			this.material.SetFloat("_Value", this.Alpha);
			this.material.SetFloat("_Value2", this.Colors);
			this.material.SetFloat("_Value3", this.Green_Mod);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D4A RID: 3402 RVA: 0x00075D14 File Offset: 0x00073F14
	private void Update()
	{
	}

	// Token: 0x06000D4B RID: 3403 RVA: 0x00075D16 File Offset: 0x00073F16
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001199 RID: 4505
	public Shader SCShader;

	// Token: 0x0400119A RID: 4506
	private float TimeX = 1f;

	// Token: 0x0400119B RID: 4507
	private Material SCMaterial;

	// Token: 0x0400119C RID: 4508
	[Range(-5f, 5f)]
	public float Alpha = 1f;

	// Token: 0x0400119D RID: 4509
	[Range(0f, 16f)]
	private float Colors = 11f;

	// Token: 0x0400119E RID: 4510
	[Range(-1f, 1f)]
	private float Green_Mod = 1f;

	// Token: 0x0400119F RID: 4511
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
