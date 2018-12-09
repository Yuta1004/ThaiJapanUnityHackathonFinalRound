using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

<<<<<<< HEAD
namespace UnityEngine.UI
{
    public class GraphicCast : Graphic
    {

        protected override void OnFillVBO(System.Collections.Generic.List<UIVertex> vbo)
        {
            base.OnFillVBO(vbo);
            vbo.Clear();
        }
#if UNITY_EDITOR

        [CustomEditor(typeof(GraphicCast))]
        class GraphicCastEditor : Editor
        {
            public override void OnInspectorGUI()
            {
            }
        }

#endif
    }
=======
public class MoveSkyBox : MonoBehaviour {
	float _curRot = 0f;
	float rotSpeed = 5f;

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		_curRot += rotSpeed * Time.deltaTime;
		_curRot %= 360f;
		RenderSettings.skybox.SetFloat("_Rotation", _curRot);
	}
>>>>>>> 264332f48f97d4004dba65c50a03aeecb62df2c4
}

