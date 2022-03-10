using System;
using UnityEngine;

// Token: 0x0200021B RID: 539
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/VCR Distortion")]
public class CameraFilterPack_TV_Vcr : MonoBehaviour
{
	// Token: 0x1700031F RID: 799
	// (get) Token: 0x06001185 RID: 4485 RVA: 0x000885FF File Offset: 0x000867FF
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

	// Token: 0x06001186 RID: 4486 RVA: 0x00088633 File Offset: 0x00086833
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Vcr");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001187 RID: 4487 RVA: 0x00088654 File Offset: 0x00086854
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

	// Token: 0x06001188 RID: 4488 RVA: 0x000886DA File Offset: 0x000868DA
	private void Update()
	{
	}

	// Token: 0x06001189 RID: 4489 RVA: 0x000886DC File Offset: 0x000868DC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001621 RID: 5665
	public Shader SCShader;

	// Token: 0x04001622 RID: 5666
	private float TimeX = 1f;

	// Token: 0x04001623 RID: 5667
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x04001624 RID: 5668
	private Material SCMaterial;
}
