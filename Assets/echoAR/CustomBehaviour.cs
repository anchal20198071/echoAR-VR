/**************************************************************************
* Copyright (C) echoAR, Inc. 2018-2020.                                   *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echoar.xyz/terms, or another agreement                      *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;

    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>
    private int[] ARR = {1,2,3,4,5 };
    private Dictionary<int, Data> dataMap = new Dictionary<int, Data>();
    private int scale = 1;

        public class Data
        {

            public GameObject graph;

            public Data(GameObject graph)
            {
                this.graph = graph;
            }
        }


    // Use this for initialization
    void Start()
    {
        // Add RemoteTransformations script to object and set its entry
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;

        // Qurey additional data to get the name
        string value = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("name", out value))
        {
            // Set name
            this.gameObject.name = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (entry.getAdditionalData() != null)
        {
                    string scaleString = "";

                    if (entry.getAdditionalData().TryGetValue("scale", out scaleString))
                    {
                        scale = int.Parse(scaleString);
                    }
                    int x = 0;
                     foreach(int continent in ARR)
                    {             Thread.Sleep(3000);
                                  GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                  cube.AddComponent<MeshCollider>();
                                  cube.transform.position = new Vector3(x, 0, 8.5f);

                                  x += 2;

                    }
        }
    }
}