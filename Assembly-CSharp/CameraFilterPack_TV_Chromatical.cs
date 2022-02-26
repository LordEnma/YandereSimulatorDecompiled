using System;
using UnityEngine;

// Token: 0x0200020A RID: 522
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Chromatical")]
public class CameraFilterPack_TV_Chromatical : MonoBehaviour
{
	// Token: 0x1700030E RID: 782
	// (get) Token: 0x0600111F RID: 4383 RVA: 0x00086C73 File Offset: 0x00084E73
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

	// Token: 0x06001120 RID: 4384 RVA: 0x00086CA7 File Offset: 0x00084EA7
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Chromatical");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001121 RID: 4385 RVA: 0x00086CC8 File Offset: 0x00084EC8
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime * 2f;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("Intensity", this.Intensity);
			this.material.SetFloat("Speed", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001122 RID: 4386 RVA: 0x00086DA9 File Offset: 0x00084FA9
	private void Update()
	{
	}

	// Token: 0x06001123 RID: 4387 RVA: 0x00086DAB File Offset: 0x00084FAB
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015BA RID: 5562
	public Shader SCShader;

	// Token: 0x040015BB RID: 5563
	private float TimeX = 1f;

	// Token: 0x040015BC RID: 5564
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015BD RID: 5565
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x040015BE RID: 5566
	[Range(0f, 3f)]
	public float Speed = 1f;

	// Token: 0x040015BF RID: 5567
	private Material SCMaterial;
}
