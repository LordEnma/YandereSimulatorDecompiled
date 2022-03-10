using System;
using UnityEngine;

// Token: 0x0200018A RID: 394
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Crosshatch")]
public class CameraFilterPack_Drawing_Crosshatch : MonoBehaviour
{
	// Token: 0x1700028E RID: 654
	// (get) Token: 0x06000DFB RID: 3579 RVA: 0x00078748 File Offset: 0x00076948
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

	// Token: 0x06000DFC RID: 3580 RVA: 0x0007877C File Offset: 0x0007697C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Crosshatch");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DFD RID: 3581 RVA: 0x000787A0 File Offset: 0x000769A0
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

	// Token: 0x06000DFE RID: 3582 RVA: 0x00078856 File Offset: 0x00076A56
	private void Update()
	{
	}

	// Token: 0x06000DFF RID: 3583 RVA: 0x00078858 File Offset: 0x00076A58
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400124B RID: 4683
	public Shader SCShader;

	// Token: 0x0400124C RID: 4684
	private float TimeX = 1f;

	// Token: 0x0400124D RID: 4685
	private Material SCMaterial;

	// Token: 0x0400124E RID: 4686
	[Range(1f, 10f)]
	public float Width = 2f;
}
