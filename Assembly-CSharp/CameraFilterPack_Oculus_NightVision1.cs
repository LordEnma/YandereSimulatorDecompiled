using System;
using UnityEngine;

// Token: 0x020001F0 RID: 496
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 1")]
public class CameraFilterPack_Oculus_NightVision1 : MonoBehaviour
{
	// Token: 0x170002F4 RID: 756
	// (get) Token: 0x0600107E RID: 4222 RVA: 0x00083D83 File Offset: 0x00081F83
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

	// Token: 0x0600107F RID: 4223 RVA: 0x00083DB7 File Offset: 0x00081FB7
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Oculus_NightVision1");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001080 RID: 4224 RVA: 0x00083DD8 File Offset: 0x00081FD8
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
			this.material.SetFloat("_Vignette", this.Vignette);
			this.material.SetFloat("_Linecount", this.Linecount);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001081 RID: 4225 RVA: 0x00083EBA File Offset: 0x000820BA
	private void Update()
	{
	}

	// Token: 0x06001082 RID: 4226 RVA: 0x00083EBC File Offset: 0x000820BC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400150E RID: 5390
	public Shader SCShader;

	// Token: 0x0400150F RID: 5391
	private float TimeX = 1f;

	// Token: 0x04001510 RID: 5392
	private float Distortion = 1f;

	// Token: 0x04001511 RID: 5393
	private Material SCMaterial;

	// Token: 0x04001512 RID: 5394
	[Range(0f, 100f)]
	public float Vignette = 1.3f;

	// Token: 0x04001513 RID: 5395
	[Range(1f, 150f)]
	public float Linecount = 90f;
}
