using System;
using UnityEngine;

// Token: 0x02000154 RID: 340
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Tilt_Shift")]
public class CameraFilterPack_Blur_Tilt_Shift : MonoBehaviour
{
	// Token: 0x17000258 RID: 600
	// (get) Token: 0x06000CB4 RID: 3252 RVA: 0x00072C66 File Offset: 0x00070E66
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

	// Token: 0x06000CB5 RID: 3253 RVA: 0x00072C9A File Offset: 0x00070E9A
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/BlurTiltShift");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CB6 RID: 3254 RVA: 0x00072CBC File Offset: 0x00070EBC
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

	// Token: 0x06000CB7 RID: 3255 RVA: 0x00072E76 File Offset: 0x00071076
	private void Update()
	{
	}

	// Token: 0x06000CB8 RID: 3256 RVA: 0x00072E78 File Offset: 0x00071078
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010F8 RID: 4344
	public Shader SCShader;

	// Token: 0x040010F9 RID: 4345
	private float TimeX = 1f;

	// Token: 0x040010FA RID: 4346
	private Material SCMaterial;

	// Token: 0x040010FB RID: 4347
	[Range(0f, 20f)]
	public float Amount = 3f;

	// Token: 0x040010FC RID: 4348
	[Range(2f, 16f)]
	public int FastFilter = 8;

	// Token: 0x040010FD RID: 4349
	[Range(0f, 1f)]
	public float Smooth = 0.5f;

	// Token: 0x040010FE RID: 4350
	[Range(0f, 1f)]
	public float Size = 0.5f;

	// Token: 0x040010FF RID: 4351
	[Range(-1f, 1f)]
	public float Position = 0.5f;
}
