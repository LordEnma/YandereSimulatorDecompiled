using System;
using UnityEngine;

// Token: 0x02000133 RID: 307
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/HardMix")]
public class CameraFilterPack_Blend2Camera_HardMix : MonoBehaviour
{
	// Token: 0x17000237 RID: 567
	// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x0006E8C3 File Offset: 0x0006CAC3
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

	// Token: 0x06000BC9 RID: 3017 RVA: 0x0006E8F8 File Offset: 0x0006CAF8
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

	// Token: 0x06000BCA RID: 3018 RVA: 0x0006E95C File Offset: 0x0006CB5C
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

	// Token: 0x06000BCB RID: 3019 RVA: 0x0006EA4C File Offset: 0x0006CC4C
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BCC RID: 3020 RVA: 0x0006EA84 File Offset: 0x0006CC84
	private void Update()
	{
	}

	// Token: 0x06000BCD RID: 3021 RVA: 0x0006EA86 File Offset: 0x0006CC86
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BCE RID: 3022 RVA: 0x0006EABE File Offset: 0x0006CCBE
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

	// Token: 0x04000FFF RID: 4095
	private string ShaderName = "CameraFilterPack/Blend2Camera_HardMix";

	// Token: 0x04001000 RID: 4096
	public Shader SCShader;

	// Token: 0x04001001 RID: 4097
	public Camera Camera2;

	// Token: 0x04001002 RID: 4098
	private float TimeX = 1f;

	// Token: 0x04001003 RID: 4099
	private Material SCMaterial;

	// Token: 0x04001004 RID: 4100
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001005 RID: 4101
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001006 RID: 4102
	private RenderTexture Camera2tex;
}
