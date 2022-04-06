using System;
using UnityEngine;

// Token: 0x0200021F RID: 543
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Vintage")]
public class CameraFilterPack_TV_Vintage : MonoBehaviour
{
	// Token: 0x17000323 RID: 803
	// (get) Token: 0x0600119F RID: 4511 RVA: 0x00088F30 File Offset: 0x00087130
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

	// Token: 0x060011A0 RID: 4512 RVA: 0x00088F64 File Offset: 0x00087164
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Vintage");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011A1 RID: 4513 RVA: 0x00088F88 File Offset: 0x00087188
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

	// Token: 0x060011A2 RID: 4514 RVA: 0x0008900E File Offset: 0x0008720E
	private void Update()
	{
	}

	// Token: 0x060011A3 RID: 4515 RVA: 0x00089010 File Offset: 0x00087210
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001639 RID: 5689
	public Shader SCShader;

	// Token: 0x0400163A RID: 5690
	private float TimeX = 1f;

	// Token: 0x0400163B RID: 5691
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x0400163C RID: 5692
	private Material SCMaterial;
}
