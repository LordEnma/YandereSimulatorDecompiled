using System;
using UnityEngine;

// Token: 0x0200021A RID: 538
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/VHS_Rewind")]
public class CameraFilterPack_TV_VHS_Rewind : MonoBehaviour
{
	// Token: 0x1700031E RID: 798
	// (get) Token: 0x06001181 RID: 4481 RVA: 0x000888D0 File Offset: 0x00086AD0
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

	// Token: 0x06001182 RID: 4482 RVA: 0x00088904 File Offset: 0x00086B04
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_VHS_Rewind");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001183 RID: 4483 RVA: 0x00088928 File Offset: 0x00086B28
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
			this.material.SetFloat("_Value", this.Cryptage);
			this.material.SetFloat("_Value2", this.Parasite);
			this.material.SetFloat("_Value3", this.Parasite2);
			this.material.SetFloat("_Value4", this.WhiteParasite);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001184 RID: 4484 RVA: 0x00088A20 File Offset: 0x00086C20
	private void Update()
	{
	}

	// Token: 0x06001185 RID: 4485 RVA: 0x00088A22 File Offset: 0x00086C22
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001621 RID: 5665
	public Shader SCShader;

	// Token: 0x04001622 RID: 5666
	private float TimeX = 1f;

	// Token: 0x04001623 RID: 5667
	private Material SCMaterial;

	// Token: 0x04001624 RID: 5668
	[Range(0f, 1f)]
	public float Cryptage = 1f;

	// Token: 0x04001625 RID: 5669
	[Range(-20f, 20f)]
	public float Parasite = 9f;

	// Token: 0x04001626 RID: 5670
	[Range(-20f, 20f)]
	public float Parasite2 = 12f;

	// Token: 0x04001627 RID: 5671
	[Range(0f, 1f)]
	private float WhiteParasite = 1f;
}
