using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName="NewVector3Reference", menuName="Variables/Vector3Reference")]
[Serializable]
public class Vector3Reference : ScriptableObject 
{
	public bool UseConstant = true;
	public Vector3 ConstantValue;
	public Vector3Variable Variable;

	public Vector3 Value
	{ 
		get
		{
			return UseConstant ? ConstantValue : Variable.Value;
		}
	}
	
}
