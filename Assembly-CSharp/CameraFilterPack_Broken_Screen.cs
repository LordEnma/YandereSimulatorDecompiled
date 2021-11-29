using System;
using UnityEngine;

// Token: 0x02000156 RID: 342
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Broken/Broken_Screen")]
public class CameraFilterPack_Broken_Screen : MonoBehaviour
{
	// Token: 0x1700025B RID: 603
	// (get) Token: 0x06000CC3 RID: 3267 RVA: 0x000731B9 File Offset: 0x000713B9
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

	// Token: 0x06000CC4 RID: 3268 RVA: 0x000731ED File Offset: 0x000713ED
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Broken_Screen1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Broken_Screen");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CC5 RID: 3269 RVA: 0x00073224 File Offset: 0x00071424
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
			this.material.SetFloat("_Fade", this.Fade);
			this.material.SetFloat("_Shadow", this.Shadow);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CC6 RID: 3270 RVA: 0x000732D9 File Offset: 0x000714D9
	private void Update()
	{
	}

	// Token: 0x06000CC7 RID: 3271 RVA: 0x000732DB File Offset: 0x000714DB
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
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x0400110F RID: 4367
	[Range(-1f, 1f)]
	public float Shadow = 1f;

	// Token: 0x04001110 RID: 4368
	private Material SCMaterial;

	// Token: 0x04001111 RID: 4369
	private Texture2D Texture2;
}
