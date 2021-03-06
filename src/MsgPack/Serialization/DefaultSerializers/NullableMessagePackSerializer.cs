#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2010-2012 FUJIWARA, Yusuke
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
using System.Reflection;

namespace MsgPack.Serialization.DefaultSerializers
{
	internal static class NullableMessagePackSerializer
	{
		// ReSharper disable InconsistentNaming
		public static readonly PropertyInfo MessagePackObject_IsNilProperty = FromExpression.ToProperty( ( MessagePackObject value ) => value.IsNil );
		public static readonly PropertyInfo Nullable_MessagePackObject_ValueProperty = FromExpression.ToProperty( ( MessagePackObject? value ) => value.Value );
		public static readonly PropertyInfo UnpackerLastReadDataProperty = FromExpression.ToProperty( ( Unpacker unpacker ) => unpacker.LastReadData );
		// ReSharper restore InconsistentNaming
		public static readonly MethodInfo PackerPackNull = FromExpression.ToMethod( ( Packer packer ) => packer.PackNull() );
	}
}
