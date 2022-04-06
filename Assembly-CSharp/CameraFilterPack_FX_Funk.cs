using System;
using UnityEngine;

// Token: 0x020001B2 RID: 434
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Funk")]
public class CameraFilterPack_FX_Funk : MonoBehaviour
{
	// Token: 0x170002B6 RID: 694
	// (get) Token: 0x06000EEE RID: 3822 RVA: 0x0007C937 File Offset: 0x0007AB37
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

	// Token: 0x06000EEF RID: 3823 RVA: 0x0007C96B File Offset: 0x0007AB6B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Funk");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EF0 RID: 3824 RVA: 0x0007C98C File Offset: 0x0007AB8C
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EF1 RID: 3825 RVA: 0x0007CA29 File Offset: 0x0007AC29
	private void Update()
	{
	}

	// Token: 0x06000EF2 RID: 3826 RVA: 0x0007CA2B File Offset: 0x0007AC2B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001354 RID: 4948
	public Shader SCShader;

	// Token: 0x04001355 RID: 4949
	private float TimeX = 1f;

	// Token: 0x04001356 RID: 4950
	private Material SCMaterial;
}
