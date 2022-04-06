using System;
using UnityEngine;

// Token: 0x02000204 RID: 516
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/ARCADE")]
public class CameraFilterPack_TV_ARCADE : MonoBehaviour
{
	// Token: 0x17000308 RID: 776
	// (get) Token: 0x060010FD RID: 4349 RVA: 0x000865A4 File Offset: 0x000847A4
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

	// Token: 0x060010FE RID: 4350 RVA: 0x000865D8 File Offset: 0x000847D8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_ARCADE");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010FF RID: 4351 RVA: 0x000865FC File Offset: 0x000847FC
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001100 RID: 4352 RVA: 0x000866B2 File Offset: 0x000848B2
	private void Update()
	{
	}

	// Token: 0x06001101 RID: 4353 RVA: 0x000866B4 File Offset: 0x000848B4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001597 RID: 5527
	public Shader SCShader;

	// Token: 0x04001598 RID: 5528
	private float TimeX = 1f;

	// Token: 0x04001599 RID: 5529
	private Material SCMaterial;

	// Token: 0x0400159A RID: 5530
	[Range(0f, 1f)]
	public float Fade = 1f;
}
