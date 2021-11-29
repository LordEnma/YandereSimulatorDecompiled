using System;
using UnityEngine;

// Token: 0x02000161 RID: 353
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Noise")]
public class CameraFilterPack_Color_Noise : MonoBehaviour
{
	// Token: 0x17000266 RID: 614
	// (get) Token: 0x06000D05 RID: 3333 RVA: 0x00074264 File Offset: 0x00072464
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

	// Token: 0x06000D06 RID: 3334 RVA: 0x00074298 File Offset: 0x00072498
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D07 RID: 3335 RVA: 0x000742BC File Offset: 0x000724BC
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
			this.material.SetFloat("_Noise", this.Noise);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D08 RID: 3336 RVA: 0x00074372 File Offset: 0x00072572
	private void Update()
	{
	}

	// Token: 0x06000D09 RID: 3337 RVA: 0x00074374 File Offset: 0x00072574
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400114E RID: 4430
	public Shader SCShader;

	// Token: 0x0400114F RID: 4431
	private float TimeX = 1f;

	// Token: 0x04001150 RID: 4432
	private Material SCMaterial;

	// Token: 0x04001151 RID: 4433
	[Range(0f, 1f)]
	public float Noise = 0.235f;
}
