using System;
using UnityEngine;

// Token: 0x02000160 RID: 352
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Invert")]
public class CameraFilterPack_Color_Invert : MonoBehaviour
{
	// Token: 0x17000265 RID: 613
	// (get) Token: 0x06000CFF RID: 3327 RVA: 0x0007411C File Offset: 0x0007231C
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

	// Token: 0x06000D00 RID: 3328 RVA: 0x00074150 File Offset: 0x00072350
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Invert");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D01 RID: 3329 RVA: 0x00074174 File Offset: 0x00072374
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

	// Token: 0x06000D02 RID: 3330 RVA: 0x0007422A File Offset: 0x0007242A
	private void Update()
	{
	}

	// Token: 0x06000D03 RID: 3331 RVA: 0x0007422C File Offset: 0x0007242C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400114A RID: 4426
	public Shader SCShader;

	// Token: 0x0400114B RID: 4427
	private float TimeX = 1f;

	// Token: 0x0400114C RID: 4428
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x0400114D RID: 4429
	private Material SCMaterial;
}
