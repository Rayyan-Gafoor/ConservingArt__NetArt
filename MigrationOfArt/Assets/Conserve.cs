using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conserve : MonoBehaviour
{
    public ParticleSystem particle__system;
    public Gradient[] gradient1;
    public Material[] my__skybox;
    public CreateWaypoint[] waypoints;
    public GameObject age__text;
    public int age;
   // WaypointMover waypoint__mover;
    public Image work__image;
    public Image conserve__image;
    public GameObject work__text;
    public float work__value;
    public float conserve__value;
    public float speed__decrease;
    public float size__decrease;
    public float max__size;
    public float max__speed;
    public int i = 0;
    public int j = 0;
    public int k = 0;
    WaypointMover waypoint__mover;

    // Start is called before the first frame update
    void Start()
    {
        age__text.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        waypoint__mover = GetComponent<WaypointMover>();
        waypoint__mover.move__speed = max__speed;
        work__text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        work__decrese();
        conserve__decrese();
        decrease__speed();
       // decrease__size();
        maintain__work();
    }
    void work__decrese()
    {
        work__image.fillAmount += -(work__value / 100);
    }
    void conserve__decrese()
    {
        conserve__image.fillAmount += -(conserve__value / 100);
    }
    void maintain__work()
    {
        if (work__image.fillAmount < 0.5)
        {
            work__image.color = Color.red;
        }
        else
        {
            work__image.color = Color.cyan;
        }
    }
    public void work__increase()
    {
        work__image.fillAmount += (work__value/2f);
        Debug.Log("worked");
    }
    public void conserve__increase()
    {
        if (work__image.fillAmount < 0.5)
        {
            StartCoroutine(display__text());
        }
        else
        {
            conserve__image.fillAmount = 1;
            conserved();
        }
        
    }
   void decrease__conservation()
    {
        particle__system = particle__system.GetComponent<ParticleSystem>();

    }
    void decrease__speed()
    {
        if (waypoint__mover.move__speed > 0)
        {
            waypoint__mover.move__speed += -(speed__decrease / 100);
        }
    }
    void decrease__size()
    {
        particle__system = particle__system.GetComponent<ParticleSystem>();
        var scale = particle__system.sizeOverLifetime.xMultiplier;
        scale += -(size__decrease / 100);
    }
    IEnumerator display__text()
    {
        work__text.SetActive(true);
        yield return new WaitForSeconds(1);
        work__text.SetActive(false);
    }
    void conserved()
    {
        particle__system = particle__system.GetComponent<ParticleSystem>();
        var col = particle__system.colorOverLifetime;
        col.enabled = true;
        waypoint__mover.move__speed = max__speed;
        age = age + 1;
        age__text.GetComponent<TMPro.TextMeshProUGUI>().text = age.ToString();

        i = Random.Range(0, gradient1.Length - 1);
        j = Random.Range(0, waypoints.Length - 1);
        k = Random.Range(0, my__skybox.Length - 1);

        col.color = gradient1[i];
        waypoint__mover.waypoints = waypoints[j];
        RenderSettings.skybox = my__skybox[k];
        /* if (i < gradient1.Length - 1)
         {
             i = i + 1;
             col.color = gradient1[i];
             waypoint__mover.waypoints = waypoints[i];
             RenderSettings.skybox = my__skybox[i];
         }
         else
         {
             i = 0;
             col.color = gradient1[i];
             waypoint__mover.waypoints = waypoints[i];
         }*/
    }
    void check__conservation()
    {
        if (conserve__image.fillAmount == 0)
        {
            Debug.Log("Game Over!");
        }
    }
}
