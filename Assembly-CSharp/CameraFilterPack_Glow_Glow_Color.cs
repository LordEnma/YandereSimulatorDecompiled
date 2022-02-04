using System;
using UnityEngine;

// Token: 0x020001CE RID: 462
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glow/Glow_Color")]
public class CameraFilterPack_Glow_Glow_Color : MonoBehaviour
{
	// Token: 0x170002D2 RID: 722
	// (get) Token: 0x06000F93 RID: 3987 RVA: 0x0007F061 File Offset: 0x0007D261
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

	// Token: 0x06000F94 RID: 3988 RVA: 0x0007F095 File Offset: 0x0007D295
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Glow_Glow_Color");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F95 RID: 3989 RVA: 0x0007F0B8 File Offset: 0x0007D2B8
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (!(this.SCShader != null))
		{
			Graphics.Blit(sourceTexture, destTexture);
			return;
		}
		int fastFilter = this.FastFilter;
		this.TimeX += Time.deltaTime;
		if (this.TimeX > 100f)
		{
			this.TimeX = 0f;
		}
		this.material.SetFloat("_TimeX", this.TimeX);
		this.material.SetFloat("_Amount", this.Amount);
		this.material.SetFloat("_Value1", this.Threshold);
		this.material.SetFloat("_Value2", this.Intensity);
		this.material.SetFloat("_Value3", this.Precision);
		this.material.SetColor("_GlowColor", this.GlowColor);
		this.material.SetVector("_ScreenResolution", new Vector2((float)(Screen.width / fastFilter), (float)(Screen.height / fastFilter)));
		int width = sourceTexture.width / fastFilter;
		int height = sourceTexture.height / fastFilter;
		if (this.FastFilter > 1)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
			RenderTexture temporary2 = RenderTexture.GetTemporary(width, height, 0);
			temporary.filterMode = FilterMode.Trilinear;
			Graphics.Blit(sourceTexture, temporary, this.material, 3);
			Graphics.Blit(temporary, temporary2, this.material, 2);
			Graphics.Blit(temporary2, temporary, this.material, 0);
			this.material.SetFloat("_Amount", this.Amount * 2f);
			Graphics.Blit(temporary, temporary2, this.material, 2);
			Graphics.Blit(temporary2, temporary, this.material, 0);
			this.material.SetTexture("_MainTex2", temporary);
			RenderTexture.ReleaseTemporary(temporary);
			RenderTexture.ReleaseTemporary(temporary2);
			Graphics.Blit(sourceTexture, destTexture, this.material, 1);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture, this.material, 0);
	}

	// Token: 0x06000F96 RID: 3990 RVA: 0x0007F296 File Offset: 0x0007D496
	private void Update()
	{
	}

	// Token: 0x06000F97 RID: 3991 RVA: 0x0007F298 File Offset: 0x0007D498
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001403 RID: 5123
	public Shader SCShader;

	// Token: 0x04001404 RID: 5124
	private float TimeX = 1f;

	// Token: 0x04001405 RID: 5125
	private Material SCMaterial;

	// Token: 0x04001406 RID: 5126
	[Range(0f, 20f)]
	public float Amount = 4f;

	// Token: 0x04001407 RID: 5127
	[Range(2f, 16f)]
	public int FastFilter = 4;

	// Token: 0x04001408 RID: 5128
	[Range(0f, 1f)]
	public float Threshold = 0.5f;

	// Token: 0x04001409 RID: 5129
	[Range(0f, 3f)]
	public float Intensity = 2.25f;

	// Token: 0x0400140A RID: 5130
	[Range(-1f, 1f)]
	public float Precision = 0.56f;

	// Token: 0x0400140B RID: 5131
	public Color GlowColor = new Color(0f, 0.7f, 1f, 1f);
}
