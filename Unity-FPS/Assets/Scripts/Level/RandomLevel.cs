using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevel : MonoBehaviour
{
    public GameObject levelTemplate;
    public int levelsAmount;

    // Start is called before the first frame update
    void Start()
    {
        if (levelTemplate)
        {
            for (int i = 0; i < levelsAmount; i++)
            {
                GameObject newLevel = Instantiate(levelTemplate, new Vector3(20 * i, levelTemplate.transform.position.y, 0), Quaternion.identity);
                int whichLevel = 0;
                
                if (i == 0)
                {
                    newLevel.transform.Find("LevelTemplateStart").gameObject.SetActive(true);
                }
                else if(i == levelsAmount-1)
                {
                    newLevel.transform.Find("LevelTemplateEnd").gameObject.SetActive(true);
                }
                else
                {
                    whichLevel = Random.Range(1, 6);
                    switch (whichLevel)
                    {
                        case 1:
                            newLevel.transform.Find("LevelTemplate1").gameObject.SetActive(true);
                            break;
                        case 2:
                            newLevel.transform.Find("LevelTemplate2").gameObject.SetActive(true);
                            break;
                        case 3:
                            newLevel.transform.Find("LevelTemplate3").gameObject.SetActive(true);
                            break;
                        case 4:
                            newLevel.transform.Find("LevelTemplate4").gameObject.SetActive(true);
                            break;
                        case 5:
                            newLevel.transform.Find("LevelTemplate5").gameObject.SetActive(true);
                            break;
                        default:
                            break;
                    }
                } 
            }
        }
    }
}
