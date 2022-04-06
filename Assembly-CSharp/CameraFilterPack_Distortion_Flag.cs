using System;
using UnityEngine;

// Token: 0x0200017A RID: 378
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Flag")]
public class CameraFilterPack_Distortion_Flag : MonoBehaviour
{
	// Token: 0x1700027E RID: 638
	// (get) Token: 0x06000D9D RID: 3485 RVA: 0x000773E4 File Offset: 0x000755E4
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

	// Token: 0x06000D9E RID: 3486 RVA: 0x00077418 File Offset: 0x00075618
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Flag");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D9F RID: 3487 RVA: 0x0007743C File Offset: 0x0007563C
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
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DA0 RID: 3488 RVA: 0x000774EB File Offset: 0x000756EB
	private void Update()
	{
	}

	// Token: 0x06000DA1 RID: 3489 RVA: 0x000774ED File Offset: 0x000756ED
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011F1 RID: 4593
	public Shader SCShader;

	// Token: 0x040011F2 RID: 4594
	private float TimeX = 1f;

	// Token: 0x040011F3 RID: 4595
	[Range(0f, 2f)]
	public float Distortion = 1f;

	// Token: 0x040011F4 RID: 4596
	private Material SCMaterial;

	// Token: 0x040011F5 RID: 4597
	public static float ChangeDistortion;
}
