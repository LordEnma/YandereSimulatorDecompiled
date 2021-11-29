using System;
using UnityEngine;

// Token: 0x0200014D RID: 333
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Movie")]
public class CameraFilterPack_Blur_Movie : MonoBehaviour
{
	// Token: 0x17000252 RID: 594
	// (get) Token: 0x06000C8D RID: 3213 RVA: 0x00072121 File Offset: 0x00070321
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

	// Token: 0x06000C8E RID: 3214 RVA: 0x00072155 File Offset: 0x00070355
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Movie");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C8F RID: 3215 RVA: 0x00072178 File Offset: 0x00070378
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

	// Token: 0x06000C90 RID: 3216 RVA: 0x0007228A File Offset: 0x0007048A
	private void Update()
	{
	}

	// Token: 0x06000C91 RID: 3217 RVA: 0x0007228C File Offset: 0x0007048C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010D0 RID: 4304
	public Shader SCShader;

	// Token: 0x040010D1 RID: 4305
	private float TimeX = 1f;

	// Token: 0x040010D2 RID: 4306
	private Material SCMaterial;

	// Token: 0x040010D3 RID: 4307
	[Range(0f, 1000f)]
	public float Radius = 150f;

	// Token: 0x040010D4 RID: 4308
	[Range(0f, 1000f)]
	public float Factor = 200f;

	// Token: 0x040010D5 RID: 4309
	[Range(1f, 8f)]
	public int FastFilter = 2;
}
