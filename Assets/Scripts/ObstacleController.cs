using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public int damage = 1;
    public float speed;

    public GameObject effect;
    public GameObject soundEffect;

    private void Update() {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            Instantiate(soundEffect, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            other.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        
        
    }
}
