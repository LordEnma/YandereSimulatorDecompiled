using System;
using UnityEngine;

// Token: 0x0200016D RID: 365
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/HUE_Rotate")]
public class CameraFilterPack_Colors_HUE_Rotate : MonoBehaviour
{
	// Token: 0x17000272 RID: 626
	// (get) Token: 0x06000D4F RID: 3407 RVA: 0x000758C7 File Offset: 0x00073AC7
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

	// Token: 0x06000D50 RID: 3408 RVA: 0x000758FB File Offset: 0x00073AFB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_HUE_Rotate");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D51 RID: 3409 RVA: 0x0007591C File Offset: 0x00073B1C
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
			this.material.SetFloat("_Speed", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D52 RID: 3410 RVA: 0x000759CB File Offset: 0x00073BCB
	private void Update()
	{
	}

	// Token: 0x06000D53 RID: 3411 RVA: 0x000759CD File Offset: 0x00073BCD
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001194 RID: 4500
	public Shader SCShader;

	// Token: 0x04001195 RID: 4501
	private float TimeX = 1f;

	// Token: 0x04001196 RID: 4502
	private Material SCMaterial;

	// Token: 0x04001197 RID: 4503
	[Range(1f, 20f)]
	public float Speed = 10f;
}
