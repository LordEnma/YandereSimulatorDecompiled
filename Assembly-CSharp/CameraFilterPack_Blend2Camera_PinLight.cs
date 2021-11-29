using System;
using UnityEngine;

// Token: 0x0200013D RID: 317
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/PinLight")]
public class CameraFilterPack_Blend2Camera_PinLight : MonoBehaviour
{
	// Token: 0x17000242 RID: 578
	// (get) Token: 0x06000C1D RID: 3101 RVA: 0x000700C6 File Offset: 0x0006E2C6
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

	// Token: 0x06000C1E RID: 3102 RVA: 0x000700FC File Offset: 0x0006E2FC
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C1F RID: 3103 RVA: 0x00070160 File Offset: 0x0006E360
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			if (this.Camera2 != null)
			{
				this.material.SetTexture("_MainTex2", this.Camera2tex);
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetFloat("_Value2", this.SwitchCameraToCamera2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C20 RID: 3104 RVA: 0x00070250 File Offset: 0x0006E450
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C21 RID: 3105 RVA: 0x00070288 File Offset: 0x0006E488
	private void Update()
	{
	}

	// Token: 0x06000C22 RID: 3106 RVA: 0x0007028A File Offset: 0x0006E48A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C23 RID: 3107 RVA: 0x000702C2 File Offset: 0x0006E4C2
	private void OnDisable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2.targetTexture = null;
		}
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001051 RID: 4177
	private string ShaderName = "CameraFilterPack/Blend2Camera_PinLight";

	// Token: 0x04001052 RID: 4178
	public Shader SCShader;

	// Token: 0x04001053 RID: 4179
	public Camera Camera2;

	// Token: 0x04001054 RID: 4180
	private float TimeX = 1f;

	// Token: 0x04001055 RID: 4181
	private Material SCMaterial;

	// Token: 0x04001056 RID: 4182
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001057 RID: 4183
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001058 RID: 4184
	private RenderTexture Camera2tex;
}
