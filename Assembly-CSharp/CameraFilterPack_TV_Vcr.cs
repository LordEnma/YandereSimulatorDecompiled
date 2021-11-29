using System;
using UnityEngine;

// Token: 0x0200021A RID: 538
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/VCR Distortion")]
public class CameraFilterPack_TV_Vcr : MonoBehaviour
{
	// Token: 0x1700031F RID: 799
	// (get) Token: 0x06001181 RID: 4481 RVA: 0x0008805B File Offset: 0x0008625B
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

	// Token: 0x06001182 RID: 4482 RVA: 0x0008808F File Offset: 0x0008628F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Vcr");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001183 RID: 4483 RVA: 0x000880B0 File Offset: 0x000862B0
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

	// Token: 0x06001184 RID: 4484 RVA: 0x00088136 File Offset: 0x00086336
	private void Update()
	{
	}

	// Token: 0x06001185 RID: 4485 RVA: 0x00088138 File Offset: 0x00086338
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001610 RID: 5648
	public Shader SCShader;

	// Token: 0x04001611 RID: 5649
	private float TimeX = 1f;

	// Token: 0x04001612 RID: 5650
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x04001613 RID: 5651
	private Material SCMaterial;
}
