using System;
using UnityEngine;

// Token: 0x020001BD RID: 445
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Psycho")]
public class CameraFilterPack_FX_Psycho : MonoBehaviour
{
	// Token: 0x170002C1 RID: 705
	// (get) Token: 0x06000F2E RID: 3886 RVA: 0x0007D140 File Offset: 0x0007B340
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

	// Token: 0x06000F2F RID: 3887 RVA: 0x0007D174 File Offset: 0x0007B374
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Psycho");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F30 RID: 3888 RVA: 0x0007D198 File Offset: 0x0007B398
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

	// Token: 0x06000F31 RID: 3889 RVA: 0x0007D21E File Offset: 0x0007B41E
	private void Update()
	{
	}

	// Token: 0x06000F32 RID: 3890 RVA: 0x0007D220 File Offset: 0x0007B420
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001371 RID: 4977
	public Shader SCShader;

	// Token: 0x04001372 RID: 4978
	private Material SCMaterial;

	// Token: 0x04001373 RID: 4979
	private float TimeX = 1f;

	// Token: 0x04001374 RID: 4980
	[Range(0f, 1f)]
	public float Distortion = 1f;
}
