using System;
using UnityEngine;

// Token: 0x020001B2 RID: 434
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Funk")]
public class CameraFilterPack_FX_Funk : MonoBehaviour
{
	// Token: 0x170002B6 RID: 694
	// (get) Token: 0x06000EEC RID: 3820 RVA: 0x0007C4BB File Offset: 0x0007A6BB
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

	// Token: 0x06000EED RID: 3821 RVA: 0x0007C4EF File Offset: 0x0007A6EF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Funk");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EEE RID: 3822 RVA: 0x0007C510 File Offset: 0x0007A710
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

	// Token: 0x06000EEF RID: 3823 RVA: 0x0007C5AD File Offset: 0x0007A7AD
	private void Update()
	{
	}

	// Token: 0x06000EF0 RID: 3824 RVA: 0x0007C5AF File Offset: 0x0007A7AF
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400134D RID: 4941
	public Shader SCShader;

	// Token: 0x0400134E RID: 4942
	private float TimeX = 1f;

	// Token: 0x0400134F RID: 4943
	private Material SCMaterial;
}
