using System;
using UnityEngine;

// Token: 0x02000160 RID: 352
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/GrayScale")]
public class CameraFilterPack_Color_GrayScale : MonoBehaviour
{
	// Token: 0x17000264 RID: 612
	// (get) Token: 0x06000CFD RID: 3325 RVA: 0x00074578 File Offset: 0x00072778
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

	// Token: 0x06000CFE RID: 3326 RVA: 0x000745AC File Offset: 0x000727AC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_GrayScale");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CFF RID: 3327 RVA: 0x000745D0 File Offset: 0x000727D0
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

	// Token: 0x06000D00 RID: 3328 RVA: 0x00074686 File Offset: 0x00072886
	private void Update()
	{
	}

	// Token: 0x06000D01 RID: 3329 RVA: 0x00074688 File Offset: 0x00072888
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001157 RID: 4439
	public Shader SCShader;

	// Token: 0x04001158 RID: 4440
	private float TimeX = 1f;

	// Token: 0x04001159 RID: 4441
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x0400115A RID: 4442
	private Material SCMaterial;
}
