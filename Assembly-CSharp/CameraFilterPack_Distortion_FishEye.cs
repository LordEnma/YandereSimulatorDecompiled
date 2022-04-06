using System;
using UnityEngine;

// Token: 0x02000179 RID: 377
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/FishEye")]
public class CameraFilterPack_Distortion_FishEye : MonoBehaviour
{
	// Token: 0x1700027D RID: 637
	// (get) Token: 0x06000D97 RID: 3479 RVA: 0x0007729D File Offset: 0x0007549D
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

	// Token: 0x06000D98 RID: 3480 RVA: 0x000772D1 File Offset: 0x000754D1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_FishEye");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D99 RID: 3481 RVA: 0x000772F4 File Offset: 0x000754F4
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D9A RID: 3482 RVA: 0x000773AA File Offset: 0x000755AA
	private void Update()
	{
	}

	// Token: 0x06000D9B RID: 3483 RVA: 0x000773AC File Offset: 0x000755AC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011ED RID: 4589
	public Shader SCShader;

	// Token: 0x040011EE RID: 4590
	private float TimeX = 1f;

	// Token: 0x040011EF RID: 4591
	private Material SCMaterial;

	// Token: 0x040011F0 RID: 4592
	[Range(0f, 1f)]
	public float Distortion = 0.35f;
}
