using System;
using UnityEngine;

// Token: 0x020001B3 RID: 435
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Glitch2")]
public class CameraFilterPack_FX_Glitch2 : MonoBehaviour
{
	// Token: 0x170002B8 RID: 696
	// (get) Token: 0x06000EF4 RID: 3828 RVA: 0x0007C180 File Offset: 0x0007A380
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

	// Token: 0x06000EF5 RID: 3829 RVA: 0x0007C1B4 File Offset: 0x0007A3B4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Glitch2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EF6 RID: 3830 RVA: 0x0007C1D8 File Offset: 0x0007A3D8
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
			this.material.SetFloat("_Glitch", this.Glitch);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EF7 RID: 3831 RVA: 0x0007C28E File Offset: 0x0007A48E
	private void Update()
	{
	}

	// Token: 0x06000EF8 RID: 3832 RVA: 0x0007C290 File Offset: 0x0007A490
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001343 RID: 4931
	public Shader SCShader;

	// Token: 0x04001344 RID: 4932
	private float TimeX = 1f;

	// Token: 0x04001345 RID: 4933
	private Material SCMaterial;

	// Token: 0x04001346 RID: 4934
	[Range(0f, 1f)]
	public float Glitch = 1f;
}
