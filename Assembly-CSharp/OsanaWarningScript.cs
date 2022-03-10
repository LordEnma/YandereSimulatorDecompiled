using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x0200038B RID: 907
public class OsanaWarningScript : MonoBehaviour
{
	// Token: 0x06001A3E RID: 6718 RVA: 0x00116EF8 File Offset: 0x001150F8
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

	// Token: 0x06001A3F RID: 6719 RVA: 0x0011702C File Offset: 0x0011522C
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

	// Token: 0x06001A40 RID: 6720 RVA: 0x001170D8 File Offset: 0x001152D8
	private void LateUpdate()
	{
		this.RightHand.localEulerAngles += new Vector3(UnityEngine.Random.Range(1f, -1f), UnityEngine.Random.Range(1f, -1f), UnityEngine.Random.Range(1f, -1f));
	}

	// Token: 0x04002AF8 RID: 11000
	public PostProcessingProfile Profile;

	// Token: 0x04002AF9 RID: 11001
	public Transform RightHand;

	// Token: 0x04002AFA RID: 11002
	public UISprite Darkness;

	// Token: 0x04002AFB RID: 11003
	public float Alpha = 1f;

	// Token: 0x04002AFC RID: 11004
	public bool FadeOut;
}
