﻿#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2010-2014 FUJIWARA, Yusuke
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
#endregion -- License Terms --

using System;
#if !UNITY_ANDROID && !UNITY_IPHONE
using System.Diagnostics.Contracts;
#endif // !UNITY_ANDROID && !UNITY_IPHONE

namespace MsgPack
{
	/// <summary>
	///		Define bit operations which enforce big endian.
	/// </summary>
	internal static class BigEndianBinary
	{
		public static sbyte ToSByte( byte[] buffer, int offset )
		{
#if !UNITY_ANDROID && !UNITY_IPHONE
			Contract.Assume( buffer.Length >= offset + sizeof( sbyte ) );
#endif // !UNITY_ANDROID && !UNITY_IPHONE

			unchecked
			{
				return ( sbyte )buffer[ offset ];
			}
		}

		public static short ToInt16( byte[] buffer, int offset )
		{
#if !UNITY_ANDROID && !UNITY_IPHONE
			Contract.Assume( buffer.Length >= offset + sizeof( short ) );
#endif // !UNITY_ANDROID && !UNITY_IPHONE

			unchecked
			{
				return ( short )( buffer[ offset ] << 8 | buffer[ 1 + offset ] );
			}
		}

		public static int ToInt32( byte[] buffer, int offset )
		{
#if !UNITY_ANDROID && !UNITY_IPHONE
			Contract.Assume( buffer.Length >= offset + sizeof( int ) );
#endif // !UNITY_ANDROID && !UNITY_IPHONE

			unchecked
			{
				return buffer[ offset ] << 24 | buffer[ 1 + offset ] << 16 | buffer[ 2 + offset ] << 8 | buffer[ 3 + offset ];
			}
		}

		public static long ToInt64( byte[] buffer, int offset )
		{
#if !UNITY_ANDROID && !UNITY_IPHONE
			Contract.Assume( buffer.Length >= offset + sizeof( long ) );
#endif // !UNITY_ANDROID && !UNITY_IPHONE

			unchecked
			{
				return
					( long )buffer[ offset ] << 56 | ( long )buffer[ 1 + offset ] << 48 | ( long )buffer[ 2 + offset ] << 40 | ( long )buffer[ 3 + offset ] << 32
					| ( long )buffer[ 4 + offset ] << 24 | ( long )buffer[ 5 + offset ] << 16 | ( long )buffer[ 6 + offset ] << 8 | buffer[ 7 + offset ];
			}
		}

		public static byte ToByte( byte[] buffer, int offset )
		{
#if !UNITY_ANDROID && !UNITY_IPHONE
			Contract.Assume( buffer.Length >= offset + sizeof( byte ) );
#endif // !UNITY_ANDROID && !UNITY_IPHONE

			return buffer[ offset ];
		}

		public static ushort ToUInt16( byte[] buffer, int offset )
		{
#if !UNITY_ANDROID && !UNITY_IPHONE
			Contract.Assume( buffer.Length >= offset + sizeof( ushort ) );
#endif // !UNITY_ANDROID && !UNITY_IPHONE

			unchecked
			{
				return ( ushort )( ( buffer[ offset ] << 8 ) | buffer[ 1 + offset ] );
			}
		}

		public static uint ToUInt32( byte[] buffer, int offset )
		{
#if !UNITY_ANDROID && !UNITY_IPHONE
			Contract.Assume( buffer.Length >= offset + sizeof( uint ) );
#endif // !UNITY_ANDROID && !UNITY_IPHONE

			unchecked
			{
				return ( uint )( ( buffer[ offset ] << 24 ) | buffer[ 1 + offset ] << 16 | buffer[ 2 + offset ] << 8 | buffer[ 3 + offset ] );
			}
		}

		public static ulong ToUInt64( byte[] buffer, int offset )
		{
#if !UNITY_ANDROID && !UNITY_IPHONE
			Contract.Assume( buffer.Length >= offset + sizeof( ulong ) );
#endif // !UNITY_ANDROID && !UNITY_IPHONE

			unchecked
			{
				return
					( ulong )( ( long )buffer[ offset ] << 56 | ( long )buffer[ 1 + offset ] << 48 | ( long )buffer[ 2 + offset ] << 40 | ( long )buffer[ 3 + offset ] << 32
					| ( long )buffer[ 4 + offset ] << 24 | ( long )buffer[ 5 + offset ] << 16 | ( long )buffer[ 6 + offset ] << 8 | buffer[ 7 + offset ] );
			}
		}

		public static float ToSingle( byte[] buffer, int offset )
		{
			return new Float32Bits( buffer, offset ).Value;
		}

		public static double ToDouble( byte[] buffer, int offset )
		{
			return new Float64Bits( buffer, offset ).Value;
		}
	}
}
