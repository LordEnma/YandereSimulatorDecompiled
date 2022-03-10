using System;
using UnityEngine;

// Token: 0x02000154 RID: 340
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Tilt_Shift")]
public class CameraFilterPack_Blur_Tilt_Shift : MonoBehaviour
{
	// Token: 0x17000258 RID: 600
	// (get) Token: 0x06000CB5 RID: 3253 RVA: 0x00073012 File Offset: 0x00071212
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

	// Token: 0x06000CB6 RID: 3254 RVA: 0x00073046 File Offset: 0x00071246
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/BlurTiltShift");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CB7 RID: 3255 RVA: 0x00073068 File Offset: 0x00071268
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
		this.material.SetFloat("_Value1", this.Smooth);
		this.material.SetFloat("_Value2", this.Size);
		this.material.SetFloat("_Value3", this.Position);
		this.material.SetVector("_ScreenResolution", new Vector2((float)(Screen.width / fastFilter), (float)(Screen.height / fastFilter)));
		int width = sourceTexture.width / fastFilter;
		int height = sourceTexture.height / fastFilter;
		if (this.FastFilter > 1)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
			RenderTexture temporary2 = RenderTexture.GetTemporary(width, height, 0);
			temporary.filterMode = FilterMode.Trilinear;
			Graphics.Blit(sourceTexture, temporary, this.material, 2);
			Graphics.Blit(temporary, temporary2, this.material, 0);
			this.material.SetFloat("_Amount", this.Amount * 2f);
			Graphics.Blit(temporary2, temporary, this.material, 2);
			Graphics.Blit(temporary, temporary2, this.material, 0);
			this.material.SetTexture("_MainTex2", temporary2);
			RenderTexture.ReleaseTemporary(temporary);
			RenderTexture.ReleaseTemporary(temporary2);
			Graphics.Blit(sourceTexture, destTexture, this.material, 1);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture, this.material, 0);
	}

	// Token: 0x06000CB8 RID: 3256 RVA: 0x00073222 File Offset: 0x00071422
	private void Update()
	{
	}

	// Token: 0x06000CB9 RID: 3257 RVA: 0x00073224 File Offset: 0x00071424
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001104 RID: 4356
	public Shader SCShader;

	// Token: 0x04001105 RID: 4357
	private float TimeX = 1f;

	// Token: 0x04001106 RID: 4358
	private Material SCMaterial;

	// Token: 0x04001107 RID: 4359
	[Range(0f, 20f)]
	public float Amount = 3f;

	// Token: 0x04001108 RID: 4360
	[Range(2f, 16f)]
	public int FastFilter = 8;

	// Token: 0x04001109 RID: 4361
	[Range(0f, 1f)]
	public float Smooth = 0.5f;

	// Token: 0x0400110A RID: 4362
	[Range(0f, 1f)]
	public float Size = 0.5f;

	// Token: 0x0400110B RID: 4363
	[Range(-1f, 1f)]
	public float Position = 0.5f;
}
