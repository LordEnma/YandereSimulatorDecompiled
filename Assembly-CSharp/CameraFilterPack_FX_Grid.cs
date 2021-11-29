using System;
using UnityEngine;

// Token: 0x020001B5 RID: 437
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Grid")]
public class CameraFilterPack_FX_Grid : MonoBehaviour
{
	// Token: 0x170002BA RID: 698
	// (get) Token: 0x06000F00 RID: 3840 RVA: 0x0007C431 File Offset: 0x0007A631
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

	// Token: 0x06000F01 RID: 3841 RVA: 0x0007C465 File Offset: 0x0007A665
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Grid");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F02 RID: 3842 RVA: 0x0007C488 File Offset: 0x0007A688
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

	// Token: 0x06000F03 RID: 3843 RVA: 0x0007C50E File Offset: 0x0007A70E
	private void Update()
	{
	}

	// Token: 0x06000F04 RID: 3844 RVA: 0x0007C510 File Offset: 0x0007A710
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400134C RID: 4940
	public Shader SCShader;

	// Token: 0x0400134D RID: 4941
	private float TimeX = 1f;

	// Token: 0x0400134E RID: 4942
	private Material SCMaterial;

	// Token: 0x0400134F RID: 4943
	[Range(0f, 5f)]
	public float Distortion = 1f;

	// Token: 0x04001350 RID: 4944
	public static float ChangeDistortion;
}
