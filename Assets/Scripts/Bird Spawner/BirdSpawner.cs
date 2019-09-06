using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public static BirdSpawner instance;

    [SerializeField]
    private GameObject bird;

    private GameObject[] birds = new GameObject[2];

    private float yBG;
    private float leftX = -1.8f, rightX = 1.8f;

    void Awake() {
        if(instance == null) {
            instance = this;
        }

        Vector3 temp = transform.position;

        for(int i = 0; i < birds.Length; i++) {
            birds[i] = Instantiate(bird, temp, Quaternion.identity);
            birds[i].SetActive(false);
        }

    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "BG") {
           Vector3 temp = target.transform.position;
           float birdY = temp.y;
           if(temp.y > 5) {
                temp.x = Random.Range(leftX, rightX);
                temp.y = Random.Range(birdY - 3, birdY + 3);
                for(int i = 0; i < birds.Length; i++) {
                    if(!birds[i].activeInHierarchy) {
                        birds[i].transform.position = temp;
                        birds[i].gameObject.SetActive(true);
                        break;
                    }
                }
           }
        }
    }

    // void SpawnBird() {
    //     Vector3 temp = transform.position;
    //     GameObject newBird = null;

    //     yBG = temp.y;

    //     temp.x = Random.Range(leftX, rightX);
    //     temp.y = Random.Range(yBG - 2, yBG + 2);
    //     newBird = Instantiate(bird, temp, Quaternion.identity);
    // }

}
