using System;
using UnityEngine;

// Token: 0x0200014E RID: 334
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Movie")]
public class CameraFilterPack_Blur_Movie : MonoBehaviour
{
	// Token: 0x17000252 RID: 594
	// (get) Token: 0x06000C90 RID: 3216 RVA: 0x00072319 File Offset: 0x00070519
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

	// Token: 0x06000C91 RID: 3217 RVA: 0x0007234D File Offset: 0x0007054D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Movie");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C92 RID: 3218 RVA: 0x00072370 File Offset: 0x00070570
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
		this.material.SetFloat("_Radius", this.Radius / (float)fastFilter);
		this.material.SetFloat("_Factor", this.Factor);
		this.material.SetVector("_ScreenResolution", new Vector2((float)(Screen.width / fastFilter), (float)(Screen.height / fastFilter)));
		int width = sourceTexture.width / fastFilter;
		int height = sourceTexture.height / fastFilter;
		if (this.FastFilter > 1)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
			Graphics.Blit(sourceTexture, temporary, this.material);
			Graphics.Blit(temporary, destTexture);
			RenderTexture.ReleaseTemporary(temporary);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture, this.material);
	}

	// Token: 0x06000C93 RID: 3219 RVA: 0x00072482 File Offset: 0x00070682
	private void Update()
	{
	}

	// Token: 0x06000C94 RID: 3220 RVA: 0x00072484 File Offset: 0x00070684
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010D5 RID: 4309
	public Shader SCShader;

	// Token: 0x040010D6 RID: 4310
	private float TimeX = 1f;

	// Token: 0x040010D7 RID: 4311
	private Material SCMaterial;

	// Token: 0x040010D8 RID: 4312
	[Range(0f, 1000f)]
	public float Radius = 150f;

	// Token: 0x040010D9 RID: 4313
	[Range(0f, 1000f)]
	public float Factor = 200f;

	// Token: 0x040010DA RID: 4314
	[Range(1f, 8f)]
	public int FastFilter = 2;
}
