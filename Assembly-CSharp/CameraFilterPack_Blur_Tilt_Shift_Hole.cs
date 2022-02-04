using System;
using UnityEngine;

// Token: 0x02000155 RID: 341
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Tilt_Shift_Hole")]
public class CameraFilterPack_Blur_Tilt_Shift_Hole : MonoBehaviour
{
	// Token: 0x17000259 RID: 601
	// (get) Token: 0x06000CBA RID: 3258 RVA: 0x00072EE5 File Offset: 0x000710E5
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

	// Token: 0x06000CBB RID: 3259 RVA: 0x00072F19 File Offset: 0x00071119
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/BlurTiltShift_Hole");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CBC RID: 3260 RVA: 0x00072F3C File Offset: 0x0007113C
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
		this.material.SetFloat("_Value3", this.PositionX);
		this.material.SetFloat("_Value4", this.PositionY);
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

	// Token: 0x06000CBD RID: 3261 RVA: 0x000730E2 File Offset: 0x000712E2
	private void Update()
	{
	}

	// Token: 0x06000CBE RID: 3262 RVA: 0x000730E4 File Offset: 0x000712E4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001100 RID: 4352
	public Shader SCShader;

	// Token: 0x04001101 RID: 4353
	private float TimeX = 1f;

	// Token: 0x04001102 RID: 4354
	private Material SCMaterial;

	// Token: 0x04001103 RID: 4355
	[Range(0f, 20f)]
	public float Amount = 3f;

	// Token: 0x04001104 RID: 4356
	[Range(2f, 16f)]
	public int FastFilter = 8;

	// Token: 0x04001105 RID: 4357
	[Range(0f, 1f)]
	public float Smooth = 0.5f;

	// Token: 0x04001106 RID: 4358
	[Range(0f, 1f)]
	public float Size = 0.2f;

	// Token: 0x04001107 RID: 4359
	[Range(-1f, 1f)]
	public float PositionX = 0.5f;

	// Token: 0x04001108 RID: 4360
	[Range(-1f, 1f)]
	public float PositionY = 0.5f;
}
