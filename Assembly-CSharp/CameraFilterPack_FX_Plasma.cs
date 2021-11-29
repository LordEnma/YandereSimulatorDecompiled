using System;
using UnityEngine;

// Token: 0x020001BB RID: 443
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Plasma")]
public class CameraFilterPack_FX_Plasma : MonoBehaviour
{
	// Token: 0x170002C0 RID: 704
	// (get) Token: 0x06000F24 RID: 3876 RVA: 0x0007CB9C File Offset: 0x0007AD9C
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

	// Token: 0x06000F25 RID: 3877 RVA: 0x0007CBD0 File Offset: 0x0007ADD0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Plasma");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F26 RID: 3878 RVA: 0x0007CBF4 File Offset: 0x0007ADF4
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F27 RID: 3879 RVA: 0x0007CCAA File Offset: 0x0007AEAA
	private void Update()
	{
	}

	// Token: 0x06000F28 RID: 3880 RVA: 0x0007CCAC File Offset: 0x0007AEAC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001365 RID: 4965
	public Shader SCShader;

	// Token: 0x04001366 RID: 4966
	private float TimeX = 1f;

	// Token: 0x04001367 RID: 4967
	private Material SCMaterial;

	// Token: 0x04001368 RID: 4968
	[Range(0f, 20f)]
	private float Value = 6f;
}
