using System;
using UnityEngine;

// Token: 0x02000212 RID: 530
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Old")]
public class CameraFilterPack_TV_Old : MonoBehaviour
{
	// Token: 0x17000316 RID: 790
	// (get) Token: 0x06001151 RID: 4433 RVA: 0x00087D80 File Offset: 0x00085F80
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

	// Token: 0x06001152 RID: 4434 RVA: 0x00087DB4 File Offset: 0x00085FB4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Old");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001153 RID: 4435 RVA: 0x00087DD8 File Offset: 0x00085FD8
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

	// Token: 0x06001154 RID: 4436 RVA: 0x00087E5E File Offset: 0x0008605E
	private void Update()
	{
	}

	// Token: 0x06001155 RID: 4437 RVA: 0x00087E60 File Offset: 0x00086060
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015F4 RID: 5620
	public Shader SCShader;

	// Token: 0x040015F5 RID: 5621
	private float TimeX = 1f;

	// Token: 0x040015F6 RID: 5622
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040015F7 RID: 5623
	private Material SCMaterial;
}
