// Decompiled with JetBrains decompiler
// Type: IScheduledEventTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public interface IScheduledEventTime
{
  ScheduledEventTimeType ScheduleType { get; }

  bool OccurringNow(DateAndTime currentTime);

  bool OccursInTheFuture(DateAndTime currentTime);

  bool OccurredInThePast(DateAndTime currentTime);
}
