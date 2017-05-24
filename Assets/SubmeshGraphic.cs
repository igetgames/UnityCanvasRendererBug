using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmeshGraphic : Graphic
{
    [SerializeField]
    private int _submeshCount = 1;

    public int submeshCount
    {
        get
        {
            return _submeshCount;
        }

        set
        {
            if (_submeshCount != value)
            {
                _submeshCount = value;
                SetAllDirty();
            }
        }
    }
    protected override void UpdateMaterial()
    {
        if (submeshCount <= 0)
        {
            return;
        }

        canvasRenderer.materialCount = submeshCount;

        for (int i = 0; i < canvasRenderer.materialCount; ++i)
        {
            canvasRenderer.SetMaterial(defaultMaterial, i);
        }
    }

    protected override void UpdateGeometry()
    {
        if (submeshCount <= 0)
        {
            return;
        }

        var indices = new List<int[]>();
        var r = GetPixelAdjustedRect();
        Color32 color32 = color;

        using (var vh = new VertexHelper())
        {
            for (int i = 0; i < submeshCount; ++i)
            {
                var v = new Vector4(r.x, r.y, r.x + r.width, r.y + r.height);
                int indexOffset = vh.currentVertCount;

                r.x += r.width;

                vh.AddVert(new Vector3(v.x, v.y), color32, new Vector2(0f, 0f));
                vh.AddVert(new Vector3(v.x, v.w), color32, new Vector2(0f, 1f));
                vh.AddVert(new Vector3(v.z, v.w), color32, new Vector2(1f, 1f));
                vh.AddVert(new Vector3(v.z, v.y), color32, new Vector2(1f, 0f));

                indices.Add(new int[] { indexOffset + 0, indexOffset + 1, indexOffset + 2, indexOffset + 2, indexOffset + 3, indexOffset + 0 });
            }

            vh.FillMesh(workerMesh);
        }

        workerMesh.subMeshCount = submeshCount;

        for (int i = 0; i < submeshCount; ++i)
        {
            workerMesh.SetIndices(indices[i], MeshTopology.Triangles, i);
        }

        canvasRenderer.SetMesh(workerMesh);
    }
}
