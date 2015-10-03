using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
    public GameObject Ball;
    public Vector3 TargetPosition;
    public KeyCode InteractionKey;

    public float UpVelocityConstant = 5f;

    public float HortForce;
    public float UpForce;

    private float ballInitPos;

    void Start() {
        this.ballInitPos = this.Ball.GetComponent<BallBehaviour>().startingPosition.y;
    }

    void Update() {
        if (Input.GetKeyDown(InteractionKey)) {
            Rigidbody rigidbody = this.Ball.GetComponent<Rigidbody>();
            Vector3 ballVelocity = rigidbody.velocity;
            Vector3 ballPosition = rigidbody.position;
            Vector3 aimDirection = this.TargetPosition - ballPosition;

            if (ballVelocity.magnitude == 0) {
                rigidbody.useGravity = true;
            }

            float finalUpVelocity = 2 * (ballInitPos - ballPosition.y) * UpVelocityConstant;
            float timeToFall = solveQuadratic(-4.9f, finalUpVelocity, ballPosition.y);

            float zVelocity = aimDirection.z / timeToFall;

            Vector3 zeroPlusVelocity = new Vector3(0, finalUpVelocity, zVelocity);
            rigidbody.AddForce(rigidbody.mass * (zeroPlusVelocity - ballVelocity), ForceMode.Impulse);
        }
    }

    private float solveQuadratic(float a, float b, float c) {
        return (-Mathf.Sqrt(b * b - 4 * a * c) - b) / (2 * a);
    }
}
