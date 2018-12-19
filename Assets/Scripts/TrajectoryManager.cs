using Assets.Scripts;
using Assets.Scripts.ValuesForTrajectory;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryManager : MonoBehaviour
{
    public GameManager gameManager;

    public Camera mainCamera;
    public Transform spotPointR;
    public Transform spotPointB;
    public Transform spotPointL;
    public Transform spotPointT;

    private int CantSpawn;

    public List<Element> ElementList;

    private GameObject goParent;
    public GameObject Element1Prefab;
    public GameObject Element2Prefab;
    public GameObject Element3Prefab;
    public GameObject Element4Prefab;

    private void Awake()
    {
        Inicializar();
    }

    public void StartGame(int pCantSpwn)
    {
        InvokeRepeating("RunElementsInvoke", 0f, 0.3f); // Empieza a los 0 segundos, se ejecuta cada 1 segundos.
    }

    public void StopGame()
    {
        GeneralGameValues.SlowTimeStarted = 0f;
    }

    public void RestartGame(int pCantSpawn)
    {
        Destroy(goParent);

        CancelInvoke();

        CantSpawn = pCantSpawn;

        ElementList.Clear();

        PostInitilizer();
    }

    private void RunElementsInvoke()
    {
        if (ElementList.Count != 0)
        {
            Element selectedToGo = ElementList[Random.Range(0, ElementList.Count)];

            selectedToGo.Activar(true);
        }
        else
        {
            CancelInvoke();
        }
    }

    public void Inicializar()
    {
        CantSpawn = GeneralGameValues.CantElemetsSpawn;

        UbicarSpotsPoints(spotPointR);

        PostInitilizer();
    }

    private void PostInitilizer()
    {
        InstanciarElementosPrefab();

        UbicarElementos();

        ConfigurarTrayectoriasElementos();
    }

    public void InstanciarElementosPrefab()
    {
        ElementList = new List<Element>();

        List<GameObject> ElementsPrefabs = new List<GameObject>();

        ElementsPrefabs.Add(Element1Prefab);
        ElementsPrefabs.Add(Element2Prefab);
        ElementsPrefabs.Add(Element3Prefab);
        ElementsPrefabs.Add(Element4Prefab);

        goParent = new GameObject();

        for (int i = 0; i < CantSpawn; i++)
        {
            Element instance = Instantiate(ElementsPrefabs[Random.Range(0, ElementsPrefabs.Count)], goParent.transform).GetComponent<Element>();
            instance.Initializer(gameManager);
            ElementList.Add(instance);
        }
    }

    public void UbicarSpotsPoints(Transform pListSpot)
    {
        float CantDivisiones = pListSpot.childCount + 1;
        float amountDivisiones = 1f / CantDivisiones;

        float offset = amountDivisiones;

        
    }

    private void UbicarElementos()
    {
        List<Transform> ListaSport = new List<Transform>();
       

        Transform[] pListaSporArray = ListaSport.ToArray();

        foreach (Element item in ElementList)
        {
            Transform selectedSpot = pListaSporArray[Random.Range(0, ListaSport.Count)];

            item.transform.localPosition = new Vector3(selectedSpot.localPosition.x, selectedSpot.localPosition.z, selectedSpot.localPosition.z);

            item.transform.position = new Vector3(selectedSpot.position.x, selectedSpot.position.y, selectedSpot.localPosition.z);
        }
    }

    private void ObtenerSpotHijos(List<Transform> pListaSport, Transform pSpotPoint)
    {
        foreach (Transform item in pSpotPoint.GetComponentsInChildren<Transform>())
        {
            if (item.tag == "Spot")
            {
                pListaSport.Add(item);
            }
        }
    }


    private void ConfigurarTrayectoriasElementos()
    {
        //El Transform en Y debe estar DENTRO de (0;1) en X 
        //El Transform en X debe estar DENTRO de (0;1) en Y

        foreach (Element item in ElementList)
        {
           
        }
    }
}
