using System;
using UnityEngine;

// Token: 0x020001B6 RID: 438
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Grid")]
public class CameraFilterPack_FX_Grid : MonoBehaviour
{
	// Token: 0x170002BA RID: 698
	// (get) Token: 0x06000F06 RID: 3846 RVA: 0x0007CE51 File Offset: 0x0007B051
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

	// Token: 0x06000F07 RID: 3847 RVA: 0x0007CE85 File Offset: 0x0007B085
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Grid");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F08 RID: 3848 RVA: 0x0007CEA8 File Offset: 0x0007B0A8
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
			this.material.SetFloat("_Distortion", this.Distortion);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F09 RID: 3849 RVA: 0x0007CF2E File Offset: 0x0007B12E
	private void Update()
	{
	}

	// Token: 0x06000F0A RID: 3850 RVA: 0x0007CF30 File Offset: 0x0007B130
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001364 RID: 4964
	public Shader SCShader;

	// Token: 0x04001365 RID: 4965
	private float TimeX = 1f;

	// Token: 0x04001366 RID: 4966
	private Material SCMaterial;

	// Token: 0x04001367 RID: 4967
	[Range(0f, 5f)]
	public float Distortion = 1f;

	// Token: 0x04001368 RID: 4968
	public static float ChangeDistortion;
}
