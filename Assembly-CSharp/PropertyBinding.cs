using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Internal/Property Binding")]
public class PropertyBinding : MonoBehaviour
{
	[DoNotObfuscateNGUI]
	public enum UpdateCondition
	{
		OnStart = 0,
		OnUpdate = 1,
		OnLateUpdate = 2,
		OnFixedUpdate = 3
	}

	[DoNotObfuscateNGUI]
	public enum Direction
	{
		SourceUpdatesTarget = 0,
		TargetUpdatesSource = 1,
		BiDirectional = 2
	}

	public PropertyReference source;

	public PropertyReference target;

	public Direction direction;

	public UpdateCondition update = UpdateCondition.OnUpdate;

	public bool editMode = true;

	private object mLastValue;

	private void Start()
	{
		UpdateTarget();
		if (update == UpdateCondition.OnStart)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (update == UpdateCondition.OnUpdate)
		{
			UpdateTarget();
		}
	}

	private void LateUpdate()
	{
		if (update == UpdateCondition.OnLateUpdate)
		{
			UpdateTarget();
		}
	}

	private void FixedUpdate()
	{
		if (update == UpdateCondition.OnFixedUpdate)
		{
			UpdateTarget();
		}
	}

	private void OnValidate()
	{
		if (source != null)
		{
			source.Reset();
		}
		if (target != null)
		{
			target.Reset();
		}
	}

	[ContextMenu("Update Now")]
	public void UpdateTarget()
	{
		if (source == null || target == null || !source.isValid || !target.isValid)
		{
			return;
		}
		if (direction == Direction.SourceUpdatesTarget)
		{
			target.Set(source.Get());
		}
		else if (direction == Direction.TargetUpdatesSource)
		{
			source.Set(target.Get());
		}
		else
		{
			if (!(source.GetPropertyType() == target.GetPropertyType()))
			{
				return;
			}
			object obj = source.Get();
			if (mLastValue == null || !mLastValue.Equals(obj))
			{
				mLastValue = obj;
				target.Set(obj);
				return;
			}
			obj = target.Get();
			if (!mLastValue.Equals(obj))
			{
				mLastValue = obj;
				source.Set(obj);
			}
		}
	}
}
