using System;
using UnityEngine;

// Token: 0x020001BA RID: 442
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Mirror")]
public class CameraFilterPack_FX_Mirror : MonoBehaviour
{
	// Token: 0x170002BF RID: 703
	// (get) Token: 0x06000F1E RID: 3870 RVA: 0x0007CA78 File Offset: 0x0007AC78
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

	// Token: 0x06000F1F RID: 3871 RVA: 0x0007CAAC File Offset: 0x0007ACAC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Mirror");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F20 RID: 3872 RVA: 0x0007CAD0 File Offset: 0x0007ACD0
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

	// Token: 0x06000F21 RID: 3873 RVA: 0x0007CB6D File Offset: 0x0007AD6D
	private void Update()
	{
	}

	// Token: 0x06000F22 RID: 3874 RVA: 0x0007CB6F File Offset: 0x0007AD6F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001362 RID: 4962
	public Shader SCShader;

	// Token: 0x04001363 RID: 4963
	private float TimeX = 1f;

	// Token: 0x04001364 RID: 4964
	private Material SCMaterial;
}
