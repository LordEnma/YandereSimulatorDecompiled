using System;
using UnityEngine;

// Token: 0x02000216 RID: 534
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Posterize")]
public class CameraFilterPack_TV_Posterize : MonoBehaviour
{
	// Token: 0x1700031A RID: 794
	// (get) Token: 0x06001169 RID: 4457 RVA: 0x000882D9 File Offset: 0x000864D9
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

	// Token: 0x0600116A RID: 4458 RVA: 0x0008830D File Offset: 0x0008650D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Posterize");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600116B RID: 4459 RVA: 0x00088330 File Offset: 0x00086530
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
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("_Distortion", this.Posterize);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600116C RID: 4460 RVA: 0x000883CC File Offset: 0x000865CC
	private void Update()
	{
	}

	// Token: 0x0600116D RID: 4461 RVA: 0x000883CE File Offset: 0x000865CE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001609 RID: 5641
	public Shader SCShader;

	// Token: 0x0400160A RID: 5642
	private float TimeX = 1f;

	// Token: 0x0400160B RID: 5643
	[Range(1f, 256f)]
	public float Posterize = 64f;

	// Token: 0x0400160C RID: 5644
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x0400160D RID: 5645
	private Material SCMaterial;
}
