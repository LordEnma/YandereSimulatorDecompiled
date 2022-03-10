using System;
using UnityEngine;

// Token: 0x02000162 RID: 354
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Noise")]
public class CameraFilterPack_Color_Noise : MonoBehaviour
{
	// Token: 0x17000266 RID: 614
	// (get) Token: 0x06000D09 RID: 3337 RVA: 0x00074808 File Offset: 0x00072A08
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

	// Token: 0x06000D0A RID: 3338 RVA: 0x0007483C File Offset: 0x00072A3C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D0B RID: 3339 RVA: 0x00074860 File Offset: 0x00072A60
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

	// Token: 0x06000D0C RID: 3340 RVA: 0x00074916 File Offset: 0x00072B16
	private void Update()
	{
	}

	// Token: 0x06000D0D RID: 3341 RVA: 0x00074918 File Offset: 0x00072B18
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400115F RID: 4447
	public Shader SCShader;

	// Token: 0x04001160 RID: 4448
	private float TimeX = 1f;

	// Token: 0x04001161 RID: 4449
	private Material SCMaterial;

	// Token: 0x04001162 RID: 4450
	[Range(0f, 1f)]
	public float Noise = 0.235f;
}
