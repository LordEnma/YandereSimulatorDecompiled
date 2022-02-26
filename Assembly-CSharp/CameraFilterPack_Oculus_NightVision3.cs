using System;
using UnityEngine;

// Token: 0x020001F2 RID: 498
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 3")]
public class CameraFilterPack_Oculus_NightVision3 : MonoBehaviour
{
	// Token: 0x170002F6 RID: 758
	// (get) Token: 0x0600108C RID: 4236 RVA: 0x000840A6 File Offset: 0x000822A6
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

	// Token: 0x0600108D RID: 4237 RVA: 0x000840DA File Offset: 0x000822DA
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Oculus_NightVision3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600108E RID: 4238 RVA: 0x000840FC File Offset: 0x000822FC
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
			this.material.SetFloat("_Greenness", this.Greenness);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600108F RID: 4239 RVA: 0x000841AB File Offset: 0x000823AB
	private void Update()
	{
	}

	// Token: 0x06001090 RID: 4240 RVA: 0x000841AD File Offset: 0x000823AD
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001511 RID: 5393
	public Shader SCShader;

	// Token: 0x04001512 RID: 5394
	private float TimeX = 1f;

	// Token: 0x04001513 RID: 5395
	private Material SCMaterial;

	// Token: 0x04001514 RID: 5396
	[Range(0.2f, 2f)]
	public float Greenness = 1f;
}
