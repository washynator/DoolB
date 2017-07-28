using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Gun : MonoBehaviour
{
    private List<string> gunStrings = new List<string>();
    
    private List<GunData> guns = new List<GunData>();

    private string path;
    private string jsongString;

    private GameObject gun;
    private int index = 0;

    public Material newMat;

    private void Start()
    {
        path = Application.streamingAssetsPath;

        foreach(string directories in Directory.GetDirectories(path))
        {
            foreach(string gunNames in Directory.GetFiles(directories, "*.json"))
            {
                gunStrings.Add(gunNames);
            }
        }

        foreach(string jsonString in gunStrings)
        {
            string gunFile = File.ReadAllText(jsonString);

            guns.Add(JsonUtility.FromJson<GunData>(gunFile));

            gun = new GameObject();
            gun.transform.parent = this.transform;
            gun.name = guns[index].name;
            gun.AddComponent<MeshRenderer>();
            MeshFilter meshFilter = gun.AddComponent<MeshFilter>();

            Mesh holderMesh = new Mesh();
            ObjImporter newMesh = new ObjImporter();
            holderMesh = newMesh.ImportFile(path + "/Guns/" + "donut_tutorial.obj");
            
            meshFilter.mesh = holderMesh;
            gun.GetComponent<MeshRenderer>().material = newMat;

            gun.transform.localPosition = Vector3.zero;
            gun.transform.localScale = new Vector3(10f, 10f, 10f);

            gun.gameObject.layer = LayerMask.NameToLayer("Gun");
            

            index++;
        }

        ChangeWeapon(guns[0].name);
    }

    private void ChangeWeapon(string gunNameToEquip)
    {
        Debug.Log(gunNameToEquip);
    }

}
