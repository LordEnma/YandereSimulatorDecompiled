using UnityEngine;

[AddComponentMenu("NGUI/Examples/Spin")]
public class Spin : MonoBehaviour
{
	public Vector3 rotationsPerSecond = new Vector3(0f, 0.1f, 0f);

	public bool ignoreTimeScale;

	private Rigidbody mRb;

	private Transform mTrans;

	private void Start()
	{
		mTrans = base.transform;
		mRb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (mRb == null)
		{
			ApplyDelta(ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
		}
	}

	private void FixedUpdate()
	{
		if (mRb != null)
		{
			ApplyDelta(Time.deltaTime);
		}
	}

	public void ApplyDelta(float delta)
	{
		delta *= 360f;
		Quaternion quaternion = Quaternion.Euler(rotationsPerSecond * delta);
		if (mRb == null)
		{
			mTrans.rotation *= quaternion;
		}
		else
		{
			mRb.MoveRotation(mRb.rotation * quaternion);
		}
	}
}
