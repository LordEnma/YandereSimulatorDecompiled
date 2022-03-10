using System;
using UnityEngine;

// Token: 0x020001F2 RID: 498
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 3")]
public class CameraFilterPack_Oculus_NightVision3 : MonoBehaviour
{
	// Token: 0x170002F6 RID: 758
	// (get) Token: 0x0600108C RID: 4236 RVA: 0x000841EE File Offset: 0x000823EE
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

	// Token: 0x0600108D RID: 4237 RVA: 0x00084222 File Offset: 0x00082422
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Oculus_NightVision3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600108E RID: 4238 RVA: 0x00084244 File Offset: 0x00082444
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

	// Token: 0x0600108F RID: 4239 RVA: 0x000842F3 File Offset: 0x000824F3
	private void Update()
	{
	}

	// Token: 0x06001090 RID: 4240 RVA: 0x000842F5 File Offset: 0x000824F5
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400151A RID: 5402
	public Shader SCShader;

	// Token: 0x0400151B RID: 5403
	private float TimeX = 1f;

	// Token: 0x0400151C RID: 5404
	private Material SCMaterial;

	// Token: 0x0400151D RID: 5405
	[Range(0.2f, 2f)]
	public float Greenness = 1f;
}
