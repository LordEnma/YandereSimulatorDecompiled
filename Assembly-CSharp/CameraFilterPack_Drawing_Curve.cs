using System;
using UnityEngine;

// Token: 0x0200018B RID: 395
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Curve")]
public class CameraFilterPack_Drawing_Curve : MonoBehaviour
{
	// Token: 0x1700028F RID: 655
	// (get) Token: 0x06000E03 RID: 3587 RVA: 0x00078D0C File Offset: 0x00076F0C
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

	// Token: 0x06000E04 RID: 3588 RVA: 0x00078D40 File Offset: 0x00076F40
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Curve");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E05 RID: 3589 RVA: 0x00078D64 File Offset: 0x00076F64
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

	// Token: 0x06000E06 RID: 3590 RVA: 0x00078E1A File Offset: 0x0007701A
	private void Update()
	{
	}

	// Token: 0x06000E07 RID: 3591 RVA: 0x00078E1C File Offset: 0x0007701C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001256 RID: 4694
	public Shader SCShader;

	// Token: 0x04001257 RID: 4695
	private float TimeX = 1f;

	// Token: 0x04001258 RID: 4696
	private Material SCMaterial;

	// Token: 0x04001259 RID: 4697
	[Range(3f, 5f)]
	public float Size = 1f;
}
