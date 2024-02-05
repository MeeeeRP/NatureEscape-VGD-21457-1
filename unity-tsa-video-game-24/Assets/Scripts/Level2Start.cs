using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel: MonoBehaviour
{
    public Collider2D finishCollider;

    // private void Start()
    // {
    //     finishCollider.enabled = true;

    // }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player") {
            Invoke("CompleteLevel", .5f);
            print("callled for level");
        }
    }

    private void CompleteLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        print("level load");
    }

}
