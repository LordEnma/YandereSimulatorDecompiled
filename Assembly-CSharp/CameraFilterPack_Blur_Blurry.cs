using System;
using UnityEngine;

// Token: 0x02000148 RID: 328
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Blurry")]
public class CameraFilterPack_Blur_Blurry : MonoBehaviour
{
	// Token: 0x1700024D RID: 589
	// (get) Token: 0x06000C6F RID: 3183 RVA: 0x000719C0 File Offset: 0x0006FBC0
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

	// Token: 0x06000C70 RID: 3184 RVA: 0x000719F4 File Offset: 0x0006FBF4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Blurry");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C71 RID: 3185 RVA: 0x00071A18 File Offset: 0x0006FC18
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
		this.material.SetVector("_ScreenResolution", new Vector2((float)(Screen.width / fastFilter), (float)(Screen.height / fastFilter)));
		int width = sourceTexture.width / fastFilter;
		int height = sourceTexture.height / fastFilter;
		if (this.FastFilter > 1)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
			temporary.filterMode = FilterMode.Trilinear;
			Graphics.Blit(sourceTexture, temporary, this.material);
			Graphics.Blit(temporary, destTexture);
			RenderTexture.ReleaseTemporary(temporary);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture, this.material);
	}

	// Token: 0x06000C72 RID: 3186 RVA: 0x00071B18 File Offset: 0x0006FD18
	private void Update()
	{
	}

	// Token: 0x06000C73 RID: 3187 RVA: 0x00071B1A File Offset: 0x0006FD1A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010B6 RID: 4278
	public Shader SCShader;

	// Token: 0x040010B7 RID: 4279
	private float TimeX = 1f;

	// Token: 0x040010B8 RID: 4280
	private Material SCMaterial;

	// Token: 0x040010B9 RID: 4281
	[Range(0f, 20f)]
	public float Amount = 2f;

	// Token: 0x040010BA RID: 4282
	[Range(1f, 8f)]
	public int FastFilter = 2;
}
