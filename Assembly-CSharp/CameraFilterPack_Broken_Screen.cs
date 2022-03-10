using System;
using UnityEngine;

// Token: 0x02000157 RID: 343
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Broken/Broken_Screen")]
public class CameraFilterPack_Broken_Screen : MonoBehaviour
{
	// Token: 0x1700025B RID: 603
	// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x0007375D File Offset: 0x0007195D
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

	// Token: 0x06000CC8 RID: 3272 RVA: 0x00073791 File Offset: 0x00071991
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

	// Token: 0x06000CC9 RID: 3273 RVA: 0x000737C8 File Offset: 0x000719C8
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

	// Token: 0x06000CCA RID: 3274 RVA: 0x0007387D File Offset: 0x00071A7D
	private void Update()
	{
	}

	// Token: 0x06000CCB RID: 3275 RVA: 0x0007387F File Offset: 0x00071A7F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400111D RID: 4381
	public Shader SCShader;

	// Token: 0x0400111E RID: 4382
	private float TimeX = 1f;

	// Token: 0x0400111F RID: 4383
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001120 RID: 4384
	[Range(-1f, 1f)]
	public float Shadow = 1f;

	// Token: 0x04001121 RID: 4385
	private Material SCMaterial;

	// Token: 0x04001122 RID: 4386
	private Texture2D Texture2;
}
