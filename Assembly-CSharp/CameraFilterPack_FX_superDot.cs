using System;
using UnityEngine;

// Token: 0x020001C2 RID: 450
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/SuperDot")]
public class CameraFilterPack_FX_superDot : MonoBehaviour
{
	// Token: 0x170002C6 RID: 710
	// (get) Token: 0x06000F4C RID: 3916 RVA: 0x0007D798 File Offset: 0x0007B998
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

	// Token: 0x06000F4D RID: 3917 RVA: 0x0007D7CC File Offset: 0x0007B9CC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_superDot");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F4E RID: 3918 RVA: 0x0007D7F0 File Offset: 0x0007B9F0
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

	// Token: 0x06000F4F RID: 3919 RVA: 0x0007D88D File Offset: 0x0007BA8D
	private void Update()
	{
	}

	// Token: 0x06000F50 RID: 3920 RVA: 0x0007D88F File Offset: 0x0007BA8F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400138D RID: 5005
	public Shader SCShader;

	// Token: 0x0400138E RID: 5006
	private float TimeX = 1f;

	// Token: 0x0400138F RID: 5007
	private Material SCMaterial;
}
