using System;
using UnityEngine;

// Token: 0x02000198 RID: 408
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/NewCellShading")]
public class CameraFilterPack_Drawing_NewCellShading : MonoBehaviour
{
	// Token: 0x1700029D RID: 669
	// (get) Token: 0x06000E51 RID: 3665 RVA: 0x0007969C File Offset: 0x0007789C
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

	// Token: 0x06000E52 RID: 3666 RVA: 0x000796D0 File Offset: 0x000778D0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_NewCellShading");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E53 RID: 3667 RVA: 0x000796F4 File Offset: 0x000778F4
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
			this.material.SetFloat("_Threshold", this.Threshold);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E54 RID: 3668 RVA: 0x000797A3 File Offset: 0x000779A3
	private void Update()
	{
	}

	// Token: 0x06000E55 RID: 3669 RVA: 0x000797A5 File Offset: 0x000779A5
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400128E RID: 4750
	public Shader SCShader;

	// Token: 0x0400128F RID: 4751
	private float TimeX = 1f;

	// Token: 0x04001290 RID: 4752
	private Material SCMaterial;

	// Token: 0x04001291 RID: 4753
	[Range(0f, 1f)]
	public float Threshold = 0.2f;
}
