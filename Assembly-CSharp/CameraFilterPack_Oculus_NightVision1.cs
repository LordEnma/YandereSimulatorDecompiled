using System;
using UnityEngine;

// Token: 0x020001EF RID: 495
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 1")]
public class CameraFilterPack_Oculus_NightVision1 : MonoBehaviour
{
	// Token: 0x170002F4 RID: 756
	// (get) Token: 0x0600107A RID: 4218 RVA: 0x000837DF File Offset: 0x000819DF
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

	// Token: 0x0600107B RID: 4219 RVA: 0x00083813 File Offset: 0x00081A13
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Oculus_NightVision1");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600107C RID: 4220 RVA: 0x00083834 File Offset: 0x00081A34
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

	// Token: 0x0600107D RID: 4221 RVA: 0x00083916 File Offset: 0x00081B16
	private void Update()
	{
	}

	// Token: 0x0600107E RID: 4222 RVA: 0x00083918 File Offset: 0x00081B18
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014FD RID: 5373
	public Shader SCShader;

	// Token: 0x040014FE RID: 5374
	private float TimeX = 1f;

	// Token: 0x040014FF RID: 5375
	private float Distortion = 1f;

	// Token: 0x04001500 RID: 5376
	private Material SCMaterial;

	// Token: 0x04001501 RID: 5377
	[Range(0f, 100f)]
	public float Vignette = 1.3f;

	// Token: 0x04001502 RID: 5378
	[Range(1f, 150f)]
	public float Linecount = 90f;
}
