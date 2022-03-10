using System;
using UnityEngine;

// Token: 0x02000156 RID: 342
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Tilt_Shift_V")]
public class CameraFilterPack_Blur_Tilt_Shift_V : MonoBehaviour
{
	// Token: 0x1700025A RID: 602
	// (get) Token: 0x06000CC1 RID: 3265 RVA: 0x00073508 File Offset: 0x00071708
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

	// Token: 0x06000CC2 RID: 3266 RVA: 0x0007353C File Offset: 0x0007173C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/BlurTiltShift_V");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CC3 RID: 3267 RVA: 0x00073560 File Offset: 0x00071760
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

	// Token: 0x06000CC4 RID: 3268 RVA: 0x000736F0 File Offset: 0x000718F0
	private void Update()
	{
	}

	// Token: 0x06000CC5 RID: 3269 RVA: 0x000736F2 File Offset: 0x000718F2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001115 RID: 4373
	public Shader SCShader;

	// Token: 0x04001116 RID: 4374
	private float TimeX = 1f;

	// Token: 0x04001117 RID: 4375
	private Material SCMaterial;

	// Token: 0x04001118 RID: 4376
	[Range(0f, 20f)]
	public float Amount = 3f;

	// Token: 0x04001119 RID: 4377
	[Range(2f, 16f)]
	public int FastFilter = 8;

	// Token: 0x0400111A RID: 4378
	[Range(0f, 1f)]
	public float Smooth = 0.5f;

	// Token: 0x0400111B RID: 4379
	[Range(0f, 1f)]
	public float Size = 0.5f;

	// Token: 0x0400111C RID: 4380
	[Range(-1f, 1f)]
	public float Position = 0.5f;
}
