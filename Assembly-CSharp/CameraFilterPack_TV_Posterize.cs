using System;
using UnityEngine;

// Token: 0x02000216 RID: 534
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Posterize")]
public class CameraFilterPack_TV_Posterize : MonoBehaviour
{
	// Token: 0x1700031A RID: 794
	// (get) Token: 0x06001166 RID: 4454 RVA: 0x00087AB1 File Offset: 0x00085CB1
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

	// Token: 0x06001167 RID: 4455 RVA: 0x00087AE5 File Offset: 0x00085CE5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Posterize");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001168 RID: 4456 RVA: 0x00087B08 File Offset: 0x00085D08
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
			this.material.SetFloat("_Distortion", this.Posterize);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001169 RID: 4457 RVA: 0x00087BA4 File Offset: 0x00085DA4
	private void Update()
	{
	}

	// Token: 0x0600116A RID: 4458 RVA: 0x00087BA6 File Offset: 0x00085DA6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015F6 RID: 5622
	public Shader SCShader;

	// Token: 0x040015F7 RID: 5623
	private float TimeX = 1f;

	// Token: 0x040015F8 RID: 5624
	[Range(1f, 256f)]
	public float Posterize = 64f;

	// Token: 0x040015F9 RID: 5625
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015FA RID: 5626
	private Material SCMaterial;
}
