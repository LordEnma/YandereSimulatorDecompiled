using System;
using UnityEngine;

// Token: 0x02000203 RID: 515
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/80s")]
public class CameraFilterPack_TV_80 : MonoBehaviour
{
	// Token: 0x17000307 RID: 775
	// (get) Token: 0x060010F5 RID: 4341 RVA: 0x00085E98 File Offset: 0x00084098
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

	// Token: 0x060010F6 RID: 4342 RVA: 0x00085ECC File Offset: 0x000840CC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_80");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010F7 RID: 4343 RVA: 0x00085EF0 File Offset: 0x000840F0
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

	// Token: 0x060010F8 RID: 4344 RVA: 0x00085FA6 File Offset: 0x000841A6
	private void Update()
	{
	}

	// Token: 0x060010F9 RID: 4345 RVA: 0x00085FA8 File Offset: 0x000841A8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001583 RID: 5507
	public Shader SCShader;

	// Token: 0x04001584 RID: 5508
	private float TimeX = 1f;

	// Token: 0x04001585 RID: 5509
	private Material SCMaterial;

	// Token: 0x04001586 RID: 5510
	[Range(0f, 1f)]
	public float Fade = 1f;
}
