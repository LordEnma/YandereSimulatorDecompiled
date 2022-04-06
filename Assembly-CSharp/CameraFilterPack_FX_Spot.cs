using System;
using UnityEngine;

// Token: 0x020001C0 RID: 448
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Spot")]
public class CameraFilterPack_FX_Spot : MonoBehaviour
{
	// Token: 0x170002C4 RID: 708
	// (get) Token: 0x06000F42 RID: 3906 RVA: 0x0007DB9B File Offset: 0x0007BD9B
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

	// Token: 0x06000F43 RID: 3907 RVA: 0x0007DBCF File Offset: 0x0007BDCF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Spot");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F44 RID: 3908 RVA: 0x0007DBF0 File Offset: 0x0007BDF0
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
			this.material.SetFloat("_PositionX", this.center.x);
			this.material.SetFloat("_PositionY", this.center.y);
			this.material.SetFloat("_Radius", this.Radius);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F45 RID: 3909 RVA: 0x0007DCDC File Offset: 0x0007BEDC
	private void Update()
	{
	}

	// Token: 0x06000F46 RID: 3910 RVA: 0x0007DCDE File Offset: 0x0007BEDE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001394 RID: 5012
	public Shader SCShader;

	// Token: 0x04001395 RID: 5013
	private float TimeX = 1f;

	// Token: 0x04001396 RID: 5014
	private Material SCMaterial;

	// Token: 0x04001397 RID: 5015
	public Vector2 center = new Vector2(0.5f, 0.5f);

	// Token: 0x04001398 RID: 5016
	public float Radius = 0.2f;
}
