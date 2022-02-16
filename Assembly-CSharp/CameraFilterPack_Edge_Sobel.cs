using System;
using UnityEngine;

// Token: 0x020001A5 RID: 421
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Sobel")]
public class CameraFilterPack_Edge_Sobel : MonoBehaviour
{
	// Token: 0x170002A9 RID: 681
	// (get) Token: 0x06000E9E RID: 3742 RVA: 0x0007AD85 File Offset: 0x00078F85
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

	// Token: 0x06000E9F RID: 3743 RVA: 0x0007ADB9 File Offset: 0x00078FB9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Sobel");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EA0 RID: 3744 RVA: 0x0007ADDC File Offset: 0x00078FDC
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EA1 RID: 3745 RVA: 0x0007AE79 File Offset: 0x00079079
	private void Update()
	{
	}

	// Token: 0x06000EA2 RID: 3746 RVA: 0x0007AE7B File Offset: 0x0007907B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012EB RID: 4843
	public Shader SCShader;

	// Token: 0x040012EC RID: 4844
	private float TimeX = 1f;

	// Token: 0x040012ED RID: 4845
	private Material SCMaterial;
}
