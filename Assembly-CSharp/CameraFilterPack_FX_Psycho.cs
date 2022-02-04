using System;
using UnityEngine;

// Token: 0x020001BD RID: 445
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Psycho")]
public class CameraFilterPack_FX_Psycho : MonoBehaviour
{
	// Token: 0x170002C1 RID: 705
	// (get) Token: 0x06000F2D RID: 3885 RVA: 0x0007CEDC File Offset: 0x0007B0DC
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

	// Token: 0x06000F2E RID: 3886 RVA: 0x0007CF10 File Offset: 0x0007B110
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Psycho");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F2F RID: 3887 RVA: 0x0007CF34 File Offset: 0x0007B134
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

	// Token: 0x06000F30 RID: 3888 RVA: 0x0007CFBA File Offset: 0x0007B1BA
	private void Update()
	{
	}

	// Token: 0x06000F31 RID: 3889 RVA: 0x0007CFBC File Offset: 0x0007B1BC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400136E RID: 4974
	public Shader SCShader;

	// Token: 0x0400136F RID: 4975
	private Material SCMaterial;

	// Token: 0x04001370 RID: 4976
	private float TimeX = 1f;

	// Token: 0x04001371 RID: 4977
	[Range(0f, 1f)]
	public float Distortion = 1f;
}
