using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasdMove : MonoBehaviour
{
	
	public Vector3 scaleChange;
	Vector3 m;
	float x, y, z;
	// Start is called before the first frame update
	void Start()
	{
		
		m.x = 0.0f;
		m.y = 0.0f;
		m.z = 0.0f;
	}

	// Update is called once per frame
	void Update()

	{

		if (Input.GetKey(KeyCode.W))
		{
			m.x = 0.1f;
			Movimento(m);
			LogMessage("w");
			m.x = 0.0f;
		}
		if (Input.GetKey(KeyCode.S))
		{

			m.x = -0.1f;
			Movimento(m);
			LogMessage("s");
			m.x = 0.0f;

		}
		if (Input.GetKey(KeyCode.D))
		{
			m.z = -0.1f;
			Movimento(m);
			LogMessage("D");
			m.z = 0.0f;
		}
		if (Input.GetKey(KeyCode.A))
		{
			m.z = 0.1f;
			Movimento(m);
			LogMessage("a");
		}
		if (Input.GetKey(KeyCode.X))
		{
			x = Random.Range(1.0f, 100.0f);
			y = Random.Range(1.0f, 100.0f);
			z = Random.Range(1.0f, 100.0f);
			scaleChange.Set(x, y, z);
			Escala(scaleChange);
		}
		if (Input.GetKey(KeyCode.R))
		{
			x = Random.Range(1.0f, 100.0f);
			y = Random.Range(1.0f, 100.0f);
			z = Random.Range(1.0f, 100.0f);
			scaleChange.Set(x, y, z);
			Rotacao(scaleChange);
		}






	}

	void Escala(Vector3 x)
	{
		transform.localScale = x;
	}
	void Rotacao(Vector3 x)
	{
		transform.Rotate(x);
	}

	void Movimento(Vector3 m)
	{
		transform.Translate(m);

	}

	void LogMessage(string msg)
	{

		Debug.Log("A opção selecionada foi " + msg.ToUpper());
	}
}
