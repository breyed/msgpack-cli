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

using NUnit.Framework;

namespace MsgPack.Serialization
{
	[TestFixture]
	internal class PreGeneratedSerializerGenerator
	{
		// To test generated serializers, enable this test and run, then copy bin/Debug/MsgPack contents to project's Serialization/GeneratedSerializers/ directory.
		// [Test]
		public void GenerateFiles()
		{
			SerializerGenerator.GenerateCode(
				new SerializerCodeGenerationConfiguration
				{
					Namespace = "MsgPack.Serialization.GeneratedSerializers.ArrayBased",
					SerializationMethod = SerializationMethod.Array
				},
				PreGeneratedSerializerActivator.KnownTypes
			);
			SerializerGenerator.GenerateCode(
				new SerializerCodeGenerationConfiguration
				{
					Namespace = "MsgPack.Serialization.GeneratedSerializers.MapBased",
					SerializationMethod = SerializationMethod.Map
				},
				PreGeneratedSerializerActivator.KnownTypes
			);
		}
	}
}
