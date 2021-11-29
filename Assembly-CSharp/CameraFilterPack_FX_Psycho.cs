using System;
using UnityEngine;

// Token: 0x020001BC RID: 444
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Psycho")]
public class CameraFilterPack_FX_Psycho : MonoBehaviour
{
	// Token: 0x170002C1 RID: 705
	// (get) Token: 0x06000F2A RID: 3882 RVA: 0x0007CCE4 File Offset: 0x0007AEE4
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

	// Token: 0x06000F2B RID: 3883 RVA: 0x0007CD18 File Offset: 0x0007AF18
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Psycho");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F2C RID: 3884 RVA: 0x0007CD3C File Offset: 0x0007AF3C
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

	// Token: 0x06000F2D RID: 3885 RVA: 0x0007CDC2 File Offset: 0x0007AFC2
	private void Update()
	{
	}

	// Token: 0x06000F2E RID: 3886 RVA: 0x0007CDC4 File Offset: 0x0007AFC4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001369 RID: 4969
	public Shader SCShader;

	// Token: 0x0400136A RID: 4970
	private Material SCMaterial;

	// Token: 0x0400136B RID: 4971
	private float TimeX = 1f;

	// Token: 0x0400136C RID: 4972
	[Range(0f, 1f)]
	public float Distortion = 1f;
}
