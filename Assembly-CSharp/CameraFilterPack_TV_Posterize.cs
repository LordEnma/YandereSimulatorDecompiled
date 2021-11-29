using System;
using UnityEngine;

// Token: 0x02000215 RID: 533
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Posterize")]
public class CameraFilterPack_TV_Posterize : MonoBehaviour
{
	// Token: 0x1700031A RID: 794
	// (get) Token: 0x06001163 RID: 4451 RVA: 0x000878B9 File Offset: 0x00085AB9
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

	// Token: 0x06001164 RID: 4452 RVA: 0x000878ED File Offset: 0x00085AED
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Posterize");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001165 RID: 4453 RVA: 0x00087910 File Offset: 0x00085B10
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

	// Token: 0x06001166 RID: 4454 RVA: 0x000879AC File Offset: 0x00085BAC
	private void Update()
	{
	}

	// Token: 0x06001167 RID: 4455 RVA: 0x000879AE File Offset: 0x00085BAE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015F1 RID: 5617
	public Shader SCShader;

	// Token: 0x040015F2 RID: 5618
	private float TimeX = 1f;

	// Token: 0x040015F3 RID: 5619
	[Range(1f, 256f)]
	public float Posterize = 64f;

	// Token: 0x040015F4 RID: 5620
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015F5 RID: 5621
	private Material SCMaterial;
}
