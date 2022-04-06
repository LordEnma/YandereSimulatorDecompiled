using System;
using UnityEngine;

// Token: 0x020001CE RID: 462
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glow/Glow_Color")]
public class CameraFilterPack_Glow_Glow_Color : MonoBehaviour
{
	// Token: 0x170002D2 RID: 722
	// (get) Token: 0x06000F96 RID: 3990 RVA: 0x0007F889 File Offset: 0x0007DA89
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

	// Token: 0x06000F97 RID: 3991 RVA: 0x0007F8BD File Offset: 0x0007DABD
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Glow_Glow_Color");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F98 RID: 3992 RVA: 0x0007F8E0 File Offset: 0x0007DAE0
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

	// Token: 0x06000F99 RID: 3993 RVA: 0x0007FABE File Offset: 0x0007DCBE
	private void Update()
	{
	}

	// Token: 0x06000F9A RID: 3994 RVA: 0x0007FAC0 File Offset: 0x0007DCC0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001416 RID: 5142
	public Shader SCShader;

	// Token: 0x04001417 RID: 5143
	private float TimeX = 1f;

	// Token: 0x04001418 RID: 5144
	private Material SCMaterial;

	// Token: 0x04001419 RID: 5145
	[Range(0f, 20f)]
	public float Amount = 4f;

	// Token: 0x0400141A RID: 5146
	[Range(2f, 16f)]
	public int FastFilter = 4;

	// Token: 0x0400141B RID: 5147
	[Range(0f, 1f)]
	public float Threshold = 0.5f;

	// Token: 0x0400141C RID: 5148
	[Range(0f, 3f)]
	public float Intensity = 2.25f;

	// Token: 0x0400141D RID: 5149
	[Range(-1f, 1f)]
	public float Precision = 0.56f;

	// Token: 0x0400141E RID: 5150
	public Color GlowColor = new Color(0f, 0.7f, 1f, 1f);
}
