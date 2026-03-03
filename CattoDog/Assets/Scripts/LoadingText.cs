using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingText : MonoBehaviour
{
    public float amplitude = 10f;
    public float frequency = 6f;

    TMP_Text textMesh;
    TMP_TextInfo textInfo;

    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    void Update()
    {
        textMesh.ForceMeshUpdate();
        textInfo = textMesh.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible) continue;

            var charInfo = textInfo.characterInfo[i];
            int vertexIndex = charInfo.vertexIndex;
            int meshIndex = charInfo.materialReferenceIndex;

            Vector3[] verts = textInfo.meshInfo[meshIndex].vertices;

            float offset = Mathf.Sin((Time.time * frequency) + i * 0.3f) * amplitude;

            Vector3 wiggle = new Vector3(0, offset, 0);

            verts[vertexIndex + 0] += wiggle;
            verts[vertexIndex + 1] += wiggle;
            verts[vertexIndex + 2] += wiggle;
            verts[vertexIndex + 3] += wiggle;
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            textMesh.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}

  
