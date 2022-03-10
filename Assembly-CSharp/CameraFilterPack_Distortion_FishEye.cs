using System;
using UnityEngine;

// Token: 0x02000179 RID: 377
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/FishEye")]
public class CameraFilterPack_Distortion_FishEye : MonoBehaviour
{
	// Token: 0x1700027D RID: 637
	// (get) Token: 0x06000D95 RID: 3477 RVA: 0x00076E21 File Offset: 0x00075021
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

	// Token: 0x06000D96 RID: 3478 RVA: 0x00076E55 File Offset: 0x00075055
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_FishEye");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D97 RID: 3479 RVA: 0x00076E78 File Offset: 0x00075078
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

	// Token: 0x06000D98 RID: 3480 RVA: 0x00076F2E File Offset: 0x0007512E
	private void Update()
	{
	}

	// Token: 0x06000D99 RID: 3481 RVA: 0x00076F30 File Offset: 0x00075130
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011E6 RID: 4582
	public Shader SCShader;

	// Token: 0x040011E7 RID: 4583
	private float TimeX = 1f;

	// Token: 0x040011E8 RID: 4584
	private Material SCMaterial;

	// Token: 0x040011E9 RID: 4585
	[Range(0f, 1f)]
	public float Distortion = 0.35f;
}
