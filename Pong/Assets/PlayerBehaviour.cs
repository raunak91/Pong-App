using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {
    public GameObject Ball;
    public Vector3 TargetPosition;
    public KeyCode InteractionKey;

    public float HortForce;
    public float UpForce;
	
	void Update () {
        if (Input.GetKeyDown(InteractionKey)) {
            Rigidbody rigidbody = this.Ball.GetComponent<Rigidbody>();
            Vector3 ballVelocity = rigidbody.velocity;
            Vector3 ballPosition = rigidbody.position;

            float mod = 1f;
            if (ballVelocity.magnitude == 0) {
                rigidbody.useGravity = true;
            }

            Vector3 aimDirection = this.TargetPosition - ballPosition;
            float timeToFall = Mathf.Sqrt(2 * ballPosition.y / 9.8f);
            float zVelocity = aimDirection.z / timeToFall;
            float yVelocity = ballVelocity.y;
            Vector3 zeroPlusVelocity = new Vector3(0, yVelocity, zVelocity);
            rigidbody.AddForce(rigidbody.mass * (zeroPlusVelocity - ballVelocity) * mod, ForceMode.Impulse);
        }
	}

    void Start() {
    }
}
