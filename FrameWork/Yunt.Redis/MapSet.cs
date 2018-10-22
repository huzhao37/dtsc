﻿
#region using namespace

using System.Collections.Generic;


#endregion

namespace Yunt.Redis
{
    public abstract class MapSet
    {
        private readonly string _mDataKey;

        private readonly DataType _mDataType;

        public MapSet(string key, DataType dataType)
        {
            _mDataKey = key;
            _mDataType = dataType;
        }

        /// <summary>
        ///     返回哈希表key中，一个或多个给定域的值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fields"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public IList<T> MGet<T>(string[] fields,  RedisCachingProvider db = null)
        {
            var nts = new NameType[fields.Length];
            for (var i = 0; i < fields.Length; i++)
            {
                nts[i] = new NameType(fields[i], i);
            }
            db =  RedisCachingProvider.GetClient(db);
            return db.HashGetFields<T>(_mDataKey, nts, _mDataType);
        }

        /// <summary>
        ///     查看哈希表key中，给定域field是否存在。
        /// </summary>
        /// <param name="ke"></param>
        /// <returns></returns>
        public bool HExists(string ke,  RedisCachingProvider db = null)
        {
            db =  RedisCachingProvider.GetClient(db);
            return db.HashFieldExists(_mDataKey, ke, _mDataType) > 0;
        }

        /// <summary>
        ///     返回哈希表key中的所有域。
        /// </summary>
        /// <returns></returns>
        public IList<string> Keys( RedisCachingProvider db = null)
        {
            db =  RedisCachingProvider.GetClient(db);
            return db.HashGetAllFields(_mDataKey, _mDataType);
        }

        /// <summary>
        ///     返回哈希表key中的所有值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> Vals<T>( RedisCachingProvider db = null)
        {
            db =  RedisCachingProvider.GetClient(db);
            return db.HashGetAllValues<T>(_mDataKey, _mDataType);
        }

        /// <summary>
        ///     返回哈希表key中给定域field的值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Hget<T>(string name,  RedisCachingProvider db = null)
        {
            db =  RedisCachingProvider.GetClient(db);
            return db.HashGet<T>(_mDataKey, name, _mDataType);
        }

        /// <summary>
        ///     返回哈希表key中，所有的域和值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<Field> GetAll<T>( RedisCachingProvider db = null)
        {
            db =  RedisCachingProvider.GetClient(db);
            return db.HashGetAll<T>(_mDataKey, _mDataType);
        }

        /// <summary>
        ///     同时将多个field - value(域-值)对设置到哈希表key中。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool MSet(string name, object value,  RedisCachingProvider db = null)
        {
            db =  RedisCachingProvider.GetClient(db);
            return db.SetFields((string) _mDataKey, name, value, _mDataType) == "OK";
        }

        /// <summary>
        ///     将哈希表key中的域field的值设为value。
        /// </summary>
        /// <param name="serverid"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int HSet(int serverid, string name, object value,  RedisCachingProvider db = null)
        {
            db =  RedisCachingProvider.GetClient(db);
            return db.HashSetFieldValue((string) _mDataKey, name, value, _mDataType);
        }

        /// <summary>
        ///     将哈希表key中的域field的值设置为value，当且仅当域field不存在。
        /// </summary>
        /// <param name="item"></param>
        public void HSETNX(Field item,  RedisCachingProvider db = null)
        {
            db =  RedisCachingProvider.GetClient(db);
            db.HashSetFieldValueNx((string) _mDataKey, item, _mDataType);
        }

        public int HLen( RedisCachingProvider db = null)
        {
            db =  RedisCachingProvider.GetClient(db);
            return db.HLen((string) _mDataKey);
        }

        public void Clear( RedisCachingProvider db = null)
        {
            db =  RedisCachingProvider.GetClient(db);
            db.Delete(_mDataKey);
        }

        public void Remove(string field,  RedisCachingProvider db = null)
        {
            db =  RedisCachingProvider.GetClient(db);
            db.HDelete(_mDataKey, field);
        }
    }

    public class StringMapSet : MapSet
    {
        public StringMapSet(string key)
            : base(key, DataType.String)
        {
        }

        public static implicit operator StringMapSet(string key)
        {
            return new StringMapSet(key);
        }
    }

    public class JsonMapSet : MapSet
    {
        public JsonMapSet(string key)
            : base(key, DataType.Json)
        {
        }

        public static implicit operator JsonMapSet(string key)
        {
            return new JsonMapSet(key);
        }
    }

    public class ProtobufMapSet : MapSet
    {
        public ProtobufMapSet(string key)
            : base(key, DataType.Protobuf)
        {
        }

        public static implicit operator ProtobufMapSet(string key)
        {
            return new ProtobufMapSet(key);
        }
    }
}