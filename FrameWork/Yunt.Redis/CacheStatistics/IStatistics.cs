﻿#region Code File Comment

// SOLUTION   ： **物联网V3
// PROJECT    ： Yunt.Redis
// FILENAME   ： BufferPool.cs
// AUTHOR     ： soft-zh
// CREATE TIME： 2018-3-14 9:42
// COPYRIGHT  ： 版权所有 (C) **公司 https://gitee.com/zhaohu37/dtsc 2018~2020

#endregion

namespace Yunt.Redis
{
    /// <summary>
    /// redis命中统计
    /// </summary>
    public interface IStatistics
    {
        string Name { get; set; }
        void Show();
        void AddHit();
        void AddTotal();
        void Reset();
    }
}