﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace DynamicGrass
{
	[CustomEditor(typeof(DynamicGrassPopulator))]
	public class DynamicGrassPopulatorEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			DynamicGrassPopulator populator = (DynamicGrassPopulator) target;

			//if (GUILayout.Button("Repopulate"))
			//{
				populator.Populate();
			//}
		}
	}

}