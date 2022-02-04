using System;
using UnityEngine;

// Token: 0x0200021B RID: 539
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/VCR Distortion")]
public class CameraFilterPack_TV_Vcr : MonoBehaviour
{
	// Token: 0x1700031F RID: 799
	// (get) Token: 0x06001184 RID: 4484 RVA: 0x00088253 File Offset: 0x00086453
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

	// Token: 0x06001185 RID: 4485 RVA: 0x00088287 File Offset: 0x00086487
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Vcr");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001186 RID: 4486 RVA: 0x000882A8 File Offset: 0x000864A8
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
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001187 RID: 4487 RVA: 0x0008832E File Offset: 0x0008652E
	private void Update()
	{
	}

	// Token: 0x06001188 RID: 4488 RVA: 0x00088330 File Offset: 0x00086530
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001615 RID: 5653
	public Shader SCShader;

	// Token: 0x04001616 RID: 5654
	private float TimeX = 1f;

	// Token: 0x04001617 RID: 5655
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x04001618 RID: 5656
	private Material SCMaterial;
}
