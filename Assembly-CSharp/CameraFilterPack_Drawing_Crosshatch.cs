using System;
using UnityEngine;

// Token: 0x0200018A RID: 394
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Crosshatch")]
public class CameraFilterPack_Drawing_Crosshatch : MonoBehaviour
{
	// Token: 0x1700028E RID: 654
	// (get) Token: 0x06000DFB RID: 3579 RVA: 0x00078600 File Offset: 0x00076800
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

	// Token: 0x06000DFC RID: 3580 RVA: 0x00078634 File Offset: 0x00076834
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Crosshatch");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DFD RID: 3581 RVA: 0x00078658 File Offset: 0x00076858
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

	// Token: 0x06000DFE RID: 3582 RVA: 0x0007870E File Offset: 0x0007690E
	private void Update()
	{
	}

	// Token: 0x06000DFF RID: 3583 RVA: 0x00078710 File Offset: 0x00076910
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001242 RID: 4674
	public Shader SCShader;

	// Token: 0x04001243 RID: 4675
	private float TimeX = 1f;

	// Token: 0x04001244 RID: 4676
	private Material SCMaterial;

	// Token: 0x04001245 RID: 4677
	[Range(1f, 10f)]
	public float Width = 2f;
}
