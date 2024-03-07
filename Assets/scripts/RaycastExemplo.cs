using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExemplo : MonoBehaviour
{
    Ray ray;
    RaycastHit hitData;
    Vector3 point;
    Color color;
    public Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
       // _camera = GetComponent<Camera>();
        Debug.Log("Inicio!");

    }

    // Update is called once per frame
    void Update()
    {


        if (UnityEngine.Input.GetKey(KeyCode.Mouse0))
        {
            //point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight/2, 0);
            //ray = _camera.ScreenPointToRay(point);
            //ray = new Ray(transform.position, transform.forward);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            color = Color.green;
            Lancar(ray, color );
        }
        if (UnityEngine.Input.GetKey(KeyCode.Space))
        {
            ray = new Ray(transform.position, transform.forward);
            color = Color.yellow
;           Lancar(ray, color);
        }
        if (UnityEngine.Input.GetKey(KeyCode.Return))
        {
            point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight/2, 0);
            ray = _camera.ScreenPointToRay(point);
            color = Color.blue;
            Lancar(ray, color);
        }
    }
    private void Lancar(Ray ray, Color color)
    {
        Debug.Log("Origem: " + ray.origin);

        Debug.Log("Direção: " + ray.direction);

        if (Physics.Raycast(ray, out hitData))
        {



            Vector3 hitPosition = hitData.point;
            Debug.Log(" hitPosition:" + hitPosition);


            float hitDistance = hitData.distance;
            Debug.Log("Distancia: " + hitDistance);
            string tag = hitData.collider.tag;
            Debug.Log("Tag:" + tag);
            GameObject hitObject = hitData.transform.gameObject;
            Debug.DrawRay(ray.origin, hitPosition * hitDistance, color);
            StartCoroutine(SphereIndicator(hitPosition));


        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.magenta);
            Debug.Log("Target missed");
        }
    }
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        sphere.transform.localScale = new Vector3(5,5,5);
        Material bombMaterial = Resources.Load("cherrybomb", typeof(Material)) as Material;
       
        sphere.GetComponent<Renderer>().material = bombMaterial;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        
        Gizmos.DrawRay(ray);
    }
}
