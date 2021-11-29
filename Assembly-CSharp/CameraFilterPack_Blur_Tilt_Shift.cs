using System;
using UnityEngine;

// Token: 0x02000153 RID: 339
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Tilt_Shift")]
public class CameraFilterPack_Blur_Tilt_Shift : MonoBehaviour
{
	// Token: 0x17000258 RID: 600
	// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x00072A6E File Offset: 0x00070C6E
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

	// Token: 0x06000CB2 RID: 3250 RVA: 0x00072AA2 File Offset: 0x00070CA2
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/BlurTiltShift");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CB3 RID: 3251 RVA: 0x00072AC4 File Offset: 0x00070CC4
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

	// Token: 0x06000CB4 RID: 3252 RVA: 0x00072C7E File Offset: 0x00070E7E
	private void Update()
	{
	}

	// Token: 0x06000CB5 RID: 3253 RVA: 0x00072C80 File Offset: 0x00070E80
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010F3 RID: 4339
	public Shader SCShader;

	// Token: 0x040010F4 RID: 4340
	private float TimeX = 1f;

	// Token: 0x040010F5 RID: 4341
	private Material SCMaterial;

	// Token: 0x040010F6 RID: 4342
	[Range(0f, 20f)]
	public float Amount = 3f;

	// Token: 0x040010F7 RID: 4343
	[Range(2f, 16f)]
	public int FastFilter = 8;

	// Token: 0x040010F8 RID: 4344
	[Range(0f, 1f)]
	public float Smooth = 0.5f;

	// Token: 0x040010F9 RID: 4345
	[Range(0f, 1f)]
	public float Size = 0.5f;

	// Token: 0x040010FA RID: 4346
	[Range(-1f, 1f)]
	public float Position = 0.5f;
}
