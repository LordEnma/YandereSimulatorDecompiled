using System;
using UnityEngine;

// Token: 0x020001AC RID: 428
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/DigitalMatrixDistortion")]
public class CameraFilterPack_FX_DigitalMatrixDistortion : MonoBehaviour
{
	// Token: 0x170002B1 RID: 689
	// (get) Token: 0x06000ECA RID: 3786 RVA: 0x0007B699 File Offset: 0x00079899
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

	// Token: 0x06000ECB RID: 3787 RVA: 0x0007B6CD File Offset: 0x000798CD
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_DigitalMatrixDistortion");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000ECC RID: 3788 RVA: 0x0007B6F0 File Offset: 0x000798F0
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.Distortion);
			this.material.SetFloat("_Value5", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000ECD RID: 3789 RVA: 0x0007B7D2 File Offset: 0x000799D2
	private void Update()
	{
	}

	// Token: 0x06000ECE RID: 3790 RVA: 0x0007B7D4 File Offset: 0x000799D4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001316 RID: 4886
	public Shader SCShader;

	// Token: 0x04001317 RID: 4887
	private float TimeX = 1f;

	// Token: 0x04001318 RID: 4888
	private Material SCMaterial;

	// Token: 0x04001319 RID: 4889
	[Range(0.4f, 5f)]
	public float Size = 1.4f;

	// Token: 0x0400131A RID: 4890
	[Range(-2f, 2f)]
	public float Speed = 0.5f;

	// Token: 0x0400131B RID: 4891
	[Range(-5f, 5f)]
	public float Distortion = 2.3f;
}
