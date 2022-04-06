using System;
using UnityEngine;

// Token: 0x020001F2 RID: 498
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 3")]
public class CameraFilterPack_Oculus_NightVision3 : MonoBehaviour
{
	// Token: 0x170002F6 RID: 758
	// (get) Token: 0x0600108E RID: 4238 RVA: 0x0008466A File Offset: 0x0008286A
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

	// Token: 0x0600108F RID: 4239 RVA: 0x0008469E File Offset: 0x0008289E
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Oculus_NightVision3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001090 RID: 4240 RVA: 0x000846C0 File Offset: 0x000828C0
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

	// Token: 0x06001091 RID: 4241 RVA: 0x0008476F File Offset: 0x0008296F
	private void Update()
	{
	}

	// Token: 0x06001092 RID: 4242 RVA: 0x00084771 File Offset: 0x00082971
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001521 RID: 5409
	public Shader SCShader;

	// Token: 0x04001522 RID: 5410
	private float TimeX = 1f;

	// Token: 0x04001523 RID: 5411
	private Material SCMaterial;

	// Token: 0x04001524 RID: 5412
	[Range(0.2f, 2f)]
	public float Greenness = 1f;
}
