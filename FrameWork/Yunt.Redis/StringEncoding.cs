﻿#region Code File Comment

// SOLUTION   ： **物联网V3
// PROJECT    ： Yunt.Redis
// FILENAME   ： StringEncoding.cs
// AUTHOR     ： soft-zh
// CREATE TIME： 2018-3-14 9:42
// COPYRIGHT  ： 版权所有 (C) **公司 https://gitee.com/zhaohu37/dtsc 2018~2020

#endregion

#region using namespace

using System.Text;

#endregion

namespace Yunt.Redis
{
    class StringEncoding
    {
        public byte[] Buffer;

        public StringEncoding(int length)
        {
            Buffer = new byte[length];
        }


        public int Encode(string value)
        {
            var count = Encoding.UTF8.GetBytes(value, 0, value.Length, Buffer, 0);
            return count;
        }
    }
}