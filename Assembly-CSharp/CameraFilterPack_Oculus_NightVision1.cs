using System;
using UnityEngine;

// Token: 0x020001F0 RID: 496
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 1")]
public class CameraFilterPack_Oculus_NightVision1 : MonoBehaviour
{
	// Token: 0x170002F4 RID: 756
	// (get) Token: 0x06001080 RID: 4224 RVA: 0x000841FF File Offset: 0x000823FF
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

	// Token: 0x06001081 RID: 4225 RVA: 0x00084233 File Offset: 0x00082433
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Oculus_NightVision1");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001082 RID: 4226 RVA: 0x00084254 File Offset: 0x00082454
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

	// Token: 0x06001083 RID: 4227 RVA: 0x00084336 File Offset: 0x00082536
	private void Update()
	{
	}

	// Token: 0x06001084 RID: 4228 RVA: 0x00084338 File Offset: 0x00082538
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001515 RID: 5397
	public Shader SCShader;

	// Token: 0x04001516 RID: 5398
	private float TimeX = 1f;

	// Token: 0x04001517 RID: 5399
	private float Distortion = 1f;

	// Token: 0x04001518 RID: 5400
	private Material SCMaterial;

	// Token: 0x04001519 RID: 5401
	[Range(0f, 100f)]
	public float Vignette = 1.3f;

	// Token: 0x0400151A RID: 5402
	[Range(1f, 150f)]
	public float Linecount = 90f;
}
