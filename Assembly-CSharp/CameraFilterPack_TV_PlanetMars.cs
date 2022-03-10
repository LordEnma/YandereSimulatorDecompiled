using System;
using UnityEngine;

// Token: 0x02000215 RID: 533
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Planet Mars")]
public class CameraFilterPack_TV_PlanetMars : MonoBehaviour
{
	// Token: 0x17000319 RID: 793
	// (get) Token: 0x06001161 RID: 4449 RVA: 0x00087CF5 File Offset: 0x00085EF5
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

	// Token: 0x06001162 RID: 4450 RVA: 0x00087D29 File Offset: 0x00085F29
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_PlanetMars");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001163 RID: 4451 RVA: 0x00087D4C File Offset: 0x00085F4C
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
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001164 RID: 4452 RVA: 0x00087E18 File Offset: 0x00086018
	private void Update()
	{
	}

	// Token: 0x06001165 RID: 4453 RVA: 0x00087E1A File Offset: 0x0008601A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015FD RID: 5629
	public Shader SCShader;

	// Token: 0x040015FE RID: 5630
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015FF RID: 5631
	private float TimeX = 1f;

	// Token: 0x04001600 RID: 5632
	[Range(-10f, 10f)]
	public float Distortion = 1f;

	// Token: 0x04001601 RID: 5633
	private Material SCMaterial;
}
