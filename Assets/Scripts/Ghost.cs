using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    public enum GhostType
    {
        Teacher,
        Student
    }


    private GhostType ghostType;
    private GameObject ghostModel;

    //First = teacher
    //Second = student

    [SerializeField]
    public GameObject[] Ghosts = { GameObject.Find("GhostProfesor"), GameObject.Find("GhostStudent") };

    private String[] teacherNames = {
        "Janez Demšar",
        "Ajda Lampe",
        "Bojan Klemenc",
        "Gašper Fijavž",
        "Jelena Klisara",
        "Robert Rozman",
        "Žiga Pušnik",
        "Vlado Stankovski",
        "Matej Dobrevski",
        "Polona Oblak",
        "Damir Franetič",
        "Boštjan Slivnik",
        "Luka Fürst",
        "Tomaž Hočevar",
        "Marko Poženel",
        "Žerovnik Mekuč",
        "Matjaž Kukar",
        "Matej Pičulin",
        "Luka Šajn",
        "Peter Peer",
        "Borut Batagelj",
        "Žiga Emeršič",
        "Bojan Klemenc",
        "Uroš Čibej",
        "Tomaž Dobravec",
        "Igor Rožanc",
        "Boštjan Slivnik",
        "Aleš Jaklič",
        "Rok Rupnik",
    };

    [SerializeField]
    private GameObject teacherName = GameObject.Find("TeacherNameTag");

    public Ghost(GhostType ghostType)
    {
        this.ghostType = ghostType;
        setGhostModel();
    }

    public void setGhostModel()
    {

        if (this.ghostType == GhostType.Teacher)
        {
            ghostModel = Ghosts[0];

            Ghosts[0].gameObject.SetActive(true);
            Ghosts[1].gameObject.SetActive(false);

            String randomTeacherName = teacherNames[UnityEngine.Random.Range(0, teacherNames.Length)];
            teacherName.GetComponent<TMPro.TextMeshProUGUI>().text = randomTeacherName.Split(" ")[0] + "<br>" + randomTeacherName.Split(" ")[1];

        }
        else
        {
            ghostModel = Ghosts[1];

            Ghosts[0].gameObject.SetActive(false);
            Ghosts[1].gameObject.SetActive(true);
        }



    }

    public void setGhostType(GhostType ghostType)
    {
        this.ghostType = ghostType;

    }


    public void talk()
    {
        AudioManager.Play("Boop");
    }



}
