using System;
using UnityEngine;

// Token: 0x0200017D RID: 381
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Heat")]
public class CameraFilterPack_Distortion_Heat : MonoBehaviour
{
	// Token: 0x17000281 RID: 641
	// (get) Token: 0x06000DAD RID: 3501 RVA: 0x00077236 File Offset: 0x00075436
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

	// Token: 0x06000DAE RID: 3502 RVA: 0x0007726A File Offset: 0x0007546A
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Heat");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DAF RID: 3503 RVA: 0x0007728C File Offset: 0x0007548C
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DB0 RID: 3504 RVA: 0x00077342 File Offset: 0x00075542
	private void Update()
	{
	}

	// Token: 0x06000DB1 RID: 3505 RVA: 0x00077344 File Offset: 0x00075544
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011F1 RID: 4593
	public Shader SCShader;

	// Token: 0x040011F2 RID: 4594
	private float TimeX = 1f;

	// Token: 0x040011F3 RID: 4595
	private Material SCMaterial;

	// Token: 0x040011F4 RID: 4596
	[Range(1f, 100f)]
	public float Distortion = 35f;
}
