using System;
using UnityEngine;

// Token: 0x0200018B RID: 395
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Curve")]
public class CameraFilterPack_Drawing_Curve : MonoBehaviour
{
	// Token: 0x1700028F RID: 655
	// (get) Token: 0x06000E01 RID: 3585 RVA: 0x00078890 File Offset: 0x00076A90
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

	// Token: 0x06000E02 RID: 3586 RVA: 0x000788C4 File Offset: 0x00076AC4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Curve");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E03 RID: 3587 RVA: 0x000788E8 File Offset: 0x00076AE8
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E04 RID: 3588 RVA: 0x0007899E File Offset: 0x00076B9E
	private void Update()
	{
	}

	// Token: 0x06000E05 RID: 3589 RVA: 0x000789A0 File Offset: 0x00076BA0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400124F RID: 4687
	public Shader SCShader;

	// Token: 0x04001250 RID: 4688
	private float TimeX = 1f;

	// Token: 0x04001251 RID: 4689
	private Material SCMaterial;

	// Token: 0x04001252 RID: 4690
	[Range(3f, 5f)]
	public float Size = 1f;
}
