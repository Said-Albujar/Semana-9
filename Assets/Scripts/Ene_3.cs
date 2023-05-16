using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ene_3 : MonoBehaviour
{
	public float MovementSpeed;
	// Tasa de fuego del enemigo
	public float FireRate;
	public float Damage;
	public int EneHealth;
	// Instancia de la prefab de bala del enemigo
	public GameObject BulletPrefab;

	// Enviado al método cuando se ha cargado
	void Start()
	{
		// Direcciones de movimiento iniciales
		Vector3 movementDirection = Vector3.down;
		transform.position = new Vector3(Transform.position.x, Transform.position.y + 4f, Transform.position.z);
		transform.LookAt(Vector3.zero);
		StartCoroutine(MoveEnemy());
	}

	// Coroutine para mover al enemigo
	IEnumerator MoveEnemy()
	{
		while (true)
		{
			// Actualizar posición y rotación del enemigo
			transform.position += movementDirection * MovementSpeed * Time.deltaTime;
			transform.LookAt(Vector3.zero);

			// Disparar bala si el jugador está en rango
			if (Vector3.Distance(transform.position, transform.position + movementDirection) > 30f &&
			   Vector3.Distance(transform.position, transform.position + movementDirection) <= 100f &&
			   Vector3.Distance(transform.position, transform.position + movementDirection) / 100f >= FireRate * Time.deltaTime)
			{
				// Disarar bala
				GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
				bullet.GetComponent<Rigidbody>().AddForce(player.transform.position - transform.position - movementDirection, ForceMode.Impulse);
			}

			// Actualizar salud del enemigo
			float timeDelta = Time.time - lastHealthUpdate;
			float healthDelta = 1f * timeDelta;
			EneHealth -= healthDelta;

			// Si la salud del enemigo baja a cero
			if (EneHealth <= 0)
			{
				// Code to run when enemy is defeated
				Destroy(gameObject);
			}
		}
	}
}
