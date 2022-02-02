using System;

// Token: 0x02000493 RID: 1171
public static class CardinalDirection
{
	// Token: 0x06001F24 RID: 7972 RVA: 0x001B88E8 File Offset: 0x001B6AE8
	public static Direction Reversed(Direction direction)
	{
		if (direction == Direction.North)
		{
			return Direction.South;
		}
		if (direction == Direction.East)
		{
			return Direction.West;
		}
		if (direction == Direction.South)
		{
			return Direction.North;
		}
		return Direction.East;
	}

	// Token: 0x06001F25 RID: 7973 RVA: 0x001B88FC File Offset: 0x001B6AFC
	public static Direction LeftPerp(Direction direction)
	{
		if (direction == Direction.North)
		{
			return Direction.West;
		}
		if (direction == Direction.East)
		{
			return Direction.North;
		}
		if (direction == Direction.South)
		{
			return Direction.East;
		}
		return Direction.South;
	}

	// Token: 0x06001F26 RID: 7974 RVA: 0x001B8910 File Offset: 0x001B6B10
	public static Direction RightPerp(Direction direction)
	{
		if (direction == Direction.North)
		{
			return Direction.East;
		}
		if (direction == Direction.East)
		{
			return Direction.South;
		}
		if (direction == Direction.South)
		{
			return Direction.West;
		}
		return Direction.North;
	}
}
