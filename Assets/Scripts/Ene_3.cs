using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ene_3 : MonoBehaviour, IObserver
{
	[SerializeField] public float MovementSpeed;
	// Tasa de fuego del enemigo
	public float FireRate;
	public float Damage;
	[SerializeField] public float EneHealth;
	// Instancia de la prefab de bala del enemigo
	public GameObject BulletPrefab;


	void Start()
	{

		GameManager.GetInstance().Attach(this);

		Vector3 movementDirection = Vector3.down;
		transform.position = new Vector3(Transform.position.x, Transform.position.y + 4f, Transform.position.z);
		transform.LookAt(Vector3.zero);
		StartCoroutine(MoveEnemy());
	}

	public void Execute(ISubject subjet)
    {
		if(subjet is GameManager)
        {
			MovementSpeed = ((GameManager)subjet).Progresion;
			EneHealth = ((GameManager)subjet).Progresion;
		}
    }

	IEnumerator MoveEnemy()
	{
		while (true)
		{
			// Actualizar posici�n y rotaci�n del enemigo
			transform.position += movementDirection * MovementSpeed * Time.deltaTime;
			transform.LookAt(Vector3.zero);

			// Disparar bala si el jugador est� en rango
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
