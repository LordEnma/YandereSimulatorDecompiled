using System;
using System.Collections;
using System.Collections.Generic;
using HighlightingSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class GenericAnimationSequenceController : MonoBehaviour
{
	[Serializable]
	public class CharacterAnimation
	{
		public string name;

		public Animation animationComponent;

		public List<string> animationNames = new List<string>();
	}

	[Serializable]
	public class PropAnimation
	{
		public string name;

		public Animation animationComponent;

		public List<string> animationNames = new List<string>();
	}

	[Serializable]
	public class CameraShot
	{
		public int frame;

		public Transform referenceTransform;

		[HideInInspector]
		public bool triggered;
	}

	[Serializable]
	public class CameraSequenceShots
	{
		public string name;

		public int sequenceIndex;

		public List<CameraShot> shots = new List<CameraShot>();
	}

	[Serializable]
	public class CameraAnimationEntry
	{
		public string name;

		public int sequenceIndex;

		public Animation rigAnimation;

		public string animationName;
	}

	[Serializable]
	public class SubtitleFrame
	{
		public int frame;

		[TextArea]
		public string text;

		[HideInInspector]
		public bool triggered;
	}

	[Serializable]
	public class SubtitleSequence
	{
		public string name;

		public int sequenceIndex;

		public List<SubtitleFrame> subtitles = new List<SubtitleFrame>();
	}

	[Serializable]
	public class FrameVisibilityTrigger
	{
		public string name;

		public GameObject targetObject;

		public string targetTag;

		public List<int> sequenceIndexes = new List<int>();

		public int frame;

		public bool visible;

		[HideInInspector]
		public bool triggered;
	}

	[Serializable]
	public class DOFTargetFrame
	{
		public int sequenceIndex;

		public int frame;

		public Transform target;

		[HideInInspector]
		public bool triggered;
	}

	[Serializable]
	public class SFXEvent
	{
		public int sequenceIndex;

		public AudioClip clip;

		public List<AudioClip> clipVariants = new List<AudioClip>();

		public AudioSource sourceReference;

		public Transform origin;

		[Range(0f, 1f)]
		public float volume = 1f;

		[Range(0.5f, 2f)]
		public float pitch = 1f;

		public bool spatialize;

		public List<int> frames = new List<int>();

		[HideInInspector]
		public HashSet<int> triggeredFrames = new HashSet<int>();

		public bool playOnSource;

		public AudioMixerGroup outputAudioMixerGroup;
	}

	[Header("Cutscene Settings")]
	[Tooltip("FPS the cutscene will run at")]
	public float cutsceneFPS = 30f;

	[Tooltip("Number of sequences (procedural)")]
	public int sequenceCount = 1;

	[Header("Characters")]
	public List<CharacterAnimation> characters = new List<CharacterAnimation>();

	[Header("Props")]
	public List<PropAnimation> props = new List<PropAnimation>();

	[Header("Audio")]
	public AudioSource audioSource;

	public List<AudioClip> sequenceAudioClips = new List<AudioClip>();

	[Header("Camera")]
	public Camera mainCamera;

	[Tooltip("Toggle between Camera Sequence (true) and Camera Animation (false)")]
	public bool useCameraSequence = true;

	[Header("Camera Sequence")]
	public List<CameraSequenceShots> cameraSequences = new List<CameraSequenceShots>();

	[Header("Camera Animation")]
	public List<CameraAnimationEntry> cameraAnimations = new List<CameraAnimationEntry>();

	[Header("Subtitles")]
	public string currentSubtitleText = "";

	public TextMeshProUGUI debugSubtitleDisplay;

	public List<SubtitleSequence> subtitleSequences = new List<SubtitleSequence>();

	[Header("Visibility Triggers")]
	public List<FrameVisibilityTrigger> frameVisibilityTriggers = new List<FrameVisibilityTrigger>();

	[Header("Post Processing")]
	public PostProcessingProfile postProcessingProfile;

	[Header("DOF Targets (per sequence/frame)")]
	public List<DOFTargetFrame> dofTargetFrames = new List<DOFTargetFrame>();

	[Tooltip("DOF transition duration in seconds. Larger = slower transition.")]
	public float dofTransitionDuration = 2f;

	[Header("SFX Events")]
	public List<SFXEvent> sfxEvents = new List<SFXEvent>();

	[Header("Debug")]
	public bool enableFrameLogs;

	[Tooltip("Enable detailed SFX debug logs (shows selection, triggers and reasons).")]
	public bool sfxDebug = true;

	[Tooltip("Enable debug playback controls (increase/decrease speed during cutscene). Default disabled.")]
	public bool debugMode;

	public float debugPlaybackSpeed = 1f;

	private int currentSequenceIndex = -1;

	private float sequenceTimer;

	private bool isSequencePlaying;

	private Dictionary<UnityEngine.Object, Mesh> originalMeshes = new Dictionary<UnityEngine.Object, Mesh>();

	private Transform currentDOFTarget;

	private float currentDOFFocusDistance = 2f;

	private float targetDOFFocusDistance = 2f;

	private float dofTransitionElapsed;

	private float dofTransitionStartDistance;

	private bool isDOFTransitioning;

	private float playbackSpeed = 1f;

	private bool prevDebugMode;

	private float originalMainAudioPitch = 1f;

	private float originalFixedDeltaTime = 0.02f;

	public CosmeticScript SenpaiCosmetic;

	public YandereScript YandereHair;

	public CosmeticScript Yandere;

	public JsonScript JSON;

	public GameObject NoFemaleSenpai;

	public GameObject UICamera;

	public GameObject AyanoHair;

	public GameObject RyobaHair;

	public UISprite Darkness;

	public UILabel Subtitle;

	public bool Initiated;

	public float Timer;

	public AudioSource[] Fountain;

	public DynamicBoneCollider HeadCollider;

	public UISprite SkipCircle;

	public UIPanel SkipPanel;

	public float SkipTimer;

	public bool EndEarly;

	private void Awake()
	{
		originalFixedDeltaTime = Time.fixedDeltaTime;
		if (audioSource != null)
		{
			originalMainAudioPitch = audioSource.pitch;
		}
		if (GameGlobals.Eighties)
		{
			UICamera.SetActive(value: true);
			debugSubtitleDisplay.gameObject.SetActive(value: false);
			if (GameGlobals.CustomMode)
			{
				Debug.Log("We are now in Custom Mode.");
			}
		}
		debugMode = false;
		DisableOutlineScripts(YandereHair.gameObject);
	}

	private void Start()
	{
		if (sfxDebug)
		{
			Debug.Log($"[GenericAnimationHandler][SFX] Start: sfxEvents count = {((sfxEvents != null) ? sfxEvents.Count : 0)}");
			if (sfxEvents != null)
			{
				for (int i = 0; i < sfxEvents.Count; i++)
				{
					SFXEvent sFXEvent = sfxEvents[i];
					string text = ((sFXEvent.frames != null && sFXEvent.frames.Count > 0) ? string.Join(",", sFXEvent.frames) : "<none>");
					Debug.Log(string.Format("[GenericAnimationHandler][SFX] Event[{0}] seq={1} frames=[{2}] clip={3} variants={4} sourceRef={5} playOnSource={6}", i, sFXEvent.sequenceIndex, text, (sFXEvent.clip != null) ? sFXEvent.clip.name : "null", (sFXEvent.clipVariants != null) ? sFXEvent.clipVariants.Count : 0, (sFXEvent.sourceReference != null) ? sFXEvent.sourceReference.gameObject.name : "null", sFXEvent.playOnSource));
				}
			}
		}
		if (sfxDebug)
		{
			AudioListener audioListener = UnityEngine.Object.FindObjectOfType<AudioListener>();
			Debug.Log($"[GenericAnimationHandler][SFX] AudioListener present: {audioListener != null}; main audioSource assigned: {audioSource != null}");
			if (audioSource != null)
			{
				Debug.Log($"[GenericAnimationHandler][SFX] main audioSource on GameObject: {audioSource.gameObject.name}, pitch={audioSource.pitch}");
			}
		}
		postProcessingProfile.depthOfField.enabled = OptionGlobals.DepthOfField;
	}

	private void OnDestroy()
	{
		Time.timeScale = 1f;
		Time.fixedDeltaTime = originalFixedDeltaTime;
		if (audioSource != null)
		{
			audioSource.pitch = originalMainAudioPitch;
		}
	}

	private void Update()
	{
		SkipTimer += Time.deltaTime;
		if (SkipTimer > 5f)
		{
			SkipPanel.alpha -= Time.deltaTime;
		}
		if (EndEarly)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			SkipPanel.alpha -= Time.deltaTime;
			Subtitle.text = "";
			if (Darkness.alpha > 0.999f)
			{
				GameGlobals.DarkEnding = true;
				SceneManager.LoadScene("GenocideScene");
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Genocide", 1);
					PlayerPrefs.SetInt("a", 1);
				}
			}
		}
		else if (Input.GetButton(InputNames.Xbox_X))
		{
			SkipPanel.alpha = 1f;
			SkipTimer = 0f;
			SkipCircle.fillAmount -= Time.deltaTime;
			if (SkipCircle.fillAmount == 0f)
			{
				EndEarly = true;
			}
		}
		else
		{
			SkipCircle.fillAmount = 1f;
		}
		Timer += Time.deltaTime;
		if (!Initiated)
		{
			if (Timer >= 1f)
			{
				RenderSettings.ambientLight = new Color(0.6514058f, 0.3515327f, 0.2422812f, 1f);
				int index = (currentSequenceIndex + 1) % sequenceCount;
				PlaySequence(index);
				Initiated = true;
				Yandere.DisableHair();
				if (GameGlobals.Eighties)
				{
					AyanoHair.gameObject.SetActive(value: false);
					RyobaHair.gameObject.SetActive(value: false);
					Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
					Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
					Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
					if (!GameGlobals.CustomMode)
					{
						RyobaHair.gameObject.SetActive(value: true);
						Yandere.MyRenderer.materials[0].mainTexture = Yandere.MyRenderer.materials[1].mainTexture;
					}
					else
					{
						YandereHair.gameObject.SetActive(value: true);
						YandereHair.Hairstyle = 0;
						YandereHair.UpdateHair();
						string hairstyle = JSON.Students[0].Hairstyle;
						YandereHair.Hairstyles[int.Parse(hairstyle)].SetActive(value: true);
						if (GameGlobals.FemaleSenpai)
						{
							NoFemaleSenpai.SetActive(value: true);
						}
					}
				}
				else
				{
					AyanoHair.gameObject.SetActive(value: true);
					RyobaHair.gameObject.SetActive(value: false);
				}
				SenpaiCosmetic.GrabCustomTextures();
			}
		}
		else
		{
			Subtitle.text = debugSubtitleDisplay.text;
		}
		if (Timer > 11f)
		{
			Fountain[0].volume -= Time.deltaTime * 0.0007f;
			Fountain[1].volume -= Time.deltaTime * 0.0007f;
			Fountain[2].volume -= Time.deltaTime * 7E-05f;
		}
		if (Timer < 25.5f)
		{
			HeadCollider.m_Radius = Mathf.MoveTowards(HeadCollider.m_Radius, 0.09f, Time.deltaTime * 0.1f);
		}
		else if (Timer < 29f)
		{
			HeadCollider.m_Radius = Mathf.MoveTowards(HeadCollider.m_Radius, 0.15f, Time.deltaTime * 0.1f);
		}
		else
		{
			HeadCollider.m_Radius = Mathf.MoveTowards(HeadCollider.m_Radius, 0f, Time.deltaTime * 0.1f);
		}
		if (mainCamera == null)
		{
			Debug.LogWarning("[GenericAnimationHandler] mainCamera is not assigned.");
		}
		if (audioSource == null)
		{
			Debug.LogWarning("[GenericAnimationHandler] audioSource is not assigned.");
		}
		foreach (CharacterAnimation character in characters)
		{
			if (character.animationComponent == null)
			{
				Debug.LogWarning("[GenericAnimationHandler] Character '" + character.name + "' has no Animation component assigned.");
			}
			else if (character.animationNames == null || character.animationNames.Count == 0)
			{
				Debug.LogWarning("[GenericAnimationHandler] Character '" + character.name + "' has no animations defined.");
			}
		}
		foreach (PropAnimation prop in props)
		{
			if (prop.animationComponent == null)
			{
				Debug.LogWarning("[GenericAnimationHandler] Prop '" + prop.name + "' has no Animation component assigned.");
			}
			else if (prop.animationNames == null || prop.animationNames.Count == 0)
			{
				Debug.LogWarning("[GenericAnimationHandler] Prop '" + prop.name + "' has no animations defined.");
			}
		}
		if (debugMode != prevDebugMode)
		{
			prevDebugMode = debugMode;
			if (debugMode)
			{
				playbackSpeed = Mathf.Clamp(debugPlaybackSpeed, 0.01f, 5f);
				ApplyTimeScale(playbackSpeed);
				if (enableFrameLogs)
				{
					Debug.Log($"[GenericAnimationHandler][Debug] Debug mode enabled. TimeScale set to {playbackSpeed:F2}");
				}
			}
			else
			{
				ApplyTimeScale(1f);
				if (enableFrameLogs)
				{
					Debug.Log("[GenericAnimationHandler][Debug] Debug mode disabled. TimeScale restored to 1.0");
				}
			}
		}
		if (debugMode)
		{
			if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus))
			{
				playbackSpeed = SnapPlaybackSpeed(playbackSpeed + 0.5f);
				ApplyTimeScale(playbackSpeed);
				Debug.Log($"[GenericAnimationHandler][Debug] TimeScale increased to {playbackSpeed:F2}");
			}
			if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
			{
				playbackSpeed = SnapPlaybackSpeed(playbackSpeed - 0.5f);
				ApplyTimeScale(playbackSpeed);
				Debug.Log($"[GenericAnimationHandler][Debug] TimeScale decreased to {playbackSpeed:F2}");
			}
			if (Input.GetKeyDown(KeyCode.Backspace))
			{
				playbackSpeed = 1f;
				ApplyTimeScale(playbackSpeed);
				Debug.Log("[GenericAnimationHandler][Debug] TimeScale reset to 1.0");
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				int index2 = (currentSequenceIndex + 1) % sequenceCount;
				PlaySequence(index2);
			}
		}
		else
		{
			playbackSpeed = 1f;
		}
		if (isSequencePlaying)
		{
			sequenceTimer += Time.deltaTime;
			int num = Mathf.FloorToInt(sequenceTimer * cutsceneFPS);
			if (enableFrameLogs)
			{
				Debug.Log($"[SequenceTimer] Seq:{currentSequenceIndex} | Time: {sequenceTimer:F3}s | Frame: {num} | Speed:{playbackSpeed:F2}");
			}
			UpdateFrameVisibility(num);
			UpdateCamera(num);
			UpdateSubtitles(num);
			UpdateDOF(num);
			UpdateSFX(num);
			bool flag = true;
			foreach (CharacterAnimation character2 in characters)
			{
				if (character2.animationComponent != null && currentSequenceIndex >= 0 && currentSequenceIndex < character2.animationNames.Count)
				{
					string value = character2.animationNames[currentSequenceIndex];
					if (!string.IsNullOrEmpty(value) && character2.animationComponent.IsPlaying(value))
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				isSequencePlaying = false;
				Debug.Log($"[SequenceEnd] Sequence {currentSequenceIndex} ended.");
				GameGlobals.DarkEnding = true;
				SceneManager.LoadScene("GenocideScene");
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Genocide", 1);
					PlayerPrefs.SetInt("a", 1);
				}
			}
		}
		else if (enableFrameLogs)
		{
			Debug.Log("[GenericAnimationHandler] Cutscene is not running (isSequencePlaying == false).");
		}
	}

	private void ApplyTimeScale(float scale)
	{
		scale = Mathf.Clamp(scale, 0.01f, 5f);
		Time.timeScale = scale;
		Time.fixedDeltaTime = originalFixedDeltaTime * scale;
		if (audioSource != null)
		{
			audioSource.pitch = originalMainAudioPitch * scale;
		}
	}

	private void UpdateDOF(int currentFrame)
	{
		if (postProcessingProfile == null || !postProcessingProfile.depthOfField.enabled || mainCamera == null || dofTargetFrames == null || dofTargetFrames.Count == 0)
		{
			return;
		}
		DOFTargetFrame dOFTargetFrame = null;
		foreach (DOFTargetFrame dofTargetFrame in dofTargetFrames)
		{
			if (!dofTargetFrame.triggered && dofTargetFrame.sequenceIndex == currentSequenceIndex && currentFrame >= dofTargetFrame.frame && dofTargetFrame.target != null)
			{
				dOFTargetFrame = dofTargetFrame;
				break;
			}
		}
		if (dOFTargetFrame != null)
		{
			if (currentDOFTarget == null || dOFTargetFrame.target != currentDOFTarget)
			{
				dofTransitionElapsed = 0f;
				dofTransitionStartDistance = currentDOFFocusDistance;
				currentDOFTarget = dOFTargetFrame.target;
				targetDOFFocusDistance = Vector3.Distance(mainCamera.transform.position, currentDOFTarget.position);
				isDOFTransitioning = true;
				dOFTargetFrame.triggered = true;
				Debug.Log($"[DOF] Switching target -> sequence {dOFTargetFrame.sequenceIndex} frame {dOFTargetFrame.frame}: {currentDOFTarget.name}. Transition start:{dofTransitionStartDistance:F2} target:{targetDOFFocusDistance:F2}");
			}
			else
			{
				dOFTargetFrame.triggered = true;
			}
		}
		if (!(currentDOFTarget != null))
		{
			return;
		}
		if (isDOFTransitioning)
		{
			dofTransitionElapsed += Time.deltaTime;
			if (dofTransitionDuration <= 0.0001f)
			{
				currentDOFFocusDistance = targetDOFFocusDistance;
				isDOFTransitioning = false;
			}
			else
			{
				targetDOFFocusDistance = Vector3.Distance(mainCamera.transform.position, currentDOFTarget.position);
				currentDOFFocusDistance = Mathf.MoveTowards(currentDOFFocusDistance, targetDOFFocusDistance, Time.deltaTime * dofTransitionDuration);
			}
		}
		else
		{
			targetDOFFocusDistance = Vector3.Distance(mainCamera.transform.position, currentDOFTarget.position);
			currentDOFFocusDistance = targetDOFFocusDistance;
		}
		DepthOfFieldModel.Settings settings = postProcessingProfile.depthOfField.settings;
		settings.focusDistance = currentDOFFocusDistance;
		postProcessingProfile.depthOfField.settings = settings;
	}

	private void UpdateSFX(int currentFrame)
	{
		if (sfxEvents == null || sfxEvents.Count == 0)
		{
			if (sfxDebug)
			{
				Debug.Log("[SFX] No SFXEvents defined.");
			}
			return;
		}
		if (sfxDebug)
		{
			Debug.Log($"[SFX] UpdateSFX called. currentSequenceIndex={currentSequenceIndex} currentFrame={currentFrame} totalEvents={sfxEvents.Count}");
		}
		foreach (SFXEvent sfxEvent in sfxEvents)
		{
			if (sfxEvent.sequenceIndex != currentSequenceIndex)
			{
				if (sfxDebug)
				{
					Debug.Log($"[SFX] Skipping event seq {sfxEvent.sequenceIndex} (current seq {currentSequenceIndex}).");
				}
				continue;
			}
			string text = ((sfxEvent.frames != null) ? string.Join(",", sfxEvent.frames) : "<none>");
			if (sfxDebug)
			{
				Debug.Log($"[SFX] Evaluating event seq={sfxEvent.sequenceIndex} frames=[{text}] triggeredCount={sfxEvent.triggeredFrames.Count} playOnSource={sfxEvent.playOnSource}");
			}
			foreach (int frame in sfxEvent.frames)
			{
				bool flag = sfxEvent.triggeredFrames.Contains(frame);
				if (sfxDebug)
				{
					Debug.Log($"[SFX] Checking frame {frame} (alreadyTriggered={flag}) currentFrame={currentFrame}");
				}
				if (currentFrame < frame || flag)
				{
					continue;
				}
				AudioClip audioClip = null;
				if (sfxEvent.clipVariants != null && sfxEvent.clipVariants.Count > 0)
				{
					audioClip = sfxEvent.clipVariants[UnityEngine.Random.Range(0, sfxEvent.clipVariants.Count)];
					if (sfxDebug)
					{
						Debug.Log($"[SFX] Selected variant (count={sfxEvent.clipVariants.Count}).");
					}
				}
				else if (sfxEvent.clip != null)
				{
					audioClip = sfxEvent.clip;
					if (sfxDebug)
					{
						Debug.Log("[SFX] Using single clip field.");
					}
				}
				else if (sfxEvent.sourceReference != null && sfxEvent.sourceReference.clip != null)
				{
					audioClip = sfxEvent.sourceReference.clip;
					if (sfxDebug)
					{
						Debug.Log("[SFX] Using clip from sourceReference.");
					}
				}
				if (audioClip == null)
				{
					Debug.LogWarning($"[SFX] No audio clip available for SFXEvent in sequence {sfxEvent.sequenceIndex} frame {frame}.");
					continue;
				}
				try
				{
					if (sfxEvent.playOnSource && sfxEvent.sourceReference != null)
					{
						float pitch = sfxEvent.sourceReference.pitch;
						float num = sfxEvent.pitch * Time.timeScale;
						sfxEvent.sourceReference.pitch = num;
						AudioMixerGroup outputAudioMixerGroup = sfxEvent.sourceReference.outputAudioMixerGroup;
						if (sfxEvent.outputAudioMixerGroup != null)
						{
							sfxEvent.sourceReference.outputAudioMixerGroup = sfxEvent.outputAudioMixerGroup;
							if (sfxDebug)
							{
								Debug.Log("[SFX] Mixer group set to '" + sfxEvent.outputAudioMixerGroup.name + "' on source '" + sfxEvent.sourceReference.gameObject.name + "'");
							}
						}
						sfxEvent.sourceReference.PlayOneShot((sfxEvent.clip != null) ? sfxEvent.clip : audioClip, sfxEvent.volume);
						StartCoroutine(RestoreSourcePitch(sfxEvent.sourceReference, pitch, audioClip.length / Mathf.Max(0.0001f, sfxEvent.sourceReference.pitch)));
						if (sfxEvent.outputAudioMixerGroup != null)
						{
							StartCoroutine(RestoreSourceMixer(sfxEvent.sourceReference, outputAudioMixerGroup, audioClip.length / Mathf.Max(0.0001f, sfxEvent.sourceReference.pitch)));
						}
						if (sfxDebug)
						{
							Debug.Log($"[SFX] Played on source '{sfxEvent.sourceReference.gameObject.name}' clip='{audioClip.name}' vol={sfxEvent.volume:F2} pitch={num:F2}");
						}
					}
					else
					{
						PlaySFX(audioClip, sfxEvent);
						if (sfxDebug)
						{
							Debug.Log("[SFX] Played on temp source clip='" + audioClip.name + "' origin=" + ((sfxEvent.origin != null) ? sfxEvent.origin.name : "(camera)"));
						}
					}
					sfxEvent.triggeredFrames.Add(frame);
				}
				catch (Exception ex)
				{
					Debug.LogError(string.Format("[SFX] Exception while playing SFX '{0}' seq={1} frame={2}: {3}", (audioClip != null) ? audioClip.name : "null", sfxEvent.sequenceIndex, frame, ex));
				}
			}
		}
	}

	private void PlaySFX(AudioClip chosenClip, SFXEvent sfx)
	{
		if (chosenClip == null)
		{
			Debug.LogWarning("[SFX] PlaySFX called with null clip.");
			return;
		}
		try
		{
			GameObject gameObject = new GameObject("TempSFX");
			Vector3 vector = Vector3.zero;
			if (sfx.origin != null)
			{
				vector = sfx.origin.position;
			}
			else if (mainCamera != null)
			{
				vector = mainCamera.transform.position;
			}
			else
			{
				AudioListener audioListener = UnityEngine.Object.FindObjectOfType<AudioListener>();
				if (audioListener != null)
				{
					vector = audioListener.transform.position;
				}
			}
			gameObject.transform.position = vector;
			AudioSource audioSource = gameObject.AddComponent<AudioSource>();
			audioSource.spatialBlend = (sfx.spatialize ? 1f : 0f);
			audioSource.spatialize = sfx.spatialize;
			audioSource.volume = sfx.volume;
			audioSource.pitch = sfx.pitch * Time.timeScale;
			if (sfx.outputAudioMixerGroup != null)
			{
				audioSource.outputAudioMixerGroup = sfx.outputAudioMixerGroup;
				if (sfxDebug)
				{
					Debug.Log("[SFX] Mixer group set to '" + sfx.outputAudioMixerGroup.name + "' on temp source");
				}
			}
			if (audioSource.spatialBlend >= 0.99f)
			{
				if (sfx.sourceReference != null)
				{
					audioSource.rolloffMode = sfx.sourceReference.rolloffMode;
					audioSource.minDistance = Mathf.Max(0.01f, sfx.sourceReference.minDistance);
					audioSource.maxDistance = Mathf.Max(audioSource.minDistance + 0.1f, sfx.sourceReference.maxDistance);
					audioSource.dopplerLevel = sfx.sourceReference.dopplerLevel;
					audioSource.spread = sfx.sourceReference.spread;
				}
				else
				{
					audioSource.rolloffMode = AudioRolloffMode.Linear;
					audioSource.minDistance = 0.5f;
					audioSource.maxDistance = 50f;
					audioSource.dopplerLevel = 0f;
					audioSource.spread = 0f;
				}
				AudioListener audioListener2 = UnityEngine.Object.FindObjectOfType<AudioListener>();
				if (sfxDebug)
				{
					float num = ((audioListener2 != null) ? Vector3.Distance(gameObject.transform.position, audioListener2.transform.position) : (-1f));
					Debug.Log($"[SFX] 3D temp source at {vector} listenerDist={num:F2} minDist={audioSource.minDistance:F2} maxDist={audioSource.maxDistance:F2} rolloff={audioSource.rolloffMode}");
					if (audioSource.spatialize && audioListener2 == null && sfxDebug)
					{
						Debug.LogWarning("[SFX] spatialize enabled but no AudioListener found in scene.");
					}
					if (audioSource.spatialize && !AudioSettings.GetSpatializerPluginName().Equals(""))
					{
						Debug.Log("[SFX] Spatializer plugin detected: " + AudioSettings.GetSpatializerPluginName());
					}
				}
			}
			if (sfxDebug)
			{
				Debug.Log($"[SFX] Temp source created at {vector} playing '{chosenClip.name}' pitch:{audioSource.pitch:F2} vol:{audioSource.volume:F2} spatial:{audioSource.spatialBlend}");
			}
			audioSource.PlayOneShot(chosenClip, audioSource.volume);
			float num2 = chosenClip.length / Mathf.Max(0.0001f, audioSource.pitch) + 0.1f;
			if (num2 <= 0.2f)
			{
				num2 = Mathf.Max(0.5f, num2);
			}
			UnityEngine.Object.Destroy(gameObject, num2);
		}
		catch (Exception arg)
		{
			Debug.LogError($"[SFX] Exception in PlaySFX: {arg}");
		}
	}

	private IEnumerator RestoreSourcePitch(AudioSource src, float originalPitch, float delay)
	{
		if (src == null)
		{
			yield break;
		}
		if (delay <= 0f)
		{
			delay = 0.1f;
		}
		yield return new WaitForSecondsRealtime(delay);
		try
		{
			if (src != null)
			{
				src.pitch = originalPitch;
				if (sfxDebug)
				{
					Debug.Log($"[SFX] Restored pitch of source '{src.gameObject.name}' to {originalPitch:F2}");
				}
			}
		}
		catch
		{
		}
	}

	private IEnumerator RestoreSourceMixer(AudioSource src, AudioMixerGroup originalMixer, float delay)
	{
		if (src == null)
		{
			yield break;
		}
		if (delay <= 0f)
		{
			delay = 0.1f;
		}
		yield return new WaitForSecondsRealtime(delay);
		try
		{
			if (src != null)
			{
				src.outputAudioMixerGroup = originalMixer;
				if (sfxDebug)
				{
					Debug.Log("[SFX] Restored mixer group of source '" + src.gameObject.name + "'");
				}
			}
		}
		catch
		{
		}
	}

	public void PlaySequence(int index)
	{
		if (index < 0 || index >= sequenceCount)
		{
			Debug.LogError($"[GenericAnimationHandler] Index {index} out of range for sequences.");
			return;
		}
		sequenceTimer = 0f;
		isSequencePlaying = true;
		currentSequenceIndex = index;
		ResetVisibilityTriggers();
		ResetCameraShots();
		ResetSubtitles();
		ResetDOFTargets();
		ResetSFXEvents();
		if (sfxDebug && sfxEvents != null)
		{
			Debug.Log($"[GenericAnimationHandler][SFX] PlaySequence {index} - scanning {sfxEvents.Count} events for triggers.");
			for (int i = 0; i < sfxEvents.Count; i++)
			{
				SFXEvent sFXEvent = sfxEvents[i];
				if (sFXEvent.sequenceIndex == index)
				{
					string text = ((sFXEvent.frames != null && sFXEvent.frames.Count > 0) ? string.Join(",", sFXEvent.frames) : "<none>");
					Debug.Log(string.Format("[GenericAnimationHandler][SFX] -> Event[{0}] frames=[{1}] clip={2} variants={3} sourceRef={4}", i, text, (sFXEvent.clip != null) ? sFXEvent.clip.name : "null", (sFXEvent.clipVariants != null) ? sFXEvent.clipVariants.Count : 0, (sFXEvent.sourceReference != null) ? sFXEvent.sourceReference.gameObject.name : "null"));
					if (sFXEvent.frames == null || sFXEvent.frames.Count == 0)
					{
						Debug.LogWarning($"[GenericAnimationHandler][SFX] Event[{i}] has no frames defined and will never trigger.");
					}
				}
			}
		}
		foreach (CharacterAnimation character in characters)
		{
			if (!(character.animationComponent == null) && character.animationNames != null && character.animationNames.Count > index)
			{
				string text2 = character.animationNames[index];
				if (!string.IsNullOrEmpty(text2) && character.animationComponent.GetClip(text2) != null)
				{
					character.animationComponent.Stop();
					character.animationComponent[text2].wrapMode = WrapMode.Once;
					character.animationComponent.Play(text2);
					continue;
				}
				Debug.LogWarning("[GenericAnimationHandler] Animation '" + text2 + "' not found on '" + character.name + "'.");
			}
		}
		foreach (PropAnimation prop in props)
		{
			if (!(prop.animationComponent == null) && prop.animationNames != null && prop.animationNames.Count > index)
			{
				string text3 = prop.animationNames[index];
				if (!string.IsNullOrEmpty(text3) && prop.animationComponent.GetClip(text3) != null)
				{
					prop.animationComponent.Stop();
					prop.animationComponent[text3].wrapMode = WrapMode.Once;
					prop.animationComponent.Play(text3);
					continue;
				}
				Debug.LogWarning("[GenericAnimationHandler] Animation '" + text3 + "' not found on prop '" + prop.name + "'.");
			}
		}
		if (audioSource != null && index < sequenceAudioClips.Count && sequenceAudioClips[index] != null)
		{
			audioSource.clip = sequenceAudioClips[index];
			audioSource.Play();
		}
		if (!useCameraSequence)
		{
			foreach (CameraAnimationEntry cameraAnimation in cameraAnimations)
			{
				if (cameraAnimation.sequenceIndex == index && cameraAnimation.rigAnimation != null && !string.IsNullOrEmpty(cameraAnimation.animationName) && cameraAnimation.rigAnimation.GetClip(cameraAnimation.animationName) != null)
				{
					cameraAnimation.rigAnimation.Stop();
					cameraAnimation.rigAnimation[cameraAnimation.animationName].wrapMode = WrapMode.Once;
					cameraAnimation.rigAnimation.Play(cameraAnimation.animationName);
					Debug.Log($"[CameraAnimation] Playing animation '{cameraAnimation.animationName}' on '{cameraAnimation.rigAnimation.gameObject.name}' for sequence {index}");
				}
			}
		}
		Debug.Log($"[PlaySequence] Started sequence {index}");
	}

	private void UpdateCamera(int currentFrame)
	{
		if (!useCameraSequence || mainCamera == null)
		{
			return;
		}
		foreach (CameraSequenceShots cameraSequence in cameraSequences)
		{
			if (cameraSequence.sequenceIndex != currentSequenceIndex)
			{
				continue;
			}
			foreach (CameraShot shot in cameraSequence.shots)
			{
				if (!shot.triggered && !(shot.referenceTransform == null) && currentFrame >= shot.frame)
				{
					mainCamera.transform.position = shot.referenceTransform.position;
					mainCamera.transform.rotation = shot.referenceTransform.rotation;
					shot.triggered = true;
					Debug.Log($"[CameraShot] {cameraSequence.name} → Frame:{shot.frame}");
				}
			}
		}
	}

	private void UpdateFrameVisibility(int currentFrame)
	{
		foreach (FrameVisibilityTrigger frameVisibilityTrigger in frameVisibilityTriggers)
		{
			if (!frameVisibilityTrigger.triggered && frameVisibilityTrigger.sequenceIndexes.Contains(currentSequenceIndex) && currentFrame >= frameVisibilityTrigger.frame)
			{
				ApplyVisibility(frameVisibilityTrigger);
				frameVisibilityTrigger.triggered = true;
				string arg = (frameVisibilityTrigger.visible ? "ENABLED" : "DISABLED");
				Debug.Log($"[VisibilityTrigger] \"{frameVisibilityTrigger.name}\" at Frame:{frameVisibilityTrigger.frame} → {arg}");
			}
		}
		foreach (CharacterAnimation character in characters)
		{
			if (character.animationComponent != null && currentSequenceIndex >= 0 && currentSequenceIndex < character.animationNames.Count)
			{
				string value = character.animationNames[currentSequenceIndex];
				if (!string.IsNullOrEmpty(value) && !character.animationComponent.IsPlaying(value))
				{
					isSequencePlaying = false;
					Debug.Log($"[SequenceEnd] Sequence {currentSequenceIndex} ended.");
				}
			}
		}
	}

	private void ApplyVisibility(FrameVisibilityTrigger trigger)
	{
		if (trigger.targetObject != null)
		{
			ApplyVisibilityToObject(trigger.targetObject, trigger.visible);
		}
		else if (!string.IsNullOrEmpty(trigger.targetTag))
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag(trigger.targetTag);
			foreach (GameObject obj in array)
			{
				ApplyVisibilityToObject(obj, trigger.visible);
			}
		}
	}

	private void ApplyVisibilityToObject(GameObject obj, bool makeVisible)
	{
		MeshFilter[] componentsInChildren = obj.GetComponentsInChildren<MeshFilter>(includeInactive: true);
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			if (makeVisible)
			{
				if (meshFilter.sharedMesh == null && originalMeshes.ContainsKey(meshFilter))
				{
					meshFilter.sharedMesh = originalMeshes[meshFilter];
				}
				continue;
			}
			if (!originalMeshes.ContainsKey(meshFilter))
			{
				originalMeshes[meshFilter] = meshFilter.sharedMesh;
			}
			meshFilter.sharedMesh = null;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = obj.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
		{
			if (makeVisible)
			{
				if (skinnedMeshRenderer.sharedMesh == null && originalMeshes.ContainsKey(skinnedMeshRenderer))
				{
					skinnedMeshRenderer.sharedMesh = originalMeshes[skinnedMeshRenderer];
				}
				continue;
			}
			if (!originalMeshes.ContainsKey(skinnedMeshRenderer))
			{
				originalMeshes[skinnedMeshRenderer] = skinnedMeshRenderer.sharedMesh;
			}
			skinnedMeshRenderer.sharedMesh = null;
		}
	}

	private void UpdateSubtitles(int currentFrame)
	{
		if (subtitleSequences == null || subtitleSequences.Count == 0)
		{
			Debug.LogWarning("[GenericAnimationHandler] No subtitle sequences defined.");
			return;
		}
		bool flag = false;
		foreach (SubtitleSequence subtitleSequence in subtitleSequences)
		{
			if (subtitleSequence.sequenceIndex != currentSequenceIndex)
			{
				continue;
			}
			foreach (SubtitleFrame subtitle in subtitleSequence.subtitles)
			{
				if (!subtitle.triggered && currentFrame >= subtitle.frame)
				{
					currentSubtitleText = subtitle.text;
					if (debugSubtitleDisplay != null)
					{
						debugSubtitleDisplay.text = currentSubtitleText;
					}
					subtitle.triggered = true;
					flag = true;
					Debug.Log($"[Subtitle] {subtitleSequence.name} → Frame:{subtitle.frame} → \"{subtitle.text}\"");
				}
			}
		}
		if (!flag && enableFrameLogs)
		{
			Debug.Log("[GenericAnimationHandler] No subtitle triggered this frame.");
		}
	}

	private void ResetVisibilityTriggers()
	{
		foreach (FrameVisibilityTrigger frameVisibilityTrigger in frameVisibilityTriggers)
		{
			frameVisibilityTrigger.triggered = false;
		}
	}

	private void ResetCameraShots()
	{
		foreach (CameraSequenceShots cameraSequence in cameraSequences)
		{
			foreach (CameraShot shot in cameraSequence.shots)
			{
				shot.triggered = false;
			}
		}
	}

	private void ResetSubtitles()
	{
		foreach (SubtitleSequence subtitleSequence in subtitleSequences)
		{
			foreach (SubtitleFrame subtitle in subtitleSequence.subtitles)
			{
				subtitle.triggered = false;
			}
		}
		currentSubtitleText = "";
		if (debugSubtitleDisplay != null)
		{
			debugSubtitleDisplay.text = "";
		}
		Debug.Log("[Reset] All subtitles reset");
	}

	private void ResetDOFTargets()
	{
		foreach (DOFTargetFrame dofTargetFrame in dofTargetFrames)
		{
			dofTargetFrame.triggered = false;
		}
		currentDOFTarget = null;
		currentDOFFocusDistance = 2f;
		targetDOFFocusDistance = 2f;
	}

	private void ResetSFXEvents()
	{
		if (sfxEvents == null)
		{
			return;
		}
		foreach (SFXEvent sfxEvent in sfxEvents)
		{
			sfxEvent.triggeredFrames.Clear();
		}
		if (sfxDebug)
		{
			Debug.Log("[GenericAnimationHandler][SFX] ResetSFXEvents: all triggered frames cleared.");
		}
	}

	private float SnapPlaybackSpeed(float v)
	{
		v = Mathf.Round(v * 100f) / 100f;
		if (Mathf.Abs(v - 1f) <= 0.01f)
		{
			v = 1f;
		}
		return Mathf.Clamp(v, 0.01f, 5f);
	}

	private void DisableOutlineScripts(GameObject root)
	{
		OutlineScript[] componentsInChildren = root.GetComponentsInChildren<OutlineScript>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			UnityEngine.Object.Destroy(componentsInChildren[i]);
		}
		Highlighter[] componentsInChildren2 = root.GetComponentsInChildren<Highlighter>(includeInactive: true);
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			UnityEngine.Object.Destroy(componentsInChildren2[i]);
		}
	}
}
