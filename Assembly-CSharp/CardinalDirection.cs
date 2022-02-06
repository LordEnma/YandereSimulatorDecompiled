using System;

// Token: 0x02000493 RID: 1171
public static class CardinalDirection
{
	// Token: 0x06001F29 RID: 7977 RVA: 0x001B8E14 File Offset: 0x001B7014
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

	// Token: 0x06001F2A RID: 7978 RVA: 0x001B8E28 File Offset: 0x001B7028
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

	// Token: 0x06001F2B RID: 7979 RVA: 0x001B8E3C File Offset: 0x001B703C
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
