using System;
using UnityEngine;

// Token: 0x02000153 RID: 339
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Steam")]
public class CameraFilterPack_Blur_Steam : MonoBehaviour
{
	// Token: 0x17000257 RID: 599
	// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x0007332D File Offset: 0x0007152D
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

	// Token: 0x06000CB2 RID: 3250 RVA: 0x00073361 File Offset: 0x00071561
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Steam");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CB3 RID: 3251 RVA: 0x00073384 File Offset: 0x00071584
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
			this.material.SetFloat("_Radius", this.Radius);
			this.material.SetFloat("_Quality", this.Quality);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CB4 RID: 3252 RVA: 0x00073449 File Offset: 0x00071649
	private void Update()
	{
	}

	// Token: 0x06000CB5 RID: 3253 RVA: 0x0007344B File Offset: 0x0007164B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001106 RID: 4358
	public Shader SCShader;

	// Token: 0x04001107 RID: 4359
	private float TimeX = 1f;

	// Token: 0x04001108 RID: 4360
	private Material SCMaterial;

	// Token: 0x04001109 RID: 4361
	[Range(0f, 1f)]
	public float Radius = 0.1f;

	// Token: 0x0400110A RID: 4362
	[Range(0f, 1f)]
	public float Quality = 0.75f;
}
