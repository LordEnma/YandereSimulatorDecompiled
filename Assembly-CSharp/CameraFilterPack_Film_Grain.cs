using System;
using UnityEngine;

// Token: 0x020001C3 RID: 451
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Film/Grain")]
public class CameraFilterPack_Film_Grain : MonoBehaviour
{
	// Token: 0x170002C8 RID: 712
	// (get) Token: 0x06000F54 RID: 3924 RVA: 0x0007D71F File Offset: 0x0007B91F
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

	// Token: 0x06000F55 RID: 3925 RVA: 0x0007D753 File Offset: 0x0007B953
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Film_Grain");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F56 RID: 3926 RVA: 0x0007D774 File Offset: 0x0007B974
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

	// Token: 0x06000F57 RID: 3927 RVA: 0x0007D82A File Offset: 0x0007BA2A
	private void Update()
	{
	}

	// Token: 0x06000F58 RID: 3928 RVA: 0x0007D82C File Offset: 0x0007BA2C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400138F RID: 5007
	public Shader SCShader;

	// Token: 0x04001390 RID: 5008
	private float TimeX = 1f;

	// Token: 0x04001391 RID: 5009
	private Material SCMaterial;

	// Token: 0x04001392 RID: 5010
	[Range(-64f, 64f)]
	public float Value = 32f;
}
