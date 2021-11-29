using System;
using UnityEngine;

// Token: 0x020001A1 RID: 417
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Golden")]
public class CameraFilterPack_Edge_Golden : MonoBehaviour
{
	// Token: 0x170002A6 RID: 678
	// (get) Token: 0x06000E88 RID: 3720 RVA: 0x0007A6A1 File Offset: 0x000788A1
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

	// Token: 0x06000E89 RID: 3721 RVA: 0x0007A6D5 File Offset: 0x000788D5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Golden");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E8A RID: 3722 RVA: 0x0007A6F8 File Offset: 0x000788F8
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

	// Token: 0x06000E8B RID: 3723 RVA: 0x0007A78E File Offset: 0x0007898E
	private void Update()
	{
	}

	// Token: 0x06000E8C RID: 3724 RVA: 0x0007A790 File Offset: 0x00078990
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012D8 RID: 4824
	public Shader SCShader;

	// Token: 0x040012D9 RID: 4825
	private float TimeX = 1f;

	// Token: 0x040012DA RID: 4826
	private Material SCMaterial;
}
