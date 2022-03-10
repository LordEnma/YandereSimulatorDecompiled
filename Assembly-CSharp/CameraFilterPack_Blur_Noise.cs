using System;
using UnityEngine;

// Token: 0x0200014F RID: 335
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Noise")]
public class CameraFilterPack_Blur_Noise : MonoBehaviour
{
	// Token: 0x17000253 RID: 595
	// (get) Token: 0x06000C97 RID: 3223 RVA: 0x0007287A File Offset: 0x00070A7A
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

	// Token: 0x06000C98 RID: 3224 RVA: 0x000728AE File Offset: 0x00070AAE
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C99 RID: 3225 RVA: 0x000728D0 File Offset: 0x00070AD0
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
			this.material.SetFloat("_Level", (float)this.Level);
			this.material.SetVector("_Distance", this.Distance);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C9A RID: 3226 RVA: 0x000729A2 File Offset: 0x00070BA2
	private void Update()
	{
	}

	// Token: 0x06000C9B RID: 3227 RVA: 0x000729A4 File Offset: 0x00070BA4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010E7 RID: 4327
	public Shader SCShader;

	// Token: 0x040010E8 RID: 4328
	private float TimeX = 1f;

	// Token: 0x040010E9 RID: 4329
	private Material SCMaterial;

	// Token: 0x040010EA RID: 4330
	[Range(2f, 16f)]
	public int Level = 4;

	// Token: 0x040010EB RID: 4331
	public Vector2 Distance = new Vector2(30f, 0f);
}
