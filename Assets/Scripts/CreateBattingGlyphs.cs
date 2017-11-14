using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class CreateBattingGlyphs : MonoBehaviour {

	public Transform battingglyph, hits_child, doubles_child, triples_child, homeruns_child;
	public string[] words;
	public float[] coords = new float[] {0.0f,0.0f,0.0f};
	public float xpos, ypos, zpos;

	void Start() {
		ReadString ();
		for (int y = 0; y < 5; y++) {
			for (int x = 0; x < 5; x++) {
				//Instantiate(battingglyph, new Vector3(x, y, 0), Quaternion.identity);
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void ReadString()
	{
		string path = "/Users/jsale/unity/test.txt";
		int counter = 0;  
		string line, debug_string;
		char[] delimiterChars = { ' ' };
		float glyph_scale, hits_scale, doubles_scale, triples_scale, homeruns_scale;

		//coords [0] = 0;
		//coords [1] = 0;
		//coords [2] = 0;

		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(path); 
		while((line = reader.ReadLine()) != null)  
		{  
			//System.Console.WriteLine (line);
//			Debug.Log(counter);
//			Debug.Log(line);
			words = line.Split(delimiterChars);
//			debug_string = "Words[0]: " + words[0];
//			Debug.Log (debug_string);
//			debug_string = "Words[1]: " + words[1];
//			Debug.Log (debug_string);
//			coords [counter] = float.Parse(words[1]);
//			debug_string = "coords[" + Convert.ToString(counter) + "]: " + Convert.ToString(coords[counter]);
//			Debug.Log (debug_string);
			xpos = float.Parse (words [0]);
			ypos = float.Parse (words [1]);
			zpos = float.Parse (words [2]);
			glyph_scale = float.Parse (words [3]);
			hits_scale = float.Parse (words [4]);
			doubles_scale = float.Parse (words [5]);
			triples_scale = float.Parse (words [6]);
			homeruns_scale = float.Parse (words [7]);
			Instantiate(battingglyph, new Vector3(xpos, ypos, zpos), Quaternion.identity);
			hits_child = battingglyph.transform.GetChild(0); 
			hits_child.transform.localScale = new Vector3 (hits_scale, hits_scale, hits_scale);
			doubles_child = battingglyph.transform.GetChild(1); 
			doubles_child.transform.localScale = new Vector3 (doubles_scale, doubles_scale, doubles_scale);
			triples_child = battingglyph.transform.GetChild(2); 
			triples_child.transform.localScale = new Vector3 (triples_scale, triples_scale, triples_scale);
			homeruns_child = battingglyph.transform.GetChild(3); 
			homeruns_child.transform.localScale = new Vector3 (homeruns_scale, homeruns_scale, homeruns_scale);
			counter++;
		}  
		Debug.Log(reader.ReadToEnd());
		reader.Close();
	}

}
