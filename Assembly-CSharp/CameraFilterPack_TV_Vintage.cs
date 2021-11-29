using System;
using UnityEngine;

// Token: 0x0200021E RID: 542
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Vintage")]
public class CameraFilterPack_TV_Vintage : MonoBehaviour
{
	// Token: 0x17000323 RID: 803
	// (get) Token: 0x06001199 RID: 4505 RVA: 0x00088510 File Offset: 0x00086710
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

	// Token: 0x0600119A RID: 4506 RVA: 0x00088544 File Offset: 0x00086744
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Vintage");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600119B RID: 4507 RVA: 0x00088568 File Offset: 0x00086768
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
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600119C RID: 4508 RVA: 0x000885EE File Offset: 0x000867EE
	private void Update()
	{
	}

	// Token: 0x0600119D RID: 4509 RVA: 0x000885F0 File Offset: 0x000867F0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001621 RID: 5665
	public Shader SCShader;

	// Token: 0x04001622 RID: 5666
	private float TimeX = 1f;

	// Token: 0x04001623 RID: 5667
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x04001624 RID: 5668
	private Material SCMaterial;
}
