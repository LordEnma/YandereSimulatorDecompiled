using System;
using UnityEngine;

// Token: 0x020001C4 RID: 452
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Film/Grain")]
public class CameraFilterPack_Film_Grain : MonoBehaviour
{
	// Token: 0x170002C8 RID: 712
	// (get) Token: 0x06000F58 RID: 3928 RVA: 0x0007DA67 File Offset: 0x0007BC67
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

	// Token: 0x06000F59 RID: 3929 RVA: 0x0007DA9B File Offset: 0x0007BC9B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Film_Grain");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F5A RID: 3930 RVA: 0x0007DABC File Offset: 0x0007BCBC
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

	// Token: 0x06000F5B RID: 3931 RVA: 0x0007DB72 File Offset: 0x0007BD72
	private void Update()
	{
	}

	// Token: 0x06000F5C RID: 3932 RVA: 0x0007DB74 File Offset: 0x0007BD74
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001397 RID: 5015
	public Shader SCShader;

	// Token: 0x04001398 RID: 5016
	private float TimeX = 1f;

	// Token: 0x04001399 RID: 5017
	private Material SCMaterial;

	// Token: 0x0400139A RID: 5018
	[Range(-64f, 64f)]
	public float Value = 32f;
}
