using System;
using UnityEngine;

// Token: 0x02000203 RID: 515
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/80s")]
public class CameraFilterPack_TV_80 : MonoBehaviour
{
	// Token: 0x17000307 RID: 775
	// (get) Token: 0x060010F5 RID: 4341 RVA: 0x00085FE0 File Offset: 0x000841E0
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

	// Token: 0x060010F6 RID: 4342 RVA: 0x00086014 File Offset: 0x00084214
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_80");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010F7 RID: 4343 RVA: 0x00086038 File Offset: 0x00084238
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
			this.material.SetFloat("_Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010F8 RID: 4344 RVA: 0x000860EE File Offset: 0x000842EE
	private void Update()
	{
	}

	// Token: 0x060010F9 RID: 4345 RVA: 0x000860F0 File Offset: 0x000842F0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400158C RID: 5516
	public Shader SCShader;

	// Token: 0x0400158D RID: 5517
	private float TimeX = 1f;

	// Token: 0x0400158E RID: 5518
	private Material SCMaterial;

	// Token: 0x0400158F RID: 5519
	[Range(0f, 1f)]
	public float Fade = 1f;
}
