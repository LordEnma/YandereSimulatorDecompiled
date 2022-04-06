using System;
using UnityEngine;

// Token: 0x020001A1 RID: 417
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Edge_filter")]
public class CameraFilterPack_Edge_Edge_filter : MonoBehaviour
{
	// Token: 0x170002A5 RID: 677
	// (get) Token: 0x06000E88 RID: 3720 RVA: 0x0007AF55 File Offset: 0x00079155
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

	// Token: 0x06000E89 RID: 3721 RVA: 0x0007AF89 File Offset: 0x00079189
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Edge_filter");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E8A RID: 3722 RVA: 0x0007AFAC File Offset: 0x000791AC
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
			this.material.SetFloat("_RedAmplifier", this.RedAmplifier);
			this.material.SetFloat("_GreenAmplifier", this.GreenAmplifier);
			this.material.SetFloat("_BlueAmplifier", this.BlueAmplifier);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E8B RID: 3723 RVA: 0x0007B087 File Offset: 0x00079287
	private void Update()
	{
	}

	// Token: 0x06000E8C RID: 3724 RVA: 0x0007B089 File Offset: 0x00079289
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012EA RID: 4842
	public Shader SCShader;

	// Token: 0x040012EB RID: 4843
	private float TimeX = 1f;

	// Token: 0x040012EC RID: 4844
	private Material SCMaterial;

	// Token: 0x040012ED RID: 4845
	[Range(0f, 10f)]
	public float RedAmplifier;

	// Token: 0x040012EE RID: 4846
	[Range(0f, 10f)]
	public float GreenAmplifier = 2f;

	// Token: 0x040012EF RID: 4847
	[Range(0f, 10f)]
	public float BlueAmplifier;
}
