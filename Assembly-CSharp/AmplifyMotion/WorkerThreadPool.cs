// Decompiled with JetBrains decompiler
// Type: AmplifyMotion.WorkerThreadPool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace AmplifyMotion
{
  internal class WorkerThreadPool
  {
    private const int ThreadStateQueueCapacity = 1024;
    internal Queue<MotionState>[] m_threadStateQueues;
    internal object[] m_threadStateQueueLocks;
    private int m_threadPoolSize;
    private ManualResetEvent m_threadPoolTerminateSignal;
    private AutoResetEvent[] m_threadPoolContinueSignals;
    private Thread[] m_threadPool;
    private bool m_threadPoolFallback;
    internal object m_threadPoolLock;
    internal int m_threadPoolIndex;

    internal void InitializeAsyncUpdateThreads(int threadCount, bool systemThreadPool)
    {
      if (systemThreadPool)
      {
        this.m_threadPoolFallback = true;
      }
      else
      {
        try
        {
          this.m_threadPoolSize = threadCount;
          this.m_threadStateQueues = new Queue<MotionState>[this.m_threadPoolSize];
          this.m_threadStateQueueLocks = new object[this.m_threadPoolSize];
          this.m_threadPool = new Thread[this.m_threadPoolSize];
          this.m_threadPoolTerminateSignal = new ManualResetEvent(false);
          this.m_threadPoolContinueSignals = new AutoResetEvent[this.m_threadPoolSize];
          this.m_threadPoolLock = new object();
          this.m_threadPoolIndex = 0;
          for (int index = 0; index < this.m_threadPoolSize; ++index)
          {
            this.m_threadStateQueues[index] = new Queue<MotionState>(1024);
            this.m_threadStateQueueLocks[index] = new object();
            this.m_threadPoolContinueSignals[index] = new AutoResetEvent(false);
            this.m_threadPool[index] = new Thread(new ParameterizedThreadStart(WorkerThreadPool.AsyncUpdateThread));
            this.m_threadPool[index].Start((object) new KeyValuePair<object, int>((object) this, index));
          }
        }
        catch (Exception ex)
        {
          Debug.LogWarning((object) ("[AmplifyMotion] Non-critical error while initializing WorkerThreads. Falling back to using System.Threading.ThreadPool().\n" + ex.Message));
          this.m_threadPoolFallback = true;
        }
      }
    }

    internal void FinalizeAsyncUpdateThreads()
    {
      if (this.m_threadPoolFallback)
        return;
      this.m_threadPoolTerminateSignal.Set();
      for (int index = 0; index < this.m_threadPoolSize; ++index)
      {
        if (this.m_threadPool[index].IsAlive)
        {
          this.m_threadPoolContinueSignals[index].Set();
          this.m_threadPool[index].Join();
          this.m_threadPool[index] = (Thread) null;
        }
        lock (this.m_threadStateQueueLocks[index])
        {
          while (this.m_threadStateQueues[index].Count > 0)
            this.m_threadStateQueues[index].Dequeue().AsyncUpdate();
        }
      }
      this.m_threadStateQueues = (Queue<MotionState>[]) null;
      this.m_threadStateQueueLocks = (object[]) null;
      this.m_threadPoolSize = 0;
      this.m_threadPool = (Thread[]) null;
      this.m_threadPoolTerminateSignal = (ManualResetEvent) null;
      this.m_threadPoolContinueSignals = (AutoResetEvent[]) null;
      this.m_threadPoolLock = (object) null;
      this.m_threadPoolIndex = 0;
    }

    internal void EnqueueAsyncUpdate(MotionState state)
    {
      if (!this.m_threadPoolFallback)
      {
        lock (this.m_threadStateQueueLocks[this.m_threadPoolIndex])
          this.m_threadStateQueues[this.m_threadPoolIndex].Enqueue(state);
        this.m_threadPoolContinueSignals[this.m_threadPoolIndex].Set();
        ++this.m_threadPoolIndex;
        if (this.m_threadPoolIndex < this.m_threadPoolSize)
          return;
        this.m_threadPoolIndex = 0;
      }
      else
        ThreadPool.QueueUserWorkItem(new WaitCallback(WorkerThreadPool.AsyncUpdateCallback), (object) state);
    }

    private static void AsyncUpdateCallback(object obj) => ((MotionState) obj).AsyncUpdate();

    private static void AsyncUpdateThread(object obj)
    {
      KeyValuePair<object, int> keyValuePair = (KeyValuePair<object, int>) obj;
      WorkerThreadPool key = (WorkerThreadPool) keyValuePair.Key;
      int index = keyValuePair.Value;
label_1:
      while (true)
      {
        try
        {
          key.m_threadPoolContinueSignals[index].WaitOne();
          if (key.m_threadPoolTerminateSignal.WaitOne(0))
            break;
          while (true)
          {
            MotionState motionState = (MotionState) null;
            lock (key.m_threadStateQueueLocks[index])
            {
              if (key.m_threadStateQueues[index].Count > 0)
                motionState = key.m_threadStateQueues[index].Dequeue();
            }
            if (motionState != null)
              motionState.AsyncUpdate();
            else
              goto label_1;
          }
        }
        catch (Exception ex)
        {
          if (ex.GetType() != typeof (ThreadAbortException))
            Debug.LogWarning((object) ex);
        }
      }
    }
  }
}
