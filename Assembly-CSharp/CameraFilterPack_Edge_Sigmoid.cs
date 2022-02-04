using System;
using UnityEngine;

// Token: 0x020001A4 RID: 420
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Sigmoid")]
public class CameraFilterPack_Edge_Sigmoid : MonoBehaviour
{
	// Token: 0x170002A8 RID: 680
	// (get) Token: 0x06000E97 RID: 3735 RVA: 0x0007AAF5 File Offset: 0x00078CF5
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

	// Token: 0x06000E98 RID: 3736 RVA: 0x0007AB29 File Offset: 0x00078D29
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Sigmoid");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E99 RID: 3737 RVA: 0x0007AB4C File Offset: 0x00078D4C
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
			this.material.SetFloat("_Gain", this.Gain);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E9A RID: 3738 RVA: 0x0007ABFB File Offset: 0x00078DFB
	private void Update()
	{
	}

	// Token: 0x06000E9B RID: 3739 RVA: 0x0007ABFD File Offset: 0x00078DFD
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012E4 RID: 4836
	public Shader SCShader;

	// Token: 0x040012E5 RID: 4837
	private float TimeX = 1f;

	// Token: 0x040012E6 RID: 4838
	private Material SCMaterial;

	// Token: 0x040012E7 RID: 4839
	[Range(1f, 10f)]
	public float Gain = 3f;
}
