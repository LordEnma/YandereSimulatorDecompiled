using System;
using UnityEngine;

// Token: 0x02000203 RID: 515
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/ARCADE")]
public class CameraFilterPack_TV_ARCADE : MonoBehaviour
{
	// Token: 0x17000308 RID: 776
	// (get) Token: 0x060010F7 RID: 4343 RVA: 0x00085B84 File Offset: 0x00083D84
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

	// Token: 0x060010F8 RID: 4344 RVA: 0x00085BB8 File Offset: 0x00083DB8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_ARCADE");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010F9 RID: 4345 RVA: 0x00085BDC File Offset: 0x00083DDC
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010FA RID: 4346 RVA: 0x00085C92 File Offset: 0x00083E92
	private void Update()
	{
	}

	// Token: 0x060010FB RID: 4347 RVA: 0x00085C94 File Offset: 0x00083E94
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400157F RID: 5503
	public Shader SCShader;

	// Token: 0x04001580 RID: 5504
	private float TimeX = 1f;

	// Token: 0x04001581 RID: 5505
	private Material SCMaterial;

	// Token: 0x04001582 RID: 5506
	[Range(0f, 1f)]
	public float Fade = 1f;
}
