using System;
using UnityEngine;

// Token: 0x0200020E RID: 526
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Horror")]
public class CameraFilterPack_TV_Horror : MonoBehaviour
{
	// Token: 0x17000312 RID: 786
	// (get) Token: 0x06001139 RID: 4409 RVA: 0x000877E5 File Offset: 0x000859E5
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

	// Token: 0x0600113A RID: 4410 RVA: 0x00087819 File Offset: 0x00085A19
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

	// Token: 0x0600113B RID: 4411 RVA: 0x00087850 File Offset: 0x00085A50
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

	// Token: 0x0600113C RID: 4412 RVA: 0x00087932 File Offset: 0x00085B32
	private void Update()
	{
	}

	// Token: 0x0600113D RID: 4413 RVA: 0x00087934 File Offset: 0x00085B34
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015E0 RID: 5600
	public Shader SCShader;

	// Token: 0x040015E1 RID: 5601
	private float TimeX = 1f;

	// Token: 0x040015E2 RID: 5602
	private Material SCMaterial;

	// Token: 0x040015E3 RID: 5603
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015E4 RID: 5604
	[Range(0f, 1f)]
	public float Distortion = 1f;

	// Token: 0x040015E5 RID: 5605
	private Texture2D Texture2;
}
