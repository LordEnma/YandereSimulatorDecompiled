using System;
using UnityEngine;

// Token: 0x02000157 RID: 343
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Broken/Broken_Screen")]
public class CameraFilterPack_Broken_Screen : MonoBehaviour
{
	// Token: 0x1700025B RID: 603
	// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x00073615 File Offset: 0x00071815
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

	// Token: 0x06000CC8 RID: 3272 RVA: 0x00073649 File Offset: 0x00071849
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

	// Token: 0x06000CC9 RID: 3273 RVA: 0x00073680 File Offset: 0x00071880
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

	// Token: 0x06000CCA RID: 3274 RVA: 0x00073735 File Offset: 0x00071935
	private void Update()
	{
	}

	// Token: 0x06000CCB RID: 3275 RVA: 0x00073737 File Offset: 0x00071937
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001114 RID: 4372
	public Shader SCShader;

	// Token: 0x04001115 RID: 4373
	private float TimeX = 1f;

	// Token: 0x04001116 RID: 4374
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001117 RID: 4375
	[Range(-1f, 1f)]
	public float Shadow = 1f;

	// Token: 0x04001118 RID: 4376
	private Material SCMaterial;

	// Token: 0x04001119 RID: 4377
	private Texture2D Texture2;
}
