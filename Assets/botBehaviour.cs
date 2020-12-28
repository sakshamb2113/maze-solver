using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botBehaviour : MonoBehaviour
{
    private float velocity = 1.0f;
    public Rigidbody bot;
    bool flag;

    // public GameObject col, Front, Back;

    // Start is called before the first frame update
    void Start() {
        flag = false;
        InvokeRepeating("move", 0, 0.2f);
    }

    // Update is called once per frame
    void move() {
        // flag = !flag;
        // if (flag) {
        //     return;
        // }

        if (Physics.Raycast(transform.position, -transform.up, 1.0f) == false) {
            stop();
        }
        if (Physics.Raycast(transform.position, transform.forward, 0.4f)) {
            print("Left");
            turnLeft(45.0f);
        }
        else if (Physics.Raycast(transform.position, transform.right, 0.4f) == false) {
            print("Right");
            turnRight(45.0f);
        }
        else {
            forward();
        }
    }

    void forward() {
        bot.velocity = transform.forward * velocity;
    }

    void stop() {
        bot.velocity = transform.forward * 0;
    }

    IEnumerator turnRight(float x) {
        print("Right Start");
        var v = new Vector3(0, x, 0);
        Quaternion deltaRotation = Quaternion.Euler(v);
        forward();
        yield return new WaitForSeconds(0.2f);
        bot.MoveRotation(bot.rotation * deltaRotation);
        forward();
        yield return new WaitForSeconds(0.3f);
        print("Right End");
    }

    void turnLeft(float x) {
        var v = new Vector3(0, -x, 0);
        Quaternion deltaRotation = Quaternion.Euler(v);
        bot.MoveRotation(bot.rotation * deltaRotation);
    }

    IEnumerator Wait(float x) {
        yield return new WaitForSeconds(x);
    }
}
