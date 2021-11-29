using System;
using UnityEngine;

// Token: 0x0200016B RID: 363
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/DarkColor")]
public class CameraFilterPack_Colors_DarkColor : MonoBehaviour
{
	// Token: 0x17000270 RID: 624
	// (get) Token: 0x06000D43 RID: 3395 RVA: 0x00075623 File Offset: 0x00073823
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

	// Token: 0x06000D44 RID: 3396 RVA: 0x00075657 File Offset: 0x00073857
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_DarkColor");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D45 RID: 3397 RVA: 0x00075678 File Offset: 0x00073878
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

	// Token: 0x06000D46 RID: 3398 RVA: 0x00075770 File Offset: 0x00073970
	private void Update()
	{
	}

	// Token: 0x06000D47 RID: 3399 RVA: 0x00075772 File Offset: 0x00073972
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001188 RID: 4488
	public Shader SCShader;

	// Token: 0x04001189 RID: 4489
	private float TimeX = 1f;

	// Token: 0x0400118A RID: 4490
	private Material SCMaterial;

	// Token: 0x0400118B RID: 4491
	[Range(-5f, 5f)]
	public float Alpha = 1f;

	// Token: 0x0400118C RID: 4492
	[Range(0f, 16f)]
	private float Colors = 11f;

	// Token: 0x0400118D RID: 4493
	[Range(-1f, 1f)]
	private float Green_Mod = 1f;

	// Token: 0x0400118E RID: 4494
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
