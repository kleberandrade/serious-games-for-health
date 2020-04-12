using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 3.0f;

    // Pathfinding
    Vector3[] path;
    int targetIndex;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Pathfinding
        if (Input.GetMouseButtonDown(0)) {
            Vector3 origin = transform.position;
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;

            PathRequestManager.RequestPath(origin, target, OnPathFound);
        }

        Vector2 movement = Vector2.zero;

        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.MovePosition(rb2d.position + movement.normalized * speed * Time.deltaTime);
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
        if (pathSuccessful) {
            path = newPath;
            StopCoroutine("FollowPath");
            if (path.Length <= 0) return;
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath() {
        Vector3 currentWaypoint = path[0];

        while (true) {
            if (transform.position == currentWaypoint) {
                targetIndex++;
                if (targetIndex >= path.Length) {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;

        }
    }
}