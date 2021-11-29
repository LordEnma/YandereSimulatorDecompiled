using System;
using UnityEngine;

// Token: 0x02000201 RID: 513
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/50s")]
public class CameraFilterPack_TV_50 : MonoBehaviour
{
	// Token: 0x17000306 RID: 774
	// (get) Token: 0x060010EB RID: 4331 RVA: 0x000858F7 File Offset: 0x00083AF7
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

	// Token: 0x060010EC RID: 4332 RVA: 0x0008592B File Offset: 0x00083B2B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_50");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010ED RID: 4333 RVA: 0x0008594C File Offset: 0x00083B4C
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

	// Token: 0x060010EE RID: 4334 RVA: 0x00085A02 File Offset: 0x00083C02
	private void Update()
	{
	}

	// Token: 0x060010EF RID: 4335 RVA: 0x00085A04 File Offset: 0x00083C04
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001577 RID: 5495
	public Shader SCShader;

	// Token: 0x04001578 RID: 5496
	private float TimeX = 1f;

	// Token: 0x04001579 RID: 5497
	private Material SCMaterial;

	// Token: 0x0400157A RID: 5498
	[Range(0f, 1f)]
	public float Fade = 1f;
}
