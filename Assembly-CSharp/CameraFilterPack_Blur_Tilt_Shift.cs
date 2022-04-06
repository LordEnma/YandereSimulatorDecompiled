using System;
using UnityEngine;

// Token: 0x02000154 RID: 340
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Tilt_Shift")]
public class CameraFilterPack_Blur_Tilt_Shift : MonoBehaviour
{
	// Token: 0x17000258 RID: 600
	// (get) Token: 0x06000CB7 RID: 3255 RVA: 0x0007348E File Offset: 0x0007168E
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

	// Token: 0x06000CB8 RID: 3256 RVA: 0x000734C2 File Offset: 0x000716C2
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/BlurTiltShift");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CB9 RID: 3257 RVA: 0x000734E4 File Offset: 0x000716E4
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

	// Token: 0x06000CBA RID: 3258 RVA: 0x0007369E File Offset: 0x0007189E
	private void Update()
	{
	}

	// Token: 0x06000CBB RID: 3259 RVA: 0x000736A0 File Offset: 0x000718A0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400110B RID: 4363
	public Shader SCShader;

	// Token: 0x0400110C RID: 4364
	private float TimeX = 1f;

	// Token: 0x0400110D RID: 4365
	private Material SCMaterial;

	// Token: 0x0400110E RID: 4366
	[Range(0f, 20f)]
	public float Amount = 3f;

	// Token: 0x0400110F RID: 4367
	[Range(2f, 16f)]
	public int FastFilter = 8;

	// Token: 0x04001110 RID: 4368
	[Range(0f, 1f)]
	public float Smooth = 0.5f;

	// Token: 0x04001111 RID: 4369
	[Range(0f, 1f)]
	public float Size = 0.5f;

	// Token: 0x04001112 RID: 4370
	[Range(-1f, 1f)]
	public float Position = 0.5f;
}
