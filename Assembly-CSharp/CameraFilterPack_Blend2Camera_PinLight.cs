using System;
using UnityEngine;

// Token: 0x0200013E RID: 318
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/PinLight")]
public class CameraFilterPack_Blend2Camera_PinLight : MonoBehaviour
{
	// Token: 0x17000242 RID: 578
	// (get) Token: 0x06000C21 RID: 3105 RVA: 0x0007066A File Offset: 0x0006E86A
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

	// Token: 0x06000C22 RID: 3106 RVA: 0x000706A0 File Offset: 0x0006E8A0
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

	// Token: 0x06000C23 RID: 3107 RVA: 0x00070704 File Offset: 0x0006E904
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

	// Token: 0x06000C24 RID: 3108 RVA: 0x000707F4 File Offset: 0x0006E9F4
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C25 RID: 3109 RVA: 0x0007082C File Offset: 0x0006EA2C
	private void Update()
	{
	}

	// Token: 0x06000C26 RID: 3110 RVA: 0x0007082E File Offset: 0x0006EA2E
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000C27 RID: 3111 RVA: 0x00070866 File Offset: 0x0006EA66
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

	// Token: 0x04001062 RID: 4194
	private string ShaderName = "CameraFilterPack/Blend2Camera_PinLight";

	// Token: 0x04001063 RID: 4195
	public Shader SCShader;

	// Token: 0x04001064 RID: 4196
	public Camera Camera2;

	// Token: 0x04001065 RID: 4197
	private float TimeX = 1f;

	// Token: 0x04001066 RID: 4198
	private Material SCMaterial;

	// Token: 0x04001067 RID: 4199
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001068 RID: 4200
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001069 RID: 4201
	private RenderTexture Camera2tex;
}
