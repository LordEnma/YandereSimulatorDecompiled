using System;
using UnityEngine;

// Token: 0x0200020E RID: 526
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Horror")]
public class CameraFilterPack_TV_Horror : MonoBehaviour
{
	// Token: 0x17000312 RID: 786
	// (get) Token: 0x06001137 RID: 4407 RVA: 0x00087369 File Offset: 0x00085569
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

	// Token: 0x06001138 RID: 4408 RVA: 0x0008739D File Offset: 0x0008559D
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_TV_HorrorFX") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/TV_Horror");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001139 RID: 4409 RVA: 0x000873D4 File Offset: 0x000855D4
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetTexture("Texture2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600113A RID: 4410 RVA: 0x000874B6 File Offset: 0x000856B6
	private void Update()
	{
	}

	// Token: 0x0600113B RID: 4411 RVA: 0x000874B8 File Offset: 0x000856B8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015D9 RID: 5593
	public Shader SCShader;

	// Token: 0x040015DA RID: 5594
	private float TimeX = 1f;

	// Token: 0x040015DB RID: 5595
	private Material SCMaterial;

	// Token: 0x040015DC RID: 5596
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015DD RID: 5597
	[Range(0f, 1f)]
	public float Distortion = 1f;

	// Token: 0x040015DE RID: 5598
	private Texture2D Texture2;
}
