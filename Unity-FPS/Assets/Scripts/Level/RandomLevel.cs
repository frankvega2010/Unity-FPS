using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevel : MonoBehaviour
{
    public GameObject levelTemplate;

    // Start is called before the first frame update
    void Start()
    {
        if (levelTemplate)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject newLevel = Instantiate(levelTemplate, new Vector3(20 * i, levelTemplate.transform.position.y, 0), Quaternion.identity);
                int whichLevel = 0;
                

                if (i == 0)
                {
                    newLevel.transform.Find("LevelTemplateStart").gameObject.transform.Find("Acid").gameObject.GetComponent<AcidFloor>().iterationMultiplier = i + 1;
                    newLevel.transform.Find("LevelTemplateStart").gameObject.transform.Find("Ghost").gameObject.GetComponent<Ghost>().iterationMultiplier = i + 1;

                    newLevel.transform.Find("LevelTemplateStart").gameObject.SetActive(true);
                    newLevel.transform.Find("LevelTemplate3").gameObject.SetActive(false);
                    newLevel.transform.Find("LevelTemplate2").gameObject.SetActive(false);
                    newLevel.transform.Find("LevelTemplate1").gameObject.SetActive(false);
                    newLevel.transform.Find("LevelTemplateEnd").gameObject.SetActive(false);

                }
                else if(i == 7)
                {
                    newLevel.transform.Find("LevelTemplateEnd").gameObject.transform.Find("Acid").gameObject.GetComponent<AcidFloor>().iterationMultiplier = i + 1;
                    newLevel.transform.Find("LevelTemplateEnd").gameObject.transform.Find("Ghost").gameObject.GetComponent<Ghost>().iterationMultiplier = i + 1;

                    newLevel.transform.Find("LevelTemplateEnd").gameObject.SetActive(true);
                    newLevel.transform.Find("LevelTemplate3").gameObject.SetActive(false);
                    newLevel.transform.Find("LevelTemplate2").gameObject.SetActive(false);
                    newLevel.transform.Find("LevelTemplate1").gameObject.SetActive(false);
                    newLevel.transform.Find("LevelTemplateStart").gameObject.SetActive(false);
                }
                else
                {
                    whichLevel = Random.Range(1, 4);
                    newLevel.transform.Find("LevelTemplate" + whichLevel).gameObject.transform.Find("Acid").gameObject.GetComponent<AcidFloor>().iterationMultiplier = i + 1;
                    newLevel.transform.Find("LevelTemplate" + whichLevel).gameObject.transform.Find("Ghost").gameObject.GetComponent<Ghost>().iterationMultiplier = i + 1;
                    switch (whichLevel)
                    {
                        case 1:
                            newLevel.transform.Find("LevelTemplate3").gameObject.SetActive(false);
                            newLevel.transform.Find("LevelTemplate2").gameObject.SetActive(false);
                            newLevel.transform.Find("LevelTemplate1").gameObject.SetActive(true);
                            break;
                        case 2:
                            newLevel.transform.Find("LevelTemplate3").gameObject.SetActive(false);
                            newLevel.transform.Find("LevelTemplate1").gameObject.SetActive(false);
                            newLevel.transform.Find("LevelTemplate2").gameObject.SetActive(true);
                            break;
                        case 3:
                            newLevel.transform.Find("LevelTemplate3").gameObject.SetActive(true);
                            newLevel.transform.Find("LevelTemplate2").gameObject.SetActive(false);
                            newLevel.transform.Find("LevelTemplate1").gameObject.SetActive(false);
                            break;
                        default:
                            break;
                    }
                }

                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
