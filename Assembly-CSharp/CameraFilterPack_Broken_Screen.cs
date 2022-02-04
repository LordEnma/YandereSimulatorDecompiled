using System;
using UnityEngine;

// Token: 0x02000157 RID: 343
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Broken/Broken_Screen")]
public class CameraFilterPack_Broken_Screen : MonoBehaviour
{
	// Token: 0x1700025B RID: 603
	// (get) Token: 0x06000CC6 RID: 3270 RVA: 0x000733B1 File Offset: 0x000715B1
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

	// Token: 0x06000CC7 RID: 3271 RVA: 0x000733E5 File Offset: 0x000715E5
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

	// Token: 0x06000CC8 RID: 3272 RVA: 0x0007341C File Offset: 0x0007161C
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

	// Token: 0x06000CC9 RID: 3273 RVA: 0x000734D1 File Offset: 0x000716D1
	private void Update()
	{
	}

	// Token: 0x06000CCA RID: 3274 RVA: 0x000734D3 File Offset: 0x000716D3
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001111 RID: 4369
	public Shader SCShader;

	// Token: 0x04001112 RID: 4370
	private float TimeX = 1f;

	// Token: 0x04001113 RID: 4371
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001114 RID: 4372
	[Range(-1f, 1f)]
	public float Shadow = 1f;

	// Token: 0x04001115 RID: 4373
	private Material SCMaterial;

	// Token: 0x04001116 RID: 4374
	private Texture2D Texture2;
}
