using System;
using UnityEngine;

// Token: 0x020001C4 RID: 452
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Film/Grain")]
public class CameraFilterPack_Film_Grain : MonoBehaviour
{
	// Token: 0x170002C8 RID: 712
	// (get) Token: 0x06000F5A RID: 3930 RVA: 0x0007E13F File Offset: 0x0007C33F
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

	// Token: 0x06000F5B RID: 3931 RVA: 0x0007E173 File Offset: 0x0007C373
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Film_Grain");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F5C RID: 3932 RVA: 0x0007E194 File Offset: 0x0007C394
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

	// Token: 0x06000F5D RID: 3933 RVA: 0x0007E24A File Offset: 0x0007C44A
	private void Update()
	{
	}

	// Token: 0x06000F5E RID: 3934 RVA: 0x0007E24C File Offset: 0x0007C44C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013A7 RID: 5031
	public Shader SCShader;

	// Token: 0x040013A8 RID: 5032
	private float TimeX = 1f;

	// Token: 0x040013A9 RID: 5033
	private Material SCMaterial;

	// Token: 0x040013AA RID: 5034
	[Range(-64f, 64f)]
	public float Value = 32f;
}
