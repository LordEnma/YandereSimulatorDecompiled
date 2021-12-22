using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000388 RID: 904
public class OsanaWarningScript : MonoBehaviour
{
	// Token: 0x06001A24 RID: 6692 RVA: 0x00115050 File Offset: 0x00113250
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
		settings.basic.saturation = 1f;
		settings.channelMixer.red = new Vector3(1f, 0f, 0f);
		settings.channelMixer.green = new Vector3(0f, 1f, 0f);
		settings.channelMixer.blue = new Vector3(0f, 0f, 1f);
		this.Profile.colorGrading.settings = settings;
		DepthOfFieldModel.Settings settings2 = this.Profile.depthOfField.settings;
		settings2.focusDistance = 10f;
		settings2.aperture = 11.2f;
		this.Profile.depthOfField.settings = settings2;
		BloomModel.Settings settings3 = this.Profile.bloom.settings;
		settings3.bloom.intensity = 1f;
		this.Profile.bloom.settings = settings3;
	}

	// Token: 0x06001A25 RID: 6693 RVA: 0x00115184 File Offset: 0x00113384
	private void Update()
	{
		if (this.FadeOut)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
		}
		this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
		if (this.Alpha == 0f)
		{
			if (Input.GetButtonDown("A"))
			{
				this.FadeOut = true;
				return;
			}
		}
		else if (this.Alpha == 1f)
		{
			SceneManager.LoadScene("CalendarScene");
		}
	}

	// Token: 0x06001A26 RID: 6694 RVA: 0x00115230 File Offset: 0x00113430
	private void LateUpdate()
	{
		this.RightHand.localEulerAngles += new Vector3(UnityEngine.Random.Range(1f, -1f), UnityEngine.Random.Range(1f, -1f), UnityEngine.Random.Range(1f, -1f));
	}

	// Token: 0x04002AB5 RID: 10933
	public PostProcessingProfile Profile;

	// Token: 0x04002AB6 RID: 10934
	public Transform RightHand;

	// Token: 0x04002AB7 RID: 10935
	public UISprite Darkness;

	// Token: 0x04002AB8 RID: 10936
	public float Alpha = 1f;

	// Token: 0x04002AB9 RID: 10937
	public bool FadeOut;
}
