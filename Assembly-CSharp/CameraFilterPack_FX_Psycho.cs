using System;
using UnityEngine;

// Token: 0x020001BD RID: 445
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Psycho")]
public class CameraFilterPack_FX_Psycho : MonoBehaviour
{
	// Token: 0x170002C1 RID: 705
	// (get) Token: 0x06000F2E RID: 3886 RVA: 0x0007D288 File Offset: 0x0007B488
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

	// Token: 0x06000F2F RID: 3887 RVA: 0x0007D2BC File Offset: 0x0007B4BC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Psycho");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F30 RID: 3888 RVA: 0x0007D2E0 File Offset: 0x0007B4E0
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

	// Token: 0x06000F31 RID: 3889 RVA: 0x0007D366 File Offset: 0x0007B566
	private void Update()
	{
	}

	// Token: 0x06000F32 RID: 3890 RVA: 0x0007D368 File Offset: 0x0007B568
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400137A RID: 4986
	public Shader SCShader;

	// Token: 0x0400137B RID: 4987
	private Material SCMaterial;

	// Token: 0x0400137C RID: 4988
	private float TimeX = 1f;

	// Token: 0x0400137D RID: 4989
	[Range(0f, 1f)]
	public float Distortion = 1f;
}
