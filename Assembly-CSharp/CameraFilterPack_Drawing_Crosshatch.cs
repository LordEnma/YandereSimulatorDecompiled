using System;
using UnityEngine;

// Token: 0x02000189 RID: 393
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Crosshatch")]
public class CameraFilterPack_Drawing_Crosshatch : MonoBehaviour
{
	// Token: 0x1700028E RID: 654
	// (get) Token: 0x06000DF7 RID: 3575 RVA: 0x000781A4 File Offset: 0x000763A4
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

	// Token: 0x06000DF8 RID: 3576 RVA: 0x000781D8 File Offset: 0x000763D8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Crosshatch");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DF9 RID: 3577 RVA: 0x000781FC File Offset: 0x000763FC
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
			this.material.SetFloat("_Distortion", this.Width);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DFA RID: 3578 RVA: 0x000782B2 File Offset: 0x000764B2
	private void Update()
	{
	}

	// Token: 0x06000DFB RID: 3579 RVA: 0x000782B4 File Offset: 0x000764B4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400123A RID: 4666
	public Shader SCShader;

	// Token: 0x0400123B RID: 4667
	private float TimeX = 1f;

	// Token: 0x0400123C RID: 4668
	private Material SCMaterial;

	// Token: 0x0400123D RID: 4669
	[Range(1f, 10f)]
	public float Width = 2f;
}
