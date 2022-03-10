using System;
using UnityEngine;

// Token: 0x02000155 RID: 341
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Tilt_Shift_Hole")]
public class CameraFilterPack_Blur_Tilt_Shift_Hole : MonoBehaviour
{
	// Token: 0x17000259 RID: 601
	// (get) Token: 0x06000CBB RID: 3259 RVA: 0x00073291 File Offset: 0x00071491
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

	// Token: 0x06000CBC RID: 3260 RVA: 0x000732C5 File Offset: 0x000714C5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/BlurTiltShift_Hole");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CBD RID: 3261 RVA: 0x000732E8 File Offset: 0x000714E8
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

	// Token: 0x06000CBE RID: 3262 RVA: 0x0007348E File Offset: 0x0007168E
	private void Update()
	{
	}

	// Token: 0x06000CBF RID: 3263 RVA: 0x00073490 File Offset: 0x00071690
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400110C RID: 4364
	public Shader SCShader;

	// Token: 0x0400110D RID: 4365
	private float TimeX = 1f;

	// Token: 0x0400110E RID: 4366
	private Material SCMaterial;

	// Token: 0x0400110F RID: 4367
	[Range(0f, 20f)]
	public float Amount = 3f;

	// Token: 0x04001110 RID: 4368
	[Range(2f, 16f)]
	public int FastFilter = 8;

	// Token: 0x04001111 RID: 4369
	[Range(0f, 1f)]
	public float Smooth = 0.5f;

	// Token: 0x04001112 RID: 4370
	[Range(0f, 1f)]
	public float Size = 0.2f;

	// Token: 0x04001113 RID: 4371
	[Range(-1f, 1f)]
	public float PositionX = 0.5f;

	// Token: 0x04001114 RID: 4372
	[Range(-1f, 1f)]
	public float PositionY = 0.5f;
}
