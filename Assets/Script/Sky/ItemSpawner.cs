using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;

public class ItemSpawner : MonoBehaviourPunCallbacks
{
    public GameObject[] items;
    public Transform playerTransform;

    private float lastSpawnTime;
    public float maxDistance = 100f;

    private Vector3[] itemPosition;
    public int numOfItems;

    void Start()
    {
        lastSpawnTime = 0;

        numOfItems = 10;
        itemPosition = new Vector3[numOfItems];

        for(int i = 0; i < numOfItems; i++)
        {
            itemPosition[i] = GetRandomPositionOnNavMesh(playerTransform.position, maxDistance, NavMesh.AllAreas);
            itemPosition[i] += Vector3.up * 0.5f;
        }
        
    }

    void Update()
    {
        if(photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                Spawn();
            }
        }
        //Spawn();
    }

    private void Spawn()
    {
        for(int i = 0; i < numOfItems; i++)
        {
            var item = PhotonNetwork.Instantiate(items[Random.Range(0, items.Length)].name, itemPosition[i], Quaternion.identity);
        }
    }

    public static Vector3 GetRandomPositionOnNavMesh(Vector3 center, float distance, int areaMask)
    {
        var randomPos = Random.insideUnitSphere * distance + center;

        NavMeshHit hit;

        NavMesh.SamplePosition(randomPos, out hit, distance, areaMask);
        
        return hit.position;
    }
}
