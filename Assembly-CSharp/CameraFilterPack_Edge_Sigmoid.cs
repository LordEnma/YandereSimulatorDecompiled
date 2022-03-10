using System;
using UnityEngine;

// Token: 0x020001A4 RID: 420
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Sigmoid")]
public class CameraFilterPack_Edge_Sigmoid : MonoBehaviour
{
	// Token: 0x170002A8 RID: 680
	// (get) Token: 0x06000E98 RID: 3736 RVA: 0x0007AEA1 File Offset: 0x000790A1
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

	// Token: 0x06000E99 RID: 3737 RVA: 0x0007AED5 File Offset: 0x000790D5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Sigmoid");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E9A RID: 3738 RVA: 0x0007AEF8 File Offset: 0x000790F8
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

	// Token: 0x06000E9B RID: 3739 RVA: 0x0007AFA7 File Offset: 0x000791A7
	private void Update()
	{
	}

	// Token: 0x06000E9C RID: 3740 RVA: 0x0007AFA9 File Offset: 0x000791A9
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012F0 RID: 4848
	public Shader SCShader;

	// Token: 0x040012F1 RID: 4849
	private float TimeX = 1f;

	// Token: 0x040012F2 RID: 4850
	private Material SCMaterial;

	// Token: 0x040012F3 RID: 4851
	[Range(1f, 10f)]
	public float Gain = 3f;
}
