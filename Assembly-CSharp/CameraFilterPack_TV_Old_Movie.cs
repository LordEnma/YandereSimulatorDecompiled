using System;
using UnityEngine;

// Token: 0x02000213 RID: 531
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Old_Movie")]
public class CameraFilterPack_TV_Old_Movie : MonoBehaviour
{
	// Token: 0x17000317 RID: 791
	// (get) Token: 0x06001155 RID: 4437 RVA: 0x000877C0 File Offset: 0x000859C0
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

	// Token: 0x06001156 RID: 4438 RVA: 0x000877F4 File Offset: 0x000859F4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Old_Movie");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001157 RID: 4439 RVA: 0x00087818 File Offset: 0x00085A18
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

	// Token: 0x06001158 RID: 4440 RVA: 0x0008789E File Offset: 0x00085A9E
	private void Update()
	{
	}

	// Token: 0x06001159 RID: 4441 RVA: 0x000878A0 File Offset: 0x00085AA0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015E8 RID: 5608
	public Shader SCShader;

	// Token: 0x040015E9 RID: 5609
	private float TimeX = 1f;

	// Token: 0x040015EA RID: 5610
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040015EB RID: 5611
	private Material SCMaterial;
}
