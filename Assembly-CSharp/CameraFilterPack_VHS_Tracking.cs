using System;
using UnityEngine;

// Token: 0x02000224 RID: 548
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/Tracking")]
public class CameraFilterPack_VHS_Tracking : MonoBehaviour
{
	// Token: 0x17000328 RID: 808
	// (get) Token: 0x060011BB RID: 4539 RVA: 0x0008926F File Offset: 0x0008746F
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

	// Token: 0x060011BC RID: 4540 RVA: 0x000892A3 File Offset: 0x000874A3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/VHS_Tracking");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011BD RID: 4541 RVA: 0x000892C4 File Offset: 0x000874C4
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
			this.material.SetFloat("_Value", this.Tracking);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011BE RID: 4542 RVA: 0x0008937A File Offset: 0x0008757A
	private void Update()
	{
	}

	// Token: 0x060011BF RID: 4543 RVA: 0x0008937C File Offset: 0x0008757C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001652 RID: 5714
	public Shader SCShader;

	// Token: 0x04001653 RID: 5715
	private float TimeX = 1f;

	// Token: 0x04001654 RID: 5716
	private Material SCMaterial;

	// Token: 0x04001655 RID: 5717
	[Range(0f, 2f)]
	public float Tracking = 1f;
}
