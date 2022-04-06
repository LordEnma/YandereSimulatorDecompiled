using System;
using UnityEngine;

// Token: 0x02000213 RID: 531
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Old_Movie")]
public class CameraFilterPack_TV_Old_Movie : MonoBehaviour
{
	// Token: 0x17000317 RID: 791
	// (get) Token: 0x06001157 RID: 4439 RVA: 0x00087E98 File Offset: 0x00086098
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

	// Token: 0x06001158 RID: 4440 RVA: 0x00087ECC File Offset: 0x000860CC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Old_Movie");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001159 RID: 4441 RVA: 0x00087EF0 File Offset: 0x000860F0
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

	// Token: 0x0600115A RID: 4442 RVA: 0x00087F76 File Offset: 0x00086176
	private void Update()
	{
	}

	// Token: 0x0600115B RID: 4443 RVA: 0x00087F78 File Offset: 0x00086178
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015F8 RID: 5624
	public Shader SCShader;

	// Token: 0x040015F9 RID: 5625
	private float TimeX = 1f;

	// Token: 0x040015FA RID: 5626
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040015FB RID: 5627
	private Material SCMaterial;
}
