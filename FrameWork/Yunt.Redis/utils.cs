﻿#region Code File Comment

// SOLUTION   ： **物联网V3
// PROJECT    ： Yunt.Redis
// FILENAME   ： utils.cs
// AUTHOR     ： soft-zh
// CREATE TIME： 2018-3-14 9:42
// COPYRIGHT  ： 版权所有 (C) **公司 https://gitee.com/zhaohu37/dtsc 2018~2020

#endregion

#region using namespace

using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using ProtoBuf.Meta;

#endregion

namespace Yunt.Redis
{
    class Utils
    {
        public static byte[] Eof = Encoding.ASCII.GetBytes("\r\n");

        public static string GetString(ArraySegment<byte> data)
        {
            if (data.Count > 0)
                return Encoding.UTF8.GetString(data.Array, data.Offset, data.Count);
            return null;
        }

        public static object GetJson(ArraySegment<byte> data, Type type)
        {
            var value = GetString(data);
            if (string.IsNullOrEmpty(value))
                return null;
            return JsonConvert.DeserializeObject(value, type);
        }

        public static object GetProtobuf(ArraySegment<byte> data, Type type)
        {
            if (data.Count > 0)
            {
                var stream = new MemoryStream(data.Array, data.Offset, data.Count);
                stream.Position = 0;
                return RuntimeTypeModel.Default.Deserialize(stream, null, type);
            }

            return null;
        }
    }
}