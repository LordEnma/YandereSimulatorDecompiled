using System;
using UnityEngine;

// Token: 0x02000220 RID: 544
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/WideScreenHV")]
public class CameraFilterPack_TV_WideScreenHV : MonoBehaviour
{
	// Token: 0x17000325 RID: 805
	// (get) Token: 0x060011A5 RID: 4517 RVA: 0x000887D3 File Offset: 0x000869D3
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

	// Token: 0x060011A6 RID: 4518 RVA: 0x00088807 File Offset: 0x00086A07
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_WideScreenHV");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011A7 RID: 4519 RVA: 0x00088828 File Offset: 0x00086A28
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.Smooth);
			this.material.SetFloat("_Value3", this.StretchX);
			this.material.SetFloat("_Value4", this.StretchY);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011A8 RID: 4520 RVA: 0x00088920 File Offset: 0x00086B20
	private void Update()
	{
	}

	// Token: 0x060011A9 RID: 4521 RVA: 0x00088922 File Offset: 0x00086B22
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400162C RID: 5676
	public Shader SCShader;

	// Token: 0x0400162D RID: 5677
	private float TimeX = 1f;

	// Token: 0x0400162E RID: 5678
	private Material SCMaterial;

	// Token: 0x0400162F RID: 5679
	[Range(0f, 0.8f)]
	public float Size = 0.55f;

	// Token: 0x04001630 RID: 5680
	[Range(0.001f, 0.4f)]
	public float Smooth = 0.01f;

	// Token: 0x04001631 RID: 5681
	[Range(0f, 10f)]
	private float StretchX = 1f;

	// Token: 0x04001632 RID: 5682
	[Range(0f, 10f)]
	private float StretchY = 1f;
}
