using System;
using UnityEngine;

// Token: 0x02000210 RID: 528
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Noise")]
public class CameraFilterPack_TV_Noise : MonoBehaviour
{
	// Token: 0x17000315 RID: 789
	// (get) Token: 0x06001145 RID: 4421 RVA: 0x00087218 File Offset: 0x00085418
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

	// Token: 0x06001146 RID: 4422 RVA: 0x0008724C File Offset: 0x0008544C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001147 RID: 4423 RVA: 0x00087270 File Offset: 0x00085470
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
			this.material.SetFloat("_Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001148 RID: 4424 RVA: 0x00087326 File Offset: 0x00085526
	private void Update()
	{
	}

	// Token: 0x06001149 RID: 4425 RVA: 0x00087328 File Offset: 0x00085528
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015D8 RID: 5592
	public Shader SCShader;

	// Token: 0x040015D9 RID: 5593
	private float TimeX = 1f;

	// Token: 0x040015DA RID: 5594
	private Material SCMaterial;

	// Token: 0x040015DB RID: 5595
	[Range(0.0001f, 1f)]
	public float Fade = 0.01f;
}
