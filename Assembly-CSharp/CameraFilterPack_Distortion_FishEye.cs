using System;
using UnityEngine;

// Token: 0x02000178 RID: 376
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/FishEye")]
public class CameraFilterPack_Distortion_FishEye : MonoBehaviour
{
	// Token: 0x1700027D RID: 637
	// (get) Token: 0x06000D91 RID: 3473 RVA: 0x0007687D File Offset: 0x00074A7D
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

	// Token: 0x06000D92 RID: 3474 RVA: 0x000768B1 File Offset: 0x00074AB1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_FishEye");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D93 RID: 3475 RVA: 0x000768D4 File Offset: 0x00074AD4
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

	// Token: 0x06000D94 RID: 3476 RVA: 0x0007698A File Offset: 0x00074B8A
	private void Update()
	{
	}

	// Token: 0x06000D95 RID: 3477 RVA: 0x0007698C File Offset: 0x00074B8C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011D5 RID: 4565
	public Shader SCShader;

	// Token: 0x040011D6 RID: 4566
	private float TimeX = 1f;

	// Token: 0x040011D7 RID: 4567
	private Material SCMaterial;

	// Token: 0x040011D8 RID: 4568
	[Range(0f, 1f)]
	public float Distortion = 0.35f;
}
