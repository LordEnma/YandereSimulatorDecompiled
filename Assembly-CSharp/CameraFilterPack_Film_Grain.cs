using System;
using UnityEngine;

// Token: 0x020001C4 RID: 452
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Film/Grain")]
public class CameraFilterPack_Film_Grain : MonoBehaviour
{
	// Token: 0x170002C8 RID: 712
	// (get) Token: 0x06000F57 RID: 3927 RVA: 0x0007D917 File Offset: 0x0007BB17
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

	// Token: 0x06000F58 RID: 3928 RVA: 0x0007D94B File Offset: 0x0007BB4B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Film_Grain");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F59 RID: 3929 RVA: 0x0007D96C File Offset: 0x0007BB6C
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

	// Token: 0x06000F5A RID: 3930 RVA: 0x0007DA22 File Offset: 0x0007BC22
	private void Update()
	{
	}

	// Token: 0x06000F5B RID: 3931 RVA: 0x0007DA24 File Offset: 0x0007BC24
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001394 RID: 5012
	public Shader SCShader;

	// Token: 0x04001395 RID: 5013
	private float TimeX = 1f;

	// Token: 0x04001396 RID: 5014
	private Material SCMaterial;

	// Token: 0x04001397 RID: 5015
	[Range(-64f, 64f)]
	public float Value = 32f;
}
