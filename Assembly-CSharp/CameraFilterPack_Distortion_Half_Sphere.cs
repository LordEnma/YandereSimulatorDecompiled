using System;
using UnityEngine;

// Token: 0x0200017C RID: 380
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Half_Sphere")]
public class CameraFilterPack_Distortion_Half_Sphere : MonoBehaviour
{
	// Token: 0x17000280 RID: 640
	// (get) Token: 0x06000DA9 RID: 3497 RVA: 0x0007766C File Offset: 0x0007586C
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

	// Token: 0x06000DAA RID: 3498 RVA: 0x000776A0 File Offset: 0x000758A0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Half_Sphere");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DAB RID: 3499 RVA: 0x000776C4 File Offset: 0x000758C4
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
			this.material.SetFloat("_SphereSize", this.SphereSize);
			this.material.SetFloat("_SpherePositionX", this.SpherePositionX);
			this.material.SetFloat("_SpherePositionY", this.SpherePositionY);
			this.material.SetFloat("_Strength", this.Strength);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DAC RID: 3500 RVA: 0x000777B5 File Offset: 0x000759B5
	private void Update()
	{
	}

	// Token: 0x06000DAD RID: 3501 RVA: 0x000777B7 File Offset: 0x000759B7
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011FA RID: 4602
	public Shader SCShader;

	// Token: 0x040011FB RID: 4603
	private float TimeX = 1f;

	// Token: 0x040011FC RID: 4604
	[Range(1f, 6f)]
	private Material SCMaterial;

	// Token: 0x040011FD RID: 4605
	public float SphereSize = 2.5f;

	// Token: 0x040011FE RID: 4606
	[Range(-1f, 1f)]
	public float SpherePositionX;

	// Token: 0x040011FF RID: 4607
	[Range(-1f, 1f)]
	public float SpherePositionY;

	// Token: 0x04001200 RID: 4608
	[Range(1f, 10f)]
	public float Strength = 5f;
}
