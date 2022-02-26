using System;
using UnityEngine;

// Token: 0x02000179 RID: 377
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/FishEye")]
public class CameraFilterPack_Distortion_FishEye : MonoBehaviour
{
	// Token: 0x1700027D RID: 637
	// (get) Token: 0x06000D95 RID: 3477 RVA: 0x00076CD9 File Offset: 0x00074ED9
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

	// Token: 0x06000D96 RID: 3478 RVA: 0x00076D0D File Offset: 0x00074F0D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_FishEye");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D97 RID: 3479 RVA: 0x00076D30 File Offset: 0x00074F30
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

	// Token: 0x06000D98 RID: 3480 RVA: 0x00076DE6 File Offset: 0x00074FE6
	private void Update()
	{
	}

	// Token: 0x06000D99 RID: 3481 RVA: 0x00076DE8 File Offset: 0x00074FE8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011DD RID: 4573
	public Shader SCShader;

	// Token: 0x040011DE RID: 4574
	private float TimeX = 1f;

	// Token: 0x040011DF RID: 4575
	private Material SCMaterial;

	// Token: 0x040011E0 RID: 4576
	[Range(0f, 1f)]
	public float Distortion = 0.35f;
}
