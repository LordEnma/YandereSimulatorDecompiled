using System;
using UnityEngine;

// Token: 0x020001B8 RID: 440
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Hexagon_Black")]
public class CameraFilterPack_FX_Hexagon_Black : MonoBehaviour
{
	// Token: 0x170002BC RID: 700
	// (get) Token: 0x06000F10 RID: 3856 RVA: 0x0007CC10 File Offset: 0x0007AE10
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

	// Token: 0x06000F11 RID: 3857 RVA: 0x0007CC44 File Offset: 0x0007AE44
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Hexagon_Black");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F12 RID: 3858 RVA: 0x0007CC68 File Offset: 0x0007AE68
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F13 RID: 3859 RVA: 0x0007CD1E File Offset: 0x0007AF1E
	private void Update()
	{
	}

	// Token: 0x06000F14 RID: 3860 RVA: 0x0007CD20 File Offset: 0x0007AF20
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001365 RID: 4965
	public Shader SCShader;

	// Token: 0x04001366 RID: 4966
	private float TimeX = 1f;

	// Token: 0x04001367 RID: 4967
	private Material SCMaterial;

	// Token: 0x04001368 RID: 4968
	[Range(0.2f, 10f)]
	public float Value = 1f;
}
