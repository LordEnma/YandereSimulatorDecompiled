using System;
using UnityEngine;

// Token: 0x0200018A RID: 394
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Crosshatch")]
public class CameraFilterPack_Drawing_Crosshatch : MonoBehaviour
{
	// Token: 0x1700028E RID: 654
	// (get) Token: 0x06000DFD RID: 3581 RVA: 0x00078BC4 File Offset: 0x00076DC4
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

	// Token: 0x06000DFE RID: 3582 RVA: 0x00078BF8 File Offset: 0x00076DF8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Crosshatch");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DFF RID: 3583 RVA: 0x00078C1C File Offset: 0x00076E1C
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

	// Token: 0x06000E00 RID: 3584 RVA: 0x00078CD2 File Offset: 0x00076ED2
	private void Update()
	{
	}

	// Token: 0x06000E01 RID: 3585 RVA: 0x00078CD4 File Offset: 0x00076ED4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001252 RID: 4690
	public Shader SCShader;

	// Token: 0x04001253 RID: 4691
	private float TimeX = 1f;

	// Token: 0x04001254 RID: 4692
	private Material SCMaterial;

	// Token: 0x04001255 RID: 4693
	[Range(1f, 10f)]
	public float Width = 2f;
}
