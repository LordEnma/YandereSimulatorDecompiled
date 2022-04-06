using System;
using UnityEngine;

// Token: 0x020001BD RID: 445
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Psycho")]
public class CameraFilterPack_FX_Psycho : MonoBehaviour
{
	// Token: 0x170002C1 RID: 705
	// (get) Token: 0x06000F30 RID: 3888 RVA: 0x0007D704 File Offset: 0x0007B904
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

	// Token: 0x06000F31 RID: 3889 RVA: 0x0007D738 File Offset: 0x0007B938
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Psycho");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F32 RID: 3890 RVA: 0x0007D75C File Offset: 0x0007B95C
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

	// Token: 0x06000F33 RID: 3891 RVA: 0x0007D7E2 File Offset: 0x0007B9E2
	private void Update()
	{
	}

	// Token: 0x06000F34 RID: 3892 RVA: 0x0007D7E4 File Offset: 0x0007B9E4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001381 RID: 4993
	public Shader SCShader;

	// Token: 0x04001382 RID: 4994
	private Material SCMaterial;

	// Token: 0x04001383 RID: 4995
	private float TimeX = 1f;

	// Token: 0x04001384 RID: 4996
	[Range(0f, 1f)]
	public float Distortion = 1f;
}
