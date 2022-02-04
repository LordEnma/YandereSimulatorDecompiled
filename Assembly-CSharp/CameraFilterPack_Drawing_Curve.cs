using System;
using UnityEngine;

// Token: 0x0200018B RID: 395
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Curve")]
public class CameraFilterPack_Drawing_Curve : MonoBehaviour
{
	// Token: 0x1700028F RID: 655
	// (get) Token: 0x06000E00 RID: 3584 RVA: 0x000784E4 File Offset: 0x000766E4
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

	// Token: 0x06000E01 RID: 3585 RVA: 0x00078518 File Offset: 0x00076718
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Curve");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E02 RID: 3586 RVA: 0x0007853C File Offset: 0x0007673C
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E03 RID: 3587 RVA: 0x000785F2 File Offset: 0x000767F2
	private void Update()
	{
	}

	// Token: 0x06000E04 RID: 3588 RVA: 0x000785F4 File Offset: 0x000767F4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001243 RID: 4675
	public Shader SCShader;

	// Token: 0x04001244 RID: 4676
	private float TimeX = 1f;

	// Token: 0x04001245 RID: 4677
	private Material SCMaterial;

	// Token: 0x04001246 RID: 4678
	[Range(3f, 5f)]
	public float Size = 1f;
}
