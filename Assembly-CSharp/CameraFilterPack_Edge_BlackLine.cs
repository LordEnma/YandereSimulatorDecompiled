using System;
using UnityEngine;

// Token: 0x020001A0 RID: 416
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/BlackLine")]
public class CameraFilterPack_Edge_BlackLine : MonoBehaviour
{
	// Token: 0x170002A4 RID: 676
	// (get) Token: 0x06000E80 RID: 3712 RVA: 0x0007A875 File Offset: 0x00078A75
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

	// Token: 0x06000E81 RID: 3713 RVA: 0x0007A8A9 File Offset: 0x00078AA9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_BlackLine");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E82 RID: 3714 RVA: 0x0007A8CC File Offset: 0x00078ACC
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
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E83 RID: 3715 RVA: 0x0007A962 File Offset: 0x00078B62
	private void Update()
	{
	}

	// Token: 0x06000E84 RID: 3716 RVA: 0x0007A964 File Offset: 0x00078B64
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012D7 RID: 4823
	public Shader SCShader;

	// Token: 0x040012D8 RID: 4824
	private float TimeX = 1f;

	// Token: 0x040012D9 RID: 4825
	private Material SCMaterial;
}
