using System;
using UnityEngine;

// Token: 0x0200016C RID: 364
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/DarkColor")]
public class CameraFilterPack_Colors_DarkColor : MonoBehaviour
{
	// Token: 0x17000270 RID: 624
	// (get) Token: 0x06000D49 RID: 3401 RVA: 0x00076043 File Offset: 0x00074243
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

	// Token: 0x06000D4A RID: 3402 RVA: 0x00076077 File Offset: 0x00074277
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_DarkColor");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D4B RID: 3403 RVA: 0x00076098 File Offset: 0x00074298
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

	// Token: 0x06000D4C RID: 3404 RVA: 0x00076190 File Offset: 0x00074390
	private void Update()
	{
	}

	// Token: 0x06000D4D RID: 3405 RVA: 0x00076192 File Offset: 0x00074392
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011A0 RID: 4512
	public Shader SCShader;

	// Token: 0x040011A1 RID: 4513
	private float TimeX = 1f;

	// Token: 0x040011A2 RID: 4514
	private Material SCMaterial;

	// Token: 0x040011A3 RID: 4515
	[Range(-5f, 5f)]
	public float Alpha = 1f;

	// Token: 0x040011A4 RID: 4516
	[Range(0f, 16f)]
	private float Colors = 11f;

	// Token: 0x040011A5 RID: 4517
	[Range(-1f, 1f)]
	private float Green_Mod = 1f;

	// Token: 0x040011A6 RID: 4518
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
