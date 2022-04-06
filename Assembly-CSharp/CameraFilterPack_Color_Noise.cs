using System;
using UnityEngine;

// Token: 0x02000162 RID: 354
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Noise")]
public class CameraFilterPack_Color_Noise : MonoBehaviour
{
	// Token: 0x17000266 RID: 614
	// (get) Token: 0x06000D0B RID: 3339 RVA: 0x00074C84 File Offset: 0x00072E84
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

	// Token: 0x06000D0C RID: 3340 RVA: 0x00074CB8 File Offset: 0x00072EB8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D0D RID: 3341 RVA: 0x00074CDC File Offset: 0x00072EDC
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

	// Token: 0x06000D0E RID: 3342 RVA: 0x00074D92 File Offset: 0x00072F92
	private void Update()
	{
	}

	// Token: 0x06000D0F RID: 3343 RVA: 0x00074D94 File Offset: 0x00072F94
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001166 RID: 4454
	public Shader SCShader;

	// Token: 0x04001167 RID: 4455
	private float TimeX = 1f;

	// Token: 0x04001168 RID: 4456
	private Material SCMaterial;

	// Token: 0x04001169 RID: 4457
	[Range(0f, 1f)]
	public float Noise = 0.235f;
}
