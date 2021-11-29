using System;
using UnityEngine;

// Token: 0x020001B2 RID: 434
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Glitch1")]
public class CameraFilterPack_FX_Glitch1 : MonoBehaviour
{
	// Token: 0x170002B7 RID: 695
	// (get) Token: 0x06000EEE RID: 3822 RVA: 0x0007C038 File Offset: 0x0007A238
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

	// Token: 0x06000EEF RID: 3823 RVA: 0x0007C06C File Offset: 0x0007A26C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Glitch1");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EF0 RID: 3824 RVA: 0x0007C090 File Offset: 0x0007A290
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
			this.material.SetFloat("_Glitch", this.Glitch);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EF1 RID: 3825 RVA: 0x0007C146 File Offset: 0x0007A346
	private void Update()
	{
	}

	// Token: 0x06000EF2 RID: 3826 RVA: 0x0007C148 File Offset: 0x0007A348
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400133F RID: 4927
	public Shader SCShader;

	// Token: 0x04001340 RID: 4928
	private float TimeX = 1f;

	// Token: 0x04001341 RID: 4929
	private Material SCMaterial;

	// Token: 0x04001342 RID: 4930
	[Range(0f, 1f)]
	public float Glitch = 1f;
}
