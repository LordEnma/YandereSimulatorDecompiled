using UnityEngine;

public class LagPosition : MonoBehaviour
{
	public Vector3 speed = new Vector3(10f, 10f, 10f);

	public bool ignoreTimeScale;

	private Transform mTrans;

	private Vector3 mRelative;

	private Vector3 mAbsolute;

	private bool mStarted;

	public void OnRepositionEnd()
	{
		Interpolate(1000f);
	}

	private void Interpolate(float delta)
	{
		Transform parent = mTrans.parent;
		if (parent != null)
		{
			Vector3 vector = parent.position + parent.rotation * mRelative;
			mAbsolute.x = Mathf.Lerp(mAbsolute.x, vector.x, Mathf.Clamp01(delta * speed.x));
			mAbsolute.y = Mathf.Lerp(mAbsolute.y, vector.y, Mathf.Clamp01(delta * speed.y));
			mAbsolute.z = Mathf.Lerp(mAbsolute.z, vector.z, Mathf.Clamp01(delta * speed.z));
			mTrans.position = mAbsolute;
		}
	}

	private void Awake()
	{
		mTrans = base.transform;
	}

	private void OnEnable()
	{
		if (mStarted)
		{
			ResetPosition();
		}
	}

	private void Start()
	{
		mStarted = true;
		ResetPosition();
	}

	public void ResetPosition()
	{
		mAbsolute = mTrans.position;
		mRelative = mTrans.localPosition;
	}

	private void Update()
	{
		Interpolate(ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
	}
}
