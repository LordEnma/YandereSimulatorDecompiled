using System;
using UnityEngine;

// Token: 0x0200021B RID: 539
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/VCR Distortion")]
public class CameraFilterPack_TV_Vcr : MonoBehaviour
{
	// Token: 0x1700031F RID: 799
	// (get) Token: 0x06001187 RID: 4487 RVA: 0x00088A7B File Offset: 0x00086C7B
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

	// Token: 0x06001188 RID: 4488 RVA: 0x00088AAF File Offset: 0x00086CAF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Vcr");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001189 RID: 4489 RVA: 0x00088AD0 File Offset: 0x00086CD0
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

	// Token: 0x0600118A RID: 4490 RVA: 0x00088B56 File Offset: 0x00086D56
	private void Update()
	{
	}

	// Token: 0x0600118B RID: 4491 RVA: 0x00088B58 File Offset: 0x00086D58
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001628 RID: 5672
	public Shader SCShader;

	// Token: 0x04001629 RID: 5673
	private float TimeX = 1f;

	// Token: 0x0400162A RID: 5674
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x0400162B RID: 5675
	private Material SCMaterial;
}
