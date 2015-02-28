using UnityEngine;
using System;
using System.Collections;
using System.IO;

public class LevelLoader 
{
    const char LevelIdentifier = '*';

	// Use this for initialization
	public void LoadData(TextAsset levelData, LevelManager manager) 
    {
        StringReader reader = new StringReader(levelData.text);
        if (reader == null)
        {
            Debug.Log("Unable to open level data");
        }

        LoadLevelData(reader, manager);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void LoadAllLevelData(StringReader reader, LevelManager manager)
    {
        Debug.Log("Starting LoadAllLevelData");
        while (reader.Peek() == LevelIdentifier)
        {
            LoadLevelData(reader, manager);
        }
        Debug.Log("Ending LoadAllLevelData");
    }

    private void LoadLevelData(StringReader reader, LevelManager manager)
    {
        Level level = new Level();
        
        string nextLine = reader.ReadLine();
        int levelNum = 0;
        int.TryParse(nextLine.Substring(1), out levelNum);
        level.Initialize(levelNum);

        int row = 0;
        while (reader.Peek() != LevelIdentifier)
        {
            nextLine = reader.ReadLine();
            Debug.Log("nextLine: " + nextLine);
            if (nextLine == null)
            {
                break;
            }

            int column = 0;
            foreach (string token in nextLine.Split(','))
            {
                level[row, column] = (Brick.BrickType)Convert.ToInt32(token);
                column++;
            }
            row++;
        }

        manager.AddLevel(level.LevelNum, level);
    }
}
