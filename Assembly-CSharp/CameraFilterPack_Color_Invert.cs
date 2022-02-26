using System;
using UnityEngine;

// Token: 0x02000161 RID: 353
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Invert")]
public class CameraFilterPack_Color_Invert : MonoBehaviour
{
	// Token: 0x17000265 RID: 613
	// (get) Token: 0x06000D03 RID: 3331 RVA: 0x00074578 File Offset: 0x00072778
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

	// Token: 0x06000D04 RID: 3332 RVA: 0x000745AC File Offset: 0x000727AC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Invert");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D05 RID: 3333 RVA: 0x000745D0 File Offset: 0x000727D0
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

	// Token: 0x06000D06 RID: 3334 RVA: 0x00074686 File Offset: 0x00072886
	private void Update()
	{
	}

	// Token: 0x06000D07 RID: 3335 RVA: 0x00074688 File Offset: 0x00072888
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001152 RID: 4434
	public Shader SCShader;

	// Token: 0x04001153 RID: 4435
	private float TimeX = 1f;

	// Token: 0x04001154 RID: 4436
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x04001155 RID: 4437
	private Material SCMaterial;
}
