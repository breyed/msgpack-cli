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

#if !UNITY_ANDROID && !UNITY_IPHONE
using System;
using System.Numerics;

namespace MsgPack.Serialization.DefaultSerializers
{
	// ReSharper disable once InconsistentNaming
	internal sealed class System_Numerics_ComplexMessagePackSerializer : MessagePackSerializer<Complex>
	{
		public System_Numerics_ComplexMessagePackSerializer( SerializationContext ownerContext )
			: base( ownerContext ) { }

		protected internal override void PackToCore( Packer packer, Complex objectTree )
		{
			packer.PackArrayHeader( 2 );
			packer.Pack( objectTree.Real );
			packer.Pack( objectTree.Imaginary );
		}

		protected internal override Complex UnpackFromCore( Unpacker unpacker )
		{
			if ( !unpacker.Read() )
			{
				throw SerializationExceptions.NewUnexpectedEndOfStream();
			}

			var real = unpacker.LastReadData.AsDouble();

			if ( !unpacker.Read() )
			{
				throw SerializationExceptions.NewUnexpectedEndOfStream();
			}

			var imaginary = unpacker.LastReadData.AsDouble();

			return new Complex( real, imaginary );
		}
	}
}
#endif // !UNITY_ANDROID && !UNITY_IPHONE
