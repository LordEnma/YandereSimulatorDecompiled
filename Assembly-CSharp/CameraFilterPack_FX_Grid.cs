using System;
using UnityEngine;

// Token: 0x020001B6 RID: 438
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Grid")]
public class CameraFilterPack_FX_Grid : MonoBehaviour
{
	// Token: 0x170002BA RID: 698
	// (get) Token: 0x06000F04 RID: 3844 RVA: 0x0007C9D5 File Offset: 0x0007ABD5
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

	// Token: 0x06000F05 RID: 3845 RVA: 0x0007CA09 File Offset: 0x0007AC09
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Grid");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F06 RID: 3846 RVA: 0x0007CA2C File Offset: 0x0007AC2C
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

	// Token: 0x06000F07 RID: 3847 RVA: 0x0007CAB2 File Offset: 0x0007ACB2
	private void Update()
	{
	}

	// Token: 0x06000F08 RID: 3848 RVA: 0x0007CAB4 File Offset: 0x0007ACB4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400135D RID: 4957
	public Shader SCShader;

	// Token: 0x0400135E RID: 4958
	private float TimeX = 1f;

	// Token: 0x0400135F RID: 4959
	private Material SCMaterial;

	// Token: 0x04001360 RID: 4960
	[Range(0f, 5f)]
	public float Distortion = 1f;

	// Token: 0x04001361 RID: 4961
	public static float ChangeDistortion;
}
