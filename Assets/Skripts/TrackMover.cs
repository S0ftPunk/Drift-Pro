using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMover : MonoBehaviour
{
    public GameObject trackPrefab;
    //GameObject[] tracks = new GameObject[4];
    public List<GameObject> tracks;
    Vector3 trackSpawn = new Vector3(0.2f, 0, 0);
    public float speed = 5f;
    void Awake()
    {
        tracks.Add(Instantiate(trackPrefab, trackSpawn, trackPrefab.transform.rotation));
    }
    void Update()
    {
        foreach (GameObject track in tracks)
        {
            track.transform.position += transform.right * speed * Time.deltaTime;
        }
            for (int i = 0;i< tracks.Count; i++)
        {
            if (tracks[i].transform.position.x >= 4.7f & tracks.Count == i+1)
            {
                //tracks.Add(Instantiate(trackPrefab, new Vector3(-19.6f, 0, 0), trackPrefab.transform.rotation));
                tracks.Add(Instantiate(trackPrefab, tracks[i].GetComponentsInChildren<Transform>()[1].position, trackPrefab.transform.rotation));
            }
            if (tracks[i].transform.position.x >= 25f)
            {
                Destroy(tracks[i]);
                tracks.RemoveAt(i);
            }
        }
       

    }
}
