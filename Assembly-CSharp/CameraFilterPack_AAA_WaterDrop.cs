using System;
using UnityEngine;

// Token: 0x0200011C RID: 284
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/WaterDrop")]
public class CameraFilterPack_AAA_WaterDrop : MonoBehaviour
{
	// Token: 0x17000221 RID: 545
	// (get) Token: 0x06000B28 RID: 2856 RVA: 0x0006B33C File Offset: 0x0006953C
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

	// Token: 0x06000B29 RID: 2857 RVA: 0x0006B370 File Offset: 0x00069570
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_WaterDrop") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/AAA_WaterDrop");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B2A RID: 2858 RVA: 0x0006B3A8 File Offset: 0x000695A8
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
			this.material.SetFloat("_SizeX", this.SizeX);
			this.material.SetFloat("_SizeY", this.SizeY);
			this.material.SetFloat("_Speed", this.Speed);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B2B RID: 2859 RVA: 0x0006B489 File Offset: 0x00069689
	private void Update()
	{
	}

	// Token: 0x06000B2C RID: 2860 RVA: 0x0006B48B File Offset: 0x0006968B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F27 RID: 3879
	public Shader SCShader;

	// Token: 0x04000F28 RID: 3880
	private float TimeX = 1f;

	// Token: 0x04000F29 RID: 3881
	[Range(8f, 64f)]
	public float Distortion = 8f;

	// Token: 0x04000F2A RID: 3882
	[Range(0f, 7f)]
	public float SizeX = 1f;

	// Token: 0x04000F2B RID: 3883
	[Range(0f, 7f)]
	public float SizeY = 0.5f;

	// Token: 0x04000F2C RID: 3884
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04000F2D RID: 3885
	private Material SCMaterial;

	// Token: 0x04000F2E RID: 3886
	private Texture2D Texture2;
}
