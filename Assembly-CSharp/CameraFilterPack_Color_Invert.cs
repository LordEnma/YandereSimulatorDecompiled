using System;
using UnityEngine;

// Token: 0x02000161 RID: 353
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Invert")]
public class CameraFilterPack_Color_Invert : MonoBehaviour
{
	// Token: 0x17000265 RID: 613
	// (get) Token: 0x06000D02 RID: 3330 RVA: 0x00074314 File Offset: 0x00072514
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

	// Token: 0x06000D03 RID: 3331 RVA: 0x00074348 File Offset: 0x00072548
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Invert");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D04 RID: 3332 RVA: 0x0007436C File Offset: 0x0007256C
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
			this.material.SetFloat("_Fade", this._Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D05 RID: 3333 RVA: 0x00074422 File Offset: 0x00072622
	private void Update()
	{
	}

	// Token: 0x06000D06 RID: 3334 RVA: 0x00074424 File Offset: 0x00072624
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400114F RID: 4431
	public Shader SCShader;

	// Token: 0x04001150 RID: 4432
	private float TimeX = 1f;

	// Token: 0x04001151 RID: 4433
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x04001152 RID: 4434
	private Material SCMaterial;
}
