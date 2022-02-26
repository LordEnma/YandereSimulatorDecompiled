using System;
using UnityEngine;

// Token: 0x0200011E RID: 286
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/WaterDropPro")]
public class CameraFilterPack_AAA_WaterDropPro : MonoBehaviour
{
	// Token: 0x17000222 RID: 546
	// (get) Token: 0x06000B32 RID: 2866 RVA: 0x0006B940 File Offset: 0x00069B40
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

	// Token: 0x06000B33 RID: 2867 RVA: 0x0006B974 File Offset: 0x00069B74
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_WaterDrop") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/AAA_WaterDropPro");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B34 RID: 2868 RVA: 0x0006B9AC File Offset: 0x00069BAC
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

	// Token: 0x06000B35 RID: 2869 RVA: 0x0006BA8D File Offset: 0x00069C8D
	private void Update()
	{
	}

	// Token: 0x06000B36 RID: 2870 RVA: 0x0006BA8F File Offset: 0x00069C8F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F37 RID: 3895
	public Shader SCShader;

	// Token: 0x04000F38 RID: 3896
	private float TimeX = 1f;

	// Token: 0x04000F39 RID: 3897
	[Range(8f, 64f)]
	public float Distortion = 8f;

	// Token: 0x04000F3A RID: 3898
	[Range(0f, 7f)]
	public float SizeX = 1f;

	// Token: 0x04000F3B RID: 3899
	[Range(0f, 7f)]
	public float SizeY = 0.5f;

	// Token: 0x04000F3C RID: 3900
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04000F3D RID: 3901
	private Material SCMaterial;

	// Token: 0x04000F3E RID: 3902
	private Texture2D Texture2;
}
