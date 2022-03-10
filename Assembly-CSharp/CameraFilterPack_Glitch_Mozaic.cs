using System;
using UnityEngine;

// Token: 0x020001CC RID: 460
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Mozaic")]
public class CameraFilterPack_Glitch_Mozaic : MonoBehaviour
{
	// Token: 0x170002D0 RID: 720
	// (get) Token: 0x06000F88 RID: 3976 RVA: 0x0007EFD9 File Offset: 0x0007D1D9
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

	// Token: 0x06000F89 RID: 3977 RVA: 0x0007F00D File Offset: 0x0007D20D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Glitch_Mozaic");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F8A RID: 3978 RVA: 0x0007F030 File Offset: 0x0007D230
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
			this.material.SetFloat("_Value", this.Intensity);
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F8B RID: 3979 RVA: 0x0007F128 File Offset: 0x0007D328
	private void Update()
	{
	}

	// Token: 0x06000F8C RID: 3980 RVA: 0x0007F12A File Offset: 0x0007D32A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001400 RID: 5120
	public Shader SCShader;

	// Token: 0x04001401 RID: 5121
	private float TimeX = 1f;

	// Token: 0x04001402 RID: 5122
	private Material SCMaterial;

	// Token: 0x04001403 RID: 5123
	[Range(0.001f, 10f)]
	public float Intensity = 1f;

	// Token: 0x04001404 RID: 5124
	[Range(0f, 10f)]
	private float Value2 = 1f;

	// Token: 0x04001405 RID: 5125
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x04001406 RID: 5126
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
